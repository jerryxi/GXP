/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItemclassService
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
    public interface IItemclassService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Itemclass记录
        /// </summary>
        /// <returns>所有的Itemclass记录</returns>
        DataSet GetAllItemclass();

        /// <summary>
        /// 根据查询条件得到Itemclass记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemclassQueryEntity">Itemclass查询实体类</param>
        /// <returns>根据查询条件得到Itemclass记录</returns>
        DataSet GetItemclassByQueryList(QueryEntity itemclassQuery);

        /// <summary>
        /// 根据itemclassID得到一条Itemclass记录
        /// </summary>
        /// <param name="itemclassID">itemclassID</param>
        /// <returns>根据itemclassID得到一条Itemclass记录</returns>
        ItemclassInfo GetItemclassByID(string itemclassID);

        /// <summary>
        /// 新增一条Itemclass记录
        /// </summary>
        /// <param name="itemclass">Itemclass对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItemclass(ItemclassInfo itemclassInfo);

        /// <summary>
        /// 更新一条Itemclass记录
        /// </summary>
        /// <param name="itemclass">Itemclass对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItemclass(ItemclassInfo itemclassInfo);

        /// <summary>
        /// 删除一条Itemclass记录
        /// </summary>
        /// <param name="itemclassID">itemclassID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItemclass(List<string> itemclassID);

        /// <summary>
        /// 检查ItemclassID是否已存在
        /// </summary>
        /// <param name="itemclassID">itemclassID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItemclassIDIsExist(string itemclassID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
