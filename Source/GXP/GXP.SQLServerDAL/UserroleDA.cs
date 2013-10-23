/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：UserroleDA
// 文件功能描述：提供Userrole数据表进行操作的一些方法
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
    public class UserroleDA : IUserroleDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Userrole 的所有记录
        private string SQL_SELECT_ALL_USERROLE = "SELECT U.Indx AS Indx, U.UserID AS UserID, U.RoleID AS RoleID, U.CreatedBy AS CreatedBy, U.CreatedDate AS CreatedDate FROM UserRole U WHERE 1=1  ";
        //INSERT_SQL 向Userrole增加一条记录
        private string SQL_INSERT_USERROLE = "INSERT INTO UserRole ( UserID, RoleID, CreatedBy, CreatedDate) VALUES ( @UserID, @RoleID, @CreatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Userrole一条记录
        private string SQL_DELETE_USERROLE = "DELETE FROM UserRole WHERE INDX = @INDX ";
        //UPDATE_SQL 更新Userrole记录
        private string SQL_UPDATE_USERROLE = "UPDATE UserRole SET UserID = @UserID, RoleID = @RoleID WHERE INDX = @INDX  ";

        //判断一个USERROLE_ID是否已存在
        private string SQL_CHECK_USERROLE_ID_IS_EXIST = " SELECT COUNT(1) FROM UserRole WHERE INDX = @INDX ";
        #endregion

        #region 基本方法

        #region 得到Userrole的所有记录

        /// <summary>
        /// 得到所有的Userrole记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Userrole记录</returns>
        public DataSet GetAllUserrole()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_USERROLE);
        }

        /// <summary>
        /// 得到所有的Userrole记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Userrole记录</returns>
        public DataSet GetAllUserrole(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_USERROLE);
        }

        #endregion

        #region 根据条件查询Userrole的记录  GetUserroleByQueryList()

        /// <summary>
        /// 根据查询条件得到Userrole记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserroleQueryEntity">Userrole查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Userrole记录</returns>
        public DataSet GetUserroleByQueryList(QueryEntity userroleQuery)
        {
            string temp = SQL_SELECT_ALL_USERROLE;

            if (userroleQuery != null && userroleQuery.sqlWhere != null && userroleQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < userroleQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + userroleQuery.sqlWhere[i];
                }
            }

            if (!userroleQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, userroleQuery.CurrentPage, userroleQuery.PageSize, userroleQuery.SortField, userroleQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Userrole记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserroleQueryEntity">Userrole查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Userrole记录</returns>
        public DataSet GetUserroleByQueryList(Database db, DbTransaction tran, QueryEntity userroleQuery)
        {
            string temp = SQL_SELECT_ALL_USERROLE;

            if (userroleQuery != null && userroleQuery.sqlWhere != null && userroleQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < userroleQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + userroleQuery.sqlWhere[i];
                }
            }
            if (!userroleQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, userroleQuery.CurrentPage, userroleQuery.PageSize, userroleQuery.SortField, userroleQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Userrole的一条记录 GetUserroleByID()

        /// <summary>
        /// 根据userroleID得到一条Userrole记录
        /// </summary>
        /// <param name="userroleID">userroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据userroleID得到一条Userrole记录</returns>
        public UserroleInfo GetUserroleByID(string userroleID)
        {
            string sql = SQL_SELECT_ALL_USERROLE + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", userroleID) };
            UserroleInfo userroleInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    userroleInfo = InitUserroleInfoByDataReader(userroleInfo, reader);
                }
            }

            return userroleInfo;
        }
        /// <summary>
        /// 根据userroleID得到一条Userrole记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userroleID">userroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据userroleID得到一条Userrole记录</returns>
        public UserroleInfo GetUserroleByID(Database db, DbTransaction tran, string userroleID)
        {
            string sql = SQL_SELECT_ALL_USERROLE + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", userroleID) };
            UserroleInfo userroleInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                userroleInfo = InitUserroleInfoByDataReader(userroleInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return userroleInfo;
        }
        /// <summary>
        /// 初始化UserroleInfo
        /// </summary>
        private UserroleInfo InitUserroleInfoByDataReader(UserroleInfo userroleInfo, IDataReader reader)
        {
            userroleInfo = new UserroleInfo(reader["Indx"].ToString() != "" ? Int32.Parse(reader["Indx"].ToString()) : 0,
reader["UserID"].ToString() != "" ? Int32.Parse(reader["UserID"].ToString()) : 0,
reader["RoleID"].ToString() != "" ? Int32.Parse(reader["RoleID"].ToString()) : 0,
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime());
            return userroleInfo;
        }
        #endregion

        #region 向Userrole增加一条记录 InsertUserrole()

        /// <summary>
        /// 新增一条Userrole记录
        /// </summary>
        /// <param name="userrole">Userrole对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUserrole(UserroleInfo userroleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Userrole_Parameters(userroleInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_USERROLE, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Userrole记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userrole">Userrole对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUserrole(Database db, DbTransaction tran, UserroleInfo userroleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Userrole_Parameters(userroleInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_USERROLE, paras);
            }
            return result;
        }
        #endregion

        #region 删除Userrole一条记录 DeleteUserrole()

        /// <summary>
        /// 删除一条Userrole记录
        /// </summary>
        /// <param name="userroleID">UserroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUserrole(string userroleID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", userroleID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_USERROLE, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Userrole记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userroleID">UserroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUserrole(Database db, DbTransaction tran, string userroleID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", userroleID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_USERROLE, paras);
            return result;
        }
        #endregion

        #region 更新一条Userrole记录 UpdateUserrole()
        /// <summary>
        /// 更新一条Userrole记录
        /// </summary>
        /// <param name="userrole">Userrole对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUserrole(UserroleInfo userroleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Userrole_Parameters(userroleInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_USERROLE, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Userrole记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userrole">Userrole对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUserrole(Database db, DbTransaction tran, UserroleInfo userroleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Userrole_Parameters(userroleInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_USERROLE, paras);
            }
            return result;
        }
        #endregion

        #region 根据INDX判断此ID在表UserRole中是否已存在

        /// <summary>
        /// 检查UserroleID是否已存在
        /// </summary>
        /// <param name="userroleID">UserroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUserroleIDIsExist(string userroleID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", userroleID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_USERROLE_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查UserroleID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userroleID">userroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUserroleIDIsExist(Database db, DbTransaction tran, string userroleID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", userroleID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_USERROLE_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Userrole_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Userrole">Userrole对象</param>
        /// <returns>Userrole参数数组</returns>
        private SqlParameter[] Set_Userrole_Parameters(UserroleInfo userroleInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@Indx",userroleInfo.Indx),
																new SqlParameter("@UserID",userroleInfo.UserID),
																new SqlParameter("@RoleID",userroleInfo.RoleID),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(userroleInfo.CreatedBy)?"":userroleInfo.CreatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法

        public int SetUserRoles(int userID, List<int> roleList, string createdBy)
        {
            int result = 0;
            if (roleList != null && roleList.Count > 0)
            {
                string sql = string.Format("DELETE FROM USERROLE WHERE USERID='{0}'", userID);
                DBHelper.ExecuteNonQuery(CommandType.Text, sql);
                for (int i = 0; i < roleList.Count; i++)
                {
                    result += InsertUserrole(new UserroleInfo() { UserID = userID, RoleID = roleList[i], CreatedBy = createdBy, CreatedDate = DateTime.Now });
                }
            }
            return result;
        }

        public List<string> GetUserRoleListByUserID(string userID)
        {            
            List<string> roleList = new List<string>();
            string sql = string.Format("SELECT ROLEID FROM UserRole WHERE USERID='{0}'", userID);
            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    roleList.Add(reader["ROLEID"].ToString());
                }
            }
            return roleList;
        }

        #endregion
    }
}
