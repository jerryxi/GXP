/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IInventoryDA
// 文件功能描述：提供Inventory数据表操作的方法的定义
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
    public interface IInventoryDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Inventory记录
        /// </summary>
        /// <returns>所有的Inventory记录</returns>
        DataSet GetAllInventory();
        /// <summary>
        /// 得到所有的Inventory记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Inventory记录</returns>
        DataSet GetAllInventory(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Inventory记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InventoryQueryEntity">Inventory查询实体类</param>
        /// <returns>根据查询条件得到Inventory记录</returns>
        DataSet GetInventoryByQueryList(QueryEntity inventoryQuery);
        /// <summary>
        /// 根据查询条件得到Inventory记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InventoryQueryEntity">Inventory查询实体类</param>
        /// <returns>根据查询条件得到Inventory记录</returns>
        DataSet GetInventoryByQueryList(Database db, DbTransaction tran, QueryEntity inventoryQuery);

        /// <summary>
        /// 根据inventoryID得到一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>根据inventoryID得到一条Inventory记录</returns>
        InventoryInfo GetInventoryByID(string inventoryID);
        /// <summary>
        /// 根据inventoryID得到一条Inventory记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>根据inventoryID得到一条Inventory记录</returns>
        InventoryInfo GetInventoryByID(Database db, DbTransaction tran, string inventoryID);

        /// <summary>
        /// 新增一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertInventory(InventoryInfo inventoryInfo);
        /// <summary>
        /// 新增一条Inventory记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventory">Inventory对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertInventory(Database db, DbTransaction tran, InventoryInfo inventoryInfo);

        /// <summary>
        /// 更新一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateInventory(InventoryInfo inventoryInfo);
        /// <summary>
        /// 更新一条Inventory记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventory">Inventory对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateInventory(Database db, DbTransaction tran, InventoryInfo inventoryInfo);

        /// <summary>
        /// 删除一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteInventory(string inventoryID);
        /// <summary>
        /// 删除一条Inventory记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteInventory(Database db, DbTransaction tran, string inventoryID);

        /// <summary>
        /// 检查InventoryID是否已存在
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckInventoryIDIsExist(string inventoryID);
        /// <summary>
        /// 检查InventoryID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckInventoryIDIsExist(Database db, DbTransaction tran, string inventoryID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
