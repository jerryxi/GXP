/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：PurchaseorderService
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
    public class PurchaseorderService : IPurchaseorderService
    {
        [Dependency]
        public IPurchaseorderDA purchaseorderDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Purchaseorder记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Purchaseorder记录</returns>
        public DataSet GetAllPurchaseorder()
        {
            return purchaseorderDA.GetAllPurchaseorder();
        }

        /// <summary>
        /// 根据查询条件得到Purchaseorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderQueryEntity">Purchaseorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Purchaseorder记录</returns>
        public DataSet GetPurchaseorderByQueryList(QueryEntity purchaseorderQuery)
        {
            return purchaseorderDA.GetPurchaseorderByQueryList(purchaseorderQuery);
        }

        /// <summary>
        /// 根据purchaseorderID得到一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据purchaseorderID得到一条Purchaseorder记录</returns>
        public PurchaseorderInfo GetPurchaseorderByID(string purchaseorderID)
        {
            return purchaseorderDA.GetPurchaseorderByID(purchaseorderID);
        }

        /// <summary>
        /// 新增一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertPurchaseorder(PurchaseorderInfo purchaseorderInfo)
        {
            return purchaseorderDA.InsertPurchaseorder(purchaseorderInfo);
        }

        /// <summary>
        /// 删除一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">PurchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeletePurchaseorder(List<string> purchaseorderID)
        {
            int result = 0;
            if (purchaseorderID != null && purchaseorderID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < purchaseorderID.Count; i++)
                    {
                        result += purchaseorderDA.DeletePurchaseorder(db, dbTran, purchaseorderID[i]);
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
        /// 更新一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdatePurchaseorder(PurchaseorderInfo purchaseorderInfo)
        {
            return purchaseorderDA.UpdatePurchaseorder(purchaseorderInfo);
        }

        /// <summary>
        /// 检查PurchaseorderID是否已存在
        /// </summary>
        /// <param name="purchaseorderID">PurchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckPurchaseorderIDIsExist(string purchaseorderID)
        {
            return purchaseorderDA.CheckPurchaseorderIDIsExist(purchaseorderID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
