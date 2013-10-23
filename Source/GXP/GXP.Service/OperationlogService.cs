/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：OperationlogService
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
    public class OperationlogService : IOperationlogService
    {
        [Dependency]
        public IOperationlogDA operationlogDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Operationlog记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Operationlog记录</returns>
        public DataSet GetAllOperationlog()
        {
            return operationlogDA.GetAllOperationlog();
        }

        /// <summary>
        /// 根据查询条件得到Operationlog记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="OperationlogQueryEntity">Operationlog查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Operationlog记录</returns>
        public DataSet GetOperationlogByQueryList(QueryEntity operationlogQuery)
        {
            return operationlogDA.GetOperationlogByQueryList(operationlogQuery);
        }

        /// <summary>
        /// 根据operationlogID得到一条Operationlog记录
        /// </summary>
        /// <param name="operationlogID">operationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据operationlogID得到一条Operationlog记录</returns>
        public OperationlogInfo GetOperationlogByID(string operationlogID)
        {
            return operationlogDA.GetOperationlogByID(operationlogID);
        }

        /// <summary>
        /// 新增一条Operationlog记录
        /// </summary>
        /// <param name="operationlog">Operationlog对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertOperationlog(OperationlogInfo operationlogInfo)
        {
            return operationlogDA.InsertOperationlog(operationlogInfo);
        }

        /// <summary>
        /// 删除一条Operationlog记录
        /// </summary>
        /// <param name="operationlogID">OperationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteOperationlog(List<string> operationlogID)
        {
            int result = 0;
            if (operationlogID != null && operationlogID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < operationlogID.Count; i++)
                    {
                        result += operationlogDA.DeleteOperationlog(db, dbTran, operationlogID[i]);
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
        /// 更新一条Operationlog记录
        /// </summary>
        /// <param name="operationlog">Operationlog对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateOperationlog(OperationlogInfo operationlogInfo)
        {
            return operationlogDA.UpdateOperationlog(operationlogInfo);
        }

        /// <summary>
        /// 检查OperationlogID是否已存在
        /// </summary>
        /// <param name="operationlogID">OperationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckOperationlogIDIsExist(string operationlogID)
        {
            return operationlogDA.CheckOperationlogIDIsExist(operationlogID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
