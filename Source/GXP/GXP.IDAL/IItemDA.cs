/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItemDA
// 文件功能描述：提供Item数据表操作的方法的定义
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
    public interface IItemDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Item记录
        /// </summary>
        /// <returns>所有的Item记录</returns>
        DataSet GetAllItem();
        /// <summary>
        /// 得到所有的Item记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Item记录</returns>
        DataSet GetAllItem(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Item记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemQueryEntity">Item查询实体类</param>
        /// <returns>根据查询条件得到Item记录</returns>
        DataSet GetItemByQueryList(QueryEntity itemQuery);
        /// <summary>
        /// 根据查询条件得到Item记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemQueryEntity">Item查询实体类</param>
        /// <returns>根据查询条件得到Item记录</returns>
        DataSet GetItemByQueryList(Database db, DbTransaction tran, QueryEntity itemQuery);

        /// <summary>
        /// 根据itemID得到一条Item记录
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <returns>根据itemID得到一条Item记录</returns>
        ItemInfo GetItemByID(string itemID);
        /// <summary>
        /// 根据itemID得到一条Item记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemID">itemID</param>
        /// <returns>根据itemID得到一条Item记录</returns>
        ItemInfo GetItemByID(Database db, DbTransaction tran, string itemID);

        /// <summary>
        /// 新增一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItem(ItemInfo itemInfo);
        /// <summary>
        /// 新增一条Item记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="item">Item对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItem(Database db, DbTransaction tran, ItemInfo itemInfo);

        /// <summary>
        /// 更新一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItem(ItemInfo itemInfo);
        /// <summary>
        /// 更新一条Item记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="item">Item对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItem(Database db, DbTransaction tran, ItemInfo itemInfo);

        /// <summary>
        /// 删除一条Item记录
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItem(string itemID);
        /// <summary>
        /// 删除一条Item记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemID">itemID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItem(Database db, DbTransaction tran, string itemID);

        /// <summary>
        /// 检查ItemID是否已存在
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItemIDIsExist(string itemID);
        /// <summary>
        /// 检查ItemID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemID">itemID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItemIDIsExist(Database db, DbTransaction tran, string itemID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
