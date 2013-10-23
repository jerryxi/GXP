/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItemclassDA
// 文件功能描述：提供Itemclass数据表进行操作的一些方法
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
    public class ItemclassDA : IItemclassDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Itemclass 的所有记录
        private string SQL_SELECT_ALL_ITEMCLASS = "SELECT I.ClassID AS ClassID, I.ClassName AS ClassName, I.IsActive AS IsActive, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate, I.UpdatedBy AS UpdatedBy, I.UpdatedDate AS UpdatedDate FROM ItemClass I WHERE 1=1  ";
        //INSERT_SQL 向Itemclass增加一条记录
        private string SQL_INSERT_ITEMCLASS = "INSERT INTO ItemClass ( ClassName, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @ClassName, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Itemclass一条记录
        private string SQL_DELETE_ITEMCLASS = "DELETE FROM ItemClass WHERE CLASSID = @CLASSID ";
        //UPDATE_SQL 更新Itemclass记录
        private string SQL_UPDATE_ITEMCLASS = "UPDATE ItemClass SET ClassName = @ClassName, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE CLASSID = @CLASSID  ";

        //判断一个ITEMCLASS_ID是否已存在
        private string SQL_CHECK_ITEMCLASS_ID_IS_EXIST = " SELECT COUNT(1) FROM ItemClass WHERE CLASSID = @CLASSID ";
        #endregion

        #region 基本方法

        #region 得到Itemclass的所有记录

        /// <summary>
        /// 得到所有的Itemclass记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemclass记录</returns>
        public DataSet GetAllItemclass()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ITEMCLASS);
        }

        /// <summary>
        /// 得到所有的Itemclass记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itemclass记录</returns>
        public DataSet GetAllItemclass(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ITEMCLASS);
        }

        #endregion

        #region 根据条件查询Itemclass的记录  GetItemclassByQueryList()

        /// <summary>
        /// 根据查询条件得到Itemclass记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemclassQueryEntity">Itemclass查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemclass记录</returns>
        public DataSet GetItemclassByQueryList(QueryEntity itemclassQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMCLASS;

            if (itemclassQuery != null && itemclassQuery.sqlWhere != null && itemclassQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itemclassQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itemclassQuery.sqlWhere[i];
                }
            }

            if (!itemclassQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itemclassQuery.CurrentPage, itemclassQuery.PageSize, itemclassQuery.SortField, itemclassQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Itemclass记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItemclassQueryEntity">Itemclass查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itemclass记录</returns>
        public DataSet GetItemclassByQueryList(Database db, DbTransaction tran, QueryEntity itemclassQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMCLASS;

            if (itemclassQuery != null && itemclassQuery.sqlWhere != null && itemclassQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itemclassQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itemclassQuery.sqlWhere[i];
                }
            }
            if (!itemclassQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itemclassQuery.CurrentPage, itemclassQuery.PageSize, itemclassQuery.SortField, itemclassQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Itemclass的一条记录 GetItemclassByID()

        /// <summary>
        /// 根据itemclassID得到一条Itemclass记录
        /// </summary>
        /// <param name="itemclassID">itemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemclassID得到一条Itemclass记录</returns>
        public ItemclassInfo GetItemclassByID(string itemclassID)
        {
            string sql = SQL_SELECT_ALL_ITEMCLASS + " AND CLASSID = @CLASSID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CLASSID", itemclassID) };
            ItemclassInfo itemclassInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    itemclassInfo = InitItemclassInfoByDataReader(itemclassInfo, reader);
                }
            }

            return itemclassInfo;
        }
        /// <summary>
        /// 根据itemclassID得到一条Itemclass记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemclassID">itemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itemclassID得到一条Itemclass记录</returns>
        public ItemclassInfo GetItemclassByID(Database db, DbTransaction tran, string itemclassID)
        {
            string sql = SQL_SELECT_ALL_ITEMCLASS + " AND CLASSID = @CLASSID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CLASSID", itemclassID) };
            ItemclassInfo itemclassInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                itemclassInfo = InitItemclassInfoByDataReader(itemclassInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return itemclassInfo;
        }
        /// <summary>
        /// 初始化ItemclassInfo
        /// </summary>
        private ItemclassInfo InitItemclassInfoByDataReader(ItemclassInfo itemclassInfo, IDataReader reader)
        {
            itemclassInfo = new ItemclassInfo(reader["ClassID"].ToString() != "" ? Int32.Parse(reader["ClassID"].ToString()) : 0,
reader["ClassName"].ToString(),
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return itemclassInfo;
        }
        #endregion

        #region 向Itemclass增加一条记录 InsertItemclass()

        /// <summary>
        /// 新增一条Itemclass记录
        /// </summary>
        /// <param name="itemclass">Itemclass对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemclass(ItemclassInfo itemclassInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemclass_Parameters(itemclassInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ITEMCLASS, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Itemclass记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemclass">Itemclass对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItemclass(Database db, DbTransaction tran, ItemclassInfo itemclassInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemclass_Parameters(itemclassInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ITEMCLASS, paras);
            }
            return result;
        }
        #endregion

        #region 删除Itemclass一条记录 DeleteItemclass()

        /// <summary>
        /// 删除一条Itemclass记录
        /// </summary>
        /// <param name="itemclassID">ItemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemclass(string itemclassID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CLASSID", itemclassID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ITEMCLASS, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Itemclass记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemclassID">ItemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItemclass(Database db, DbTransaction tran, string itemclassID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CLASSID", itemclassID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ITEMCLASS, paras);
            return result;
        }
        #endregion

        #region 更新一条Itemclass记录 UpdateItemclass()
        /// <summary>
        /// 更新一条Itemclass记录
        /// </summary>
        /// <param name="itemclass">Itemclass对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemclass(ItemclassInfo itemclassInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemclass_Parameters(itemclassInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ITEMCLASS, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Itemclass记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemclass">Itemclass对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItemclass(Database db, DbTransaction tran, ItemclassInfo itemclassInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itemclass_Parameters(itemclassInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ITEMCLASS, paras);
            }
            return result;
        }
        #endregion

        #region 根据CLASSID判断此ID在表ItemClass中是否已存在

        /// <summary>
        /// 检查ItemclassID是否已存在
        /// </summary>
        /// <param name="itemclassID">ItemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemclassIDIsExist(string itemclassID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CLASSID", itemclassID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ITEMCLASS_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查ItemclassID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemclassID">itemclassID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItemclassIDIsExist(Database db, DbTransaction tran, string itemclassID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CLASSID", itemclassID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ITEMCLASS_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Itemclass_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Itemclass">Itemclass对象</param>
        /// <returns>Itemclass参数数组</returns>
        private SqlParameter[] Set_Itemclass_Parameters(ItemclassInfo itemclassInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ClassID",itemclassInfo.ClassID),
																new SqlParameter("@ClassName",itemclassInfo.ClassName),
																new SqlParameter("@IsActive",itemclassInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(itemclassInfo.CreatedBy)?"":itemclassInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(itemclassInfo.UpdatedBy)?"":itemclassInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
