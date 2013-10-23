/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberlevelDA
// 文件功能描述：提供Memberlevel数据表进行操作的一些方法
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
    public class MemberlevelDA : IMemberlevelDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Memberlevel 的所有记录
        private string SQL_SELECT_ALL_MEMBERLEVEL = "SELECT M.ID AS ID, M.LevelCode AS LevelCode, M.LevelName AS LevelName, M.Remark AS Remark, M.IsActive AS IsActive, M.CreatedBy AS CreatedBy, M.CreatedDate AS CreatedDate, M.UpdatedBy AS UpdatedBy, M.UpdatedDate AS UpdatedDate FROM MemberLevel M WHERE 1=1  ";
        //INSERT_SQL 向Memberlevel增加一条记录
        private string SQL_INSERT_MEMBERLEVEL = "INSERT INTO MemberLevel (LevelCode, LevelName, Remark, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @LevelCode, @LevelName, @Remark, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Memberlevel一条记录
        private string SQL_DELETE_MEMBERLEVEL = "DELETE FROM MemberLevel WHERE ID = @ID ";
        //UPDATE_SQL 更新Memberlevel记录
        private string SQL_UPDATE_MEMBERLEVEL = "UPDATE MemberLevel SET LevelCode = @LevelCode, LevelName = @LevelName, Remark = @Remark, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ID = @ID  ";

        //判断一个MEMBERLEVEL_ID是否已存在
        private string SQL_CHECK_MEMBERLEVEL_ID_IS_EXIST = " SELECT COUNT(1) FROM MemberLevel WHERE ID = @ID ";
        #endregion

        #region 基本方法

        #region 得到Memberlevel的所有记录

        /// <summary>
        /// 得到所有的Memberlevel记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberlevel记录</returns>
        public DataSet GetAllMemberlevel()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_MEMBERLEVEL);
        }

        /// <summary>
        /// 得到所有的Memberlevel记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberlevel记录</returns>
        public DataSet GetAllMemberlevel(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_MEMBERLEVEL);
        }

        #endregion

        #region 根据条件查询Memberlevel的记录  GetMemberlevelByQueryList()

        /// <summary>
        /// 根据查询条件得到Memberlevel记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberlevelQueryEntity">Memberlevel查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberlevel记录</returns>
        public DataSet GetMemberlevelByQueryList(QueryEntity memberlevelQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERLEVEL;

            if (memberlevelQuery != null && memberlevelQuery.sqlWhere != null && memberlevelQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberlevelQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberlevelQuery.sqlWhere[i];
                }
            }

            if (!memberlevelQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberlevelQuery.CurrentPage, memberlevelQuery.PageSize, memberlevelQuery.SortField, memberlevelQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Memberlevel记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberlevelQueryEntity">Memberlevel查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberlevel记录</returns>
        public DataSet GetMemberlevelByQueryList(Database db, DbTransaction tran, QueryEntity memberlevelQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBERLEVEL;

            if (memberlevelQuery != null && memberlevelQuery.sqlWhere != null && memberlevelQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberlevelQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberlevelQuery.sqlWhere[i];
                }
            }
            if (!memberlevelQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberlevelQuery.CurrentPage, memberlevelQuery.PageSize, memberlevelQuery.SortField, memberlevelQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Memberlevel的一条记录 GetMemberlevelByID()

        /// <summary>
        /// 根据memberlevelID得到一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberlevelID得到一条Memberlevel记录</returns>
        public MemberlevelInfo GetMemberlevelByID(string memberlevelID)
        {
            string sql = SQL_SELECT_ALL_MEMBERLEVEL + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", memberlevelID) };
            MemberlevelInfo memberlevelInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    memberlevelInfo = InitMemberlevelInfoByDataReader(memberlevelInfo, reader);
                }
            }

            return memberlevelInfo;
        }
        /// <summary>
        /// 根据memberlevelID得到一条Memberlevel记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberlevelID得到一条Memberlevel记录</returns>
        public MemberlevelInfo GetMemberlevelByID(Database db, DbTransaction tran, string memberlevelID)
        {
            string sql = SQL_SELECT_ALL_MEMBERLEVEL + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", memberlevelID) };
            MemberlevelInfo memberlevelInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                memberlevelInfo = InitMemberlevelInfoByDataReader(memberlevelInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return memberlevelInfo;
        }
        /// <summary>
        /// 初始化MemberlevelInfo
        /// </summary>
        private MemberlevelInfo InitMemberlevelInfoByDataReader(MemberlevelInfo memberlevelInfo, IDataReader reader)
        {
            memberlevelInfo = new MemberlevelInfo(reader["ID"].ToString() != "" ? Int32.Parse(reader["ID"].ToString()) : 0,
reader["LevelCode"].ToString(),
reader["LevelName"].ToString(),
reader["Remark"].ToString(),
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return memberlevelInfo;
        }
        #endregion

        #region 向Memberlevel增加一条记录 InsertMemberlevel()

        /// <summary>
        /// 新增一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberlevel(MemberlevelInfo memberlevelInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberlevel_Parameters(memberlevelInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_MEMBERLEVEL, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Memberlevel记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberlevel(Database db, DbTransaction tran, MemberlevelInfo memberlevelInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberlevel_Parameters(memberlevelInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_MEMBERLEVEL, paras);
            }
            return result;
        }
        #endregion

        #region 删除Memberlevel一条记录 DeleteMemberlevel()

        /// <summary>
        /// 删除一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevelID">MemberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberlevel(string memberlevelID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", memberlevelID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_MEMBERLEVEL, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Memberlevel记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberlevelID">MemberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberlevel(Database db, DbTransaction tran, string memberlevelID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", memberlevelID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_MEMBERLEVEL, paras);
            return result;
        }
        #endregion

        #region 更新一条Memberlevel记录 UpdateMemberlevel()
        /// <summary>
        /// 更新一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberlevel(MemberlevelInfo memberlevelInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberlevel_Parameters(memberlevelInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_MEMBERLEVEL, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Memberlevel记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberlevel(Database db, DbTransaction tran, MemberlevelInfo memberlevelInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Memberlevel_Parameters(memberlevelInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_MEMBERLEVEL, paras);
            }
            return result;
        }
        #endregion

        #region 根据ID判断此ID在表MemberLevel中是否已存在

        /// <summary>
        /// 检查MemberlevelID是否已存在
        /// </summary>
        /// <param name="memberlevelID">MemberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberlevelIDIsExist(string memberlevelID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", memberlevelID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_MEMBERLEVEL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查MemberlevelID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberlevelIDIsExist(Database db, DbTransaction tran, string memberlevelID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", memberlevelID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_MEMBERLEVEL_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Memberlevel_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Memberlevel">Memberlevel对象</param>
        /// <returns>Memberlevel参数数组</returns>
        private SqlParameter[] Set_Memberlevel_Parameters(MemberlevelInfo memberlevelInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ID",memberlevelInfo.ID),
																new SqlParameter("@LevelCode",memberlevelInfo.LevelCode),
																new SqlParameter("@LevelName",memberlevelInfo.LevelName),
																new SqlParameter("@Remark",string.IsNullOrEmpty(memberlevelInfo.Remark)?"":memberlevelInfo.Remark),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(memberlevelInfo.IsActive)?"":memberlevelInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(memberlevelInfo.CreatedBy)?"":memberlevelInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(memberlevelInfo.UpdatedBy)?"":memberlevelInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
