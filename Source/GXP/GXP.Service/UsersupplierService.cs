/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：UsersupplierService
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
    public class UsersupplierService : IUsersupplierService
    {
        [Dependency]
        public IUsersupplierDA usersupplierDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Usersupplier记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Usersupplier记录</returns>
        public DataSet GetAllUsersupplier()
        {
            return usersupplierDA.GetAllUsersupplier();
        }

        /// <summary>
        /// 根据查询条件得到Usersupplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UsersupplierQueryEntity">Usersupplier查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Usersupplier记录</returns>
        public DataSet GetUsersupplierByQueryList(QueryEntity usersupplierQuery)
        {
            return usersupplierDA.GetUsersupplierByQueryList(usersupplierQuery);
        }

        /// <summary>
        /// 根据usersupplierID得到一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据usersupplierID得到一条Usersupplier记录</returns>
        public UsersupplierInfo GetUsersupplierByID(string usersupplierID)
        {
            return usersupplierDA.GetUsersupplierByID(usersupplierID);
        }

        /// <summary>
        /// 新增一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertUsersupplier(UsersupplierInfo usersupplierInfo)
        {
            return usersupplierDA.InsertUsersupplier(usersupplierInfo);
        }

        /// <summary>
        /// 删除一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplierID">UsersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteUsersupplier(List<string> usersupplierID)
        {
            int result = 0;
            if (usersupplierID != null && usersupplierID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < usersupplierID.Count; i++)
                    {
                        result += usersupplierDA.DeleteUsersupplier(db, dbTran, usersupplierID[i]);
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
        /// 更新一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateUsersupplier(UsersupplierInfo usersupplierInfo)
        {
            return usersupplierDA.UpdateUsersupplier(usersupplierInfo);
        }

        /// <summary>
        /// 检查UsersupplierID是否已存在
        /// </summary>
        /// <param name="usersupplierID">UsersupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckUsersupplierIDIsExist(string usersupplierID)
        {
            return usersupplierDA.CheckUsersupplierIDIsExist(usersupplierID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
