/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IPurchaseorderdetailDA
// 文件功能描述：提供Purchaseorderdetail数据表操作的方法的定义
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
    public interface IPurchaseorderdetailDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Purchaseorderdetail记录
        /// </summary>
        /// <returns>所有的Purchaseorderdetail记录</returns>
        DataSet GetAllPurchaseorderdetail();
        /// <summary>
        /// 得到所有的Purchaseorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Purchaseorderdetail记录</returns>
        DataSet GetAllPurchaseorderdetail(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Purchaseorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderdetailQueryEntity">Purchaseorderdetail查询实体类</param>
        /// <returns>根据查询条件得到Purchaseorderdetail记录</returns>
        DataSet GetPurchaseorderdetailByQueryList(QueryEntity purchaseorderdetailQuery);
        /// <summary>
        /// 根据查询条件得到Purchaseorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderdetailQueryEntity">Purchaseorderdetail查询实体类</param>
        /// <returns>根据查询条件得到Purchaseorderdetail记录</returns>
        DataSet GetPurchaseorderdetailByQueryList(Database db, DbTransaction tran, QueryEntity purchaseorderdetailQuery);

        /// <summary>
        /// 根据purchaseorderdetailID得到一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>根据purchaseorderdetailID得到一条Purchaseorderdetail记录</returns>
        PurchaseorderdetailInfo GetPurchaseorderdetailByID(string purchaseorderdetailID);
        /// <summary>
        /// 根据purchaseorderdetailID得到一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>根据purchaseorderdetailID得到一条Purchaseorderdetail记录</returns>
        PurchaseorderdetailInfo GetPurchaseorderdetailByID(Database db, DbTransaction tran, string purchaseorderdetailID);

        /// <summary>
        /// 新增一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertPurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo);
        /// <summary>
        /// 新增一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertPurchaseorderdetail(Database db, DbTransaction tran, PurchaseorderdetailInfo purchaseorderdetailInfo);

        /// <summary>
        /// 更新一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdatePurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo);
        /// <summary>
        /// 更新一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdatePurchaseorderdetail(Database db, DbTransaction tran, PurchaseorderdetailInfo purchaseorderdetailInfo);

        /// <summary>
        /// 删除一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeletePurchaseorderdetail(string purchaseorderdetailID);
        /// <summary>
        /// 删除一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeletePurchaseorderdetail(Database db, DbTransaction tran, string purchaseorderdetailID);

        /// <summary>
        /// 检查PurchaseorderdetailID是否已存在
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckPurchaseorderdetailIDIsExist(string purchaseorderdetailID);
        /// <summary>
        /// 检查PurchaseorderdetailID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckPurchaseorderdetailIDIsExist(Database db, DbTransaction tran, string purchaseorderdetailID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
