/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：RolefunctionDA
// 文件功能描述：提供Rolefunction数据表进行操作的一些方法
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
    public class RolefunctionDA : IRolefunctionDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Rolefunction 的所有记录
        private string SQL_SELECT_ALL_ROLEFUNCTION = "SELECT R.Indx AS Indx, R.RoleID AS RoleID, R.FunctionID AS FunctionID, R.CreatedBy AS CreatedBy, R.CreatedDate AS CreatedDate FROM RoleFunction R WHERE 1=1  ";
        //INSERT_SQL 向Rolefunction增加一条记录
        private string SQL_INSERT_ROLEFUNCTION = "INSERT INTO RoleFunction ( RoleID, FunctionID, CreatedBy, CreatedDate) VALUES ( @RoleID, @FunctionID, @CreatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Rolefunction一条记录
        private string SQL_DELETE_ROLEFUNCTION = "DELETE FROM RoleFunction WHERE INDX = @INDX ";
        //UPDATE_SQL 更新Rolefunction记录
        private string SQL_UPDATE_ROLEFUNCTION = "UPDATE RoleFunction SET RoleID = @RoleID, FunctionID = @FunctionID WHERE INDX = @INDX  ";

        //判断一个ROLEFUNCTION_ID是否已存在
        private string SQL_CHECK_ROLEFUNCTION_ID_IS_EXIST = " SELECT COUNT(1) FROM RoleFunction WHERE INDX = @INDX ";
        #endregion

        #region 基本方法

        #region 得到Rolefunction的所有记录

        /// <summary>
        /// 得到所有的Rolefunction记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Rolefunction记录</returns>
        public DataSet GetAllRolefunction()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ROLEFUNCTION);
        }

        /// <summary>
        /// 得到所有的Rolefunction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Rolefunction记录</returns>
        public DataSet GetAllRolefunction(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ROLEFUNCTION);
        }

        #endregion

        #region 根据条件查询Rolefunction的记录  GetRolefunctionByQueryList()

        /// <summary>
        /// 根据查询条件得到Rolefunction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RolefunctionQueryEntity">Rolefunction查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Rolefunction记录</returns>
        public DataSet GetRolefunctionByQueryList(QueryEntity rolefunctionQuery)
        {
            string temp = SQL_SELECT_ALL_ROLEFUNCTION;

            if (rolefunctionQuery != null && rolefunctionQuery.sqlWhere != null && rolefunctionQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < rolefunctionQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + rolefunctionQuery.sqlWhere[i];
                }
            }

            if (!rolefunctionQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, rolefunctionQuery.CurrentPage, rolefunctionQuery.PageSize, rolefunctionQuery.SortField, rolefunctionQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Rolefunction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RolefunctionQueryEntity">Rolefunction查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Rolefunction记录</returns>
        public DataSet GetRolefunctionByQueryList(Database db, DbTransaction tran, QueryEntity rolefunctionQuery)
        {
            string temp = SQL_SELECT_ALL_ROLEFUNCTION;

            if (rolefunctionQuery != null && rolefunctionQuery.sqlWhere != null && rolefunctionQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < rolefunctionQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + rolefunctionQuery.sqlWhere[i];
                }
            }
            if (!rolefunctionQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, rolefunctionQuery.CurrentPage, rolefunctionQuery.PageSize, rolefunctionQuery.SortField, rolefunctionQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Rolefunction的一条记录 GetRolefunctionByID()

        /// <summary>
        /// 根据rolefunctionID得到一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据rolefunctionID得到一条Rolefunction记录</returns>
        public RolefunctionInfo GetRolefunctionByID(string rolefunctionID)
        {
            string sql = SQL_SELECT_ALL_ROLEFUNCTION + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", rolefunctionID) };
            RolefunctionInfo rolefunctionInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    rolefunctionInfo = InitRolefunctionInfoByDataReader(rolefunctionInfo, reader);
                }
            }

            return rolefunctionInfo;
        }
        /// <summary>
        /// 根据rolefunctionID得到一条Rolefunction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据rolefunctionID得到一条Rolefunction记录</returns>
        public RolefunctionInfo GetRolefunctionByID(Database db, DbTransaction tran, string rolefunctionID)
        {
            string sql = SQL_SELECT_ALL_ROLEFUNCTION + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", rolefunctionID) };
            RolefunctionInfo rolefunctionInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                rolefunctionInfo = InitRolefunctionInfoByDataReader(rolefunctionInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return rolefunctionInfo;
        }
        /// <summary>
        /// 初始化RolefunctionInfo
        /// </summary>
        private RolefunctionInfo InitRolefunctionInfoByDataReader(RolefunctionInfo rolefunctionInfo, IDataReader reader)
        {
            rolefunctionInfo = new RolefunctionInfo(reader["Indx"].ToString() != "" ? Int32.Parse(reader["Indx"].ToString()) : 0,
reader["RoleID"].ToString() != "" ? Int32.Parse(reader["RoleID"].ToString()) : 0,
reader["FunctionID"].ToString() != "" ? Int32.Parse(reader["FunctionID"].ToString()) : 0,
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime());
            return rolefunctionInfo;
        }
        #endregion

        #region 向Rolefunction增加一条记录 InsertRolefunction()

        /// <summary>
        /// 新增一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertRolefunction(RolefunctionInfo rolefunctionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Rolefunction_Parameters(rolefunctionInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ROLEFUNCTION, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Rolefunction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertRolefunction(Database db, DbTransaction tran, RolefunctionInfo rolefunctionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Rolefunction_Parameters(rolefunctionInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ROLEFUNCTION, paras);
            }
            return result;
        }
        #endregion

        #region 删除Rolefunction一条记录 DeleteRolefunction()

        /// <summary>
        /// 删除一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">RolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteRolefunction(string rolefunctionID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", rolefunctionID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ROLEFUNCTION, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Rolefunction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunctionID">RolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteRolefunction(Database db, DbTransaction tran, string rolefunctionID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", rolefunctionID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ROLEFUNCTION, paras);
            return result;
        }
        #endregion

        #region 更新一条Rolefunction记录 UpdateRolefunction()
        /// <summary>
        /// 更新一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateRolefunction(RolefunctionInfo rolefunctionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Rolefunction_Parameters(rolefunctionInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ROLEFUNCTION, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Rolefunction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateRolefunction(Database db, DbTransaction tran, RolefunctionInfo rolefunctionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Rolefunction_Parameters(rolefunctionInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ROLEFUNCTION, paras);
            }
            return result;
        }
        #endregion

        #region 根据INDX判断此ID在表RoleFunction中是否已存在

        /// <summary>
        /// 检查RolefunctionID是否已存在
        /// </summary>
        /// <param name="rolefunctionID">RolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckRolefunctionIDIsExist(string rolefunctionID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", rolefunctionID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ROLEFUNCTION_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查RolefunctionID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckRolefunctionIDIsExist(Database db, DbTransaction tran, string rolefunctionID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", rolefunctionID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ROLEFUNCTION_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Rolefunction_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Rolefunction">Rolefunction对象</param>
        /// <returns>Rolefunction参数数组</returns>
        private SqlParameter[] Set_Rolefunction_Parameters(RolefunctionInfo rolefunctionInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@Indx",rolefunctionInfo.Indx),
																new SqlParameter("@RoleID",rolefunctionInfo.RoleID),
																new SqlParameter("@FunctionID",rolefunctionInfo.FunctionID),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(rolefunctionInfo.CreatedBy)?"":rolefunctionInfo.CreatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        public int DeleteRoleFunctionByRoleID(int roleID)
        {
            string sql = string.Format("DELETE FROM RoleFunction WHERE RoleID='{0}'",roleID);
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql);
        }
        #endregion
    }
}
