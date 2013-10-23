/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItemDA
// 文件功能描述：提供Item数据表进行操作的一些方法
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
    public class ItemDA : IItemDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Item 的所有记录
        private string SQL_SELECT_ALL_ITEM = "SELECT I.ItemID AS ItemID, I.SupplierID AS SupplierID, I.ItemCode AS ItemCode, I.ItemName AS ItemName, I.ItemDescription AS ItemDescription, I.ItemSynopsis AS ItemSynopsis, I.ItemCharacter AS ItemCharacter, I.ItemClassID AS ItemClassID, I.ItemBrandID AS ItemBrandID, I.GrossWgt AS GrossWgt, I.NetWgt AS NetWgt, I.Length AS Length, I.Width AS Width, I.Height AS Height, I.Cube AS Cube, I.UomID AS UomID, I.AreaID AS AreaID, I.CostPrice AS CostPrice, I.MarketPrice AS MarketPrice, I.AdvicePrice AS AdvicePrice, I.SalesPrice AS SalesPrice, I.ItemStyle AS ItemStyle, I.ItemColor AS ItemColor, I.ItemSize AS ItemSize, I.PresentPoints AS PresentPoints, I.PhotoUrl AS PhotoUrl, I.Remark AS Remark, I.IsActive AS IsActive, I.IsAudited AS IsAudited, I.BillingType AS BillingType, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate, I.UpdatedBy AS UpdatedBy, I.UpdatedDate AS UpdatedDate FROM Item I WHERE 1=1  ";
        //INSERT_SQL 向Item增加一条记录
        private string SQL_INSERT_ITEM = "INSERT INTO Item (SupplierID, ItemCode, ItemName, ItemDescription, ItemSynopsis, ItemCharacter, ItemClassID, ItemBrandID, GrossWgt, NetWgt, Length, Width, Height, Cube, UomID, AreaID, CostPrice, MarketPrice, AdvicePrice, SalesPrice, ItemStyle, ItemColor, ItemSize, PresentPoints, PhotoUrl, Remark, IsActive, IsAudited, BillingType, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @SupplierID, @ItemCode, @ItemName, @ItemDescription, @ItemSynopsis, @ItemCharacter, @ItemClassID, @ItemBrandID, @GrossWgt, @NetWgt, @Length, @Width, @Height, @Cube, @UomID, @AreaID, @CostPrice, @MarketPrice, @AdvicePrice, @SalesPrice, @ItemStyle, @ItemColor, @ItemSize, @PresentPoints, @PhotoUrl, @Remark, @IsActive, @IsAudited, @BillingType, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Item一条记录
        private string SQL_DELETE_ITEM = "DELETE FROM Item WHERE ITEMID = @ITEMID ";
        //UPDATE_SQL 更新Item记录
        private string SQL_UPDATE_ITEM = "UPDATE Item SET SupplierID = @SupplierID, ItemCode = @ItemCode, ItemName = @ItemName, ItemDescription = @ItemDescription, ItemSynopsis = @ItemSynopsis, ItemCharacter = @ItemCharacter, ItemClassID = @ItemClassID, ItemBrandID = @ItemBrandID, GrossWgt = @GrossWgt, NetWgt = @NetWgt, Length = @Length, Width = @Width, Height = @Height, Cube = @Cube, UomID = @UomID, AreaID = @AreaID, CostPrice = @CostPrice, MarketPrice = @MarketPrice, AdvicePrice = @AdvicePrice, SalesPrice = @SalesPrice, ItemStyle = @ItemStyle, ItemColor = @ItemColor, ItemSize = @ItemSize, PresentPoints = @PresentPoints, PhotoUrl = @PhotoUrl, Remark = @Remark, IsActive = @IsActive, IsAudited = @IsAudited, BillingType = @BillingType, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ITEMID = @ITEMID  ";

        //判断一个ITEM_ID是否已存在
        private string SQL_CHECK_ITEM_ID_IS_EXIST = " SELECT COUNT(1) FROM Item WHERE ITEMID = @ITEMID ";
        #endregion

        #region 基本方法

        #region 得到Item的所有记录

        /// <summary>
        /// 得到所有的Item记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Item记录</returns>
        public DataSet GetAllItem()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ITEM);
        }

        /// <summary>
        /// 得到所有的Item记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Item记录</returns>
        public DataSet GetAllItem(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ITEM);
        }

        #endregion

        #region 根据条件查询Item的记录  GetItemByQueryList()

        /// <summary>
        /// 根据查询条件得到Item记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemQueryEntity">Item查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Item记录</returns>
        public DataSet GetItemByQueryList(QueryEntity itemQuery)
        {
            string temp = SQL_SELECT_ALL_ITEM;

            if (itemQuery != null && itemQuery.sqlWhere != null && itemQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itemQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itemQuery.sqlWhere[i];
                }
            }

            if (!itemQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itemQuery.CurrentPage, itemQuery.PageSize, itemQuery.SortField, itemQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Item记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemQueryEntity">Item查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Item记录</returns>
        public DataSet GetItemByQueryList(Database db, DbTransaction tran, QueryEntity itemQuery)
        {
            string temp = SQL_SELECT_ALL_ITEM;

            if (itemQuery != null && itemQuery.sqlWhere != null && itemQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itemQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itemQuery.sqlWhere[i];
                }
            }
            if (!itemQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itemQuery.CurrentPage, itemQuery.PageSize, itemQuery.SortField, itemQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Item的一条记录 GetItemByID()

        /// <summary>
        /// 根据itemID得到一条Item记录
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemID得到一条Item记录</returns>
        public ItemInfo GetItemByID(string itemID)
        {
            string sql = SQL_SELECT_ALL_ITEM + " AND ITEMID = @ITEMID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMID", itemID) };
            ItemInfo itemInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    itemInfo = InitItemInfoByDataReader(itemInfo, reader);
                }
            }

            return itemInfo;
        }
        /// <summary>
        /// 根据itemID得到一条Item记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemID">itemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemID得到一条Item记录</returns>
        public ItemInfo GetItemByID(Database db, DbTransaction tran, string itemID)
        {
            string sql = SQL_SELECT_ALL_ITEM + " AND ITEMID = @ITEMID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMID", itemID) };
            ItemInfo itemInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                itemInfo = InitItemInfoByDataReader(itemInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return itemInfo;
        }
        /// <summary>
        /// 初始化ItemInfo
        /// </summary>
        private ItemInfo InitItemInfoByDataReader(ItemInfo itemInfo, IDataReader reader)
        {
            itemInfo = new ItemInfo(reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["SupplierID"].ToString() != "" ? Int32.Parse(reader["SupplierID"].ToString()) : 0,
reader["ItemCode"].ToString(),
reader["ItemName"].ToString(),
reader["ItemDescription"].ToString(),
reader["ItemSynopsis"].ToString(),
reader["ItemCharacter"].ToString(),
reader["ItemClassID"].ToString(),
reader["ItemBrandID"].ToString(),
reader["GrossWgt"].ToString() != "" ? Decimal.Parse(reader["GrossWgt"].ToString()) : 0,
reader["NetWgt"].ToString() != "" ? Decimal.Parse(reader["NetWgt"].ToString()) : 0,
reader["Length"].ToString() != "" ? Decimal.Parse(reader["Length"].ToString()) : 0,
reader["Width"].ToString() != "" ? Decimal.Parse(reader["Width"].ToString()) : 0,
reader["Height"].ToString() != "" ? Decimal.Parse(reader["Height"].ToString()) : 0,
reader["Cube"].ToString() != "" ? Decimal.Parse(reader["Cube"].ToString()) : 0,
reader["UomID"].ToString(),
reader["AreaID"].ToString(),
reader["CostPrice"].ToString() != "" ? Decimal.Parse(reader["CostPrice"].ToString()) : 0,
reader["MarketPrice"].ToString() != "" ? Decimal.Parse(reader["MarketPrice"].ToString()) : 0,
reader["AdvicePrice"].ToString() != "" ? Decimal.Parse(reader["AdvicePrice"].ToString()) : 0,
reader["SalesPrice"].ToString() != "" ? Decimal.Parse(reader["SalesPrice"].ToString()) : 0,
reader["ItemStyle"].ToString(),
reader["ItemColor"].ToString(),
reader["ItemSize"].ToString(),
reader["PresentPoints"].ToString() != "" ? Int32.Parse(reader["PresentPoints"].ToString()) : 0,
reader["PhotoUrl"].ToString(),
reader["Remark"].ToString(),
reader["IsActive"].ToString(),
reader["IsAudited"].ToString(),
reader["BillingType"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return itemInfo;
        }
        #endregion

        #region 向Item增加一条记录 InsertItem()

        /// <summary>
        /// 新增一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItem(ItemInfo itemInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Item_Parameters(itemInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ITEM, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Item记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="item">Item对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItem(Database db, DbTransaction tran, ItemInfo itemInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Item_Parameters(itemInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ITEM, paras);
            }
            return result;
        }
        #endregion

        #region 删除Item一条记录 DeleteItem()

        /// <summary>
        /// 删除一条Item记录
        /// </summary>
        /// <param name="itemID">ItemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItem(string itemID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMID", itemID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ITEM, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Item记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemID">ItemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItem(Database db, DbTransaction tran, string itemID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMID", itemID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ITEM, paras);
            return result;
        }
        #endregion

        #region 更新一条Item记录 UpdateItem()
        /// <summary>
        /// 更新一条Item记录
        /// </summary>
        /// <param name="item">Item对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItem(ItemInfo itemInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Item_Parameters(itemInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ITEM, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Item记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="item">Item对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItem(Database db, DbTransaction tran, ItemInfo itemInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Item_Parameters(itemInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ITEM, paras);
            }
            return result;
        }
        #endregion

        #region 根据ITEMID判断此ID在表Item中是否已存在

        /// <summary>
        /// 检查ItemID是否已存在
        /// </summary>
        /// <param name="itemID">ItemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemIDIsExist(string itemID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMID", itemID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ITEM_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查ItemID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemID">itemID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemIDIsExist(Database db, DbTransaction tran, string itemID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMID", itemID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ITEM_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Item_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Item">Item对象</param>
        /// <returns>Item参数数组</returns>
        private SqlParameter[] Set_Item_Parameters(ItemInfo itemInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ItemID",itemInfo.ItemID),
																new SqlParameter("@SupplierID",itemInfo.SupplierID),
																new SqlParameter("@ItemCode",itemInfo.ItemCode),
																new SqlParameter("@ItemName",itemInfo.ItemName),
																new SqlParameter("@ItemDescription",string.IsNullOrEmpty(itemInfo.ItemDescription)?"":itemInfo.ItemDescription),
																new SqlParameter("@ItemSynopsis",string.IsNullOrEmpty(itemInfo.ItemSynopsis)?"":itemInfo.ItemSynopsis),
																new SqlParameter("@ItemCharacter",string.IsNullOrEmpty(itemInfo.ItemCharacter)?"":itemInfo.ItemCharacter),
																new SqlParameter("@ItemClassID",string.IsNullOrEmpty(itemInfo.ItemClassID)?"":itemInfo.ItemClassID),
																new SqlParameter("@ItemBrandID",string.IsNullOrEmpty(itemInfo.ItemBrandID)?"":itemInfo.ItemBrandID),
																new SqlParameter("@GrossWgt",itemInfo.GrossWgt),
																new SqlParameter("@NetWgt",itemInfo.NetWgt),
																new SqlParameter("@Length",itemInfo.Length),
																new SqlParameter("@Width",itemInfo.Width),
																new SqlParameter("@Height",itemInfo.Height),
																new SqlParameter("@Cube",itemInfo.Cube),
																new SqlParameter("@UomID",string.IsNullOrEmpty(itemInfo.UomID)?"":itemInfo.UomID),
																new SqlParameter("@AreaID",string.IsNullOrEmpty(itemInfo.AreaID)?"":itemInfo.AreaID),
																new SqlParameter("@CostPrice",itemInfo.CostPrice),
																new SqlParameter("@MarketPrice",itemInfo.MarketPrice),
																new SqlParameter("@AdvicePrice",itemInfo.AdvicePrice),
																new SqlParameter("@SalesPrice",itemInfo.SalesPrice),
																new SqlParameter("@ItemStyle",string.IsNullOrEmpty(itemInfo.ItemStyle)?"":itemInfo.ItemStyle),
																new SqlParameter("@ItemColor",string.IsNullOrEmpty(itemInfo.ItemColor)?"":itemInfo.ItemColor),
																new SqlParameter("@ItemSize",string.IsNullOrEmpty(itemInfo.ItemSize)?"":itemInfo.ItemSize),
																new SqlParameter("@PresentPoints",itemInfo.PresentPoints),
																new SqlParameter("@PhotoUrl",string.IsNullOrEmpty(itemInfo.PhotoUrl)?"":itemInfo.PhotoUrl),
																new SqlParameter("@Remark",string.IsNullOrEmpty(itemInfo.Remark)?"":itemInfo.Remark),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(itemInfo.IsActive)?"":itemInfo.IsActive),
																new SqlParameter("@IsAudited",string.IsNullOrEmpty(itemInfo.IsAudited)?"":itemInfo.IsAudited),
																new SqlParameter("@BillingType",string.IsNullOrEmpty(itemInfo.BillingType)?"":itemInfo.BillingType),
																new SqlParameter("@CreatedBy",itemInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",itemInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
