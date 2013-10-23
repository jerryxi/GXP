/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：PurchaseorderDA
// 文件功能描述：提供Purchaseorder数据表进行操作的一些方法
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
    public class PurchaseorderDA : IPurchaseorderDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Purchaseorder 的所有记录
        private string SQL_SELECT_ALL_PURCHASEORDER = "SELECT P.PoID AS PoID, P.SupplierID AS SupplierID, P.PoDate AS PoDate, P.Contact AS Contact, P.ContactPhone AS ContactPhone, P.ContactAddress AS ContactAddress, P.Status AS Status, P.TotalAmount AS TotalAmount, P.TotalItemCount AS TotalItemCount, P.Remark AS Remark, P.Ts AS Ts, P.CreatedBy AS CreatedBy, P.CreatedDate AS CreatedDate, P.UpdatedBy AS UpdatedBy, P.UpdatedDate AS UpdatedDate FROM PurchaseOrder P WHERE 1=1  ";
        //INSERT_SQL 向Purchaseorder增加一条记录
        private string SQL_INSERT_PURCHASEORDER = "INSERT INTO PurchaseOrder ( SupplierID, PoDate, Contact, ContactPhone, ContactAddress, Status, TotalAmount, TotalItemCount, Remark, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @SupplierID, @PoDate, @Contact, @ContactPhone, @ContactAddress, @Status, @TotalAmount, @TotalItemCount, @Remark, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Purchaseorder一条记录
        private string SQL_DELETE_PURCHASEORDER = "DELETE FROM PurchaseOrder WHERE POID = @POID ";
        //UPDATE_SQL 更新Purchaseorder记录
        private string SQL_UPDATE_PURCHASEORDER = "UPDATE PurchaseOrder SET SupplierID = @SupplierID, PoDate = @PoDate, Contact = @Contact, ContactPhone = @ContactPhone, ContactAddress = @ContactAddress, Status = @Status, TotalAmount = @TotalAmount, TotalItemCount = @TotalItemCount, Remark = @Remark, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE POID = @POID  ";

        //判断一个PURCHASEORDER_ID是否已存在
        private string SQL_CHECK_PURCHASEORDER_ID_IS_EXIST = " SELECT COUNT(1) FROM PurchaseOrder WHERE POID = @POID ";
        #endregion

        #region 基本方法

        #region 得到Purchaseorder的所有记录

        /// <summary>
        /// 得到所有的Purchaseorder记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Purchaseorder记录</returns>
        public DataSet GetAllPurchaseorder()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_PURCHASEORDER);
        }

        /// <summary>
        /// 得到所有的Purchaseorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Purchaseorder记录</returns>
        public DataSet GetAllPurchaseorder(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_PURCHASEORDER);
        }

        #endregion

        #region 根据条件查询Purchaseorder的记录  GetPurchaseorderByQueryList()

        /// <summary>
        /// 根据查询条件得到Purchaseorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderQueryEntity">Purchaseorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Purchaseorder记录</returns>
        public DataSet GetPurchaseorderByQueryList(QueryEntity purchaseorderQuery)
        {
            string temp = SQL_SELECT_ALL_PURCHASEORDER;

            if (purchaseorderQuery != null && purchaseorderQuery.sqlWhere != null && purchaseorderQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < purchaseorderQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + purchaseorderQuery.sqlWhere[i];
                }
            }

            if (!purchaseorderQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, purchaseorderQuery.CurrentPage, purchaseorderQuery.PageSize, purchaseorderQuery.SortField, purchaseorderQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Purchaseorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderQueryEntity">Purchaseorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Purchaseorder记录</returns>
        public DataSet GetPurchaseorderByQueryList(Database db, DbTransaction tran, QueryEntity purchaseorderQuery)
        {
            string temp = SQL_SELECT_ALL_PURCHASEORDER;

            if (purchaseorderQuery != null && purchaseorderQuery.sqlWhere != null && purchaseorderQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < purchaseorderQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + purchaseorderQuery.sqlWhere[i];
                }
            }
            if (!purchaseorderQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, purchaseorderQuery.CurrentPage, purchaseorderQuery.PageSize, purchaseorderQuery.SortField, purchaseorderQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Purchaseorder的一条记录 GetPurchaseorderByID()

        /// <summary>
        /// 根据purchaseorderID得到一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据purchaseorderID得到一条Purchaseorder记录</returns>
        public PurchaseorderInfo GetPurchaseorderByID(string purchaseorderID)
        {
            string sql = SQL_SELECT_ALL_PURCHASEORDER + " AND POID = @POID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@POID", purchaseorderID) };
            PurchaseorderInfo purchaseorderInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    purchaseorderInfo = InitPurchaseorderInfoByDataReader(purchaseorderInfo, reader);
                }
            }

            return purchaseorderInfo;
        }
        /// <summary>
        /// 根据purchaseorderID得到一条Purchaseorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据purchaseorderID得到一条Purchaseorder记录</returns>
        public PurchaseorderInfo GetPurchaseorderByID(Database db, DbTransaction tran, string purchaseorderID)
        {
            string sql = SQL_SELECT_ALL_PURCHASEORDER + " AND POID = @POID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@POID", purchaseorderID) };
            PurchaseorderInfo purchaseorderInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                purchaseorderInfo = InitPurchaseorderInfoByDataReader(purchaseorderInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return purchaseorderInfo;
        }
        /// <summary>
        /// 初始化PurchaseorderInfo
        /// </summary>
        private PurchaseorderInfo InitPurchaseorderInfoByDataReader(PurchaseorderInfo purchaseorderInfo, IDataReader reader)
        {
            purchaseorderInfo = new PurchaseorderInfo(reader["PoID"].ToString() != "" ? Int32.Parse(reader["PoID"].ToString()) : 0,
reader["SupplierID"].ToString() != "" ? Int32.Parse(reader["SupplierID"].ToString()) : 0,
reader["PoDate"].ToString() != "" ? DateTime.Parse(reader["PoDate"].ToString()) : new DateTime(),
reader["Contact"].ToString(),
reader["ContactPhone"].ToString(),
reader["ContactAddress"].ToString(),
reader["Status"].ToString(),
reader["TotalAmount"].ToString() != "" ? Decimal.Parse(reader["TotalAmount"].ToString()) : 0,
reader["TotalItemCount"].ToString() != "" ? Int32.Parse(reader["TotalItemCount"].ToString()) : 0,
reader["Remark"].ToString(),
reader["Ts"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return purchaseorderInfo;
        }
        #endregion

        #region 向Purchaseorder增加一条记录 InsertPurchaseorder()

        /// <summary>
        /// 新增一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertPurchaseorder(PurchaseorderInfo purchaseorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorder_Parameters(purchaseorderInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_PURCHASEORDER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Purchaseorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertPurchaseorder(Database db, DbTransaction tran, PurchaseorderInfo purchaseorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorder_Parameters(purchaseorderInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_PURCHASEORDER, paras);
            }
            return result;
        }
        #endregion

        #region 删除Purchaseorder一条记录 DeletePurchaseorder()

        /// <summary>
        /// 删除一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorderID">PurchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeletePurchaseorder(string purchaseorderID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@POID", purchaseorderID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_PURCHASEORDER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Purchaseorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderID">PurchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeletePurchaseorder(Database db, DbTransaction tran, string purchaseorderID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@POID", purchaseorderID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_PURCHASEORDER, paras);
            return result;
        }
        #endregion

        #region 更新一条Purchaseorder记录 UpdatePurchaseorder()
        /// <summary>
        /// 更新一条Purchaseorder记录
        /// </summary>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdatePurchaseorder(PurchaseorderInfo purchaseorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorder_Parameters(purchaseorderInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_PURCHASEORDER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Purchaseorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorder">Purchaseorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdatePurchaseorder(Database db, DbTransaction tran, PurchaseorderInfo purchaseorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorder_Parameters(purchaseorderInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_PURCHASEORDER, paras);
            }
            return result;
        }
        #endregion

        #region 根据POID判断此ID在表PurchaseOrder中是否已存在

        /// <summary>
        /// 检查PurchaseorderID是否已存在
        /// </summary>
        /// <param name="purchaseorderID">PurchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckPurchaseorderIDIsExist(string purchaseorderID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@POID", purchaseorderID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_PURCHASEORDER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查PurchaseorderID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderID">purchaseorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckPurchaseorderIDIsExist(Database db, DbTransaction tran, string purchaseorderID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@POID", purchaseorderID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_PURCHASEORDER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Purchaseorder_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Purchaseorder">Purchaseorder对象</param>
        /// <returns>Purchaseorder参数数组</returns>
        private SqlParameter[] Set_Purchaseorder_Parameters(PurchaseorderInfo purchaseorderInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@PoID",purchaseorderInfo.PoID),
																new SqlParameter("@SupplierID",purchaseorderInfo.SupplierID),
																new SqlParameter("@PoDate",purchaseorderInfo.PoDate),
																new SqlParameter("@Contact",string.IsNullOrEmpty(purchaseorderInfo.Contact)?"":purchaseorderInfo.Contact),
																new SqlParameter("@ContactPhone",string.IsNullOrEmpty(purchaseorderInfo.ContactPhone)?"":purchaseorderInfo.ContactPhone),
																new SqlParameter("@ContactAddress",string.IsNullOrEmpty(purchaseorderInfo.ContactAddress)?"":purchaseorderInfo.ContactAddress),
																new SqlParameter("@Status",string.IsNullOrEmpty(purchaseorderInfo.Status)?"":purchaseorderInfo.Status),
																new SqlParameter("@TotalAmount",purchaseorderInfo.TotalAmount),
																new SqlParameter("@TotalItemCount",purchaseorderInfo.TotalItemCount),
																new SqlParameter("@Remark",string.IsNullOrEmpty(purchaseorderInfo.Remark)?"":purchaseorderInfo.Remark),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(purchaseorderInfo.CreatedBy)?"":purchaseorderInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(purchaseorderInfo.UpdatedBy)?"":purchaseorderInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
