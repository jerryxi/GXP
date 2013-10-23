/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberorderDA
// 文件功能描述：提供Memberorder数据表进行操作的一些方法
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
    public class MemberorderDA : IMemberorderDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Memberorder 的所有记录
        private string SQL_SELECT_ALL_MEMBERORDER = "SELECT M.OrderID AS OrderID, M.OrderDate AS OrderDate, M.MemberID AS MemberID, M.PayMethod AS PayMethod, M.Ticket AS Ticket, M.TotalAmount AS TotalAmount, M.TotalItemCount AS TotalItemCount, M.Status AS Status, M.Contact AS Contact, M.ContactPhone AS ContactPhone, M.ContactAddress AS ContactAddress, M.Ts AS Ts, M.CreatedBy AS CreatedBy, M.CreatedDate AS CreatedDate, M.UpdatedBy AS UpdatedBy, M.UpdatedDate AS UpdatedDate FROM MemberOrder M WHERE 1=1  ";
        //INSERT_SQL 向Memberorder增加一条记录
        private string SQL_INSERT_MEMBERORDER = "INSERT INTO MemberOrder (OrderDate, MemberID, PayMethod, Ticket, TotalAmount, TotalItemCount, Status, Contact, ContactPhone, ContactAddress, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @OrderDate, @MemberID, @PayMethod, @Ticket, @TotalAmount, @TotalItemCount, @Status, @Contact, @ContactPhone, @ContactAddress, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Memberorder一条记录
        private string SQL_DELETE_MEMBERORDER = "DELETE FROM MemberOrder WHERE ORDERID = @ORDERID ";
        //UPDATE_SQL 更新Memberorder记录
        private string SQL_UPDATE_MEMBERORDER = "UPDATE MemberOrder SET OrderDate = @OrderDate, MemberID = @MemberID, PayMethod = @PayMethod, Ticket = @Ticket, TotalAmount = @TotalAmount, TotalItemCount = @TotalItemCount, Status = @Status, Contact = @Contact, ContactPhone = @ContactPhone, ContactAddress = @ContactAddress, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ORDERID = @ORDERID  ";

        //判断一个MEMBERORDER_ID是否已存在
        private string SQL_CHECK_MEMBERORDER_ID_IS_EXIST = " SELECT COUNT(1) FROM MemberOrder WHERE ORDERID = @ORDERID ";
        #endregion

        #region 基本方法

        #region 得到Memberorder的所有记录

        /// <summary>
        /// 得到所有的Memberorder记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberorder记录</returns>
        public DataSet GetAllMemberorder()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_MEMBERORDER);
        }

        /// <summary>
        /// 得到所有的Memberorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberorder记录</returns>
        public DataSet GetAllMemberorder(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_MEMBERORDER);
        }

        #endregion

        #region 根据条件查询Memberorder的记录  GetMemberorderByQueryList()

        /// <summary>
        /// 根据查询条件得到Memberorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderQueryEntity">Memberorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberorder记录</returns>
        public DataSet GetMemberorderByQueryList(QueryEntity memberorderQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERORDER;

            if (memberorderQuery != null && memberorderQuery.sqlWhere != null && memberorderQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberorderQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberorderQuery.sqlWhere[i];
                }
            }

            if (!memberorderQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberorderQuery.CurrentPage, memberorderQuery.PageSize, memberorderQuery.SortField, memberorderQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Memberorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderQueryEntity">Memberorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberorder记录</returns>
        public DataSet GetMemberorderByQueryList(Database db, DbTransaction tran, QueryEntity memberorderQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERORDER;

            if (memberorderQuery != null && memberorderQuery.sqlWhere != null && memberorderQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberorderQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberorderQuery.sqlWhere[i];
                }
            }
            if (!memberorderQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberorderQuery.CurrentPage, memberorderQuery.PageSize, memberorderQuery.SortField, memberorderQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Memberorder的一条记录 GetMemberorderByID()

        /// <summary>
        /// 根据memberorderID得到一条Memberorder记录
        /// </summary>
        /// <param name="memberorderID">memberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberorderID得到一条Memberorder记录</returns>
        public MemberorderInfo GetMemberorderByID(string memberorderID)
        {
            string sql = SQL_SELECT_ALL_MEMBERORDER + " AND ORDERID = @ORDERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ORDERID", memberorderID) };
            MemberorderInfo memberorderInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    memberorderInfo = InitMemberorderInfoByDataReader(memberorderInfo, reader);
                }
            }

            return memberorderInfo;
        }
        /// <summary>
        /// 根据memberorderID得到一条Memberorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderID">memberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberorderID得到一条Memberorder记录</returns>
        public MemberorderInfo GetMemberorderByID(Database db, DbTransaction tran, string memberorderID)
        {
            string sql = SQL_SELECT_ALL_MEMBERORDER + " AND ORDERID = @ORDERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ORDERID", memberorderID) };
            MemberorderInfo memberorderInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                memberorderInfo = InitMemberorderInfoByDataReader(memberorderInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return memberorderInfo;
        }
        /// <summary>
        /// 初始化MemberorderInfo
        /// </summary>
        private MemberorderInfo InitMemberorderInfoByDataReader(MemberorderInfo memberorderInfo, IDataReader reader)
        {
            memberorderInfo = new MemberorderInfo(reader["OrderID"].ToString() != "" ? Int32.Parse(reader["OrderID"].ToString()) : 0,
reader["OrderDate"].ToString() != "" ? DateTime.Parse(reader["OrderDate"].ToString()) : new DateTime(),
reader["MemberID"].ToString(),
reader["PayMethod"].ToString(),
reader["Ticket"].ToString(),
reader["TotalAmount"].ToString() != "" ? Decimal.Parse(reader["TotalAmount"].ToString()) : 0,
reader["TotalItemCount"].ToString() != "" ? Int32.Parse(reader["TotalItemCount"].ToString()) : 0,
reader["Status"].ToString(),
reader["Contact"].ToString(),
reader["ContactPhone"].ToString(),
reader["ContactAddress"].ToString(),
reader["Ts"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return memberorderInfo;
        }
        #endregion

        #region 向Memberorder增加一条记录 InsertMemberorder()

        /// <summary>
        /// 新增一条Memberorder记录
        /// </summary>
        /// <param name="memberorder">Memberorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberorder(MemberorderInfo memberorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorder_Parameters(memberorderInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_MEMBERORDER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Memberorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorder">Memberorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberorder(Database db, DbTransaction tran, MemberorderInfo memberorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorder_Parameters(memberorderInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_MEMBERORDER, paras);
            }
            return result;
        }
        #endregion

        #region 删除Memberorder一条记录 DeleteMemberorder()

        /// <summary>
        /// 删除一条Memberorder记录
        /// </summary>
        /// <param name="memberorderID">MemberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberorder(string memberorderID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ORDERID", memberorderID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_MEMBERORDER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Memberorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderID">MemberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberorder(Database db, DbTransaction tran, string memberorderID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ORDERID", memberorderID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_MEMBERORDER, paras);
            return result;
        }
        #endregion

        #region 更新一条Memberorder记录 UpdateMemberorder()
        /// <summary>
        /// 更新一条Memberorder记录
        /// </summary>
        /// <param name="memberorder">Memberorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberorder(MemberorderInfo memberorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorder_Parameters(memberorderInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_MEMBERORDER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Memberorder记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorder">Memberorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberorder(Database db, DbTransaction tran, MemberorderInfo memberorderInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorder_Parameters(memberorderInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_MEMBERORDER, paras);
            }
            return result;
        }
        #endregion

        #region 根据ORDERID判断此ID在表MemberOrder中是否已存在

        /// <summary>
        /// 检查MemberorderID是否已存在
        /// </summary>
        /// <param name="memberorderID">MemberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberorderIDIsExist(string memberorderID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ORDERID", memberorderID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_MEMBERORDER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查MemberorderID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderID">memberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberorderIDIsExist(Database db, DbTransaction tran, string memberorderID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ORDERID", memberorderID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_MEMBERORDER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Memberorder_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Memberorder">Memberorder对象</param>
        /// <returns>Memberorder参数数组</returns>
        private SqlParameter[] Set_Memberorder_Parameters(MemberorderInfo memberorderInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@OrderID",memberorderInfo.OrderID),
																new SqlParameter("@OrderDate",memberorderInfo.OrderDate),
																new SqlParameter("@MemberID",string.IsNullOrEmpty(memberorderInfo.MemberID)?"":memberorderInfo.MemberID),
																new SqlParameter("@PayMethod",string.IsNullOrEmpty(memberorderInfo.PayMethod)?"":memberorderInfo.PayMethod),
																new SqlParameter("@Ticket",string.IsNullOrEmpty(memberorderInfo.Ticket)?"":memberorderInfo.Ticket),
																new SqlParameter("@TotalAmount",memberorderInfo.TotalAmount),
																new SqlParameter("@TotalItemCount",memberorderInfo.TotalItemCount),
																new SqlParameter("@Status",string.IsNullOrEmpty(memberorderInfo.Status)?"":memberorderInfo.Status),
																new SqlParameter("@Contact",string.IsNullOrEmpty(memberorderInfo.Contact)?"":memberorderInfo.Contact),
																new SqlParameter("@ContactPhone",string.IsNullOrEmpty(memberorderInfo.ContactPhone)?"":memberorderInfo.ContactPhone),
																new SqlParameter("@ContactAddress",string.IsNullOrEmpty(memberorderInfo.ContactAddress)?"":memberorderInfo.ContactAddress),
                                                                //new SqlParameter("@Ts",memberorderInfo.Ts),
                                                                new SqlParameter("@CreatedBy",string.IsNullOrEmpty(memberorderInfo.CreatedBy)?"":memberorderInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(memberorderInfo.UpdatedBy)?"":memberorderInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
