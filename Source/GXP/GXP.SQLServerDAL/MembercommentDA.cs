/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MembercommentDA
// 文件功能描述：提供Membercomment数据表进行操作的一些方法
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
    public class MembercommentDA : IMembercommentDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Membercomment 的所有记录
        private string SQL_SELECT_ALL_MEMBERCOMMENT = "SELECT M.CommentID AS CommentID, M.ItemID AS ItemID, M.Title AS Title, M.Content AS Content, M.CommentPoints AS CommentPoints, M.IsActive AS IsActive, M.CreatedBy AS CreatedBy, M.CreatedDate AS CreatedDate, M.UpdatedBy AS UpdatedBy, M.UpdatedDate AS UpdatedDate FROM MemberComment M WHERE 1=1  ";
        //INSERT_SQL 向Membercomment增加一条记录
        private string SQL_INSERT_MEMBERCOMMENT = "INSERT INTO MemberComment ( ItemID, Title, Content, CommentPoints, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @ItemID, @Title, @Content, @CommentPoints, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Membercomment一条记录
        private string SQL_DELETE_MEMBERCOMMENT = "DELETE FROM MemberComment WHERE COMMENTID = @COMMENTID ";
        //UPDATE_SQL 更新Membercomment记录
        private string SQL_UPDATE_MEMBERCOMMENT = "UPDATE MemberComment SET ItemID = @ItemID, Title = @Title, Content = @Content, CommentPoints = @CommentPoints, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE COMMENTID = @COMMENTID  ";

        //判断一个MEMBERCOMMENT_ID是否已存在
        private string SQL_CHECK_MEMBERCOMMENT_ID_IS_EXIST = " SELECT COUNT(1) FROM MemberComment WHERE COMMENTID = @COMMENTID ";
        #endregion

        #region 基本方法

        #region 得到Membercomment的所有记录

        /// <summary>
        /// 得到所有的Membercomment记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Membercomment记录</returns>
        public DataSet GetAllMembercomment()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_MEMBERCOMMENT);
        }

        /// <summary>
        /// 得到所有的Membercomment记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Membercomment记录</returns>
        public DataSet GetAllMembercomment(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_MEMBERCOMMENT);
        }

        #endregion

        #region 根据条件查询Membercomment的记录  GetMembercommentByQueryList()

        /// <summary>
        /// 根据查询条件得到Membercomment记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MembercommentQueryEntity">Membercomment查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Membercomment记录</returns>
        public DataSet GetMembercommentByQueryList(QueryEntity membercommentQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERCOMMENT;

            if (membercommentQuery != null && membercommentQuery.sqlWhere != null && membercommentQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < membercommentQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + membercommentQuery.sqlWhere[i];
                }
            }

            if (!membercommentQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, membercommentQuery.CurrentPage, membercommentQuery.PageSize, membercommentQuery.SortField, membercommentQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Membercomment记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MembercommentQueryEntity">Membercomment查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Membercomment记录</returns>
        public DataSet GetMembercommentByQueryList(Database db, DbTransaction tran, QueryEntity membercommentQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERCOMMENT;

            if (membercommentQuery != null && membercommentQuery.sqlWhere != null && membercommentQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < membercommentQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + membercommentQuery.sqlWhere[i];
                }
            }
            if (!membercommentQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, membercommentQuery.CurrentPage, membercommentQuery.PageSize, membercommentQuery.SortField, membercommentQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Membercomment的一条记录 GetMembercommentByID()

        /// <summary>
        /// 根据membercommentID得到一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据membercommentID得到一条Membercomment记录</returns>
        public MembercommentInfo GetMembercommentByID(string membercommentID)
        {
            string sql = SQL_SELECT_ALL_MEMBERCOMMENT + " AND COMMENTID = @COMMENTID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@COMMENTID", membercommentID) };
            MembercommentInfo membercommentInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    membercommentInfo = InitMembercommentInfoByDataReader(membercommentInfo, reader);
                }
            }

            return membercommentInfo;
        }
        /// <summary>
        /// 根据membercommentID得到一条Membercomment记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercommentID">membercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据membercommentID得到一条Membercomment记录</returns>
        public MembercommentInfo GetMembercommentByID(Database db, DbTransaction tran, string membercommentID)
        {
            string sql = SQL_SELECT_ALL_MEMBERCOMMENT + " AND COMMENTID = @COMMENTID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@COMMENTID", membercommentID) };
            MembercommentInfo membercommentInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                membercommentInfo = InitMembercommentInfoByDataReader(membercommentInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return membercommentInfo;
        }
        /// <summary>
        /// 初始化MembercommentInfo
        /// </summary>
        private MembercommentInfo InitMembercommentInfoByDataReader(MembercommentInfo membercommentInfo, IDataReader reader)
        {
            membercommentInfo = new MembercommentInfo(reader["CommentID"].ToString() != "" ? Int32.Parse(reader["CommentID"].ToString()) : 0,
reader["ItemID"].ToString() != "" ? Int32.Parse(reader["ItemID"].ToString()) : 0,
reader["Title"].ToString(),
reader["Content"].ToString(),
reader["CommentPoints"].ToString() != "" ? Int32.Parse(reader["CommentPoints"].ToString()) : 0,
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return membercommentInfo;
        }
        #endregion

        #region 向Membercomment增加一条记录 InsertMembercomment()

        /// <summary>
        /// 新增一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMembercomment(MembercommentInfo membercommentInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Membercomment_Parameters(membercommentInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_MEMBERCOMMENT, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Membercomment记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercomment">Membercomment对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMembercomment(Database db, DbTransaction tran, MembercommentInfo membercommentInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Membercomment_Parameters(membercommentInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_MEMBERCOMMENT, paras);
            }
            return result;
        }
        #endregion

        #region 删除Membercomment一条记录 DeleteMembercomment()

        /// <summary>
        /// 删除一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">MembercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMembercomment(string membercommentID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@COMMENTID", membercommentID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_MEMBERCOMMENT, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Membercomment记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercommentID">MembercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMembercomment(Database db, DbTransaction tran, string membercommentID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@COMMENTID", membercommentID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_MEMBERCOMMENT, paras);
            return result;
        }
        #endregion

        #region 更新一条Membercomment记录 UpdateMembercomment()
        /// <summary>
        /// 更新一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMembercomment(MembercommentInfo membercommentInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Membercomment_Parameters(membercommentInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_MEMBERCOMMENT, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Membercomment记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercomment">Membercomment对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMembercomment(Database db, DbTransaction tran, MembercommentInfo membercommentInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Membercomment_Parameters(membercommentInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_MEMBERCOMMENT, paras);
            }
            return result;
        }
        #endregion

        #region 根据COMMENTID判断此ID在表MemberComment中是否已存在

        /// <summary>
        /// 检查MembercommentID是否已存在
        /// </summary>
        /// <param name="membercommentID">MembercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMembercommentIDIsExist(string membercommentID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@COMMENTID", membercommentID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_MEMBERCOMMENT_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查MembercommentID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercommentID">membercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMembercommentIDIsExist(Database db, DbTransaction tran, string membercommentID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@COMMENTID", membercommentID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_MEMBERCOMMENT_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Membercomment_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Membercomment">Membercomment对象</param>
        /// <returns>Membercomment参数数组</returns>
        private SqlParameter[] Set_Membercomment_Parameters(MembercommentInfo membercommentInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@CommentID",membercommentInfo.CommentID),
																new SqlParameter("@ItemID",membercommentInfo.ItemID),
																new SqlParameter("@Title",string.IsNullOrEmpty(membercommentInfo.Title)?"":membercommentInfo.Title),
																new SqlParameter("@Content",string.IsNullOrEmpty(membercommentInfo.Content)?"":membercommentInfo.Content),
																new SqlParameter("@CommentPoints",membercommentInfo.CommentPoints),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(membercommentInfo.IsActive)?"":membercommentInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(membercommentInfo.CreatedBy)?"":membercommentInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(membercommentInfo.UpdatedBy)?"":membercommentInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
