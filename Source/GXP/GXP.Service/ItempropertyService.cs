/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItempropertyService
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
    public class ItempropertyService : IItempropertyService
    {
        [Dependency]
        public IItempropertyDA itempropertyDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Itemproperty记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemproperty记录</returns>
        public DataSet GetAllItemproperty()
        {
            return itempropertyDA.GetAllItemproperty();
        }

        /// <summary>
        /// 根据查询条件得到Itemproperty记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItempropertyQueryEntity">Itemproperty查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemproperty记录</returns>
        public DataSet GetItempropertyByQueryList(QueryEntity itempropertyQuery)
        {
            return itempropertyDA.GetItempropertyByQueryList(itempropertyQuery);
        }

        /// <summary>
        /// 根据itempropertyID得到一条Itemproperty记录
        /// </summary>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itempropertyID得到一条Itemproperty记录</returns>
        public ItempropertyInfo GetItempropertyByID(string itempropertyID)
        {
            return itempropertyDA.GetItempropertyByID(itempropertyID);
        }

        /// <summary>
        /// 新增一条Itemproperty记录
        /// </summary>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemproperty(ItempropertyInfo itempropertyInfo)
        {
            return itempropertyDA.InsertItemproperty(itempropertyInfo);
        }

        /// <summary>
        /// 删除一条Itemproperty记录
        /// </summary>
        /// <param name="itempropertyID">ItempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemproperty(List<string> itempropertyID)
        {
            int result = 0;
            if (itempropertyID != null && itempropertyID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < itempropertyID.Count; i++)
                    {
                        result += itempropertyDA.DeleteItemproperty(db, dbTran, itempropertyID[i]);
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
        /// 更新一条Itemproperty记录
        /// </summary>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemproperty(ItempropertyInfo itempropertyInfo)
        {
            return itempropertyDA.UpdateItemproperty(itempropertyInfo);
        }

        /// <summary>
        /// 检查ItempropertyID是否已存在
        /// </summary>
        /// <param name="itempropertyID">ItempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItempropertyIDIsExist(string itempropertyID)
        {
            return itempropertyDA.CheckItempropertyIDIsExist(itempropertyID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
