/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItemfeedbackDA
// 文件功能描述：提供Itemfeedback数据表进行操作的一些方法
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
    public class ItemfeedbackDA : IItemfeedbackDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Itemfeedback 的所有记录
        private string SQL_SELECT_ALL_ITEMFEEDBACK = "SELECT I.ID AS ID, I.SupplierID AS SupplierID, I.ItemID AS ItemID, I.Title AS Title, I.Content AS Content, I.Reply AS Reply, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate, I.ReplyBy AS ReplyBy, I.ReplyDate AS ReplyDate FROM ItemFeedback I WHERE 1=1  ";
        //INSERT_SQL 向Itemfeedback增加一条记录
        private string SQL_INSERT_ITEMFEEDBACK = "INSERT INTO ItemFeedback ( SupplierID, ItemID, Title, Content, Reply, CreatedBy, CreatedDate, ReplyBy, ReplyDate) VALUES ( @SupplierID, @ItemID, @Title, @Content, @Reply, @CreatedBy, GETDATE(), @ReplyBy, @ReplyDate)  ";
        //DELETE_SQL  删除Itemfeedback一条记录
        private string SQL_DELETE_ITEMFEEDBACK = "DELETE FROM ItemFeedback WHERE ID = @ID ";
        //UPDATE_SQL 更新Itemfeedback记录
        private string SQL_UPDATE_ITEMFEEDBACK = "UPDATE ItemFeedback SET SupplierID = @SupplierID, ItemID = @ItemID, Title = @Title, Content = @Content, Reply = @Reply, ReplyBy = @ReplyBy, ReplyDate = @ReplyDate WHERE ID = @ID  ";

        //判断一个ITEMFEEDBACK_ID是否已存在
        private string SQL_CHECK_ITEMFEEDBACK_ID_IS_EXIST = " SELECT COUNT(1) FROM ItemFeedback WHERE ID = @ID ";
        #endregion

        #region 基本方法

        #region 得到Itemfeedback的所有记录

        /// <summary>
        /// 得到所有的Itemfeedback记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemfeedback记录</returns>
        public DataSet GetAllItemfeedback()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ITEMFEEDBACK);
        }

        /// <summary>
        /// 得到所有的Itemfeedback记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemfeedback记录</returns>
        public DataSet GetAllItemfeedback(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ITEMFEEDBACK);
        }

        #endregion

        #region 根据条件查询Itemfeedback的记录  GetItemfeedbackByQueryList()

        /// <summary>
        /// 根据查询条件得到Itemfeedback记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemfeedbackQueryEntity">Itemfeedback查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemfeedback记录</returns>
        public DataSet GetItemfeedbackByQueryList(QueryEntity itemfeedbackQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMFEEDBACK;

            if (itemfeedbackQuery != null && itemfeedbackQuery.sqlWhere != null && itemfeedbackQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itemfeedbackQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itemfeedbackQuery.sqlWhere[i];
                }
            }

            if (!itemfeedbackQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itemfeedbackQuery.CurrentPage, itemfeedbackQuery.PageSize, itemfeedbackQuery.SortField, itemfeedbackQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Itemfeedback记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemfeedbackQueryEntity">Itemfeedback查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemfeedback记录</returns>
        public DataSet GetItemfeedbackByQueryList(Database db, DbTransaction tran, QueryEntity itemfeedbackQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMFEEDBACK;

            if (itemfeedbackQuery != null && itemfeedbackQuery.sqlWhere != null && itemfeedbackQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itemfeedbackQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itemfeedbackQuery.sqlWhere[i];
                }
            }
            if (!itemfeedbackQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itemfeedbackQuery.CurrentPage, itemfeedbackQuery.PageSize, itemfeedbackQuery.SortField, itemfeedbackQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Itemfeedback的一条记录 GetItemfeedbackByID()

        /// <summary>
        /// 根据itemfeedbackID得到一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemfeedbackID得到一条Itemfeedback记录</returns>
        public ItemfeedbackInfo GetItemfeedbackByID(string itemfeedbackID)
        {
            string sql = SQL_SELECT_ALL_ITEMFEEDBACK + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", itemfeedbackID) };
            ItemfeedbackInfo itemfeedbackInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    itemfeedbackInfo = InitItemfeedbackInfoByDataReader(itemfeedbackInfo, reader);
                }
            }

            return itemfeedbackInfo;
        }
        /// <summary>
        /// 根据itemfeedbackID得到一条Itemfeedback记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemfeedbackID得到一条Itemfeedback记录</returns>
        public ItemfeedbackInfo GetItemfeedbackByID(Database db, DbTransaction tran, string itemfeedbackID)
        {
            string sql = SQL_SELECT_ALL_ITEMFEEDBACK + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", itemfeedbackID) };
            ItemfeedbackInfo itemfeedbackInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                itemfeedbackInfo = InitItemfeedbackInfoByDataReader(itemfeedbackInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return itemfeedbackInfo;
        }
        /// <summary>
        /// 初始化ItemfeedbackInfo
        /// </summary>
        private ItemfeedbackInfo InitItemfeedbackInfoByDataReader(ItemfeedbackInfo itemfeedbackInfo, IDataReader reader)
        {
            itemfeedbackInfo = new ItemfeedbackInfo(reader["ID"].ToString() != "" ? Int32.Parse(reader["ID"].ToString()) : 0,
reader["SupplierID"].ToString(),
reader["ItemID"].ToString(),
reader["Title"].ToString(),
reader["Content"].ToString(),
reader["Reply"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["ReplyBy"].ToString(),
reader["ReplyDate"].ToString() != "" ? DateTime.Parse(reader["ReplyDate"].ToString()) : new DateTime());
            return itemfeedbackInfo;
        }
        #endregion

        #region 向Itemfeedback增加一条记录 InsertItemfeedback()

        /// <summary>
        /// 新增一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemfeedback(ItemfeedbackInfo itemfeedbackInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemfeedback_Parameters(itemfeedbackInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ITEMFEEDBACK, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Itemfeedback记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemfeedback(Database db, DbTransaction tran, ItemfeedbackInfo itemfeedbackInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemfeedback_Parameters(itemfeedbackInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ITEMFEEDBACK, paras);
            }
            return result;
        }
        #endregion

        #region 删除Itemfeedback一条记录 DeleteItemfeedback()

        /// <summary>
        /// 删除一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedbackID">ItemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemfeedback(string itemfeedbackID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", itemfeedbackID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ITEMFEEDBACK, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Itemfeedback记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemfeedbackID">ItemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemfeedback(Database db, DbTransaction tran, string itemfeedbackID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", itemfeedbackID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ITEMFEEDBACK, paras);
            return result;
        }
        #endregion

        #region 更新一条Itemfeedback记录 UpdateItemfeedback()
        /// <summary>
        /// 更新一条Itemfeedback记录
        /// </summary>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemfeedback(ItemfeedbackInfo itemfeedbackInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemfeedback_Parameters(itemfeedbackInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ITEMFEEDBACK, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Itemfeedback记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemfeedback">Itemfeedback对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemfeedback(Database db, DbTransaction tran, ItemfeedbackInfo itemfeedbackInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemfeedback_Parameters(itemfeedbackInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ITEMFEEDBACK, paras);
            }
            return result;
        }
        #endregion

        #region 根据ID判断此ID在表ItemFeedback中是否已存在

        /// <summary>
        /// 检查ItemfeedbackID是否已存在
        /// </summary>
        /// <param name="itemfeedbackID">ItemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemfeedbackIDIsExist(string itemfeedbackID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", itemfeedbackID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ITEMFEEDBACK_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查ItemfeedbackID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemfeedbackID">itemfeedbackID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemfeedbackIDIsExist(Database db, DbTransaction tran, string itemfeedbackID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", itemfeedbackID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ITEMFEEDBACK_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Itemfeedback_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Itemfeedback">Itemfeedback对象</param>
        /// <returns>Itemfeedback参数数组</returns>
        private SqlParameter[] Set_Itemfeedback_Parameters(ItemfeedbackInfo itemfeedbackInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ID",itemfeedbackInfo.ID),
																new SqlParameter("@SupplierID",itemfeedbackInfo.SupplierID),
																new SqlParameter("@ItemID",itemfeedbackInfo.ItemID),
																new SqlParameter("@Title",itemfeedbackInfo.Title),
																new SqlParameter("@Content",string.IsNullOrEmpty(itemfeedbackInfo.Content)?"":itemfeedbackInfo.Content),
																new SqlParameter("@Reply",string.IsNullOrEmpty(itemfeedbackInfo.Reply)?"":itemfeedbackInfo.Reply),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(itemfeedbackInfo.CreatedBy)?"":itemfeedbackInfo.CreatedBy),
																new SqlParameter("@ReplyBy",string.IsNullOrEmpty(itemfeedbackInfo.ReplyBy)?"":itemfeedbackInfo.ReplyBy),
																new SqlParameter("@ReplyDate",itemfeedbackInfo.ReplyDate)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
