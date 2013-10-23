/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：FunctiongroupDA
// 文件功能描述：提供Functiongroup数据表进行操作的一些方法
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
    public class FunctiongroupDA : IFunctiongroupDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Functiongroup 的所有记录
        private string SQL_SELECT_ALL_FUNCTIONGROUP = "SELECT F.FunctionID AS FunctionID, F.ParentID AS ParentID, F.FunctionName AS FunctionName, F.SeqNo AS SeqNo, F.GroupLevel AS GroupLevel, F.Url AS Url, F.PageID AS PageID, F.PageName AS PageName, F.IsActive AS IsActive, F.UDF01 AS UDF01, F.UDF02 AS UDF02, F.UDF03 AS UDF03, F.UDF04 AS UDF04, F.UDF05 AS UDF05 FROM FunctionGroup F WHERE 1=1  ";
        //INSERT_SQL 向Functiongroup增加一条记录
        private string SQL_INSERT_FUNCTIONGROUP = "INSERT INTO FunctionGroup ( FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05) VALUES ( @FunctionID, @ParentID, @FunctionName, @SeqNo, @GroupLevel, @Url, @PageID, @PageName, @IsActive, @UDF01, @UDF02, @UDF03, @UDF04, @UDF05)  ";
        //DELETE_SQL  删除Functiongroup一条记录
        private string SQL_DELETE_FUNCTIONGROUP = "DELETE FROM FunctionGroup WHERE FUNCTIONID = @FUNCTIONID ";
        //UPDATE_SQL 更新Functiongroup记录
        private string SQL_UPDATE_FUNCTIONGROUP = "UPDATE FunctionGroup SET ParentID = @ParentID, FunctionName = @FunctionName, SeqNo = @SeqNo, GroupLevel = @GroupLevel, Url = @Url, PageID = @PageID, PageName = @PageName, IsActive = @IsActive, UDF01 = @UDF01, UDF02 = @UDF02, UDF03 = @UDF03, UDF04 = @UDF04, UDF05 = @UDF05 WHERE FUNCTIONID = @FUNCTIONID  ";

        //判断一个FUNCTIONGROUP_ID是否已存在
        private string SQL_CHECK_FUNCTIONGROUP_ID_IS_EXIST = " SELECT COUNT(1) FROM FunctionGroup WHERE FUNCTIONID = @FUNCTIONID ";
        #endregion

        #region 基本方法

        #region 得到Functiongroup的所有记录

        /// <summary>
        /// 得到所有的Functiongroup记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Functiongroup记录</returns>
        public DataSet GetAllFunctiongroup()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_FUNCTIONGROUP);
        }

        /// <summary>
        /// 得到所有的Functiongroup记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Functiongroup记录</returns>
        public DataSet GetAllFunctiongroup(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_FUNCTIONGROUP);
        }

        #endregion

        #region 根据条件查询Functiongroup的记录  GetFunctiongroupByQueryList()

        /// <summary>
        /// 根据查询条件得到Functiongroup记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="FunctiongroupQueryEntity">Functiongroup查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Functiongroup记录</returns>
        public DataSet GetFunctiongroupByQueryList(QueryEntity functiongroupQuery)
        {
            string temp = SQL_SELECT_ALL_FUNCTIONGROUP;

            if (functiongroupQuery != null && functiongroupQuery.sqlWhere != null && functiongroupQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < functiongroupQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + functiongroupQuery.sqlWhere[i];
                }
            }

            if (!functiongroupQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, functiongroupQuery.CurrentPage, functiongroupQuery.PageSize, functiongroupQuery.SortField, functiongroupQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Functiongroup记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="FunctiongroupQueryEntity">Functiongroup查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Functiongroup记录</returns>
        public DataSet GetFunctiongroupByQueryList(Database db, DbTransaction tran, QueryEntity functiongroupQuery)
        {
            string temp = SQL_SELECT_ALL_FUNCTIONGROUP;

            if (functiongroupQuery != null && functiongroupQuery.sqlWhere != null && functiongroupQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < functiongroupQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + functiongroupQuery.sqlWhere[i];
                }
            }
            if (!functiongroupQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, functiongroupQuery.CurrentPage, functiongroupQuery.PageSize, functiongroupQuery.SortField, functiongroupQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Functiongroup的一条记录 GetFunctiongroupByID()

        /// <summary>
        /// 根据functiongroupID得到一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据functiongroupID得到一条Functiongroup记录</returns>
        public FunctiongroupInfo GetFunctiongroupByID(string functiongroupID)
        {
            string sql = SQL_SELECT_ALL_FUNCTIONGROUP + " AND FUNCTIONID = @FUNCTIONID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@FUNCTIONID", functiongroupID) };
            FunctiongroupInfo functiongroupInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    functiongroupInfo = InitFunctiongroupInfoByDataReader(functiongroupInfo, reader);
                }
            }

            return functiongroupInfo;
        }
        /// <summary>
        /// 根据functiongroupID得到一条Functiongroup记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据functiongroupID得到一条Functiongroup记录</returns>
        public FunctiongroupInfo GetFunctiongroupByID(Database db, DbTransaction tran, string functiongroupID)
        {
            string sql = SQL_SELECT_ALL_FUNCTIONGROUP + " AND FUNCTIONID = @FUNCTIONID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@FUNCTIONID", functiongroupID) };
            FunctiongroupInfo functiongroupInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                functiongroupInfo = InitFunctiongroupInfoByDataReader(functiongroupInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return functiongroupInfo;
        }
        /// <summary>
        /// 初始化FunctiongroupInfo
        /// </summary>
        private FunctiongroupInfo InitFunctiongroupInfoByDataReader(FunctiongroupInfo functiongroupInfo, IDataReader reader)
        {
            functiongroupInfo = new FunctiongroupInfo(reader["FunctionID"].ToString() != "" ? Int32.Parse(reader["FunctionID"].ToString()) : 0,
reader["ParentID"].ToString(),
reader["FunctionName"].ToString(),
reader["SeqNo"].ToString() != "" ? Int32.Parse(reader["SeqNo"].ToString()) : 0,
reader["GroupLevel"].ToString() != "" ? Int32.Parse(reader["GroupLevel"].ToString()) : 0,
reader["Url"].ToString(),
reader["PageID"].ToString(),
reader["PageName"].ToString(),
reader["IsActive"].ToString(),
reader["UDF01"].ToString(),
reader["UDF02"].ToString(),
reader["UDF03"].ToString(),
reader["UDF04"].ToString(),
reader["UDF05"].ToString());
            return functiongroupInfo;
        }
        #endregion

        #region 向Functiongroup增加一条记录 InsertFunctiongroup()

        /// <summary>
        /// 新增一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertFunctiongroup(FunctiongroupInfo functiongroupInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Functiongroup_Parameters(functiongroupInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_FUNCTIONGROUP, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Functiongroup记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertFunctiongroup(Database db, DbTransaction tran, FunctiongroupInfo functiongroupInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Functiongroup_Parameters(functiongroupInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_FUNCTIONGROUP, paras);
            }
            return result;
        }
        #endregion

        #region 删除Functiongroup一条记录 DeleteFunctiongroup()

        /// <summary>
        /// 删除一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroupID">FunctiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteFunctiongroup(string functiongroupID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@FUNCTIONID", functiongroupID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_FUNCTIONGROUP, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Functiongroup记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="functiongroupID">FunctiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteFunctiongroup(Database db, DbTransaction tran, string functiongroupID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@FUNCTIONID", functiongroupID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_FUNCTIONGROUP, paras);
            return result;
        }
        #endregion

        #region 更新一条Functiongroup记录 UpdateFunctiongroup()
        /// <summary>
        /// 更新一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateFunctiongroup(FunctiongroupInfo functiongroupInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Functiongroup_Parameters(functiongroupInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_FUNCTIONGROUP, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Functiongroup记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateFunctiongroup(Database db, DbTransaction tran, FunctiongroupInfo functiongroupInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Functiongroup_Parameters(functiongroupInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_FUNCTIONGROUP, paras);
            }
            return result;
        }
        #endregion

        #region 根据FUNCTIONID判断此ID在表FunctionGroup中是否已存在

        /// <summary>
        /// 检查FunctiongroupID是否已存在
        /// </summary>
        /// <param name="functiongroupID">FunctiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckFunctiongroupIDIsExist(string functiongroupID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@FUNCTIONID", functiongroupID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_FUNCTIONGROUP_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查FunctiongroupID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckFunctiongroupIDIsExist(Database db, DbTransaction tran, string functiongroupID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@FUNCTIONID", functiongroupID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_FUNCTIONGROUP_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Functiongroup_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Functiongroup">Functiongroup对象</param>
        /// <returns>Functiongroup参数数组</returns>
        private SqlParameter[] Set_Functiongroup_Parameters(FunctiongroupInfo functiongroupInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@FunctionID",functiongroupInfo.FunctionID),
																new SqlParameter("@ParentID",string.IsNullOrEmpty(functiongroupInfo.ParentID)?"":functiongroupInfo.ParentID),
																new SqlParameter("@FunctionName",string.IsNullOrEmpty(functiongroupInfo.FunctionName)?"":functiongroupInfo.FunctionName),
																new SqlParameter("@SeqNo",functiongroupInfo.SeqNo),
																new SqlParameter("@GroupLevel",functiongroupInfo.GroupLevel),
																new SqlParameter("@Url",string.IsNullOrEmpty(functiongroupInfo.Url)?"":functiongroupInfo.Url),
																new SqlParameter("@PageID",string.IsNullOrEmpty(functiongroupInfo.PageID)?"":functiongroupInfo.PageID),
																new SqlParameter("@PageName",string.IsNullOrEmpty(functiongroupInfo.PageName)?"":functiongroupInfo.PageName),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(functiongroupInfo.IsActive)?"":functiongroupInfo.IsActive),
																new SqlParameter("@UDF01",string.IsNullOrEmpty(functiongroupInfo.UDF01)?"":functiongroupInfo.UDF01),
																new SqlParameter("@UDF02",string.IsNullOrEmpty(functiongroupInfo.UDF02)?"":functiongroupInfo.UDF02),
																new SqlParameter("@UDF03",string.IsNullOrEmpty(functiongroupInfo.UDF03)?"":functiongroupInfo.UDF03),
																new SqlParameter("@UDF04",string.IsNullOrEmpty(functiongroupInfo.UDF04)?"":functiongroupInfo.UDF04),
																new SqlParameter("@UDF05",string.IsNullOrEmpty(functiongroupInfo.UDF05)?"":functiongroupInfo.UDF05)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        public DataSet GetFunctionGroupByRoleID(int roleID)
        {
            string sql = string.Format("SELECT FG.*,RF.FunctionID as checked_functionID FROM FunctionGroup FG LEFT JOIN RoleFunction RF ON FG.FunctionID=RF.FunctionID AND RF.RoleID='{0}'", roleID);
            return DBHelper.ExecuteDataSet(CommandType.Text, sql);
        }

        public DataSet GetFunctionGroupByUserID(int userID)
        {
            string sql = string.Format("SELECT FG.*,RF.FunctionID as checked_functionID FROM FunctionGroup FG LEFT JOIN RoleFunction RF ON FG.FunctionID=RF.FunctionID LEFT JOIN UserRole UR ON UR.RoleID = RF.RoleID WHERE UR.UserID='{0}'", userID);
            return DBHelper.ExecuteDataSet(CommandType.Text, sql);        
        }

        #endregion
    }
}
