/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：UserService
// 文件功能描述：
//
// 创建标识：JerryXi 2013/4/6  
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using GXP.IService;
using GXP.IDAL;
using GXP.DataEntity;
using GXP.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GXP.Service
{
    public class UserService : IUserService
    {
        [Dependency]
        public IUserDA userDA { get; set; }

        /// <summary>
        /// 得到所有的User记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的User记录</returns>
        public DataSet GetAllUser()
        {
            return userDA.GetAllUser();
        }

        /// <summary>
        /// 根据查询条件得到User记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserQueryEntity">User查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到User记录</returns>
        public DataSet GetUserByQueryList(QueryEntity userQuery)
        {
            return userDA.GetUserByQueryList(userQuery);
        }

        /// <summary>
        /// 根据userID得到一条User记录
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据userID得到一条User记录</returns>
        public UserInfo GetUserByID(string userID)
        {
            return userDA.GetUserByID(userID);
        }

        /// <summary>
        /// 新增一条User记录
        /// </summary>
        /// <param name="user">User对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUser(UserInfo userInfo)
        {
            return userDA.InsertUser(userInfo);
        }

        /// <summary>
        /// 删除一条User记录
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUser(List<string> userID)
        {
            int result = 0;
            if (userID != null && userID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < userID.Count; i++)
                    {
                        result += userDA.DeleteUser(db, dbTran, userID[i]);
                    }
                    dbTran.Commit();
                }
                catch (Exception ex)
                {
                    result = 0;                    
                    dbTran.Rollback();
                    LogHelper.LogError(ex, "");
                }
                finally
                {
                    dbConn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 更新一条User记录
        /// </summary>
        /// <param name="user">User对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUser(UserInfo userInfo)
        {
            return userDA.UpdateUser(userInfo);
        }

        /// <summary>
        /// 检查UserID是否已存在
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUserIDIsExist(string userID)
        {
            return userDA.CheckUserIDIsExist(userID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UserInfo GetUserByCodePhoneEmail(string code)
        {
            return userDA.GetUserByCodePhoneEmail(code);
        }
    }
}
