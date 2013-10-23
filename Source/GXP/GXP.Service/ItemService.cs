/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItemService
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
    public class ItemService : IItemService
    {
        [Dependency]
        public IItemDA itemDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Item记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Item记录</returns>
        public DataSet GetAllItem()
        {
            return itemDA.GetAllItem();
        }

        /// <summary>
        /// 根据查询条件得到Item记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemQueryEntity">Item查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Item记录</returns>
        public DataSet GetItemByQueryList(QueryEntity itemQuery)
        {
            return itemDA.GetItemByQueryList(itemQuery);
        }

        /// <summary>
        /// 根据itemID得到一条Item记录
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemID得到一条Item记录</returns>
        public ItemInfo GetItemByID(string itemID)
        {
            return itemDA.GetItemByID(itemID);
        }

        /// <summary>
        /// 新增一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItem(ItemInfo itemInfo)
        {
            return itemDA.InsertItem(itemInfo);
        }

        /// <summary>
        /// 删除一条Item记录
        /// </summary>
        /// <param name="itemID">ItemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItem(List<string> itemID)
        {
            int result = 0;
            if (itemID != null && itemID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < itemID.Count; i++)
                    {
                        result += itemDA.DeleteItem(db, dbTran, itemID[i]);
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
        /// 更新一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItem(ItemInfo itemInfo)
        {
            return itemDA.UpdateItem(itemInfo);
        }

        /// <summary>
        /// 检查ItemID是否已存在
        /// </summary>
        /// <param name="itemID">ItemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemIDIsExist(string itemID)
        {
            return itemDA.CheckItemIDIsExist(itemID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
