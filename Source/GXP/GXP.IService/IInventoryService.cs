﻿/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IInventoryService
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
    public interface IInventoryService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Inventory记录
        /// </summary>
        /// <returns>所有的Inventory记录</returns>
        DataSet GetAllInventory();

        /// <summary>
        /// 根据查询条件得到Inventory记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InventoryQueryEntity">Inventory查询实体类</param>
        /// <returns>根据查询条件得到Inventory记录</returns>
        DataSet GetInventoryByQueryList(QueryEntity inventoryQuery);

        /// <summary>
        /// 根据inventoryID得到一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>根据inventoryID得到一条Inventory记录</returns>
        InventoryInfo GetInventoryByID(string inventoryID);

        /// <summary>
        /// 新增一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertInventory(InventoryInfo inventoryInfo);

        /// <summary>
        /// 更新一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateInventory(InventoryInfo inventoryInfo);

        /// <summary>
        /// 删除一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteInventory(List<string> inventoryID);

        /// <summary>
        /// 检查InventoryID是否已存在
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckInventoryIDIsExist(string inventoryID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
