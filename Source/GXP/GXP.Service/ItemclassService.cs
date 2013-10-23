/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItemclassService
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
    public class ItemclassService : IItemclassService
    {
        [Dependency]
        public IItemclassDA itemclassDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Itemclass记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemclass记录</returns>
        public DataSet GetAllItemclass()
        {
            return itemclassDA.GetAllItemclass();
        }

        /// <summary>
        /// 根据查询条件得到Itemclass记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemclassQueryEntity">Itemclass查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemclass记录</returns>
        public DataSet GetItemclassByQueryList(QueryEntity itemclassQuery)
        {
            return itemclassDA.GetItemclassByQueryList(itemclassQuery);
        }

        /// <summary>
        /// 根据itemclassID得到一条Itemclass记录
        /// </summary>
        /// <param name="itemclassID">itemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemclassID得到一条Itemclass记录</returns>
        public ItemclassInfo GetItemclassByID(string itemclassID)
        {
            return itemclassDA.GetItemclassByID(itemclassID);
        }

        /// <summary>
        /// 新增一条Itemclass记录
        /// </summary>
        /// <param name="itemclass">Itemclass对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemclass(ItemclassInfo itemclassInfo)
        {
            return itemclassDA.InsertItemclass(itemclassInfo);
        }

        /// <summary>
        /// 删除一条Itemclass记录
        /// </summary>
        /// <param name="itemclassID">ItemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemclass(List<string> itemclassID)
        {
            int result = 0;
            if (itemclassID != null && itemclassID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < itemclassID.Count; i++)
                    {
                        result += itemclassDA.DeleteItemclass(db, dbTran, itemclassID[i]);
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
        /// 更新一条Itemclass记录
        /// </summary>
        /// <param name="itemclass">Itemclass对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemclass(ItemclassInfo itemclassInfo)
        {
            return itemclassDA.UpdateItemclass(itemclassInfo);
        }

        /// <summary>
        /// 检查ItemclassID是否已存在
        /// </summary>
        /// <param name="itemclassID">ItemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemclassIDIsExist(string itemclassID)
        {
            return itemclassDA.CheckItemclassIDIsExist(itemclassID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
