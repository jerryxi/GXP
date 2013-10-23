/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SalesorderDA
// 文件功能描述：提供Salesorder数据表进行操作的一些方法
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
    public class SalesorderDA : ISalesorderDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Salesorder 的所有记录
        private string SQL_SELECT_ALL_SALESORDER = "SELECT S.SoID AS SoID, S.MemberID AS MemberID, S.SoDate AS SoDate, S.SupplierID AS SupplierID, S.Status AS Status, S.TotalAmount AS TotalAmount, S.TotalItemCount AS TotalItemCount, S.Contact AS Contact, S.ContactPhone AS ContactPhone, S.ContactAddress AS ContactAddress, S.PayMethod AS PayMethod, S.Ts AS Ts, S.CreatedBy AS CreatedBy, S.CreatedDate AS CreatedDate, S.UpdatedBy AS UpdatedBy, S.UpdatedDate AS UpdatedDate FROM SalesOrder S WHERE 1=1  ";
        //INSERT_SQL 向Salesorder增加一条记录
        private string SQL_INSERT_SALESORDER = "INSERT INTO SalesOrder ( MemberID, SoDate, SupplierID, Status, TotalAmount, TotalItemCount, Contact, ContactPhone, ContactAddress, PayMethod, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @MemberID, @SoDate, @SupplierID, @Status, @TotalAmount, @TotalItemCount, @Contact, @ContactPhone, @ContactAddress, @PayMethod, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Salesorder一条记录
        private string SQL_DELETE_SALESORDER = "DELETE FROM SalesOrder WHERE SOID = @SOID ";
        //UPDATE_SQL 更新Salesorder记录
        private string SQL_UPDATE_SALESORDER = "UPDATE SalesOrder SET MemberID = @MemberID, SoDate = @SoDate, SupplierID = @SupplierID, Status = @Status, TotalAmount = @TotalAmount, TotalItemCount = @TotalItemCount, Contact = @Contact, ContactPhone = @ContactPhone, ContactAddress = @ContactAddress, PayMethod = @PayMethod, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE SOID = @SOID  ";

        //判断一个SALESORDER_ID是否已存在
        private string SQL_CHECK_SALESORDER_ID_IS_EXIST = " SELECT COUNT(1) FROM SalesOrder WHERE SOID = @SOID ";
        #endregion

        #region 基本方法

        #region 得到Salesorder的所有记录

        /// <summary>
        /// 得到所有的Salesorder记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Salesorder记录</returns>
        public DataSet GetAllSalesorder()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_SALESORDER);
        }

        /// <summary>
        /// 得到所有的Salesorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Salesorder记录</returns>
        public DataSet GetAllSalesorder(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_SALESORDER);
        }

        #endregion

        #region 根据条件查询Salesorder的记录  GetSalesorderByQueryList()

        /// <summary>
        /// 根据查询条件得到Salesorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderQueryEntity">Salesorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Salesorder记录</returns>
        public DataSet GetSalesorderByQueryList(QueryEntity salesorderQuery)
        {
            string temp = SQL_SELECT_ALL_SALESORDER;

            if (salesorderQuery != null && salesorderQuery.sqlWhere != null && salesorderQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < salesorderQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + salesorderQuery.sqlWhere[i];
                }
            }

            if (!salesorderQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, salesorderQuery.CurrentPage, salesorderQuery.PageSize, salesorderQuery.SortField, salesorderQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Salesorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderQueryEntity">Salesorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Salesorder记录</returns>
        public DataSet GetSalesorderByQueryList(Database db, DbTransaction tran, QueryEntity salesorderQuery)
        {
            string temp = SQL_SELECT_ALL_SALESORDER;

            if (salesorderQuery != null && salesorderQuery.sqlWhere != null && salesorderQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < salesorderQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + salesorderQuery.sqlWhere[i];
                }
            }
            if (!salesorderQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, salesorderQuery.CurrentPage, salesorderQuery.PageSize, salesorderQuery.SortField, salesorderQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Salesorder的一条记录 GetSalesorderByID()

        /// <summary>
        /// 根据salesorderID得到一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据salesorderID得到一条Salesorder记录</returns>
        public SalesorderInfo GetSalesorderByID(string salesorderID)
        {
            string sql = SQL_SELECT_ALL_SALESORDER + " AND SOID = @SOID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SOID", salesorderID) };
            SalesorderInfo salesorderInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    salesorderInfo = InitSalesorderInfoByDataReader(salesorderInfo, reader);
                }
            }

            return salesorderInfo;
        }
        /// <summary>
        /// 根据salesorderID得到一条Salesorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderID">salesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据salesorderID得到一条Salesorder记录</returns>
        public SalesorderInfo GetSalesorderByID(Database db, DbTransaction tran, string salesorderID)
        {
            string sql = SQL_SELECT_ALL_SALESORDER + " AND SOID = @SOID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SOID", salesorderID) };
            SalesorderInfo salesorderInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                salesorderInfo = InitSalesorderInfoByDataReader(salesorderInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return salesorderInfo;
        }
        /// <summary>
        /// 初始化SalesorderInfo
        /// </summary>
        private SalesorderInfo InitSalesorderInfoByDataReader(SalesorderInfo salesorderInfo, IDataReader reader)
        {
            salesorderInfo = new SalesorderInfo(reader["SoID"].ToString() != "" ? Int32.Parse(reader["SoID"].ToString()) : 0,
reader["MemberID"].ToString() != "" ? Int32.Parse(reader["MemberID"].ToString()) : 0,
reader["SoDate"].ToString() != "" ? DateTime.Parse(reader["SoDate"].ToString()) : new DateTime(),
reader["SupplierID"].ToString() != "" ? Int32.Parse(reader["SupplierID"].ToString()) : 0,
reader["Status"].ToString(),
reader["TotalAmount"].ToString() != "" ? Decimal.Parse(reader["TotalAmount"].ToString()) : 0,
reader["TotalItemCount"].ToString() != "" ? Int32.Parse(reader["TotalItemCount"].ToString()) : 0,
reader["Contact"].ToString(),
reader["ContactPhone"].ToString(),
reader["ContactAddress"].ToString(),
reader["PayMethod"].ToString(),
reader["Ts"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return salesorderInfo;
        }
        #endregion

        #region 向Salesorder增加一条记录 InsertSalesorder()

        /// <summary>
        /// 新增一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSalesorder(SalesorderInfo salesorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorder_Parameters(salesorderInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_SALESORDER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Salesorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorder">Salesorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSalesorder(Database db, DbTransaction tran, SalesorderInfo salesorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorder_Parameters(salesorderInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_SALESORDER, paras);
            }
            return result;
        }
        #endregion

        #region 删除Salesorder一条记录 DeleteSalesorder()

        /// <summary>
        /// 删除一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">SalesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSalesorder(string salesorderID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SOID", salesorderID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_SALESORDER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Salesorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderID">SalesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSalesorder(Database db, DbTransaction tran, string salesorderID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SOID", salesorderID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_SALESORDER, paras);
            return result;
        }
        #endregion

        #region 更新一条Salesorder记录 UpdateSalesorder()
        /// <summary>
        /// 更新一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSalesorder(SalesorderInfo salesorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorder_Parameters(salesorderInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_SALESORDER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Salesorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorder">Salesorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSalesorder(Database db, DbTransaction tran, SalesorderInfo salesorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Salesorder_Parameters(salesorderInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_SALESORDER, paras);
            }
            return result;
        }
        #endregion

        #region 根据SOID判断此ID在表SalesOrder中是否已存在

        /// <summary>
        /// 检查SalesorderID是否已存在
        /// </summary>
        /// <param name="salesorderID">SalesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSalesorderIDIsExist(string salesorderID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SOID", salesorderID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_SALESORDER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查SalesorderID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderID">salesorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSalesorderIDIsExist(Database db, DbTransaction tran, string salesorderID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SOID", salesorderID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_SALESORDER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Salesorder_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Salesorder">Salesorder对象</param>
        /// <returns>Salesorder参数数组</returns>
        private SqlParameter[] Set_Salesorder_Parameters(SalesorderInfo salesorderInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@SoID",salesorderInfo.SoID),
																new SqlParameter("@MemberID",salesorderInfo.MemberID),
																new SqlParameter("@SoDate",salesorderInfo.SoDate),
																new SqlParameter("@SupplierID",salesorderInfo.SupplierID),
																new SqlParameter("@Status",string.IsNullOrEmpty(salesorderInfo.Status)?"":salesorderInfo.Status),
																new SqlParameter("@TotalAmount",salesorderInfo.TotalAmount),
																new SqlParameter("@TotalItemCount",salesorderInfo.TotalItemCount),
																new SqlParameter("@Contact",string.IsNullOrEmpty(salesorderInfo.Contact)?"":salesorderInfo.Contact),
																new SqlParameter("@ContactPhone",string.IsNullOrEmpty(salesorderInfo.ContactPhone)?"":salesorderInfo.ContactPhone),
																new SqlParameter("@ContactAddress",string.IsNullOrEmpty(salesorderInfo.ContactAddress)?"":salesorderInfo.ContactAddress),
																new SqlParameter("@PayMethod",string.IsNullOrEmpty(salesorderInfo.PayMethod)?"":salesorderInfo.PayMethod),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(salesorderInfo.CreatedBy)?"":salesorderInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(salesorderInfo.UpdatedBy)?"":salesorderInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
