/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：PurchaseorderdetailDA
// 文件功能描述：提供Purchaseorderdetail数据表进行操作的一些方法
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
    public class PurchaseorderdetailDA : IPurchaseorderdetailDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Purchaseorderdetail 的所有记录
        private string SQL_SELECT_ALL_PURCHASEORDERDETAIL = "SELECT P.DetailID AS DetailID, P.PoID AS PoID, P.ItemID AS ItemID, P.Qty AS Qty, P.Price AS Price, P.Status AS Status, P.Remark AS Remark, P.Ts AS Ts, P.CreatedBy AS CreatedBy, P.CreatedDate AS CreatedDate, P.UpdatedBy AS UpdatedBy, P.UpdatedDate AS UpdatedDate FROM PurchaseOrderDetail P WHERE 1=1  ";
        //INSERT_SQL 向Purchaseorderdetail增加一条记录
        private string SQL_INSERT_PURCHASEORDERDETAIL = "INSERT INTO PurchaseOrderDetail ( DetailID, PoID, ItemID, Qty, Price, Status, Remark, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @DetailID, @PoID, @ItemID, @Qty, @Price, @Status, @Remark, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Purchaseorderdetail一条记录
        private string SQL_DELETE_PURCHASEORDERDETAIL = "DELETE FROM PurchaseOrderDetail WHERE DETAILID = @DETAILID ";
        //UPDATE_SQL 更新Purchaseorderdetail记录
        private string SQL_UPDATE_PURCHASEORDERDETAIL = "UPDATE PurchaseOrderDetail SET PoID = @PoID, ItemID = @ItemID, Qty = @Qty, Price = @Price, Status = @Status, Remark = @Remark, Ts = @Ts, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE DETAILID = @DETAILID  ";

        //判断一个PURCHASEORDERDETAIL_ID是否已存在
        private string SQL_CHECK_PURCHASEORDERDETAIL_ID_IS_EXIST = " SELECT COUNT(1) FROM PurchaseOrderDetail WHERE DETAILID = @DETAILID ";
        #endregion

        #region 基本方法

        #region 得到Purchaseorderdetail的所有记录

        /// <summary>
        /// 得到所有的Purchaseorderdetail记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Purchaseorderdetail记录</returns>
        public DataSet GetAllPurchaseorderdetail()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_PURCHASEORDERDETAIL);
        }

        /// <summary>
        /// 得到所有的Purchaseorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Purchaseorderdetail记录</returns>
        public DataSet GetAllPurchaseorderdetail(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_PURCHASEORDERDETAIL);
        }

        #endregion

        #region 根据条件查询Purchaseorderdetail的记录  GetPurchaseorderdetailByQueryList()

        /// <summary>
        /// 根据查询条件得到Purchaseorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderdetailQueryEntity">Purchaseorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Purchaseorderdetail记录</returns>
        public DataSet GetPurchaseorderdetailByQueryList(QueryEntity purchaseorderdetailQuery)
        {
            string temp = SQL_SELECT_ALL_PURCHASEORDERDETAIL;

            if (purchaseorderdetailQuery != null && purchaseorderdetailQuery.sqlWhere != null && purchaseorderdetailQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < purchaseorderdetailQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + purchaseorderdetailQuery.sqlWhere[i];
                }
            }

            if (!purchaseorderdetailQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, purchaseorderdetailQuery.CurrentPage, purchaseorderdetailQuery.PageSize, purchaseorderdetailQuery.SortField, purchaseorderdetailQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Purchaseorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="PurchaseorderdetailQueryEntity">Purchaseorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Purchaseorderdetail记录</returns>
        public DataSet GetPurchaseorderdetailByQueryList(Database db, DbTransaction tran, QueryEntity purchaseorderdetailQuery)
        {
            string temp = SQL_SELECT_ALL_PURCHASEORDERDETAIL;

            if (purchaseorderdetailQuery != null && purchaseorderdetailQuery.sqlWhere != null && purchaseorderdetailQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < purchaseorderdetailQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + purchaseorderdetailQuery.sqlWhere[i];
                }
            }
            if (!purchaseorderdetailQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, purchaseorderdetailQuery.CurrentPage, purchaseorderdetailQuery.PageSize, purchaseorderdetailQuery.SortField, purchaseorderdetailQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Purchaseorderdetail的一条记录 GetPurchaseorderdetailByID()

        /// <summary>
        /// 根据purchaseorderdetailID得到一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据purchaseorderdetailID得到一条Purchaseorderdetail记录</returns>
        public PurchaseorderdetailInfo GetPurchaseorderdetailByID(string purchaseorderdetailID)
        {
            string sql = SQL_SELECT_ALL_PURCHASEORDERDETAIL + " AND DETAILID = @DETAILID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", purchaseorderdetailID) };
            PurchaseorderdetailInfo purchaseorderdetailInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    purchaseorderdetailInfo = InitPurchaseorderdetailInfoByDataReader(purchaseorderdetailInfo, reader);
                }
            }

            return purchaseorderdetailInfo;
        }
        /// <summary>
        /// 根据purchaseorderdetailID得到一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据purchaseorderdetailID得到一条Purchaseorderdetail记录</returns>
        public PurchaseorderdetailInfo GetPurchaseorderdetailByID(Database db, DbTransaction tran, string purchaseorderdetailID)
        {
            string sql = SQL_SELECT_ALL_PURCHASEORDERDETAIL + " AND DETAILID = @DETAILID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", purchaseorderdetailID) };
            PurchaseorderdetailInfo purchaseorderdetailInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                purchaseorderdetailInfo = InitPurchaseorderdetailInfoByDataReader(purchaseorderdetailInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return purchaseorderdetailInfo;
        }
        /// <summary>
        /// 初始化PurchaseorderdetailInfo
        /// </summary>
        private PurchaseorderdetailInfo InitPurchaseorderdetailInfoByDataReader(PurchaseorderdetailInfo purchaseorderdetailInfo, IDataReader reader)
        {
            purchaseorderdetailInfo = new PurchaseorderdetailInfo(reader["DetailID"].ToString() != "" ? Int32.Parse(reader["DetailID"].ToString()) : 0,
reader["PoID"].ToString() != "" ? Int32.Parse(reader["PoID"].ToString()) : 0,
reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["Qty"].ToString() != "" ? Int32.Parse(reader["Qty"].ToString()) : 0,
reader["Price"].ToString() != "" ? Decimal.Parse(reader["Price"].ToString()) : 0,
reader["Status"].ToString(),
reader["Remark"].ToString(),
reader["Ts"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return purchaseorderdetailInfo;
        }
        #endregion

        #region 向Purchaseorderdetail增加一条记录 InsertPurchaseorderdetail()

        /// <summary>
        /// 新增一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertPurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorderdetail_Parameters(purchaseorderdetailInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_PURCHASEORDERDETAIL, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertPurchaseorderdetail(Database db, DbTransaction tran, PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorderdetail_Parameters(purchaseorderdetailInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_PURCHASEORDERDETAIL, paras);
            }
            return result;
        }
        #endregion

        #region 删除Purchaseorderdetail一条记录 DeletePurchaseorderdetail()

        /// <summary>
        /// 删除一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetailID">PurchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeletePurchaseorderdetail(string purchaseorderdetailID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", purchaseorderdetailID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_PURCHASEORDERDETAIL, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetailID">PurchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeletePurchaseorderdetail(Database db, DbTransaction tran, string purchaseorderdetailID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", purchaseorderdetailID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_PURCHASEORDERDETAIL, paras);
            return result;
        }
        #endregion

        #region 更新一条Purchaseorderdetail记录 UpdatePurchaseorderdetail()
        /// <summary>
        /// 更新一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdatePurchaseorderdetail(PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorderdetail_Parameters(purchaseorderdetailInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_PURCHASEORDERDETAIL, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Purchaseorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdatePurchaseorderdetail(Database db, DbTransaction tran, PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Purchaseorderdetail_Parameters(purchaseorderdetailInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_PURCHASEORDERDETAIL, paras);
            }
            return result;
        }
        #endregion

        #region 根据DETAILID判断此ID在表PurchaseOrderDetail中是否已存在

        /// <summary>
        /// 检查PurchaseorderdetailID是否已存在
        /// </summary>
        /// <param name="purchaseorderdetailID">PurchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckPurchaseorderdetailIDIsExist(string purchaseorderdetailID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", purchaseorderdetailID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_PURCHASEORDERDETAIL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查PurchaseorderdetailID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="purchaseorderdetailID">purchaseorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckPurchaseorderdetailIDIsExist(Database db, DbTransaction tran, string purchaseorderdetailID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", purchaseorderdetailID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_PURCHASEORDERDETAIL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Purchaseorderdetail_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Purchaseorderdetail">Purchaseorderdetail对象</param>
        /// <returns>Purchaseorderdetail参数数组</returns>
        private SqlParameter[] Set_Purchaseorderdetail_Parameters(PurchaseorderdetailInfo purchaseorderdetailInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@DetailID",purchaseorderdetailInfo.DetailID),
																new SqlParameter("@PoID",purchaseorderdetailInfo.PoID),
																new SqlParameter("@ItemID",purchaseorderdetailInfo.ItemID),
																new SqlParameter("@Qty",purchaseorderdetailInfo.Qty),
																new SqlParameter("@Price",purchaseorderdetailInfo.Price),
																new SqlParameter("@Status",string.IsNullOrEmpty(purchaseorderdetailInfo.Status)?"":purchaseorderdetailInfo.Status),
																new SqlParameter("@Remark",string.IsNullOrEmpty(purchaseorderdetailInfo.Remark)?"":purchaseorderdetailInfo.Remark),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(purchaseorderdetailInfo.CreatedBy)?"":purchaseorderdetailInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(purchaseorderdetailInfo.UpdatedBy)?"":purchaseorderdetailInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
