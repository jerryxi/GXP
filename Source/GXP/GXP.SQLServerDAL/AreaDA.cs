/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：AreaDA
// 文件功能描述：提供Area数据表进行操作的一些方法
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
    public class AreaDA : IAreaDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Area 的所有记录
        private string SQL_SELECT_ALL_AREA = "SELECT A.ID AS ID, A.AreaCode AS AreaCode, A.AreaName AS AreaName, A.IsActive AS IsActive, A.Remark AS Remark, A.CreatedBy AS CreatedBy, A.CretaedDate AS CretaedDate, A.UpdatedBy AS UpdatedBy, A.UpdatedDate AS UpdatedDate FROM Area A WHERE 1=1  ";
        //INSERT_SQL 向Area增加一条记录
        private string SQL_INSERT_AREA = "INSERT INTO Area ( AreaCode, AreaName, IsActive, Remark, CreatedBy, CretaedDate, UpdatedBy, UpdatedDate) VALUES (@AreaCode, @AreaName, @IsActive, @Remark, @CreatedBy, @CretaedDate, @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Area一条记录
        private string SQL_DELETE_AREA = "DELETE FROM Area WHERE ID = @ID ";
        //UPDATE_SQL 更新Area记录
        private string SQL_UPDATE_AREA = "UPDATE Area SET AreaCode = @AreaCode, AreaName = @AreaName, IsActive = @IsActive, Remark = @Remark, CretaedDate = @CretaedDate, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE ID = @ID  ";

        //判断一个AREA_ID是否已存在
        private string SQL_CHECK_AREA_ID_IS_EXIST = " SELECT COUNT(1) FROM Area WHERE ID = @ID ";
        #endregion

        #region 基本方法

        #region 得到Area的所有记录

        /// <summary>
        /// 得到所有的Area记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Area记录</returns>
        public DataSet GetAllArea()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_AREA);
        }

        /// <summary>
        /// 得到所有的Area记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Area记录</returns>
        public DataSet GetAllArea(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_AREA);
        }

        #endregion

        #region 根据条件查询Area的记录  GetAreaByQueryList()

        /// <summary>
        /// 根据查询条件得到Area记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="AreaQueryEntity">Area查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Area记录</returns>
        public DataSet GetAreaByQueryList(QueryEntity areaQuery)
        {
            string temp = SQL_SELECT_ALL_AREA;

            if (areaQuery != null && areaQuery.sqlWhere != null && areaQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < areaQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + areaQuery.sqlWhere[i];
                }
            }

            if (!areaQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, areaQuery.CurrentPage, areaQuery.PageSize, areaQuery.SortField, areaQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Area记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="AreaQueryEntity">Area查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Area记录</returns>
        public DataSet GetAreaByQueryList(Database db, DbTransaction tran, QueryEntity areaQuery)
        {
            string temp = SQL_SELECT_ALL_AREA;

            if (areaQuery != null && areaQuery.sqlWhere != null && areaQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < areaQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + areaQuery.sqlWhere[i];
                }
            }
            if (!areaQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, areaQuery.CurrentPage, areaQuery.PageSize, areaQuery.SortField, areaQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Area的一条记录 GetAreaByID()

        /// <summary>
        /// 根据areaID得到一条Area记录
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据areaID得到一条Area记录</returns>
        public AreaInfo GetAreaByID(string areaID)
        {
            string sql = SQL_SELECT_ALL_AREA + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", areaID) };
            AreaInfo areaInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    areaInfo = InitAreaInfoByDataReader(areaInfo, reader);
                }
            }

            return areaInfo;
        }
        /// <summary>
        /// 根据areaID得到一条Area记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="areaID">areaID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据areaID得到一条Area记录</returns>
        public AreaInfo GetAreaByID(Database db, DbTransaction tran, string areaID)
        {
            string sql = SQL_SELECT_ALL_AREA + " AND ID = @ID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", areaID) };
            AreaInfo areaInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                areaInfo = InitAreaInfoByDataReader(areaInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return areaInfo;
        }
        /// <summary>
        /// 初始化AreaInfo
        /// </summary>
        private AreaInfo InitAreaInfoByDataReader(AreaInfo areaInfo, IDataReader reader)
        {
            areaInfo = new AreaInfo(reader["ID"].ToString() != "" ? Int32.Parse(reader["ID"].ToString()) : 0,
reader["AreaCode"].ToString(),
reader["AreaName"].ToString(),
reader["IsActive"].ToString(),
reader["Remark"].ToString(),
reader["CreatedBy"].ToString(),
reader["CretaedDate"].ToString() != "" ? DateTime.Parse(reader["CretaedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return areaInfo;
        }
        #endregion

        #region 向Area增加一条记录 InsertArea()

        /// <summary>
        /// 新增一条Area记录
        /// </summary>
        /// <param name="area">Area对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertArea(AreaInfo areaInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Area_Parameters(areaInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_AREA, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Area记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="area">Area对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertArea(Database db, DbTransaction tran, AreaInfo areaInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Area_Parameters(areaInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_AREA, paras);
            }
            return result;
        }
        #endregion

        #region 删除Area一条记录 DeleteArea()

        /// <summary>
        /// 删除一条Area记录
        /// </summary>
        /// <param name="areaID">AreaID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteArea(string areaID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", areaID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_AREA, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Area记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="areaID">AreaID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteArea(Database db, DbTransaction tran, string areaID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", areaID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_AREA, paras);
            return result;
        }
        #endregion

        #region 更新一条Area记录 UpdateArea()
        /// <summary>
        /// 更新一条Area记录
        /// </summary>
        /// <param name="area">Area对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateArea(AreaInfo areaInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Area_Parameters(areaInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_AREA, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Area记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="area">Area对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateArea(Database db, DbTransaction tran, AreaInfo areaInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Area_Parameters(areaInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_AREA, paras);
            }
            return result;
        }
        #endregion

        #region 根据ID判断此ID在表Area中是否已存在

        /// <summary>
        /// 检查AreaID是否已存在
        /// </summary>
        /// <param name="areaID">AreaID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckAreaIDIsExist(string areaID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", areaID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_AREA_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查AreaID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="areaID">areaID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckAreaIDIsExist(Database db, DbTransaction tran, string areaID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ID", areaID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_AREA_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Area_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Area">Area对象</param>
        /// <returns>Area参数数组</returns>
        private SqlParameter[] Set_Area_Parameters(AreaInfo areaInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@ID",areaInfo.ID),
																new SqlParameter("@AreaCode",areaInfo.AreaCode),
																new SqlParameter("@AreaName",areaInfo.AreaName),
																new SqlParameter("@IsActive",areaInfo.IsActive),
																new SqlParameter("@Remark",string.IsNullOrEmpty(areaInfo.Remark)?"":areaInfo.Remark),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(areaInfo.CreatedBy)?"":areaInfo.CreatedBy),
																new SqlParameter("@CretaedDate",areaInfo.CretaedDate),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(areaInfo.UpdatedBy)?"":areaInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
