/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：UserDA
// 文件功能描述：提供User数据表进行操作的一些方法
//
// 创建标识：JerryXi 2013/7/7  
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
    public class UserDA : IUserDA
    {
        #region SQL语句
        //SELECT_SQL 得到 User 的所有记录
        private string SQL_SELECT_ALL_USER = "SELECT U.UserID AS UserID, U.UserCode AS UserCode, U.UserName AS UserName, U.LoginPwd AS LoginPwd, U.Sex AS Sex, U.Age AS Age, U.Department AS Department, U.JobNum AS JobNum, U.Email AS Email, U.MobilePhone AS MobilePhone, U.IsActive AS IsActive, U.UserGroup AS UserGroup, U.CreatedBy AS CreatedBy, U.CreatedDate AS CreatedDate, U.UpdatedBy AS UpdatedBy, U.UpdatedDate AS UpdatedDate FROM Users U WHERE 1=1  ";
        //INSERT_SQL 向User增加一条记录
        private string SQL_INSERT_USER = "INSERT INTO Users ( UserCode, UserName, LoginPwd, Sex, Age, Department, JobNum, Email, MobilePhone, IsActive, UserGroup, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @UserCode, @UserName, @LoginPwd, @Sex, @Age, @Department, @JobNum, @Email, @MobilePhone, @IsActive, @UserGroup, @CreatedBy, GetDate(), @UpdatedBy, GetDate())  ";
        //DELETE_SQL  删除User一条记录
        private string SQL_DELETE_USER = "DELETE FROM Users WHERE USERID = @USERID ";
        //UPDATE_SQL 更新User记录
        private string SQL_UPDATE_USER = "UPDATE Users SET UserCode = @UserCode, UserName = @UserName, LoginPwd = @LoginPwd, Sex = @Sex, Age = @Age, Department = @Department, JobNum = @JobNum, Email = @Email, MobilePhone = @MobilePhone, IsActive = @IsActive, UserGroup = @UserGroup, UpdatedBy = @UpdatedBy, UpdatedDate = GetDate() WHERE USERID = @USERID  ";

        //判断一个USER_ID是否已存在
        private string SQL_CHECK_USER_ID_IS_EXIST = " SELECT COUNT(1) FROM Users WHERE USERID = @USERID ";
        #endregion

        #region 基本方法

        #region 得到User的所有记录

        /// <summary>
        /// 得到所有的User记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的User记录</returns>
        public DataSet GetAllUser()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_USER);
        }

        /// <summary>
        /// 得到所有的User记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的User记录</returns>
        public DataSet GetAllUser(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_USER);
        }

        #endregion

        #region 根据条件查询User的记录  GetUserByQueryList()

        /// <summary>
        /// 根据查询条件得到User记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserQueryEntity">User查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到User记录</returns>
        public DataSet GetUserByQueryList(QueryEntity userQuery)
        {
            string temp = SQL_SELECT_ALL_USER;

            if (userQuery != null && userQuery.sqlWhere != null && userQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < userQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + userQuery.sqlWhere[i];
                }
            }

            if (!userQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, userQuery.CurrentPage, userQuery.PageSize, userQuery.SortField, userQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到User记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserQueryEntity">User查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到User记录</returns>
        public DataSet GetUserByQueryList(Database db, DbTransaction tran, QueryEntity userQuery)
        {
            string temp = SQL_SELECT_ALL_USER;

            if (userQuery != null && userQuery.sqlWhere != null && userQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < userQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + userQuery.sqlWhere[i];
                }
            }
            if (!userQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, userQuery.CurrentPage, userQuery.PageSize, userQuery.SortField, userQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询User的一条记录 GetUserByID()

        /// <summary>
        /// 根据userID得到一条User记录
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据userID得到一条User记录</returns>
        public UserInfo GetUserByID(string userID)
        {
            string sql = SQL_SELECT_ALL_USER + " AND USERID = @USERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@USERID", userID) };
            UserInfo userInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    userInfo = InitUserInfoByDataReader(userInfo, reader);
                }
            }

            return userInfo;
        }
        /// <summary>
        /// 根据userID得到一条User记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userID">userID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据userID得到一条User记录</returns>
        public UserInfo GetUserByID(Database db, DbTransaction tran, string userID)
        {
            string sql = SQL_SELECT_ALL_USER + " AND USERID = @USERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@USERID", userID) };
            UserInfo userInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                userInfo = InitUserInfoByDataReader(userInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return userInfo;
        }
        /// <summary>
        /// 初始化UserInfo
        /// </summary>
        private UserInfo InitUserInfoByDataReader(UserInfo userInfo, IDataReader reader)
        {
            userInfo = new UserInfo(reader["UserID"].ToString() != "" ? Int32.Parse(reader["UserID"].ToString()) : 0,
reader["UserCode"].ToString(),
reader["UserName"].ToString(),
reader["LoginPwd"].ToString(),
reader["Sex"].ToString(),
reader["Age"].ToString() != "" ? Int32.Parse(reader["Age"].ToString()) : 0,
reader["Department"].ToString(),
reader["JobNum"].ToString(),
reader["Email"].ToString(),
reader["MobilePhone"].ToString(),
reader["IsActive"].ToString(),
reader["UserGroup"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return userInfo;
        }
        #endregion

        #region 向User增加一条记录 InsertUser()

        /// <summary>
        /// 新增一条User记录
        /// </summary>
        /// <param name="user">User对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUser(UserInfo userInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_User_Parameters(userInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_USER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条User记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="user">User对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUser(Database db, DbTransaction tran, UserInfo userInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_User_Parameters(userInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_USER, paras);
            }
            return result;
        }
        #endregion

        #region 删除User一条记录 DeleteUser()

        /// <summary>
        /// 删除一条User记录
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUser(string userID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@USERID", userID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_USER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条User记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userID">UserID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUser(Database db, DbTransaction tran, string userID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@USERID", userID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_USER, paras);
            return result;
        }
        #endregion

        #region 更新一条User记录 UpdateUser()
        /// <summary>
        /// 更新一条User记录
        /// </summary>
        /// <param name="user">User对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUser(UserInfo userInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_User_Parameters(userInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_USER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条User记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="user">User对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUser(Database db, DbTransaction tran, UserInfo userInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_User_Parameters(userInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_USER, paras);
            }
            return result;
        }
        #endregion

        #region 根据USERID判断此ID在表User中是否已存在

        /// <summary>
        /// 检查UserID是否已存在
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUserIDIsExist(string userID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@USERID", userID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_USER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查UserID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userID">userID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUserIDIsExist(Database db, DbTransaction tran, string userID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@USERID", userID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_USER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_User_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="User">User对象</param>
        /// <returns>User参数数组</returns>
        private SqlParameter[] Set_User_Parameters(UserInfo userInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@UserID",userInfo.UserID),
																new SqlParameter("@UserCode",userInfo.UserCode),
																new SqlParameter("@UserName",userInfo.UserName),
																new SqlParameter("@LoginPwd",string.IsNullOrEmpty(userInfo.LoginPwd)?"":userInfo.LoginPwd),
																new SqlParameter("@Sex",string.IsNullOrEmpty(userInfo.Sex)?"":userInfo.Sex),
																new SqlParameter("@Age",userInfo.Age),
																new SqlParameter("@Department",string.IsNullOrEmpty(userInfo.Department)?"":userInfo.Department),
																new SqlParameter("@JobNum",string.IsNullOrEmpty(userInfo.JobNum)?"":userInfo.JobNum),
																new SqlParameter("@Email",string.IsNullOrEmpty(userInfo.Email)?"":userInfo.Email),
																new SqlParameter("@MobilePhone",string.IsNullOrEmpty(userInfo.MobilePhone)?"":userInfo.MobilePhone),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(userInfo.IsActive)?"":userInfo.IsActive),
																new SqlParameter("@UserGroup",string.IsNullOrEmpty(userInfo.UserGroup)?"":userInfo.UserGroup),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(userInfo.CreatedBy)?"":userInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(userInfo.UpdatedBy)?"":userInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        /// <summary>
        /// 根据用户ID，Code，手机号，邮箱得到用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UserInfo GetUserByCodePhoneEmail(string code)
        {
            string sql = SQL_SELECT_ALL_USER + " AND (UserCode=@code OR Email=@code Or MobilePhone=@code) ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@code", code) };
            UserInfo userInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    userInfo = InitUserInfoByDataReader(userInfo, reader);
                }
            }

            return userInfo;
        }
        #endregion
    }
}
