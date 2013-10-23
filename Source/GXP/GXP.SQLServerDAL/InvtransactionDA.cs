/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：InvtransactionDA
// 文件功能描述：提供Invtransaction数据表进行操作的一些方法
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
    public class InvtransactionDA : IInvtransactionDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Invtransaction 的所有记录
        private string SQL_SELECT_ALL_INVTRANSACTION = "SELECT I.TransID AS TransID, I.ItemID AS ItemID, I.SupplierID AS SupplierID, I.TransType AS TransType, I.Qty AS Qty, I.PoID AS PoID, I.PoLineID AS PoLineID, I.SoID AS SoID, I.SoLineID AS SoLineID, I.CreatedBy AS CreatedBy, I.CreatedDate AS CreatedDate FROM InvTransaction I WHERE 1=1  ";
        //INSERT_SQL 向Invtransaction增加一条记录
        private string SQL_INSERT_INVTRANSACTION = "INSERT INTO InvTransaction ( TransID, ItemID, SupplierID, TransType, Qty, PoID, PoLineID, SoID, SoLineID, CreatedBy, CreatedDate) VALUES ( @TransID, @ItemID, @SupplierID, @TransType, @Qty, @PoID, @PoLineID, @SoID, @SoLineID, @CreatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Invtransaction一条记录
        private string SQL_DELETE_INVTRANSACTION = "DELETE FROM InvTransaction WHERE TRANSID = @TRANSID ";
        //UPDATE_SQL 更新Invtransaction记录
        private string SQL_UPDATE_INVTRANSACTION = "UPDATE InvTransaction SET ItemID = @ItemID, SupplierID = @SupplierID, TransType = @TransType, Qty = @Qty, PoID = @PoID, PoLineID = @PoLineID, SoID = @SoID, SoLineID = @SoLineID WHERE TRANSID = @TRANSID  ";

        //判断一个INVTRANSACTION_ID是否已存在
        private string SQL_CHECK_INVTRANSACTION_ID_IS_EXIST = " SELECT COUNT(1) FROM InvTransaction WHERE TRANSID = @TRANSID ";
        #endregion

        #region 基本方法

        #region 得到Invtransaction的所有记录

        /// <summary>
        /// 得到所有的Invtransaction记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Invtransaction记录</returns>
        public DataSet GetAllInvtransaction()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_INVTRANSACTION);
        }

        /// <summary>
        /// 得到所有的Invtransaction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Invtransaction记录</returns>
        public DataSet GetAllInvtransaction(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_INVTRANSACTION);
        }

        #endregion

        #region 根据条件查询Invtransaction的记录  GetInvtransactionByQueryList()

        /// <summary>
        /// 根据查询条件得到Invtransaction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InvtransactionQueryEntity">Invtransaction查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Invtransaction记录</returns>
        public DataSet GetInvtransactionByQueryList(QueryEntity invtransactionQuery)
        {
            string temp = SQL_SELECT_ALL_INVTRANSACTION;

            if (invtransactionQuery != null && invtransactionQuery.sqlWhere != null && invtransactionQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < invtransactionQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + invtransactionQuery.sqlWhere[i];
                }
            }

            if (!invtransactionQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, invtransactionQuery.CurrentPage, invtransactionQuery.PageSize, invtransactionQuery.SortField, invtransactionQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Invtransaction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InvtransactionQueryEntity">Invtransaction查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Invtransaction记录</returns>
        public DataSet GetInvtransactionByQueryList(Database db, DbTransaction tran, QueryEntity invtransactionQuery)
        {
            string temp = SQL_SELECT_ALL_INVTRANSACTION;

            if (invtransactionQuery != null && invtransactionQuery.sqlWhere != null && invtransactionQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < invtransactionQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + invtransactionQuery.sqlWhere[i];
                }
            }
            if (!invtransactionQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, invtransactionQuery.CurrentPage, invtransactionQuery.PageSize, invtransactionQuery.SortField, invtransactionQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Invtransaction的一条记录 GetInvtransactionByID()

        /// <summary>
        /// 根据invtransactionID得到一条Invtransaction记录
        /// </summary>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据invtransactionID得到一条Invtransaction记录</returns>
        public InvtransactionInfo GetInvtransactionByID(string invtransactionID)
        {
            string sql = SQL_SELECT_ALL_INVTRANSACTION + " AND TRANSID = @TRANSID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@TRANSID", invtransactionID) };
            InvtransactionInfo invtransactionInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    invtransactionInfo = InitInvtransactionInfoByDataReader(invtransactionInfo, reader);
                }
            }

            return invtransactionInfo;
        }
        /// <summary>
        /// 根据invtransactionID得到一条Invtransaction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据invtransactionID得到一条Invtransaction记录</returns>
        public InvtransactionInfo GetInvtransactionByID(Database db, DbTransaction tran, string invtransactionID)
        {
            string sql = SQL_SELECT_ALL_INVTRANSACTION + " AND TRANSID = @TRANSID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@TRANSID", invtransactionID) };
            InvtransactionInfo invtransactionInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                invtransactionInfo = InitInvtransactionInfoByDataReader(invtransactionInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return invtransactionInfo;
        }
        /// <summary>
        /// 初始化InvtransactionInfo
        /// </summary>
        private InvtransactionInfo InitInvtransactionInfoByDataReader(InvtransactionInfo invtransactionInfo, IDataReader reader)
        {
            invtransactionInfo = new InvtransactionInfo(reader["TransID"].ToString() != "" ? Int32.Parse(reader["TransID"].ToString()) : 0,
reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["SupplierID"].ToString() != "" ? Int32.Parse(reader["SupplierID"].ToString()) : 0,
reader["TransType"].ToString(),
reader["Qty"].ToString() != "" ? Int32.Parse(reader["Qty"].ToString()) : 0,
reader["PoID"].ToString(),
reader["PoLineID"].ToString(),
reader["SoID"].ToString(),
reader["SoLineID"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime());
            return invtransactionInfo;
        }
        #endregion

        #region 向Invtransaction增加一条记录 InsertInvtransaction()

        /// <summary>
        /// 新增一条Invtransaction记录
        /// </summary>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertInvtransaction(InvtransactionInfo invtransactionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Invtransaction_Parameters(invtransactionInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_INVTRANSACTION, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Invtransaction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertInvtransaction(Database db, DbTransaction tran, InvtransactionInfo invtransactionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Invtransaction_Parameters(invtransactionInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_INVTRANSACTION, paras);
            }
            return result;
        }
        #endregion

        #region 删除Invtransaction一条记录 DeleteInvtransaction()

        /// <summary>
        /// 删除一条Invtransaction记录
        /// </summary>
        /// <param name="invtransactionID">InvtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteInvtransaction(string invtransactionID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@TRANSID", invtransactionID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_INVTRANSACTION, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Invtransaction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransactionID">InvtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteInvtransaction(Database db, DbTransaction tran, string invtransactionID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@TRANSID", invtransactionID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_INVTRANSACTION, paras);
            return result;
        }
        #endregion

        #region 更新一条Invtransaction记录 UpdateInvtransaction()
        /// <summary>
        /// 更新一条Invtransaction记录
        /// </summary>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateInvtransaction(InvtransactionInfo invtransactionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Invtransaction_Parameters(invtransactionInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_INVTRANSACTION, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Invtransaction记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateInvtransaction(Database db, DbTransaction tran, InvtransactionInfo invtransactionInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Invtransaction_Parameters(invtransactionInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_INVTRANSACTION, paras);
            }
            return result;
        }
        #endregion

        #region 根据TRANSID判断此ID在表InvTransaction中是否已存在

        /// <summary>
        /// 检查InvtransactionID是否已存在
        /// </summary>
        /// <param name="invtransactionID">InvtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckInvtransactionIDIsExist(string invtransactionID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@TRANSID", invtransactionID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_INVTRANSACTION_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查InvtransactionID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckInvtransactionIDIsExist(Database db, DbTransaction tran, string invtransactionID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@TRANSID", invtransactionID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_INVTRANSACTION_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Invtransaction_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Invtransaction">Invtransaction对象</param>
        /// <returns>Invtransaction参数数组</returns>
        private SqlParameter[] Set_Invtransaction_Parameters(InvtransactionInfo invtransactionInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@TransID",invtransactionInfo.TransID),
																new SqlParameter("@ItemID",invtransactionInfo.ItemID),
																new SqlParameter("@SupplierID",invtransactionInfo.SupplierID),
																new SqlParameter("@TransType",string.IsNullOrEmpty(invtransactionInfo.TransType)?"":invtransactionInfo.TransType),
																new SqlParameter("@Qty",invtransactionInfo.Qty),
																new SqlParameter("@PoID",string.IsNullOrEmpty(invtransactionInfo.PoID)?"":invtransactionInfo.PoID),
																new SqlParameter("@PoLineID",string.IsNullOrEmpty(invtransactionInfo.PoLineID)?"":invtransactionInfo.PoLineID),
																new SqlParameter("@SoID",string.IsNullOrEmpty(invtransactionInfo.SoID)?"":invtransactionInfo.SoID),
																new SqlParameter("@SoLineID",string.IsNullOrEmpty(invtransactionInfo.SoLineID)?"":invtransactionInfo.SoLineID),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(invtransactionInfo.CreatedBy)?"":invtransactionInfo.CreatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
