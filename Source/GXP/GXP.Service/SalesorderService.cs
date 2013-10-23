﻿/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SalesorderService
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
    public class SalesorderService : ISalesorderService
    {
        [Dependency]
        public ISalesorderDA salesorderDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Salesorder记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Salesorder记录</returns>
        public DataSet GetAllSalesorder()
        {
            return salesorderDA.GetAllSalesorder();
        }

        /// <summary>
        /// 根据查询条件得到Salesorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderQueryEntity">Salesorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Salesorder记录</returns>
        public DataSet GetSalesorderByQueryList(QueryEntity salesorderQuery)
        {
            return salesorderDA.GetSalesorderByQueryList(salesorderQuery);
        }

        /// <summary>
        /// 根据salesorderID得到一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据salesorderID得到一条Salesorder记录</returns>
        public SalesorderInfo GetSalesorderByID(string salesorderID)
        {
            return salesorderDA.GetSalesorderByID(salesorderID);
        }

        /// <summary>
        /// 新增一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSalesorder(SalesorderInfo salesorderInfo)
        {
            return salesorderDA.InsertSalesorder(salesorderInfo);
        }

        /// <summary>
        /// 删除一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">SalesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSalesorder(List<string> salesorderID)
        {
            int result = 0;
            if (salesorderID != null && salesorderID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < salesorderID.Count; i++)
                    {
                        result += salesorderDA.DeleteSalesorder(db, dbTran, salesorderID[i]);
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
        /// 更新一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSalesorder(SalesorderInfo salesorderInfo)
        {
            return salesorderDA.UpdateSalesorder(salesorderInfo);
        }

        /// <summary>
        /// 检查SalesorderID是否已存在
        /// </summary>
        /// <param name="salesorderID">SalesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSalesorderIDIsExist(string salesorderID)
        {
            return salesorderDA.CheckSalesorderIDIsExist(salesorderID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
