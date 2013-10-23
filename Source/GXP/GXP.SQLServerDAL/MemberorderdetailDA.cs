/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberorderdetailDA
// 文件功能描述：提供Memberorderdetail数据表进行操作的一些方法
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
    public class MemberorderdetailDA : IMemberorderdetailDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Memberorderdetail 的所有记录
        private string SQL_SELECT_ALL_MEMBERORDERDETAIL = "SELECT M.DetailID AS DetailID, M.OrderID AS OrderID, M.ItemID AS ItemID, M.Qty AS Qty, M.Price AS Price, M.Status AS Status, M.Ts AS Ts, M.CreatedBy AS CreatedBy, M.CreatedDate AS CreatedDate, M.UpdatedBy AS UpdatedBy, M.UpdatedDate AS UpdatedDate FROM MemberOrderDetail M WHERE 1=1  ";
        //INSERT_SQL 向Memberorderdetail增加一条记录
        private string SQL_INSERT_MEMBERORDERDETAIL = "INSERT INTO MemberOrderDetail ( DetailID, OrderID, ItemID, Qty, Price, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @DetailID, @OrderID, @ItemID, @Qty, @Price, @Status, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Memberorderdetail一条记录
        private string SQL_DELETE_MEMBERORDERDETAIL = "DELETE FROM MemberOrderDetail WHERE DETAILID = @DETAILID ";
        //UPDATE_SQL 更新Memberorderdetail记录
        private string SQL_UPDATE_MEMBERORDERDETAIL = "UPDATE MemberOrderDetail SET OrderID = @OrderID, ItemID = @ItemID, Qty = @Qty, Price = @Price, Status = @Status, Ts = @Ts, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE DETAILID = @DETAILID  ";

        //判断一个MEMBERORDERDETAIL_ID是否已存在
        private string SQL_CHECK_MEMBERORDERDETAIL_ID_IS_EXIST = " SELECT COUNT(1) FROM MemberOrderDetail WHERE DETAILID = @DETAILID ";
        #endregion

        #region 基本方法

        #region 得到Memberorderdetail的所有记录

        /// <summary>
        /// 得到所有的Memberorderdetail记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberorderdetail记录</returns>
        public DataSet GetAllMemberorderdetail()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_MEMBERORDERDETAIL);
        }

        /// <summary>
        /// 得到所有的Memberorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberorderdetail记录</returns>
        public DataSet GetAllMemberorderdetail(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_MEMBERORDERDETAIL);
        }

        #endregion

        #region 根据条件查询Memberorderdetail的记录  GetMemberorderdetailByQueryList()

        /// <summary>
        /// 根据查询条件得到Memberorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderdetailQueryEntity">Memberorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberorderdetail记录</returns>
        public DataSet GetMemberorderdetailByQueryList(QueryEntity memberorderdetailQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERORDERDETAIL;

            if (memberorderdetailQuery != null && memberorderdetailQuery.sqlWhere != null && memberorderdetailQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberorderdetailQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberorderdetailQuery.sqlWhere[i];
                }
            }

            if (!memberorderdetailQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberorderdetailQuery.CurrentPage, memberorderdetailQuery.PageSize, memberorderdetailQuery.SortField, memberorderdetailQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Memberorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderdetailQueryEntity">Memberorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberorderdetail记录</returns>
        public DataSet GetMemberorderdetailByQueryList(Database db, DbTransaction tran, QueryEntity memberorderdetailQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERORDERDETAIL;

            if (memberorderdetailQuery != null && memberorderdetailQuery.sqlWhere != null && memberorderdetailQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberorderdetailQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberorderdetailQuery.sqlWhere[i];
                }
            }
            if (!memberorderdetailQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberorderdetailQuery.CurrentPage, memberorderdetailQuery.PageSize, memberorderdetailQuery.SortField, memberorderdetailQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Memberorderdetail的一条记录 GetMemberorderdetailByID()

        /// <summary>
        /// 根据memberorderdetailID得到一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberorderdetailID得到一条Memberorderdetail记录</returns>
        public MemberorderdetailInfo GetMemberorderdetailByID(string memberorderdetailID)
        {
            string sql = SQL_SELECT_ALL_MEMBERORDERDETAIL + " AND DETAILID = @DETAILID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", memberorderdetailID) };
            MemberorderdetailInfo memberorderdetailInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    memberorderdetailInfo = InitMemberorderdetailInfoByDataReader(memberorderdetailInfo, reader);
                }
            }

            return memberorderdetailInfo;
        }
        /// <summary>
        /// 根据memberorderdetailID得到一条Memberorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberorderdetailID得到一条Memberorderdetail记录</returns>
        public MemberorderdetailInfo GetMemberorderdetailByID(Database db, DbTransaction tran, string memberorderdetailID)
        {
            string sql = SQL_SELECT_ALL_MEMBERORDERDETAIL + " AND DETAILID = @DETAILID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", memberorderdetailID) };
            MemberorderdetailInfo memberorderdetailInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                memberorderdetailInfo = InitMemberorderdetailInfoByDataReader(memberorderdetailInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return memberorderdetailInfo;
        }
        /// <summary>
        /// 初始化MemberorderdetailInfo
        /// </summary>
        private MemberorderdetailInfo InitMemberorderdetailInfoByDataReader(MemberorderdetailInfo memberorderdetailInfo, IDataReader reader)
        {
            memberorderdetailInfo = new MemberorderdetailInfo(reader["DetailID"].ToString() != "" ? Int32.Parse(reader["DetailID"].ToString()) : 0,
reader["OrderID"].ToString() != "" ? Int32.Parse(reader["OrderID"].ToString()) : 0,
reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["Qty"].ToString() != "" ? Int32.Parse(reader["Qty"].ToString()) : 0,
reader["Price"].ToString() != "" ? Decimal.Parse(reader["Price"].ToString()) : 0,
reader["Status"].ToString(),
reader["Ts"],
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return memberorderdetailInfo;
        }
        #endregion

        #region 向Memberorderdetail增加一条记录 InsertMemberorderdetail()

        /// <summary>
        /// 新增一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorderdetail_Parameters(memberorderdetailInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_MEMBERORDERDETAIL, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Memberorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberorderdetail(Database db, DbTransaction tran, MemberorderdetailInfo memberorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorderdetail_Parameters(memberorderdetailInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_MEMBERORDERDETAIL, paras);
            }
            return result;
        }
        #endregion

        #region 删除Memberorderdetail一条记录 DeleteMemberorderdetail()

        /// <summary>
        /// 删除一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">MemberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberorderdetail(string memberorderdetailID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", memberorderdetailID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_MEMBERORDERDETAIL, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Memberorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetailID">MemberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberorderdetail(Database db, DbTransaction tran, string memberorderdetailID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", memberorderdetailID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_MEMBERORDERDETAIL, paras);
            return result;
        }
        #endregion

        #region 更新一条Memberorderdetail记录 UpdateMemberorderdetail()
        /// <summary>
        /// 更新一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorderdetail_Parameters(memberorderdetailInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_MEMBERORDERDETAIL, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Memberorderdetail记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberorderdetail(Database db, DbTransaction tran, MemberorderdetailInfo memberorderdetailInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberorderdetail_Parameters(memberorderdetailInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_MEMBERORDERDETAIL, paras);
            }
            return result;
        }
        #endregion

        #region 根据DETAILID判断此ID在表MemberOrderDetail中是否已存在

        /// <summary>
        /// 检查MemberorderdetailID是否已存在
        /// </summary>
        /// <param name="memberorderdetailID">MemberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberorderdetailIDIsExist(string memberorderdetailID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", memberorderdetailID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_MEMBERORDERDETAIL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查MemberorderdetailID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberorderdetailIDIsExist(Database db, DbTransaction tran, string memberorderdetailID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@DETAILID", memberorderdetailID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_MEMBERORDERDETAIL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Memberorderdetail_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Memberorderdetail">Memberorderdetail对象</param>
        /// <returns>Memberorderdetail参数数组</returns>
        private SqlParameter[] Set_Memberorderdetail_Parameters(MemberorderdetailInfo memberorderdetailInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@DetailID",memberorderdetailInfo.DetailID),
																new SqlParameter("@OrderID",memberorderdetailInfo.OrderID),
																new SqlParameter("@ItemID",memberorderdetailInfo.ItemID),
																new SqlParameter("@Qty",memberorderdetailInfo.Qty),
																new SqlParameter("@Price",memberorderdetailInfo.Price),
																new SqlParameter("@Status",string.IsNullOrEmpty(memberorderdetailInfo.Status)?"":memberorderdetailInfo.Status),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(memberorderdetailInfo.CreatedBy)?"":memberorderdetailInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(memberorderdetailInfo.UpdatedBy)?"":memberorderdetailInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
