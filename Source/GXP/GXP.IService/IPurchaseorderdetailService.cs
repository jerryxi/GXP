/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IPurchaseorderdetailService
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
using System.Data;
using GXP.DataEntity;

namespace GXP.IService
{
    public interface IPurchaseorderdetailService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Purchaseorderdetail记录
        /// </summary>
        /// <returns>所有的Purchaseorderdetail记录</returns>
        DataSet GetAllPurchaseorderdetail();

        /// <summary>
        /// 根据查询条件得到Purchaseorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderdetailQueryEntity">Purchaseorderdetail查询实体类</param>
        /// <returns>根据查询条件得到Purchaseorderdetail记录</returns>
        DataSet GetPurchaseorderdetailByQueryList(QueryEntity purchaseorderdetailQuery);

        /// <summary>
        /// 根据purchaseorderdetailID得到一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>根据purchaseorderdetailID得到一条Purchaseorderdetail记录</returns>
        PurchaseorderdetailInfo GetPurchaseorderdetailByID(string purchaseorderdetailID);

        /// <summary>
        /// 新增一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertPurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo);

        /// <summary>
        /// 更新一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdatePurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo);

        /// <summary>
        /// 删除一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeletePurchaseorderdetail(List<string> purchaseorderdetailID);

        /// <summary>
        /// 检查PurchaseorderdetailID是否已存在
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckPurchaseorderdetailIDIsExist(string purchaseorderdetailID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
