/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SalesorderdetailDA
// 文件功能描述：提供Salesorderdetail数据表进行操作的一些方法
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
    public class SalesorderdetailDA : ISalesorderdetailDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Salesorderdetail 的所有记录
        private string SQL_SELECT_ALL_SALESORDERDETAIL = "SELECT S.DetailID AS DetailID, S.SoID AS SoID, S.ItemID AS ItemID, S.Qty AS Qty, S.Price AS Price, S.TotalAmount AS TotalAmount, S.Remark AS Remark, S.Ts AS Ts, S.CreatedBy AS CreatedBy, S.CreatedDate AS CreatedDate, S.UpdatedBy AS UpdatedBy, S.UpdatedDate AS UpdatedDate FROM SalesOrderDetail S WHERE 1=1  ";
        //INSERT_SQL 向Salesorderdetail增加一条记录
        private string SQL_INSERT_SALESORDERDETAIL = "INSERT INTO SalesOrderDetail ( DetailID, SoID, ItemID, Qty, Price, TotalAmount, Remark, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @DetailID, @SoID, @ItemID, @Qty, @Price, @TotalAmount, @Remark, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Salesorderdetail一条记录
        private string SQL_DELETE_SALESORDERDETAIL = "DELETE FROM SalesOrderDetail WHERE DETAILID = @DETAILID ";
        //UPDATE_SQL 更新Salesorderdetail记录
        private string SQL_UPDATE_SALESORDERDETAIL = "UPDATE SalesOrderDetail SET SoID = @SoID, ItemID = @ItemID, Qty = @Qty, Price = @Price, TotalAmount = @TotalAmount, Remark = @Remark, Ts = @Ts, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE DETAILID = @DETAILID  ";

        //判断一个SALESORDERDETAIL_ID是否已存在
        private string SQL_CHECK_SALESORDERDETAIL_ID_IS_EXIST = " SELECT COUNT(1) FROM SalesOrderDetail WHERE DETAILID = @DETAILID ";
        #endregion

        #region 基本方法

        #region 得到Salesorderdetail的所有记录

        /// <summary>
        /// 得到所有的Salesorderdetail记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Salesorderdetail记录</returns>
        public DataSet GetAllSalesorderdetail()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_SALESORDERDETAIL);
        }

        /// <summary>
        /// 得到所有的Salesorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Salesorderdetail记录</returns>
        public DataSet GetAllSalesorderdetail(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_SALESORDERDETAIL);
        }

        #endregion

        #region 根据条件查询Salesorderdetail的记录  GetSalesorderdetailByQueryList()

        /// <summary>
        /// 根据查询条件得到Salesorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderdetailQueryEntity">Salesorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Salesorderdetail记录</returns>
        public DataSet GetSalesorderdetailByQueryList(QueryEntity salesorderdetailQuery)
        {
            string temp = SQL_SELECT_ALL_SALESORDERDETAIL;

            if (salesorderdetailQuery != null && salesorderdetailQuery.sqlWhere != null && salesorderdetailQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < salesorderdetailQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + salesorderdetailQuery.sqlWhere[i];
                }
            }

            if (!salesorderdetailQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, salesorderdetailQuery.CurrentPage, salesorderdetailQuery.PageSize, salesorderdetailQuery.SortField, salesorderdetailQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Salesorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderdetailQueryEntity">Salesorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Salesorderdetail记录</returns>
        public DataSet GetSalesorderdetailByQueryList(Database db, DbTransaction tran, QueryEntity salesorderdetailQuery)
        {
            string temp = SQL_SELECT_ALL_SALESORDERDETAIL;

            if (salesorderdetailQuery != null && salesorderdetailQuery.sqlWhere != null && salesorderdetailQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < salesorderdetailQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + salesorderdetailQuery.sqlWhere[i];
                }
            }
            if (!salesorderdetailQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, salesorderdetailQuery.CurrentPage, salesorderdetailQuery.PageSize, salesorderdetailQuery.SortField, salesorderdetailQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Salesorderdetail的一条记录 GetSalesorderdetailByID()

        /// <summary>
        /// 根据salesorderdetailID得到一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetailID">salesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据salesorderdetailID得到一条Salesorderdetail记录</returns>
        public SalesorderdetailInfo GetSalesorderdetailByID(string salesorderdetailID)
        {
            string sql = SQL_SELECT_ALL_SALESORDERDETAIL + " AND DETAILID = @DETAILID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", salesorderdetailID) };
            SalesorderdetailInfo salesorderdetailInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    salesorderdetailInfo = InitSalesorderdetailInfoByDataReader(salesorderdetailInfo, reader);
                }
            }

            return salesorderdetailInfo;
        }
        /// <summary>
        /// 根据salesorderdetailID得到一条Salesorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderdetailID">salesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据salesorderdetailID得到一条Salesorderdetail记录</returns>
        public SalesorderdetailInfo GetSalesorderdetailByID(Database db, DbTransaction tran, string salesorderdetailID)
        {
            string sql = SQL_SELECT_ALL_SALESORDERDETAIL + " AND DETAILID = @DETAILID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", salesorderdetailID) };
            SalesorderdetailInfo salesorderdetailInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                salesorderdetailInfo = InitSalesorderdetailInfoByDataReader(salesorderdetailInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return salesorderdetailInfo;
        }
        /// <summary>
        /// 初始化SalesorderdetailInfo
        /// </summary>
        private SalesorderdetailInfo InitSalesorderdetailInfoByDataReader(SalesorderdetailInfo salesorderdetailInfo, IDataReader reader)
        {
            salesorderdetailInfo = new SalesorderdetailInfo(reader["DetailID"].ToString() != "" ? Int32.Parse(reader["DetailID"].ToString()) : 0,
reader["SoID"].ToString() != "" ? Int32.Parse(reader["SoID"].ToString()) : 0,
reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["Qty"].ToString() != "" ? Int32.Parse(reader["Qty"].ToString()) : 0,
reader["Price"].ToString() != "" ? Decimal.Parse(reader["Price"].ToString()) : 0,
reader["TotalAmount"].ToString() != "" ? Decimal.Parse(reader["TotalAmount"].ToString()) : 0,
reader["Remark"].ToString(),
reader["Ts"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return salesorderdetailInfo;
        }
        #endregion

        #region 向Salesorderdetail增加一条记录 InsertSalesorderdetail()

        /// <summary>
        /// 新增一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetail">Salesorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSalesorderdetail(SalesorderdetailInfo salesorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorderdetail_Parameters(salesorderdetailInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_SALESORDERDETAIL, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Salesorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderdetail">Salesorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSalesorderdetail(Database db, DbTransaction tran, SalesorderdetailInfo salesorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorderdetail_Parameters(salesorderdetailInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_SALESORDERDETAIL, paras);
            }
            return result;
        }
        #endregion

        #region 删除Salesorderdetail一条记录 DeleteSalesorderdetail()

        /// <summary>
        /// 删除一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetailID">SalesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSalesorderdetail(string salesorderdetailID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", salesorderdetailID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_SALESORDERDETAIL, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Salesorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderdetailID">SalesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSalesorderdetail(Database db, DbTransaction tran, string salesorderdetailID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", salesorderdetailID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_SALESORDERDETAIL, paras);
            return result;
        }
        #endregion

        #region 更新一条Salesorderdetail记录 UpdateSalesorderdetail()
        /// <summary>
        /// 更新一条Salesorderdetail记录
        /// </summary>
        /// <param name="salesorderdetail">Salesorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSalesorderdetail(SalesorderdetailInfo salesorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorderdetail_Parameters(salesorderdetailInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_SALESORDERDETAIL, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Salesorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderdetail">Salesorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSalesorderdetail(Database db, DbTransaction tran, SalesorderdetailInfo salesorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorderdetail_Parameters(salesorderdetailInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_SALESORDERDETAIL, paras);
            }
            return result;
        }
        #endregion

        #region 根据DETAILID判断此ID在表SalesOrderDetail中是否已存在

        /// <summary>
        /// 检查SalesorderdetailID是否已存在
        /// </summary>
        /// <param name="salesorderdetailID">SalesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSalesorderdetailIDIsExist(string salesorderdetailID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", salesorderdetailID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_SALESORDERDETAIL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查SalesorderdetailID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderdetailID">salesorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSalesorderdetailIDIsExist(Database db, DbTransaction tran, string salesorderdetailID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", salesorderdetailID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_SALESORDERDETAIL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Salesorderdetail_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Salesorderdetail">Salesorderdetail对象</param>
        /// <returns>Salesorderdetail参数数组</returns>
        private SqlParameter[] Set_Salesorderdetail_Parameters(SalesorderdetailInfo salesorderdetailInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@DetailID",salesorderdetailInfo.DetailID),
																new SqlParameter("@SoID",salesorderdetailInfo.SoID),
																new SqlParameter("@ItemID",salesorderdetailInfo.ItemID),
																new SqlParameter("@Qty",salesorderdetailInfo.Qty),
																new SqlParameter("@Price",salesorderdetailInfo.Price),
																new SqlParameter("@TotalAmount",salesorderdetailInfo.TotalAmount),
																new SqlParameter("@Remark",string.IsNullOrEmpty(salesorderdetailInfo.Remark)?"":salesorderdetailInfo.Remark),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(salesorderdetailInfo.CreatedBy)?"":salesorderdetailInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(salesorderdetailInfo.UpdatedBy)?"":salesorderdetailInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
