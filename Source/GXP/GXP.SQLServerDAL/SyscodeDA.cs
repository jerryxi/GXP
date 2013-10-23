/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SyscodeDA
// 文件功能描述：提供Syscode数据表进行操作的一些方法
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
    public class SyscodeDA : ISyscodeDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Syscode 的所有记录
        private string SQL_SELECT_ALL_SYSCODE = "SELECT S.CodeID AS CodeID, S.GroupID AS GroupID, S.CodeName AS CodeName, S.SeqNo AS SeqNo, S.IsActive AS IsActive, S.CreatedBy AS CreatedBy, S.CreatedDate AS CreatedDate, S.UpdatedBy AS UpdatedBy, S.UpdatedDate AS UpdatedDate FROM SysCode S WHERE 1=1  ";
        //INSERT_SQL 向Syscode增加一条记录
        private string SQL_INSERT_SYSCODE = "INSERT INTO SysCode ( GroupID, CodeName, SeqNo, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES (  @GroupID, @CodeName, @SeqNo, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Syscode一条记录
        private string SQL_DELETE_SYSCODE = "DELETE FROM SysCode WHERE CODEID = @CODEID ";
        //UPDATE_SQL 更新Syscode记录
        private string SQL_UPDATE_SYSCODE = "UPDATE SysCode SET GroupID = @GroupID, CodeName = @CodeName, SeqNo = @SeqNo, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE CODEID = @CODEID  ";

        //判断一个SYSCODE_ID是否已存在
        private string SQL_CHECK_SYSCODE_ID_IS_EXIST = " SELECT COUNT(1) FROM SysCode WHERE CODEID = @CODEID ";
        #endregion

        #region 基本方法

        #region 得到Syscode的所有记录

        /// <summary>
        /// 得到所有的Syscode记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Syscode记录</returns>
        public DataSet GetAllSyscode()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_SYSCODE);
        }

        /// <summary>
        /// 得到所有的Syscode记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Syscode记录</returns>
        public DataSet GetAllSyscode(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_SYSCODE);
        }

        #endregion

        #region 根据条件查询Syscode的记录  GetSyscodeByQueryList()

        /// <summary>
        /// 根据查询条件得到Syscode记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyscodeQueryEntity">Syscode查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Syscode记录</returns>
        public DataSet GetSyscodeByQueryList(QueryEntity syscodeQuery)
        {
            string temp = SQL_SELECT_ALL_SYSCODE;

            if (syscodeQuery != null && syscodeQuery.sqlWhere != null && syscodeQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < syscodeQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + syscodeQuery.sqlWhere[i];
                }
            }

            if (!syscodeQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, syscodeQuery.CurrentPage, syscodeQuery.PageSize, syscodeQuery.SortField, syscodeQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Syscode记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyscodeQueryEntity">Syscode查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Syscode记录</returns>
        public DataSet GetSyscodeByQueryList(Database db, DbTransaction tran, QueryEntity syscodeQuery)
        {
            string temp = SQL_SELECT_ALL_SYSCODE;

            if (syscodeQuery != null && syscodeQuery.sqlWhere != null && syscodeQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < syscodeQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + syscodeQuery.sqlWhere[i];
                }
            }
            if (!syscodeQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, syscodeQuery.CurrentPage, syscodeQuery.PageSize, syscodeQuery.SortField, syscodeQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Syscode的一条记录 GetSyscodeByID()

        /// <summary>
        /// 根据syscodeID得到一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据syscodeID得到一条Syscode记录</returns>
        public SyscodeInfo GetSyscodeByID(string syscodeID)
        {
            string sql = SQL_SELECT_ALL_SYSCODE + " AND CODEID = @CODEID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CODEID", syscodeID) };
            SyscodeInfo syscodeInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    syscodeInfo = InitSyscodeInfoByDataReader(syscodeInfo, reader);
                }
            }

            return syscodeInfo;
        }
        /// <summary>
        /// 根据syscodeID得到一条Syscode记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscodeID">syscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据syscodeID得到一条Syscode记录</returns>
        public SyscodeInfo GetSyscodeByID(Database db, DbTransaction tran, string syscodeID)
        {
            string sql = SQL_SELECT_ALL_SYSCODE + " AND CODEID = @CODEID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CODEID", syscodeID) };
            SyscodeInfo syscodeInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                syscodeInfo = InitSyscodeInfoByDataReader(syscodeInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return syscodeInfo;
        }
        /// <summary>
        /// 初始化SyscodeInfo
        /// </summary>
        private SyscodeInfo InitSyscodeInfoByDataReader(SyscodeInfo syscodeInfo, IDataReader reader)
        {
            syscodeInfo = new SyscodeInfo(reader["CodeID"].ToString() != "" ? Int32.Parse(reader["CodeID"].ToString()) : 0,
reader["GroupID"].ToString(),
reader["CodeName"].ToString(),
reader["SeqNo"].ToString() != "" ? Int32.Parse(reader["SeqNo"].ToString()) : 0,
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return syscodeInfo;
        }
        #endregion

        #region 向Syscode增加一条记录 InsertSyscode()

        /// <summary>
        /// 新增一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSyscode(SyscodeInfo syscodeInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syscode_Parameters(syscodeInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_SYSCODE, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Syscode记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscode">Syscode对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSyscode(Database db, DbTransaction tran, SyscodeInfo syscodeInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syscode_Parameters(syscodeInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_SYSCODE, paras);
            }
            return result;
        }
        #endregion

        #region 删除Syscode一条记录 DeleteSyscode()

        /// <summary>
        /// 删除一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">SyscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSyscode(string syscodeID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CODEID", syscodeID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_SYSCODE, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Syscode记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscodeID">SyscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSyscode(Database db, DbTransaction tran, string syscodeID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CODEID", syscodeID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_SYSCODE, paras);
            return result;
        }
        #endregion

        #region 更新一条Syscode记录 UpdateSyscode()
        /// <summary>
        /// 更新一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSyscode(SyscodeInfo syscodeInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syscode_Parameters(syscodeInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_SYSCODE, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Syscode记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscode">Syscode对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSyscode(Database db, DbTransaction tran, SyscodeInfo syscodeInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syscode_Parameters(syscodeInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_SYSCODE, paras);
            }
            return result;
        }
        #endregion

        #region 根据CODEID判断此ID在表SysCode中是否已存在

        /// <summary>
        /// 检查SyscodeID是否已存在
        /// </summary>
        /// <param name="syscodeID">SyscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSyscodeIDIsExist(string syscodeID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CODEID", syscodeID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_SYSCODE_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查SyscodeID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscodeID">syscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSyscodeIDIsExist(Database db, DbTransaction tran, string syscodeID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@CODEID", syscodeID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_SYSCODE_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Syscode_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Syscode">Syscode对象</param>
        /// <returns>Syscode参数数组</returns>
        private SqlParameter[] Set_Syscode_Parameters(SyscodeInfo syscodeInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@CodeID",syscodeInfo.CodeID),
																new SqlParameter("@GroupID",syscodeInfo.GroupID),
																new SqlParameter("@CodeName",syscodeInfo.CodeName),
																new SqlParameter("@SeqNo",syscodeInfo.SeqNo),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(syscodeInfo.IsActive)?"":syscodeInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(syscodeInfo.CreatedBy)?"":syscodeInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(syscodeInfo.UpdatedBy)?"":syscodeInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
