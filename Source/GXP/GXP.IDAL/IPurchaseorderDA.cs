/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IPurchaseorderDA
// 文件功能描述：提供Purchaseorder数据表操作的方法的定义
//
// 创建标识：JerryXi 2013/7/10  
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using GXP.DataEntity;

namespace GXP.IDAL
{
    public interface IPurchaseorderDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Purchaseorder记录
        /// </summary>
        /// <returns>所有的Purchaseorder记录</returns>
        DataSet GetAllPurchaseorder();
        /// <summary>
        /// 得到所有的Purchaseorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Purchaseorder记录</returns>
        DataSet GetAllPurchaseorder(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Purchaseorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderQueryEntity">Purchaseorder查询实体类</param>
        /// <returns>根据查询条件得到Purchaseorder记录</returns>
        DataSet GetPurchaseorderByQueryList(QueryEntity purchaseorderQuery);
        /// <summary>
        /// 根据查询条件得到Purchaseorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderQueryEntity">Purchaseorder查询实体类</param>
        /// <returns>根据查询条件得到Purchaseorder记录</returns>
        DataSet GetPurchaseorderByQueryList(Database db, DbTransaction tran, QueryEntity purchaseorderQuery);

        /// <summary>
        /// 根据purchaseorderID得到一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>根据purchaseorderID得到一条Purchaseorder记录</returns>
        PurchaseorderInfo GetPurchaseorderByID(string purchaseorderID);
        /// <summary>
        /// 根据purchaseorderID得到一条Purchaseorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>根据purchaseorderID得到一条Purchaseorder记录</returns>
        PurchaseorderInfo GetPurchaseorderByID(Database db, DbTransaction tran, string purchaseorderID);

        /// <summary>
        /// 新增一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertPurchaseorder(PurchaseorderInfo purchaseorderInfo);
        /// <summary>
        /// 新增一条Purchaseorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertPurchaseorder(Database db, DbTransaction tran, PurchaseorderInfo purchaseorderInfo);

        /// <summary>
        /// 更新一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdatePurchaseorder(PurchaseorderInfo purchaseorderInfo);
        /// <summary>
        /// 更新一条Purchaseorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdatePurchaseorder(Database db, DbTransaction tran, PurchaseorderInfo purchaseorderInfo);

        /// <summary>
        /// 删除一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeletePurchaseorder(string purchaseorderID);
        /// <summary>
        /// 删除一条Purchaseorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeletePurchaseorder(Database db, DbTransaction tran, string purchaseorderID);

        /// <summary>
        /// 检查PurchaseorderID是否已存在
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckPurchaseorderIDIsExist(string purchaseorderID);
        /// <summary>
        /// 检查PurchaseorderID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckPurchaseorderIDIsExist(Database db, DbTransaction tran, string purchaseorderID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
