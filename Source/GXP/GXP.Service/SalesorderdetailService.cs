/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SalesorderdetailService
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
    public class SalesorderdetailService : ISalesorderdetailService
    {
        [Dependency]
        public ISalesorderdetailDA salesorderdetailDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Salesorderdetail记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Salesorderdetail记录</returns>
        public DataSet GetAllSalesorderdetail()
        {
            return salesorderdetailDA.GetAllSalesorderdetail();
        }

        /// <summary>
        /// 根据查询条件得到Salesorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderdetailQueryEntity">Salesorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Salesorderdetail记录</returns>
        public DataSet GetSalesorderdetailByQueryList(QueryEntity salesorderdetailQuery)
        {
            return salesorderdetailDA.GetSalesorderdetailByQueryList(salesorderdetailQuery);
        }

        /// <summary>
        /// 根据salesorderdetailID得到一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetailID">salesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据salesorderdetailID得到一条Salesorderdetail记录</returns>
        public SalesorderdetailInfo GetSalesorderdetailByID(string salesorderdetailID)
        {
            return salesorderdetailDA.GetSalesorderdetailByID(salesorderdetailID);
        }

        /// <summary>
        /// 新增一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetail">Salesorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSalesorderdetail(SalesorderdetailInfo salesorderdetailInfo)
        {
            return salesorderdetailDA.InsertSalesorderdetail(salesorderdetailInfo);
        }

        /// <summary>
        /// 删除一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetailID">SalesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSalesorderdetail(List<string> salesorderdetailID)
        {
            int result = 0;
            if (salesorderdetailID != null && salesorderdetailID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < salesorderdetailID.Count; i++)
                    {
                        result += salesorderdetailDA.DeleteSalesorderdetail(db, dbTran, salesorderdetailID[i]);
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
        /// 更新一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetail">Salesorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSalesorderdetail(SalesorderdetailInfo salesorderdetailInfo)
        {
            return salesorderdetailDA.UpdateSalesorderdetail(salesorderdetailInfo);
        }

        /// <summary>
        /// 检查SalesorderdetailID是否已存在
        /// </summary>
        /// <param name="salesorderdetailID">SalesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSalesorderdetailIDIsExist(string salesorderdetailID)
        {
            return salesorderdetailDA.CheckSalesorderdetailIDIsExist(salesorderdetailID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
