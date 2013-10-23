/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：RoleDA
// 文件功能描述：提供Role数据表进行操作的一些方法
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
    public class RoleDA : IRoleDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Role 的所有记录
        private string SQL_SELECT_ALL_ROLE = "SELECT R.RoleID AS RoleID, R.RoleName AS RoleName, R.CreatedBy AS CreatedBy, R.CreatedDate AS CreatedDate, R.UpdatedBy AS UpdatedBy, R.UpdatedDate AS UpdatedDate FROM Role R WHERE 1=1  ";
        //INSERT_SQL 向Role增加一条记录
        private string SQL_INSERT_ROLE = "INSERT INTO Role ( RoleName, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @RoleName, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Role一条记录
        private string SQL_DELETE_ROLE = "DELETE FROM Role WHERE ROLEID = @ROLEID ";
        //UPDATE_SQL 更新Role记录
        private string SQL_UPDATE_ROLE = "UPDATE Role SET RoleName = @RoleName, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ROLEID = @ROLEID  ";

        //判断一个ROLE_ID是否已存在
        private string SQL_CHECK_ROLE_ID_IS_EXIST = " SELECT COUNT(1) FROM Role WHERE ROLEID = @ROLEID ";
        #endregion

        #region 基本方法

        #region 得到Role的所有记录

        /// <summary>
        /// 得到所有的Role记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Role记录</returns>
        public DataSet GetAllRole()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ROLE);
        }

        /// <summary>
        /// 得到所有的Role记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Role记录</returns>
        public DataSet GetAllRole(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ROLE);
        }

        #endregion

        #region 根据条件查询Role的记录  GetRoleByQueryList()

        /// <summary>
        /// 根据查询条件得到Role记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RoleQueryEntity">Role查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Role记录</returns>
        public DataSet GetRoleByQueryList(QueryEntity roleQuery)
        {
            string temp = SQL_SELECT_ALL_ROLE;

            if (roleQuery != null && roleQuery.sqlWhere != null && roleQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < roleQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + roleQuery.sqlWhere[i];
                }
            }

            if (!roleQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, roleQuery.CurrentPage, roleQuery.PageSize, roleQuery.SortField, roleQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Role记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RoleQueryEntity">Role查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Role记录</returns>
        public DataSet GetRoleByQueryList(Database db, DbTransaction tran, QueryEntity roleQuery)
        {
            string temp = SQL_SELECT_ALL_ROLE;

            if (roleQuery != null && roleQuery.sqlWhere != null && roleQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < roleQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + roleQuery.sqlWhere[i];
                }
            }
            if (!roleQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, roleQuery.CurrentPage, roleQuery.PageSize, roleQuery.SortField, roleQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Role的一条记录 GetRoleByID()

        /// <summary>
        /// 根据roleID得到一条Role记录
        /// </summary>
        /// <param name="roleID">roleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据roleID得到一条Role记录</returns>
        public RoleInfo GetRoleByID(string roleID)
        {
            string sql = SQL_SELECT_ALL_ROLE + " AND ROLEID = @ROLEID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ROLEID", roleID) };
            RoleInfo roleInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    roleInfo = InitRoleInfoByDataReader(roleInfo, reader);
                }
            }

            return roleInfo;
        }
        /// <summary>
        /// 根据roleID得到一条Role记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="roleID">roleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据roleID得到一条Role记录</returns>
        public RoleInfo GetRoleByID(Database db, DbTransaction tran, string roleID)
        {
            string sql = SQL_SELECT_ALL_ROLE + " AND ROLEID = @ROLEID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ROLEID", roleID) };
            RoleInfo roleInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                roleInfo = InitRoleInfoByDataReader(roleInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return roleInfo;
        }
        /// <summary>
        /// 初始化RoleInfo
        /// </summary>
        private RoleInfo InitRoleInfoByDataReader(RoleInfo roleInfo, IDataReader reader)
        {
            roleInfo = new RoleInfo(reader["RoleID"].ToString() != "" ? Int32.Parse(reader["RoleID"].ToString()) : 0,
reader["RoleName"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return roleInfo;
        }
        #endregion

        #region 向Role增加一条记录 InsertRole()

        /// <summary>
        /// 新增一条Role记录
        /// </summary>
        /// <param name="role">Role对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertRole(RoleInfo roleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Role_Parameters(roleInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ROLE, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Role记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="role">Role对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertRole(Database db, DbTransaction tran, RoleInfo roleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Role_Parameters(roleInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ROLE, paras);
            }
            return result;
        }
        #endregion

        #region 删除Role一条记录 DeleteRole()

        /// <summary>
        /// 删除一条Role记录
        /// </summary>
        /// <param name="roleID">RoleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteRole(string roleID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ROLEID", roleID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ROLE, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Role记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="roleID">RoleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteRole(Database db, DbTransaction tran, string roleID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ROLEID", roleID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ROLE, paras);
            return result;
        }
        #endregion

        #region 更新一条Role记录 UpdateRole()
        /// <summary>
        /// 更新一条Role记录
        /// </summary>
        /// <param name="role">Role对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateRole(RoleInfo roleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Role_Parameters(roleInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ROLE, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Role记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="role">Role对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateRole(Database db, DbTransaction tran, RoleInfo roleInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Role_Parameters(roleInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ROLE, paras);
            }
            return result;
        }
        #endregion

        #region 根据ROLEID判断此ID在表Role中是否已存在

        /// <summary>
        /// 检查RoleID是否已存在
        /// </summary>
        /// <param name="roleID">RoleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckRoleIDIsExist(string roleID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ROLEID", roleID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ROLE_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查RoleID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="roleID">roleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckRoleIDIsExist(Database db, DbTransaction tran, string roleID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ROLEID", roleID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ROLE_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Role_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Role">Role对象</param>
        /// <returns>Role参数数组</returns>
        private SqlParameter[] Set_Role_Parameters(RoleInfo roleInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@RoleID",roleInfo.RoleID),
																new SqlParameter("@RoleName",roleInfo.RoleName),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(roleInfo.CreatedBy)?"":roleInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(roleInfo.UpdatedBy)?"":roleInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法

        public List<RoleInfo> GetAllRoleList()
        {
            List<RoleInfo> roleInfoList = new List<RoleInfo>();
            string sql = SQL_SELECT_ALL_ROLE;            

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    RoleInfo roleInfo = null;
                    roleInfo = InitRoleInfoByDataReader(roleInfo, reader);
                    roleInfoList.Add(roleInfo);
                }
            }
            return roleInfoList;
        }

        #endregion
    }
}
