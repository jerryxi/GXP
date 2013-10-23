/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：InventoryService
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
    public class InventoryService : IInventoryService
    {
        [Dependency]
        public IInventoryDA inventoryDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Inventory记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Inventory记录</returns>
        public DataSet GetAllInventory()
        {
            return inventoryDA.GetAllInventory();
        }

        /// <summary>
        /// 根据查询条件得到Inventory记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InventoryQueryEntity">Inventory查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Inventory记录</returns>
        public DataSet GetInventoryByQueryList(QueryEntity inventoryQuery)
        {
            return inventoryDA.GetInventoryByQueryList(inventoryQuery);
        }

        /// <summary>
        /// 根据inventoryID得到一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据inventoryID得到一条Inventory记录</returns>
        public InventoryInfo GetInventoryByID(string inventoryID)
        {
            return inventoryDA.GetInventoryByID(inventoryID);
        }

        /// <summary>
        /// 新增一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertInventory(InventoryInfo inventoryInfo)
        {
            return inventoryDA.InsertInventory(inventoryInfo);
        }

        /// <summary>
        /// 删除一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">InventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteInventory(List<string> inventoryID)
        {
            int result = 0;
            if (inventoryID != null && inventoryID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < inventoryID.Count; i++)
                    {
                        result += inventoryDA.DeleteInventory(db, dbTran, inventoryID[i]);
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
        /// 更新一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateInventory(InventoryInfo inventoryInfo)
        {
            return inventoryDA.UpdateInventory(inventoryInfo);
        }

        /// <summary>
        /// 检查InventoryID是否已存在
        /// </summary>
        /// <param name="inventoryID">InventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckInventoryIDIsExist(string inventoryID)
        {
            return inventoryDA.CheckInventoryIDIsExist(inventoryID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
