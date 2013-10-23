/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SyssettingDA
// 文件功能描述：提供Syssetting数据表进行操作的一些方法
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
    public class SyssettingDA : ISyssettingDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Syssetting 的所有记录
        private string SQL_SELECT_ALL_SYSSETTING = "SELECT S.SysSettingID AS SysSettingID, S.Description AS Description, S.Value AS Value, S.DefaultValue AS DefaultValue, S.CreatedBy AS CreatedBy, S.CreatedDate AS CreatedDate, S.UpdatedBy AS UpdatedBy, S.UpdatedDate AS UpdatedDate FROM SysSetting S WHERE 1=1  ";
        //INSERT_SQL 向Syssetting增加一条记录
        private string SQL_INSERT_SYSSETTING = "INSERT INTO SysSetting ( SysSettingID, Description, Value, DefaultValue, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @SysSettingID, @Description, @Value, @DefaultValue, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Syssetting一条记录
        private string SQL_DELETE_SYSSETTING = "DELETE FROM SysSetting WHERE SysSettingID = @SysSettingID ";
        //UPDATE_SQL 更新Syssetting记录
        private string SQL_UPDATE_SYSSETTING = "UPDATE SysSetting SET Description = @Description, Value = @Value, DefaultValue = @DefaultValue, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE SysSettingID = @SysSettingID  ";

        //判断一个SYSSETTING_ID是否已存在
        private string SQL_CHECK_SYSSETTING_ID_IS_EXIST = " SELECT COUNT(1) FROM SysSetting WHERE SysSettingID = @SysSettingID ";
        #endregion

        #region 基本方法

        #region 得到Syssetting的所有记录

        /// <summary>
        /// 得到所有的Syssetting记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Syssetting记录</returns>
        public DataSet GetAllSyssetting()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_SYSSETTING);
        }

        /// <summary>
        /// 得到所有的Syssetting记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Syssetting记录</returns>
        public DataSet GetAllSyssetting(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_SYSSETTING);
        }

        #endregion

        #region 根据条件查询Syssetting的记录  GetSyssettingByQueryList()

        /// <summary>
        /// 根据查询条件得到Syssetting记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyssettingQueryEntity">Syssetting查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Syssetting记录</returns>
        public DataSet GetSyssettingByQueryList(QueryEntity syssettingQuery)
        {
            string temp = SQL_SELECT_ALL_SYSSETTING;

            if (syssettingQuery != null && syssettingQuery.sqlWhere != null && syssettingQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < syssettingQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + syssettingQuery.sqlWhere[i];
                }
            }

            if (!syssettingQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, syssettingQuery.CurrentPage, syssettingQuery.PageSize, syssettingQuery.SortField, syssettingQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Syssetting记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyssettingQueryEntity">Syssetting查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Syssetting记录</returns>
        public DataSet GetSyssettingByQueryList(Database db, DbTransaction tran, QueryEntity syssettingQuery)
        {
            string temp = SQL_SELECT_ALL_SYSSETTING;

            if (syssettingQuery != null && syssettingQuery.sqlWhere != null && syssettingQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < syssettingQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + syssettingQuery.sqlWhere[i];
                }
            }
            if (!syssettingQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, syssettingQuery.CurrentPage, syssettingQuery.PageSize, syssettingQuery.SortField, syssettingQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Syssetting的一条记录 GetSyssettingByID()

        /// <summary>
        /// 根据syssettingID得到一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据syssettingID得到一条Syssetting记录</returns>
        public SyssettingInfo GetSyssettingByID(string syssettingID)
        {
            string sql = SQL_SELECT_ALL_SYSSETTING + " AND SysSettingID = @SysSettingID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SysSettingID", syssettingID) };
            SyssettingInfo syssettingInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    syssettingInfo = InitSyssettingInfoByDataReader(syssettingInfo, reader);
                }
            }

            return syssettingInfo;
        }
        /// <summary>
        /// 根据syssettingID得到一条Syssetting记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssettingID">syssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据syssettingID得到一条Syssetting记录</returns>
        public SyssettingInfo GetSyssettingByID(Database db, DbTransaction tran, string syssettingID)
        {
            string sql = SQL_SELECT_ALL_SYSSETTING + " AND SysSettingID = @SysSettingID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SysSettingID", syssettingID) };
            SyssettingInfo syssettingInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                syssettingInfo = InitSyssettingInfoByDataReader(syssettingInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return syssettingInfo;
        }
        /// <summary>
        /// 初始化SyssettingInfo
        /// </summary>
        private SyssettingInfo InitSyssettingInfoByDataReader(SyssettingInfo syssettingInfo, IDataReader reader)
        {
            syssettingInfo = new SyssettingInfo(reader["SysSettingID"].ToString(),
                                                reader["Description"].ToString(),
                                                reader["Value"].ToString(),
                                                reader["DefaultValue"].ToString(),
                                                reader["CreatedBy"].ToString(),
                                                reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
                                                reader["UpdatedBy"].ToString(),
                                                reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return syssettingInfo;
        }
        #endregion

        #region 向Syssetting增加一条记录 InsertSyssetting()

        /// <summary>
        /// 新增一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSyssetting(SyssettingInfo syssettingInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syssetting_Parameters(syssettingInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_SYSSETTING, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Syssetting记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssetting">Syssetting对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSyssetting(Database db, DbTransaction tran, SyssettingInfo syssettingInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syssetting_Parameters(syssettingInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_SYSSETTING, paras);
            }
            return result;
        }
        #endregion

        #region 删除Syssetting一条记录 DeleteSyssetting()

        /// <summary>
        /// 删除一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">SyssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSyssetting(string syssettingID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SysSettingID", syssettingID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_SYSSETTING, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Syssetting记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssettingID">SyssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSyssetting(Database db, DbTransaction tran, string syssettingID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SysSettingID", syssettingID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_SYSSETTING, paras);
            return result;
        }
        #endregion

        #region 更新一条Syssetting记录 UpdateSyssetting()
        /// <summary>
        /// 更新一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSyssetting(SyssettingInfo syssettingInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syssetting_Parameters(syssettingInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_SYSSETTING, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Syssetting记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssetting">Syssetting对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSyssetting(Database db, DbTransaction tran, SyssettingInfo syssettingInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Syssetting_Parameters(syssettingInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_SYSSETTING, paras);
            }
            return result;
        }
        #endregion

        #region 根据SYSSETTINGID判断此ID在表SysSetting中是否已存在

        /// <summary>
        /// 检查SyssettingID是否已存在
        /// </summary>
        /// <param name="syssettingID">SyssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSyssettingIDIsExist(string syssettingID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SysSettingID", syssettingID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_SYSSETTING_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查SyssettingID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssettingID">syssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSyssettingIDIsExist(Database db, DbTransaction tran, string syssettingID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SysSettingID", syssettingID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_SYSSETTING_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Syssetting_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Syssetting">Syssetting对象</param>
        /// <returns>Syssetting参数数组</returns>
        private SqlParameter[] Set_Syssetting_Parameters(SyssettingInfo syssettingInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@SysSettingID",syssettingInfo.SysSettingID),
																new SqlParameter("@Description",syssettingInfo.Description),
																new SqlParameter("@Value",syssettingInfo.Value),
																new SqlParameter("@DefaultValue",string.IsNullOrEmpty(syssettingInfo.DefaultValue)?"":syssettingInfo.DefaultValue),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(syssettingInfo.CreatedBy)?"":syssettingInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(syssettingInfo.UpdatedBy)?"":syssettingInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
