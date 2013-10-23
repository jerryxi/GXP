/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItemService
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
    public interface IItemService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Item记录
        /// </summary>
        /// <returns>所有的Item记录</returns>
        DataSet GetAllItem();

        /// <summary>
        /// 根据查询条件得到Item记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemQueryEntity">Item查询实体类</param>
        /// <returns>根据查询条件得到Item记录</returns>
        DataSet GetItemByQueryList(QueryEntity itemQuery);

        /// <summary>
        /// 根据itemID得到一条Item记录
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <returns>根据itemID得到一条Item记录</returns>
        ItemInfo GetItemByID(string itemID);

        /// <summary>
        /// 新增一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItem(ItemInfo itemInfo);

        /// <summary>
        /// 更新一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItem(ItemInfo itemInfo);

        /// <summary>
        /// 删除一条Item记录
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItem(List<string> itemID);

        /// <summary>
        /// 检查ItemID是否已存在
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItemIDIsExist(string itemID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
