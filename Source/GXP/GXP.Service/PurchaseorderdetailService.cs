/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：PurchaseorderdetailService
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
    public class PurchaseorderdetailService : IPurchaseorderdetailService
    {
        [Dependency]
        public IPurchaseorderdetailDA purchaseorderdetailDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Purchaseorderdetail记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Purchaseorderdetail记录</returns>
        public DataSet GetAllPurchaseorderdetail()
        {
            return purchaseorderdetailDA.GetAllPurchaseorderdetail();
        }

        /// <summary>
        /// 根据查询条件得到Purchaseorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderdetailQueryEntity">Purchaseorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Purchaseorderdetail记录</returns>
        public DataSet GetPurchaseorderdetailByQueryList(QueryEntity purchaseorderdetailQuery)
        {
            return purchaseorderdetailDA.GetPurchaseorderdetailByQueryList(purchaseorderdetailQuery);
        }

        /// <summary>
        /// 根据purchaseorderdetailID得到一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据purchaseorderdetailID得到一条Purchaseorderdetail记录</returns>
        public PurchaseorderdetailInfo GetPurchaseorderdetailByID(string purchaseorderdetailID)
        {
            return purchaseorderdetailDA.GetPurchaseorderdetailByID(purchaseorderdetailID);
        }

        /// <summary>
        /// 新增一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertPurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            return purchaseorderdetailDA.InsertPurchaseorderdetail(purchaseorderdetailInfo);
        }

        /// <summary>
        /// 删除一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">PurchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeletePurchaseorderdetail(List<string> purchaseorderdetailID)
        {
            int result = 0;
            if (purchaseorderdetailID != null && purchaseorderdetailID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < purchaseorderdetailID.Count; i++)
                    {
                        result += purchaseorderdetailDA.DeletePurchaseorderdetail(db, dbTran, purchaseorderdetailID[i]);
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
        /// 更新一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdatePurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            return purchaseorderdetailDA.UpdatePurchaseorderdetail(purchaseorderdetailInfo);
        }

        /// <summary>
        /// 检查PurchaseorderdetailID是否已存在
        /// </summary>
        /// <param name="purchaseorderdetailID">PurchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckPurchaseorderdetailIDIsExist(string purchaseorderdetailID)
        {
            return purchaseorderdetailDA.CheckPurchaseorderdetailIDIsExist(purchaseorderdetailID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
