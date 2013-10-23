/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：UserroleService
// 文件功能描述：
//
// 创建标识：JerryXi 2013/8/20  
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
    public class UserroleService : IUserroleService
    {
        [Dependency]
        public IUserroleDA userroleDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Userrole记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Userrole记录</returns>
        public DataSet GetAllUserrole()
        {
            return userroleDA.GetAllUserrole();
        }

        /// <summary>
        /// 根据查询条件得到Userrole记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserroleQueryEntity">Userrole查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Userrole记录</returns>
        public DataSet GetUserroleByQueryList(QueryEntity userroleQuery)
        {
            return userroleDA.GetUserroleByQueryList(userroleQuery);
        }

        /// <summary>
        /// 根据userroleID得到一条Userrole记录
        /// </summary>
        /// <param name="userroleID">userroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据userroleID得到一条Userrole记录</returns>
        public UserroleInfo GetUserroleByID(string userroleID)
        {
            return userroleDA.GetUserroleByID(userroleID);
        }

        /// <summary>
        /// 新增一条Userrole记录
        /// </summary>
        /// <param name="userrole">Userrole对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUserrole(UserroleInfo userroleInfo)
        {
            return userroleDA.InsertUserrole(userroleInfo);
        }

        /// <summary>
        /// 删除一条Userrole记录
        /// </summary>
        /// <param name="userroleID">UserroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUserrole(List<string> userroleID)
        {
            int result = 0;
            if (userroleID != null && userroleID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < userroleID.Count; i++)
                    {
                        result += userroleDA.DeleteUserrole(db, dbTran, userroleID[i]);
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
        /// 更新一条Userrole记录
        /// </summary>
        /// <param name="userrole">Userrole对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUserrole(UserroleInfo userroleInfo)
        {
            return userroleDA.UpdateUserrole(userroleInfo);
        }

        /// <summary>
        /// 检查UserroleID是否已存在
        /// </summary>
        /// <param name="userroleID">UserroleID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUserroleIDIsExist(string userroleID)
        {
            return userroleDA.CheckUserroleIDIsExist(userroleID);
        }
        #endregion

        #region 扩展方法

        public int SetUserRoles(int userID, List<int> roleList, string createdBy)
        {
            return userroleDA.SetUserRoles(userID, roleList, createdBy);
        }

        public List<string> GetUserRoleListByUserID(string userID)
        {
            return userroleDA.GetUserRoleListByUserID(userID);
        }

        #endregion
    }
}
