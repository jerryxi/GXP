/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SupplierDA
// 文件功能描述：提供Supplier数据表进行操作的一些方法
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
    public class SupplierDA : ISupplierDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Supplier 的所有记录
        private string SQL_SELECT_ALL_SUPPLIER = "SELECT S.SupplierID AS SupplierID, S.SupplierCode AS SupplierCode, S.SupplierName AS SupplierName, S.LoginPwd AS LoginPwd, S.Email AS Email, S.ContactAddress AS ContactAddress, S.Contact AS Contact, S.Region AS Region, S.Stage AS Stage, S.PostCode AS PostCode, S.ContactPhone AS ContactPhone, S.MobilePhone AS MobilePhone, S.QQ AS QQ, S.Msn AS Msn, S.Fax AS Fax, S.WebUrl AS WebUrl, S.Logo AS Logo, S.CompanyIntro AS CompanyIntro, S.CompanyCulture AS CompanyCulture, S.ArtificialPerson AS ArtificialPerson, S.Remark AS Remark, S.IsActive AS IsActive, S.CreatedBy AS CreatedBy, S.CreatedDate AS CreatedDate, S.UpdatedBy AS UpdatedBy, S.UpdatedDate AS UpdatedDate FROM Supplier S WHERE 1=1  ";
        //INSERT_SQL 向Supplier增加一条记录
        private string SQL_INSERT_SUPPLIER = "INSERT INTO Supplier ( SupplierCode, SupplierName, LoginPwd, Email, ContactAddress, Contact, Region, Stage, PostCode, ContactPhone, MobilePhone, QQ, Msn, Fax, WebUrl, Logo, CompanyIntro, CompanyCulture, ArtificialPerson, Remark, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @SupplierCode, @SupplierName, @LoginPwd, @Email, @ContactAddress, @Contact, @Region, @Stage, @PostCode, @ContactPhone, @MobilePhone, @QQ, @Msn, @Fax, @WebUrl, @Logo, @CompanyIntro, @CompanyCulture, @ArtificialPerson, @Remark, @IsActive, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Supplier一条记录
        private string SQL_DELETE_SUPPLIER = "DELETE FROM Supplier WHERE SUPPLIERID = @SUPPLIERID ";
        //UPDATE_SQL 更新Supplier记录
        private string SQL_UPDATE_SUPPLIER = "UPDATE Supplier SET SupplierCode = @SupplierCode, SupplierName = @SupplierName, LoginPwd = @LoginPwd, Email = @Email, ContactAddress = @ContactAddress, Contact = @Contact, Region = @Region, Stage = @Stage, PostCode = @PostCode, ContactPhone = @ContactPhone, MobilePhone = @MobilePhone, QQ = @QQ, Msn = @Msn, Fax = @Fax, WebUrl = @WebUrl, Logo = @Logo, CompanyIntro = @CompanyIntro, CompanyCulture = @CompanyCulture, ArtificialPerson = @ArtificialPerson, Remark = @Remark, IsActive = @IsActive, CreatedBy = @CreatedBy, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE SUPPLIERID = @SUPPLIERID  ";

        //判断一个SUPPLIER_ID是否已存在
        private string SQL_CHECK_SUPPLIER_ID_IS_EXIST = " SELECT COUNT(1) FROM Supplier WHERE SUPPLIERID = @SUPPLIERID ";
        #endregion

        #region 基本方法

        #region 得到Supplier的所有记录

        /// <summary>
        /// 得到所有的Supplier记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Supplier记录</returns>
        public DataSet GetAllSupplier()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_SUPPLIER);
        }

        /// <summary>
        /// 得到所有的Supplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Supplier记录</returns>
        public DataSet GetAllSupplier(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_SUPPLIER);
        }

        #endregion

        #region 根据条件查询Supplier的记录  GetSupplierByQueryList()

        /// <summary>
        /// 根据查询条件得到Supplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SupplierQueryEntity">Supplier查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Supplier记录</returns>
        public DataSet GetSupplierByQueryList(QueryEntity supplierQuery)
        {
            string temp = SQL_SELECT_ALL_SUPPLIER;

            if (supplierQuery != null && supplierQuery.sqlWhere != null && supplierQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < supplierQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + supplierQuery.sqlWhere[i];
                }
            }

            if (!supplierQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, supplierQuery.CurrentPage, supplierQuery.PageSize, supplierQuery.SortField, supplierQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Supplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SupplierQueryEntity">Supplier查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Supplier记录</returns>
        public DataSet GetSupplierByQueryList(Database db, DbTransaction tran, QueryEntity supplierQuery)
        {
            string temp = SQL_SELECT_ALL_SUPPLIER;

            if (supplierQuery != null && supplierQuery.sqlWhere != null && supplierQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < supplierQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + supplierQuery.sqlWhere[i];
                }
            }
            if (!supplierQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, supplierQuery.CurrentPage, supplierQuery.PageSize, supplierQuery.SortField, supplierQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Supplier的一条记录 GetSupplierByID()

        /// <summary>
        /// 根据supplierID得到一条Supplier记录
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据supplierID得到一条Supplier记录</returns>
        public SupplierInfo GetSupplierByID(string supplierID)
        {
            string sql = SQL_SELECT_ALL_SUPPLIER + " AND SUPPLIERID = @SUPPLIERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SUPPLIERID", supplierID) };
            SupplierInfo supplierInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    supplierInfo = InitSupplierInfoByDataReader(supplierInfo, reader);
                }
            }

            return supplierInfo;
        }
        /// <summary>
        /// 根据supplierID得到一条Supplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplierID">supplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据supplierID得到一条Supplier记录</returns>
        public SupplierInfo GetSupplierByID(Database db, DbTransaction tran, string supplierID)
        {
            string sql = SQL_SELECT_ALL_SUPPLIER + " AND SUPPLIERID = @SUPPLIERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SUPPLIERID", supplierID) };
            SupplierInfo supplierInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                supplierInfo = InitSupplierInfoByDataReader(supplierInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return supplierInfo;
        }
        /// <summary>
        /// 初始化SupplierInfo
        /// </summary>
        private SupplierInfo InitSupplierInfoByDataReader(SupplierInfo supplierInfo, IDataReader reader)
        {
            supplierInfo = new SupplierInfo(reader["SupplierID"].ToString() != "" ? Int32.Parse(reader["SupplierID"].ToString()) : 0,
reader["SupplierCode"].ToString(),
reader["SupplierName"].ToString(),
reader["LoginPwd"].ToString(),
reader["Email"].ToString(),
reader["ContactAddress"].ToString(),
reader["Contact"].ToString(),
reader["Region"].ToString(),
reader["Stage"].ToString(),
reader["PostCode"].ToString(),
reader["ContactPhone"].ToString(),
reader["MobilePhone"].ToString(),
reader["QQ"].ToString(),
reader["Msn"].ToString(),
reader["Fax"].ToString(),
reader["WebUrl"].ToString(),
reader["Logo"].ToString(),
reader["CompanyIntro"].ToString(),
reader["CompanyCulture"].ToString(),
reader["ArtificialPerson"].ToString(),
reader["Remark"].ToString(),
reader["IsActive"].ToString(),
reader["CreatedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return supplierInfo;
        }
        #endregion

        #region 向Supplier增加一条记录 InsertSupplier()

        /// <summary>
        /// 新增一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSupplier(SupplierInfo supplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Supplier_Parameters(supplierInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_SUPPLIER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Supplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplier">Supplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSupplier(Database db, DbTransaction tran, SupplierInfo supplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Supplier_Parameters(supplierInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_SUPPLIER, paras);
            }
            return result;
        }
        #endregion

        #region 删除Supplier一条记录 DeleteSupplier()

        /// <summary>
        /// 删除一条Supplier记录
        /// </summary>
        /// <param name="supplierID">SupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSupplier(string supplierID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SUPPLIERID", supplierID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_SUPPLIER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Supplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplierID">SupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSupplier(Database db, DbTransaction tran, string supplierID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SUPPLIERID", supplierID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_SUPPLIER, paras);
            return result;
        }
        #endregion

        #region 更新一条Supplier记录 UpdateSupplier()
        /// <summary>
        /// 更新一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSupplier(SupplierInfo supplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Supplier_Parameters(supplierInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_SUPPLIER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Supplier记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplier">Supplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSupplier(Database db, DbTransaction tran, SupplierInfo supplierInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Supplier_Parameters(supplierInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_SUPPLIER, paras);
            }
            return result;
        }
        #endregion

        #region 根据SUPPLIERID判断此ID在表Supplier中是否已存在

        /// <summary>
        /// 检查SupplierID是否已存在
        /// </summary>
        /// <param name="supplierID">SupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSupplierIDIsExist(string supplierID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SUPPLIERID", supplierID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_SUPPLIER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查SupplierID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplierID">supplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSupplierIDIsExist(Database db, DbTransaction tran, string supplierID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SUPPLIERID", supplierID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_SUPPLIER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Supplier_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Supplier">Supplier对象</param>
        /// <returns>Supplier参数数组</returns>
        private SqlParameter[] Set_Supplier_Parameters(SupplierInfo supplierInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@SupplierID",supplierInfo.SupplierID),
																new SqlParameter("@SupplierCode",supplierInfo.SupplierCode),
																new SqlParameter("@SupplierName",supplierInfo.SupplierName),
																new SqlParameter("@LoginPwd",string.IsNullOrEmpty(supplierInfo.LoginPwd)?"":supplierInfo.LoginPwd),
																new SqlParameter("@Email",string.IsNullOrEmpty(supplierInfo.Email)?"":supplierInfo.Email),
																new SqlParameter("@ContactAddress",string.IsNullOrEmpty(supplierInfo.ContactAddress)?"":supplierInfo.ContactAddress),
																new SqlParameter("@Contact",string.IsNullOrEmpty(supplierInfo.Contact)?"":supplierInfo.Contact),
																new SqlParameter("@Region",string.IsNullOrEmpty(supplierInfo.Region)?"":supplierInfo.Region),
																new SqlParameter("@Stage",string.IsNullOrEmpty(supplierInfo.Stage)?"":supplierInfo.Stage),
																new SqlParameter("@PostCode",string.IsNullOrEmpty(supplierInfo.PostCode)?"":supplierInfo.PostCode),
																new SqlParameter("@ContactPhone",string.IsNullOrEmpty(supplierInfo.ContactPhone)?"":supplierInfo.ContactPhone),
																new SqlParameter("@MobilePhone",string.IsNullOrEmpty(supplierInfo.MobilePhone)?"":supplierInfo.MobilePhone),
																new SqlParameter("@QQ",string.IsNullOrEmpty(supplierInfo.QQ)?"":supplierInfo.QQ),
																new SqlParameter("@Msn",string.IsNullOrEmpty(supplierInfo.Msn)?"":supplierInfo.Msn),
																new SqlParameter("@Fax",string.IsNullOrEmpty(supplierInfo.Fax)?"":supplierInfo.Fax),
																new SqlParameter("@WebUrl",string.IsNullOrEmpty(supplierInfo.WebUrl)?"":supplierInfo.WebUrl),
																new SqlParameter("@Logo",string.IsNullOrEmpty(supplierInfo.Logo)?"":supplierInfo.Logo),
																new SqlParameter("@CompanyIntro",string.IsNullOrEmpty(supplierInfo.CompanyIntro)?"":supplierInfo.CompanyIntro),
																new SqlParameter("@CompanyCulture",string.IsNullOrEmpty(supplierInfo.CompanyCulture)?"":supplierInfo.CompanyCulture),
																new SqlParameter("@ArtificialPerson",string.IsNullOrEmpty(supplierInfo.ArtificialPerson)?"":supplierInfo.ArtificialPerson),
																new SqlParameter("@Remark",string.IsNullOrEmpty(supplierInfo.Remark)?"":supplierInfo.Remark),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(supplierInfo.IsActive)?"":supplierInfo.IsActive),
																new SqlParameter("@CreatedBy",string.IsNullOrEmpty(supplierInfo.CreatedBy)?"":supplierInfo.CreatedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(supplierInfo.UpdatedBy)?"":supplierInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
