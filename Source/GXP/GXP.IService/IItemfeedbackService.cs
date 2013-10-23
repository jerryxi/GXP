/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItemfeedbackService
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
    public interface IItemfeedbackService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Itemfeedback记录
        /// </summary>
        /// <returns>所有的Itemfeedback记录</returns>
        DataSet GetAllItemfeedback();

        /// <summary>
        /// 根据查询条件得到Itemfeedback记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemfeedbackQueryEntity">Itemfeedback查询实体类</param>
        /// <returns>根据查询条件得到Itemfeedback记录</returns>
        DataSet GetItemfeedbackByQueryList(QueryEntity itemfeedbackQuery);

        /// <summary>
        /// 根据itemfeedbackID得到一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <returns>根据itemfeedbackID得到一条Itemfeedback记录</returns>
        ItemfeedbackInfo GetItemfeedbackByID(string itemfeedbackID);

        /// <summary>
        /// 新增一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItemfeedback(ItemfeedbackInfo itemfeedbackInfo);

        /// <summary>
        /// 更新一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItemfeedback(ItemfeedbackInfo itemfeedbackInfo);

        /// <summary>
        /// 删除一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItemfeedback(List<string> itemfeedbackID);

        /// <summary>
        /// 检查ItemfeedbackID是否已存在
        /// </summary>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItemfeedbackIDIsExist(string itemfeedbackID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
