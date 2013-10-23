/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：OperationlogDA
// 文件功能描述：提供Operationlog数据表进行操作的一些方法
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
    public class OperationlogDA : IOperationlogDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Operationlog 的所有记录
        private string SQL_SELECT_ALL_OPERATIONLOG = "SELECT O.Indx AS Indx, O.LogDate AS LogDate, O.UserCode AS UserCode, O.UserName AS UserName, O.Content AS Content, O.GroupName AS GroupName, O.IsSuccess AS IsSuccess, O.UDF01 AS UDF01, O.UDF02 AS UDF02, O.UDF03 AS UDF03, O.UDF04 AS UDF04, O.UDF05 AS UDF05 FROM OperationLog O WHERE 1=1  ";
        //INSERT_SQL 向Operationlog增加一条记录
        private string SQL_INSERT_OPERATIONLOG = "INSERT INTO OperationLog ( Indx, LogDate, UserCode, UserName, Content, GroupName, IsSuccess, UDF01, UDF02, UDF03, UDF04, UDF05) VALUES ( @Indx, @LogDate, @UserCode, @UserName, @Content, @GroupName, @IsSuccess, @UDF01, @UDF02, @UDF03, @UDF04, @UDF05)  ";
        //DELETE_SQL  删除Operationlog一条记录
        private string SQL_DELETE_OPERATIONLOG = "DELETE FROM OperationLog WHERE INDX = @INDX ";
        //UPDATE_SQL 更新Operationlog记录
        private string SQL_UPDATE_OPERATIONLOG = "UPDATE OperationLog SET LogDate = @LogDate, UserCode = @UserCode, UserName = @UserName, Content = @Content, GroupName = @GroupName, IsSuccess = @IsSuccess, UDF01 = @UDF01, UDF02 = @UDF02, UDF03 = @UDF03, UDF04 = @UDF04, UDF05 = @UDF05 WHERE INDX = @INDX  ";

        //判断一个OPERATIONLOG_ID是否已存在
        private string SQL_CHECK_OPERATIONLOG_ID_IS_EXIST = " SELECT COUNT(1) FROM OperationLog WHERE INDX = @INDX ";
        #endregion

        #region 基本方法

        #region 得到Operationlog的所有记录

        /// <summary>
        /// 得到所有的Operationlog记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Operationlog记录</returns>
        public DataSet GetAllOperationlog()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_OPERATIONLOG);
        }

        /// <summary>
        /// 得到所有的Operationlog记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Operationlog记录</returns>
        public DataSet GetAllOperationlog(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_OPERATIONLOG);
        }

        #endregion

        #region 根据条件查询Operationlog的记录  GetOperationlogByQueryList()

        /// <summary>
        /// 根据查询条件得到Operationlog记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="OperationlogQueryEntity">Operationlog查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Operationlog记录</returns>
        public DataSet GetOperationlogByQueryList(QueryEntity operationlogQuery)
        {
            string temp = SQL_SELECT_ALL_OPERATIONLOG;

            if (operationlogQuery != null && operationlogQuery.sqlWhere != null && operationlogQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < operationlogQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + operationlogQuery.sqlWhere[i];
                }
            }

            if (!operationlogQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, operationlogQuery.CurrentPage, operationlogQuery.PageSize, operationlogQuery.SortField, operationlogQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Operationlog记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="OperationlogQueryEntity">Operationlog查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Operationlog记录</returns>
        public DataSet GetOperationlogByQueryList(Database db, DbTransaction tran, QueryEntity operationlogQuery)
        {
            string temp = SQL_SELECT_ALL_OPERATIONLOG;

            if (operationlogQuery != null && operationlogQuery.sqlWhere != null && operationlogQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < operationlogQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + operationlogQuery.sqlWhere[i];
                }
            }
            if (!operationlogQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, operationlogQuery.CurrentPage, operationlogQuery.PageSize, operationlogQuery.SortField, operationlogQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Operationlog的一条记录 GetOperationlogByID()

        /// <summary>
        /// 根据operationlogID得到一条Operationlog记录
        /// </summary>
        /// <param name="operationlogID">operationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据operationlogID得到一条Operationlog记录</returns>
        public OperationlogInfo GetOperationlogByID(string operationlogID)
        {
            string sql = SQL_SELECT_ALL_OPERATIONLOG + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", operationlogID) };
            OperationlogInfo operationlogInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    operationlogInfo = InitOperationlogInfoByDataReader(operationlogInfo, reader);
                }
            }

            return operationlogInfo;
        }
        /// <summary>
        /// 根据operationlogID得到一条Operationlog记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlogID">operationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据operationlogID得到一条Operationlog记录</returns>
        public OperationlogInfo GetOperationlogByID(Database db, DbTransaction tran, string operationlogID)
        {
            string sql = SQL_SELECT_ALL_OPERATIONLOG + " AND INDX = @INDX  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", operationlogID) };
            OperationlogInfo operationlogInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                operationlogInfo = InitOperationlogInfoByDataReader(operationlogInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return operationlogInfo;
        }
        /// <summary>
        /// 初始化OperationlogInfo
        /// </summary>
        private OperationlogInfo InitOperationlogInfoByDataReader(OperationlogInfo operationlogInfo, IDataReader reader)
        {
            operationlogInfo = new OperationlogInfo(reader["Indx"].ToString() != "" ? Decimal.Parse(reader["Indx"].ToString()) : 0,
reader["LogDate"].ToString() != "" ? DateTime.Parse(reader["LogDate"].ToString()) : new DateTime(),
reader["UserCode"].ToString(),
reader["UserName"].ToString(),
reader["Content"].ToString(),
reader["GroupName"].ToString(),
reader["IsSuccess"].ToString(),
reader["UDF01"].ToString(),
reader["UDF02"].ToString(),
reader["UDF03"].ToString(),
reader["UDF04"].ToString(),
reader["UDF05"].ToString());
            return operationlogInfo;
        }
        #endregion

        #region 向Operationlog增加一条记录 InsertOperationlog()

        /// <summary>
        /// 新增一条Operationlog记录
        /// </summary>
        /// <param name="operationlog">Operationlog对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertOperationlog(OperationlogInfo operationlogInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Operationlog_Parameters(operationlogInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_OPERATIONLOG, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Operationlog记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlog">Operationlog对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertOperationlog(Database db, DbTransaction tran, OperationlogInfo operationlogInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Operationlog_Parameters(operationlogInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_OPERATIONLOG, paras);
            }
            return result;
        }
        #endregion

        #region 删除Operationlog一条记录 DeleteOperationlog()

        /// <summary>
        /// 删除一条Operationlog记录
        /// </summary>
        /// <param name="operationlogID">OperationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteOperationlog(string operationlogID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", operationlogID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_OPERATIONLOG, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Operationlog记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlogID">OperationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteOperationlog(Database db, DbTransaction tran, string operationlogID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", operationlogID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_OPERATIONLOG, paras);
            return result;
        }
        #endregion

        #region 更新一条Operationlog记录 UpdateOperationlog()
        /// <summary>
        /// 更新一条Operationlog记录
        /// </summary>
        /// <param name="operationlog">Operationlog对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateOperationlog(OperationlogInfo operationlogInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Operationlog_Parameters(operationlogInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_OPERATIONLOG, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Operationlog记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlog">Operationlog对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateOperationlog(Database db, DbTransaction tran, OperationlogInfo operationlogInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Operationlog_Parameters(operationlogInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_OPERATIONLOG, paras);
            }
            return result;
        }
        #endregion

        #region 根据INDX判断此ID在表OperationLog中是否已存在

        /// <summary>
        /// 检查OperationlogID是否已存在
        /// </summary>
        /// <param name="operationlogID">OperationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckOperationlogIDIsExist(string operationlogID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", operationlogID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_OPERATIONLOG_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查OperationlogID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlogID">operationlogID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckOperationlogIDIsExist(Database db, DbTransaction tran, string operationlogID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@INDX", operationlogID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_OPERATIONLOG_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Operationlog_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Operationlog">Operationlog对象</param>
        /// <returns>Operationlog参数数组</returns>
        private SqlParameter[] Set_Operationlog_Parameters(OperationlogInfo operationlogInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@Indx",operationlogInfo.Indx),
																new SqlParameter("@LogDate",operationlogInfo.LogDate),
																new SqlParameter("@UserCode",operationlogInfo.UserCode),
																new SqlParameter("@UserName",operationlogInfo.UserName),
																new SqlParameter("@Content",string.IsNullOrEmpty(operationlogInfo.Content)?"":operationlogInfo.Content),
																new SqlParameter("@GroupName",operationlogInfo.GroupName),
																new SqlParameter("@IsSuccess",operationlogInfo.IsSuccess),
																new SqlParameter("@UDF01",operationlogInfo.UDF01),
																new SqlParameter("@UDF02",operationlogInfo.UDF02),
																new SqlParameter("@UDF03",operationlogInfo.UDF03),
																new SqlParameter("@UDF04",operationlogInfo.UDF04),
																new SqlParameter("@UDF05",operationlogInfo.UDF05)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
