/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItembrandDA
// 文件功能描述：提供Itembrand数据表进行操作的一些方法
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
    public class ItembrandDA : IItembrandDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Itembrand 的所有记录
        private string SQL_SELECT_ALL_ITEMBRAND = "SELECT I.BrandID AS BrandID, I.BrandName AS BrandName, I.IsActive AS IsActive, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate, I.UpdatedBy AS UpdatedBy, I.UpdatedDate AS UpdatedDate FROM ItemBrand I WHERE 1=1  ";
        //INSERT_SQL 向Itembrand增加一条记录
        private string SQL_INSERT_ITEMBRAND = "INSERT INTO ItemBrand (  BrandName, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES (  @BrandName, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Itembrand一条记录
        private string SQL_DELETE_ITEMBRAND = "DELETE FROM ItemBrand WHERE BRANDID = @BRANDID ";
        //UPDATE_SQL 更新Itembrand记录
        private string SQL_UPDATE_ITEMBRAND = "UPDATE ItemBrand SET BrandName = @BrandName, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE BRANDID = @BRANDID  ";

        //判断一个ITEMBRAND_ID是否已存在
        private string SQL_CHECK_ITEMBRAND_ID_IS_EXIST = " SELECT COUNT(1) FROM ItemBrand WHERE BRANDID = @BRANDID ";
        #endregion

        #region 基本方法

        #region 得到Itembrand的所有记录

        /// <summary>
        /// 得到所有的Itembrand记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itembrand记录</returns>
        public DataSet GetAllItembrand()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_ITEMBRAND);
        }

        /// <summary>
        /// 得到所有的Itembrand记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itembrand记录</returns>
        public DataSet GetAllItembrand(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_ITEMBRAND);
        }

        #endregion

        #region 根据条件查询Itembrand的记录  GetItembrandByQueryList()

        /// <summary>
        /// 根据查询条件得到Itembrand记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItembrandQueryEntity">Itembrand查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itembrand记录</returns>
        public DataSet GetItembrandByQueryList(QueryEntity itembrandQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMBRAND;

            if (itembrandQuery != null && itembrandQuery.sqlWhere != null && itembrandQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itembrandQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itembrandQuery.sqlWhere[i];
                }
            }

            if (!itembrandQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itembrandQuery.CurrentPage, itembrandQuery.PageSize, itembrandQuery.SortField, itembrandQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Itembrand记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItembrandQueryEntity">Itembrand查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itembrand记录</returns>
        public DataSet GetItembrandByQueryList(Database db, DbTransaction tran, QueryEntity itembrandQuery)
        {
            string temp = SQL_SELECT_ALL_ITEMBRAND;

            if (itembrandQuery != null && itembrandQuery.sqlWhere != null && itembrandQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < itembrandQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + itembrandQuery.sqlWhere[i];
                }
            }
            if (!itembrandQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, itembrandQuery.CurrentPage, itembrandQuery.PageSize, itembrandQuery.SortField, itembrandQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Itembrand的一条记录 GetItembrandByID()

        /// <summary>
        /// 根据itembrandID得到一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itembrandID得到一条Itembrand记录</returns>
        public ItembrandInfo GetItembrandByID(string itembrandID)
        {
            string sql = SQL_SELECT_ALL_ITEMBRAND + " AND BRANDID = @BRANDID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BRANDID", itembrandID) };
            ItembrandInfo itembrandInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    itembrandInfo = InitItembrandInfoByDataReader(itembrandInfo, reader);
                }
            }

            return itembrandInfo;
        }
        /// <summary>
        /// 根据itembrandID得到一条Itembrand记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrandID">itembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itembrandID得到一条Itembrand记录</returns>
        public ItembrandInfo GetItembrandByID(Database db, DbTransaction tran, string itembrandID)
        {
            string sql = SQL_SELECT_ALL_ITEMBRAND + " AND BRANDID = @BRANDID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BRANDID", itembrandID) };
            ItembrandInfo itembrandInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                itembrandInfo = InitItembrandInfoByDataReader(itembrandInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return itembrandInfo;
        }
        /// <summary>
        /// 初始化ItembrandInfo
        /// </summary>
        private ItembrandInfo InitItembrandInfoByDataReader(ItembrandInfo itembrandInfo, IDataReader reader)
        {
            itembrandInfo = new ItembrandInfo(reader["BrandID"].ToString() != "" ? Int32.Parse(reader["BrandID"].ToString()) : 0,
reader["BrandName"].ToString(),
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return itembrandInfo;
        }
        #endregion

        #region 向Itembrand增加一条记录 InsertItembrand()

        /// <summary>
        /// 新增一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItembrand(ItembrandInfo itembrandInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itembrand_Parameters(itembrandInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_ITEMBRAND, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Itembrand记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrand">Itembrand对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItembrand(Database db, DbTransaction tran, ItembrandInfo itembrandInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itembrand_Parameters(itembrandInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_ITEMBRAND, paras);
            }
            return result;
        }
        #endregion

        #region 删除Itembrand一条记录 DeleteItembrand()

        /// <summary>
        /// 删除一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">ItembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItembrand(string itembrandID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BRANDID", itembrandID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_ITEMBRAND, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Itembrand记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrandID">ItembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItembrand(Database db, DbTransaction tran, string itembrandID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BRANDID", itembrandID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_ITEMBRAND, paras);
            return result;
        }
        #endregion

        #region 更新一条Itembrand记录 UpdateItembrand()
        /// <summary>
        /// 更新一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItembrand(ItembrandInfo itembrandInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itembrand_Parameters(itembrandInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_ITEMBRAND, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Itembrand记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrand">Itembrand对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItembrand(Database db, DbTransaction tran, ItembrandInfo itembrandInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Itembrand_Parameters(itembrandInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_ITEMBRAND, paras);
            }
            return result;
        }
        #endregion

        #region 根据BRANDID判断此ID在表ItemBrand中是否已存在

        /// <summary>
        /// 检查ItembrandID是否已存在
        /// </summary>
        /// <param name="itembrandID">ItembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItembrandIDIsExist(string itembrandID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BRANDID", itembrandID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_ITEMBRAND_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查ItembrandID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrandID">itembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItembrandIDIsExist(Database db, DbTransaction tran, string itembrandID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BRANDID", itembrandID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_ITEMBRAND_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Itembrand_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Itembrand">Itembrand对象</param>
        /// <returns>Itembrand参数数组</returns>
        private SqlParameter[] Set_Itembrand_Parameters(ItembrandInfo itembrandInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@BrandID",itembrandInfo.BrandID),
																new SqlParameter("@BrandName",itembrandInfo.BrandName),
																new SqlParameter("@IsActive",itembrandInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(itembrandInfo.CreatedBy)?"":itembrandInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(itembrandInfo.UpdatedBy)?"":itembrandInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
