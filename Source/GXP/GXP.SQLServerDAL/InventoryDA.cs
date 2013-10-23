/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：InventoryDA
// 文件功能描述：提供Inventory数据表进行操作的一些方法
//
// 创建标识：JerryXi 2013/8/20  
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
using System.Data.SqlClient;

using Microsoft.Practices.EnterpriseLibrary.Data;
using GXP.IDAL;
using GXP.Common;
using GXP.DataEntity;

namespace GXP.SQLServerDAL
{
    public class InventoryDA : IInventoryDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Inventory 的所有记录
        private string SQL_SELECT_ALL_INVENTORY = "SELECT I.ID AS ID, I.ItemID AS ItemID, I.Qty AS Qty, I.OrderQty AS OrderQty, I.TS AS TS, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate, I.UpdatedBy AS UpdatedBy, I.UpdatedDate AS UpdatedDate FROM Inventory I WHERE 1=1  ";
        //INSERT_SQL 向Inventory增加一条记录
        private string SQL_INSERT_INVENTORY = "INSERT INTO Inventory ( ItemID, Qty, OrderQty, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @ItemID, @Qty, @OrderQty, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Inventory一条记录
        private string SQL_DELETE_INVENTORY = "DELETE FROM Inventory WHERE ID = @ID ";
        //UPDATE_SQL 更新Inventory记录
        private string SQL_UPDATE_INVENTORY = "UPDATE Inventory SET ItemID = @ItemID, Qty = @Qty, OrderQty = @OrderQty, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ID = @ID  ";

        //判断一个INVENTORY_ID是否已存在
        private string SQL_CHECK_INVENTORY_ID_IS_EXIST = " SELECT COUNT(1) FROM Inventory WHERE ID = @ID ";
        #endregion

        #region 基本方法

        #region 得到Inventory的所有记录

        /// <summary>
        /// 得到所有的Inventory记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Inventory记录</returns>
        public DataSet GetAllInventory()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_INVENTORY);
        }

        /// <summary>
        /// 得到所有的Inventory记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Inventory记录</returns>
        public DataSet GetAllInventory(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_INVENTORY);
        }

        #endregion

        #region 根据条件查询Inventory的记录  GetInventoryByQueryList()

        /// <summary>
        /// 根据查询条件得到Inventory记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InventoryQueryEntity">Inventory查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Inventory记录</returns>
        public DataSet GetInventoryByQueryList(QueryEntity inventoryQuery)
        {
            string temp = SQL_SELECT_ALL_INVENTORY;

            if (inventoryQuery != null && inventoryQuery.sqlWhere != null && inventoryQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < inventoryQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + inventoryQuery.sqlWhere[i];
                }
            }

            if (!inventoryQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, inventoryQuery.CurrentPage, inventoryQuery.PageSize, inventoryQuery.SortField, inventoryQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Inventory记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InventoryQueryEntity">Inventory查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Inventory记录</returns>
        public DataSet GetInventoryByQueryList(Database db, DbTransaction tran, QueryEntity inventoryQuery)
        {
            string temp = SQL_SELECT_ALL_INVENTORY;

            if (inventoryQuery != null && inventoryQuery.sqlWhere != null && inventoryQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < inventoryQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + inventoryQuery.sqlWhere[i];
                }
            }
            if (!inventoryQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, inventoryQuery.CurrentPage, inventoryQuery.PageSize, inventoryQuery.SortField, inventoryQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Inventory的一条记录 GetInventoryByID()

        /// <summary>
        /// 根据inventoryID得到一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">inventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据inventoryID得到一条Inventory记录</returns>
        public InventoryInfo GetInventoryByID(string inventoryID)
        {
            string sql = SQL_SELECT_ALL_INVENTORY + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", inventoryID) };
            InventoryInfo inventoryInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    inventoryInfo = InitInventoryInfoByDataReader(inventoryInfo, reader);
                }
            }

            return inventoryInfo;
        }
        /// <summary>
        /// 根据inventoryID得到一条Inventory记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventoryID">inventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据inventoryID得到一条Inventory记录</returns>
        public InventoryInfo GetInventoryByID(Database db, DbTransaction tran, string inventoryID)
        {
            string sql = SQL_SELECT_ALL_INVENTORY + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", inventoryID) };
            InventoryInfo inventoryInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                inventoryInfo = InitInventoryInfoByDataReader(inventoryInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return inventoryInfo;
        }
        /// <summary>
        /// 初始化InventoryInfo
        /// </summary>
        private InventoryInfo InitInventoryInfoByDataReader(InventoryInfo inventoryInfo, IDataReader reader)
        {
            inventoryInfo = new InventoryInfo(reader["ID"].ToString() != "" ? Int32.Parse(reader["ID"].ToString()) : 0,
reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["Qty"].ToString() != "" ? Int32.Parse(reader["Qty"].ToString()) : 0,
reader["OrderQty"].ToString() != "" ? Int32.Parse(reader["OrderQty"].ToString()) : 0,
reader["TS"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return inventoryInfo;
        }
        #endregion

        #region 向Inventory增加一条记录 InsertInventory()

        /// <summary>
        /// 新增一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertInventory(InventoryInfo inventoryInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Inventory_Parameters(inventoryInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_INVENTORY, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Inventory记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventory">Inventory对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertInventory(Database db, DbTransaction tran, InventoryInfo inventoryInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Inventory_Parameters(inventoryInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_INVENTORY, paras);
            }
            return result;
        }
        #endregion

        #region 删除Inventory一条记录 DeleteInventory()

        /// <summary>
        /// 删除一条Inventory记录
        /// </summary>
        /// <param name="inventoryID">InventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteInventory(string inventoryID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", inventoryID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_INVENTORY, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Inventory记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventoryID">InventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteInventory(Database db, DbTransaction tran, string inventoryID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", inventoryID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_INVENTORY, paras);
            return result;
        }
        #endregion

        #region 更新一条Inventory记录 UpdateInventory()
        /// <summary>
        /// 更新一条Inventory记录
        /// </summary>
        /// <param name="inventory">Inventory对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateInventory(InventoryInfo inventoryInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Inventory_Parameters(inventoryInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_INVENTORY, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Inventory记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventory">Inventory对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateInventory(Database db, DbTransaction tran, InventoryInfo inventoryInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Inventory_Parameters(inventoryInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_INVENTORY, paras);
            }
            return result;
        }
        #endregion

        #region 根据ID判断此ID在表Inventory中是否已存在

        /// <summary>
        /// 检查InventoryID是否已存在
        /// </summary>
        /// <param name="inventoryID">InventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckInventoryIDIsExist(string inventoryID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", inventoryID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_INVENTORY_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查InventoryID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="inventoryID">inventoryID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckInventoryIDIsExist(Database db, DbTransaction tran, string inventoryID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", inventoryID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_INVENTORY_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Inventory_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Inventory">Inventory对象</param>
        /// <returns>Inventory参数数组</returns>
        private SqlParameter[] Set_Inventory_Parameters(InventoryInfo inventoryInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ID",inventoryInfo.ID),
																new SqlParameter("@ItemID",inventoryInfo.ItemID),
																new SqlParameter("@Qty",inventoryInfo.Qty),
																new SqlParameter("@OrderQty",inventoryInfo.OrderQty),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(inventoryInfo.CreatedBy)?"":inventoryInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(inventoryInfo.UpdatedBy)?"":inventoryInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
