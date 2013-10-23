/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IPurchaseorderService
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
    public interface IPurchaseorderService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Purchaseorder记录
        /// </summary>
        /// <returns>所有的Purchaseorder记录</returns>
        DataSet GetAllPurchaseorder();

        /// <summary>
        /// 根据查询条件得到Purchaseorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderQueryEntity">Purchaseorder查询实体类</param>
        /// <returns>根据查询条件得到Purchaseorder记录</returns>
        DataSet GetPurchaseorderByQueryList(QueryEntity purchaseorderQuery);

        /// <summary>
        /// 根据purchaseorderID得到一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>根据purchaseorderID得到一条Purchaseorder记录</returns>
        PurchaseorderInfo GetPurchaseorderByID(string purchaseorderID);

        /// <summary>
        /// 新增一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertPurchaseorder(PurchaseorderInfo purchaseorderInfo);

        /// <summary>
        /// 更新一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdatePurchaseorder(PurchaseorderInfo purchaseorderInfo);

        /// <summary>
        /// 删除一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeletePurchaseorder(List<string> purchaseorderID);

        /// <summary>
        /// 检查PurchaseorderID是否已存在
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckPurchaseorderIDIsExist(string purchaseorderID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
