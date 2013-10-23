/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：UsersupplierDA
// 文件功能描述：提供Usersupplier数据表进行操作的一些方法
//
// 创建标识：JerryXi 2013/8/20  
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Microsoft.Practices.EnterpriseLibrary.Data;
using GXP.IDAL;
using GXP.Common;
using GXP.DataEntity;

namespace GXP.SQLServerDAL
{
    public class UsersupplierDA : IUsersupplierDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Usersupplier 的所有记录
        private string SQL_SELECT_ALL_USERSUPPLIER = "SELECT U.Indx AS Indx, U.UserID AS UserID, U.SupplierID AS SupplierID, U.CreatedBy AS CreatedBy, U.CreatedDate AS CreatedDate FROM UserSupplier U WHERE 1=1  ";
        //INSERT_SQL 向Usersupplier增加一条记录
        private string SQL_INSERT_USERSUPPLIER = "INSERT INTO UserSupplier ( Indx, UserID, SupplierID, CreatedBy, CreatedDate) VALUES ( @Indx, @UserID, @SupplierID, @CreatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Usersupplier一条记录
        private string SQL_DELETE_USERSUPPLIER = "DELETE FROM UserSupplier WHERE INDX = @INDX ";
        //UPDATE_SQL 更新Usersupplier记录
        private string SQL_UPDATE_USERSUPPLIER = "UPDATE UserSupplier SET UserID = @UserID, SupplierID = @SupplierID WHERE INDX = @INDX  ";

        //判断一个USERSUPPLIER_ID是否已存在
        private string SQL_CHECK_USERSUPPLIER_ID_IS_EXIST = " SELECT COUNT(1) FROM UserSupplier WHERE INDX = @INDX ";
        #endregion

        #region 基本方法

        #region 得到Usersupplier的所有记录

        /// <summary>
        /// 得到所有的Usersupplier记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Usersupplier记录</returns>
        public DataSet GetAllUsersupplier()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_USERSUPPLIER);
        }

        /// <summary>
        /// 得到所有的Usersupplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Usersupplier记录</returns>
        public DataSet GetAllUsersupplier(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_USERSUPPLIER);
        }

        #endregion

        #region 根据条件查询Usersupplier的记录  GetUsersupplierByQueryList()

        /// <summary>
        /// 根据查询条件得到Usersupplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UsersupplierQueryEntity">Usersupplier查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Usersupplier记录</returns>
        public DataSet GetUsersupplierByQueryList(QueryEntity usersupplierQuery)
        {
            string temp = SQL_SELECT_ALL_USERSUPPLIER;

            if (usersupplierQuery != null && usersupplierQuery.sqlWhere != null && usersupplierQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < usersupplierQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + usersupplierQuery.sqlWhere[i];
                }
            }

            if (!usersupplierQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, usersupplierQuery.CurrentPage, usersupplierQuery.PageSize, usersupplierQuery.SortField, usersupplierQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Usersupplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UsersupplierQueryEntity">Usersupplier查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Usersupplier记录</returns>
        public DataSet GetUsersupplierByQueryList(Database db, DbTransaction tran, QueryEntity usersupplierQuery)
        {
            string temp = SQL_SELECT_ALL_USERSUPPLIER;

            if (usersupplierQuery != null && usersupplierQuery.sqlWhere != null && usersupplierQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < usersupplierQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + usersupplierQuery.sqlWhere[i];
                }
            }
            if (!usersupplierQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, usersupplierQuery.CurrentPage, usersupplierQuery.PageSize, usersupplierQuery.SortField, usersupplierQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Usersupplier的一条记录 GetUsersupplierByID()

        /// <summary>
        /// 根据usersupplierID得到一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据usersupplierID得到一条Usersupplier记录</returns>
        public UsersupplierInfo GetUsersupplierByID(string usersupplierID)
        {
            string sql = SQL_SELECT_ALL_USERSUPPLIER + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", usersupplierID) };
            UsersupplierInfo usersupplierInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    usersupplierInfo = InitUsersupplierInfoByDataReader(usersupplierInfo, reader);
                }
            }

            return usersupplierInfo;
        }
        /// <summary>
        /// 根据usersupplierID得到一条Usersupplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据usersupplierID得到一条Usersupplier记录</returns>
        public UsersupplierInfo GetUsersupplierByID(Database db, DbTransaction tran, string usersupplierID)
        {
            string sql = SQL_SELECT_ALL_USERSUPPLIER + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", usersupplierID) };
            UsersupplierInfo usersupplierInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                usersupplierInfo = InitUsersupplierInfoByDataReader(usersupplierInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return usersupplierInfo;
        }
        /// <summary>
        /// 初始化UsersupplierInfo
        /// </summary>
        private UsersupplierInfo InitUsersupplierInfoByDataReader(UsersupplierInfo usersupplierInfo, IDataReader reader)
        {
            usersupplierInfo = new UsersupplierInfo(reader["Indx"].ToString() != "" ? Int32.Parse(reader["Indx"].ToString()) : 0,
reader["UserID"].ToString() != "" ? Int32.Parse(reader["UserID"].ToString()) : 0,
reader["SupplierID"].ToString() != "" ? Int32.Parse(reader["SupplierID"].ToString()) : 0,
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime());
            return usersupplierInfo;
        }
        #endregion

        #region 向Usersupplier增加一条记录 InsertUsersupplier()

        /// <summary>
        /// 新增一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUsersupplier(UsersupplierInfo usersupplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Usersupplier_Parameters(usersupplierInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_USERSUPPLIER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Usersupplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUsersupplier(Database db, DbTransaction tran, UsersupplierInfo usersupplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Usersupplier_Parameters(usersupplierInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_USERSUPPLIER, paras);
            }
            return result;
        }
        #endregion

        #region 删除Usersupplier一条记录 DeleteUsersupplier()

        /// <summary>
        /// 删除一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplierID">UsersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUsersupplier(string usersupplierID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", usersupplierID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_USERSUPPLIER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Usersupplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="usersupplierID">UsersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUsersupplier(Database db, DbTransaction tran, string usersupplierID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", usersupplierID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_USERSUPPLIER, paras);
            return result;
        }
        #endregion

        #region 更新一条Usersupplier记录 UpdateUsersupplier()
        /// <summary>
        /// 更新一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUsersupplier(UsersupplierInfo usersupplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Usersupplier_Parameters(usersupplierInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_USERSUPPLIER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Usersupplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUsersupplier(Database db, DbTransaction tran, UsersupplierInfo usersupplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Usersupplier_Parameters(usersupplierInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_USERSUPPLIER, paras);
            }
            return result;
        }
        #endregion

        #region 根据INDX判断此ID在表UserSupplier中是否已存在

        /// <summary>
        /// 检查UsersupplierID是否已存在
        /// </summary>
        /// <param name="usersupplierID">UsersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUsersupplierIDIsExist(string usersupplierID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", usersupplierID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_USERSUPPLIER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查UsersupplierID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUsersupplierIDIsExist(Database db, DbTransaction tran, string usersupplierID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", usersupplierID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_USERSUPPLIER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Usersupplier_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Usersupplier">Usersupplier对象</param>
        /// <returns>Usersupplier参数数组</returns>
        private SqlParameter[] Set_Usersupplier_Parameters(UsersupplierInfo usersupplierInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@Indx",usersupplierInfo.Indx),
																new SqlParameter("@UserID",usersupplierInfo.UserID),
																new SqlParameter("@SupplierID",usersupplierInfo.SupplierID),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(usersupplierInfo.CreatedBy)?"":usersupplierInfo.CreatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
