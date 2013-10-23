﻿/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItemfeedbackService
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
using System.Text;
using System.Data;
using System.Data.Common;
using GXP.IService;
using GXP.IDAL;
using GXP.DataEntity;
using GXP.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GXP.Service
{
    public class ItemfeedbackService : IItemfeedbackService
    {
        [Dependency]
        public IItemfeedbackDA itemfeedbackDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Itemfeedback记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemfeedback记录</returns>
        public DataSet GetAllItemfeedback()
        {
            return itemfeedbackDA.GetAllItemfeedback();
        }

        /// <summary>
        /// 根据查询条件得到Itemfeedback记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemfeedbackQueryEntity">Itemfeedback查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemfeedback记录</returns>
        public DataSet GetItemfeedbackByQueryList(QueryEntity itemfeedbackQuery)
        {
            return itemfeedbackDA.GetItemfeedbackByQueryList(itemfeedbackQuery);
        }

        /// <summary>
        /// 根据itemfeedbackID得到一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemfeedbackID得到一条Itemfeedback记录</returns>
        public ItemfeedbackInfo GetItemfeedbackByID(string itemfeedbackID)
        {
            return itemfeedbackDA.GetItemfeedbackByID(itemfeedbackID);
        }

        /// <summary>
        /// 新增一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemfeedback(ItemfeedbackInfo itemfeedbackInfo)
        {
            return itemfeedbackDA.InsertItemfeedback(itemfeedbackInfo);
        }

        /// <summary>
        /// 删除一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedbackID">ItemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemfeedback(List<string> itemfeedbackID)
        {
            int result = 0;
            if (itemfeedbackID != null && itemfeedbackID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < itemfeedbackID.Count; i++)
                    {
                        result += itemfeedbackDA.DeleteItemfeedback(db, dbTran, itemfeedbackID[i]);
                    }
                    dbTran.Commit();
                }
                catch (Exception ex)
                {
                    result = 0;
                    dbTran.Rollback();
                    LogHelper.LogError(ex, "");
                }
                finally
                {
                    dbConn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 更新一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemfeedback(ItemfeedbackInfo itemfeedbackInfo)
        {
            return itemfeedbackDA.UpdateItemfeedback(itemfeedbackInfo);
        }

        /// <summary>
        /// 检查ItemfeedbackID是否已存在
        /// </summary>
        /// <param name="itemfeedbackID">ItemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemfeedbackIDIsExist(string itemfeedbackID)
        {
            return itemfeedbackDA.CheckItemfeedbackIDIsExist(itemfeedbackID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
