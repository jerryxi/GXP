/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：FunctiongroupService
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
    public class FunctiongroupService : IFunctiongroupService
    {
        [Dependency]
        public IFunctiongroupDA functiongroupDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Functiongroup记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Functiongroup记录</returns>
        public DataSet GetAllFunctiongroup()
        {
            return functiongroupDA.GetAllFunctiongroup();
        }

        /// <summary>
        /// 根据查询条件得到Functiongroup记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="FunctiongroupQueryEntity">Functiongroup查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Functiongroup记录</returns>
        public DataSet GetFunctiongroupByQueryList(QueryEntity functiongroupQuery)
        {
            return functiongroupDA.GetFunctiongroupByQueryList(functiongroupQuery);
        }

        /// <summary>
        /// 根据functiongroupID得到一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据functiongroupID得到一条Functiongroup记录</returns>
        public FunctiongroupInfo GetFunctiongroupByID(string functiongroupID)
        {
            return functiongroupDA.GetFunctiongroupByID(functiongroupID);
        }

        /// <summary>
        /// 新增一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertFunctiongroup(FunctiongroupInfo functiongroupInfo)
        {
            return functiongroupDA.InsertFunctiongroup(functiongroupInfo);
        }

        /// <summary>
        /// 删除一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroupID">FunctiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteFunctiongroup(List<string> functiongroupID)
        {
            int result = 0;
            if (functiongroupID != null && functiongroupID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < functiongroupID.Count; i++)
                    {
                        result += functiongroupDA.DeleteFunctiongroup(db, dbTran, functiongroupID[i]);
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
        /// 更新一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateFunctiongroup(FunctiongroupInfo functiongroupInfo)
        {
            return functiongroupDA.UpdateFunctiongroup(functiongroupInfo);
        }

        /// <summary>
        /// 检查FunctiongroupID是否已存在
        /// </summary>
        /// <param name="functiongroupID">FunctiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckFunctiongroupIDIsExist(string functiongroupID)
        {
            return functiongroupDA.CheckFunctiongroupIDIsExist(functiongroupID);
        }
        #endregion

        #region 扩展方法
        public DataSet GetFunctionGroupByRoleID(int roleID)
        {
            return functiongroupDA.GetFunctionGroupByRoleID(roleID);
        }

        public DataSet GetFunctionGroupByUserID(int userID)
        {
            return functiongroupDA.GetFunctionGroupByUserID(userID);
        }
        #endregion
    }
}
