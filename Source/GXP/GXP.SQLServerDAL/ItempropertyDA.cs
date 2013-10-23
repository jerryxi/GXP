/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItempropertyDA
// 文件功能描述：提供Itemproperty数据表进行操作的一些方法
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
    public class ItempropertyDA : IItempropertyDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Itemproperty 的所有记录
        private string SQL_SELECT_ALL_ITEMPROPERTY = "SELECT I.ItemPropertyID AS ItemPropertyID, I.PropertyName AS PropertyName, I.Descr AS Descr, I.Remark AS Remark, I.IsActive AS IsActive, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate, I.UpdatedBy AS UpdatedBy, I.UpdatedDate AS UpdatedDate FROM ItemProperty I WHERE 1=1  ";
        //INSERT_SQL 向Itemproperty增加一条记录
        private string SQL_INSERT_ITEMPROPERTY = "INSERT INTO ItemProperty ( PropertyName, Descr, Remark, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @PropertyName, @Descr, @Remark, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Itemproperty一条记录
        private string SQL_DELETE_ITEMPROPERTY = "DELETE FROM ItemProperty WHERE ITEMPROPERTYID = @ITEMPROPERTYID ";
        //UPDATE_SQL 更新Itemproperty记录
        private string SQL_UPDATE_ITEMPROPERTY = "UPDATE ItemProperty SET PropertyName = @PropertyName, Descr = @Descr, Remark = @Remark, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ITEMPROPERTYID = @ITEMPROPERTYID  ";

        //判断一个ITEMPROPERTY_ID是否已存在
        private string SQL_CHECK_ITEMPROPERTY_ID_IS_EXIST = " SELECT COUNT(1) FROM ItemProperty WHERE ITEMPROPERTYID = @ITEMPROPERTYID ";
        #endregion

        #region 基本方法

        #region 得到Itemproperty的所有记录

        /// <summary>
        /// 得到所有的Itemproperty记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemproperty记录</returns>
        public DataSet GetAllItemproperty()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ITEMPROPERTY);
        }

        /// <summary>
        /// 得到所有的Itemproperty记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemproperty记录</returns>
        public DataSet GetAllItemproperty(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ITEMPROPERTY);
        }

        #endregion

        #region 根据条件查询Itemproperty的记录  GetItempropertyByQueryList()

        /// <summary>
        /// 根据查询条件得到Itemproperty记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItempropertyQueryEntity">Itemproperty查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemproperty记录</returns>
        public DataSet GetItempropertyByQueryList(QueryEntity itempropertyQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMPROPERTY;

            if (itempropertyQuery != null && itempropertyQuery.sqlWhere != null && itempropertyQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itempropertyQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itempropertyQuery.sqlWhere[i];
                }
            }

            if (!itempropertyQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itempropertyQuery.CurrentPage, itempropertyQuery.PageSize, itempropertyQuery.SortField, itempropertyQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Itemproperty记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItempropertyQueryEntity">Itemproperty查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemproperty记录</returns>
        public DataSet GetItempropertyByQueryList(Database db, DbTransaction tran, QueryEntity itempropertyQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMPROPERTY;

            if (itempropertyQuery != null && itempropertyQuery.sqlWhere != null && itempropertyQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itempropertyQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itempropertyQuery.sqlWhere[i];
                }
            }
            if (!itempropertyQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itempropertyQuery.CurrentPage, itempropertyQuery.PageSize, itempropertyQuery.SortField, itempropertyQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Itemproperty的一条记录 GetItempropertyByID()

        /// <summary>
        /// 根据itempropertyID得到一条Itemproperty记录
        /// </summary>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itempropertyID得到一条Itemproperty记录</returns>
        public ItempropertyInfo GetItempropertyByID(string itempropertyID)
        {
            string sql = SQL_SELECT_ALL_ITEMPROPERTY + " AND ITEMPROPERTYID = @ITEMPROPERTYID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMPROPERTYID", itempropertyID) };
            ItempropertyInfo itempropertyInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    itempropertyInfo = InitItempropertyInfoByDataReader(itempropertyInfo, reader);
                }
            }

            return itempropertyInfo;
        }
        /// <summary>
        /// 根据itempropertyID得到一条Itemproperty记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itempropertyID得到一条Itemproperty记录</returns>
        public ItempropertyInfo GetItempropertyByID(Database db, DbTransaction tran, string itempropertyID)
        {
            string sql = SQL_SELECT_ALL_ITEMPROPERTY + " AND ITEMPROPERTYID = @ITEMPROPERTYID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMPROPERTYID", itempropertyID) };
            ItempropertyInfo itempropertyInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                itempropertyInfo = InitItempropertyInfoByDataReader(itempropertyInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return itempropertyInfo;
        }
        /// <summary>
        /// 初始化ItempropertyInfo
        /// </summary>
        private ItempropertyInfo InitItempropertyInfoByDataReader(ItempropertyInfo itempropertyInfo, IDataReader reader)
        {
            itempropertyInfo = new ItempropertyInfo(reader["ItemPropertyID"].ToString() != "" ? Int32.Parse(reader["ItemPropertyID"].ToString()) : 0,
reader["PropertyName"].ToString(),
reader["Descr"].ToString(),
reader["Remark"].ToString(),
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return itempropertyInfo;
        }
        #endregion

        #region 向Itemproperty增加一条记录 InsertItemproperty()

        /// <summary>
        /// 新增一条Itemproperty记录
        /// </summary>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemproperty(ItempropertyInfo itempropertyInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemproperty_Parameters(itempropertyInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ITEMPROPERTY, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Itemproperty记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemproperty(Database db, DbTransaction tran, ItempropertyInfo itempropertyInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemproperty_Parameters(itempropertyInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ITEMPROPERTY, paras);
            }
            return result;
        }
        #endregion

        #region 删除Itemproperty一条记录 DeleteItemproperty()

        /// <summary>
        /// 删除一条Itemproperty记录
        /// </summary>
        /// <param name="itempropertyID">ItempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemproperty(string itempropertyID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMPROPERTYID", itempropertyID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ITEMPROPERTY, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Itemproperty记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itempropertyID">ItempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemproperty(Database db, DbTransaction tran, string itempropertyID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMPROPERTYID", itempropertyID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ITEMPROPERTY, paras);
            return result;
        }
        #endregion

        #region 更新一条Itemproperty记录 UpdateItemproperty()
        /// <summary>
        /// 更新一条Itemproperty记录
        /// </summary>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemproperty(ItempropertyInfo itempropertyInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemproperty_Parameters(itempropertyInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ITEMPROPERTY, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Itemproperty记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemproperty(Database db, DbTransaction tran, ItempropertyInfo itempropertyInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemproperty_Parameters(itempropertyInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ITEMPROPERTY, paras);
            }
            return result;
        }
        #endregion

        #region 根据ITEMPROPERTYID判断此ID在表ItemProperty中是否已存在

        /// <summary>
        /// 检查ItempropertyID是否已存在
        /// </summary>
        /// <param name="itempropertyID">ItempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItempropertyIDIsExist(string itempropertyID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMPROPERTYID", itempropertyID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ITEMPROPERTY_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查ItempropertyID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItempropertyIDIsExist(Database db, DbTransaction tran, string itempropertyID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ITEMPROPERTYID", itempropertyID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ITEMPROPERTY_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Itemproperty_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Itemproperty">Itemproperty对象</param>
        /// <returns>Itemproperty参数数组</returns>
        private SqlParameter[] Set_Itemproperty_Parameters(ItempropertyInfo itempropertyInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ItemPropertyID",itempropertyInfo.ItemPropertyID),
																new SqlParameter("@PropertyName",string.IsNullOrEmpty(itempropertyInfo.PropertyName)?"":itempropertyInfo.PropertyName),
																new SqlParameter("@Descr",string.IsNullOrEmpty(itempropertyInfo.Descr)?"":itempropertyInfo.Descr),
																new SqlParameter("@Remark",string.IsNullOrEmpty(itempropertyInfo.Remark)?"":itempropertyInfo.Remark),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(itempropertyInfo.IsActive)?"":itempropertyInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(itempropertyInfo.CreatedBy)?"":itempropertyInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(itempropertyInfo.UpdatedBy)?"":itempropertyInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
