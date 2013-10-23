/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberDA
// 文件功能描述：提供Member数据表进行操作的一些方法
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
    public class MemberDA : IMemberDA
    {
        #region SQL语句
        //SELECT_SQL 得到 Member 的所有记录
        private string SQL_SELECT_ALL_MEMBER = "SELECT M.MemberID AS MemberID, M.MemberCode AS MemberCode, M.MemberName AS MemberName, M.LoginPwd AS LoginPwd, M.PayPwd AS PayPwd, M.MemberLevel AS MemberLevel, M.Sex AS Sex, M.Birthday AS Birthday, M.Age AS Age, M.Minority AS Minority, M.Trades AS Trades, M.HomeAddress AS HomeAddress, M.PostCode AS PostCode, M.Email AS Email, M.OfficePhone AS OfficePhone, M.MobilePhone AS MobilePhone, M.HomePhone AS HomePhone, M.Fax AS Fax, M.QQ AS QQ, M.Msn AS Msn, M.PwdQuestion AS PwdQuestion, M.PwdAnswer AS PwdAnswer, M.RegisterDate AS RegisterDate, M.LastLoginIP AS LastLoginIP, M.LoginCount AS LoginCount, M.LastLoginTime AS LastLoginTime, M.PreDeposits AS PreDeposits, M.Points AS Points, M.HoldPreDeposits AS HoldPreDeposits, M.HoldPoints AS HoldPoints, M.TotalConsumeMoney AS TotalConsumeMoney, M.TotalTransCount AS TotalTransCount, M.IsActive AS IsActive, M.CretaedBy AS CretaedBy, M.CreatedDate AS CreatedDate, M.UpdatedBy AS UpdatedBy, M.UpdatedDate AS UpdatedDate FROM Member M WHERE 1=1  ";
        //INSERT_SQL 向Member增加一条记录
        private string SQL_INSERT_MEMBER = "INSERT INTO Member ( MemberCode, MemberName, LoginPwd, PayPwd, MemberLevel, Sex, Birthday, Age, Minority, Trades, HomeAddress, PostCode, Email, OfficePhone, MobilePhone, HomePhone, Fax, QQ, Msn, PwdQuestion, PwdAnswer, RegisterDate, LastLoginIP, LoginCount, LastLoginTime, PreDeposits, Points, HoldPreDeposits, HoldPoints, TotalConsumeMoney, TotalTransCount, IsActive, CretaedBy, CreatedDate, UpdatedBy, UpdatedDate) VALUES ( @MemberCode, @MemberName, @LoginPwd, @PayPwd, @MemberLevel, @Sex, @Birthday, @Age, @Minority, @Trades, @HomeAddress, @PostCode, @Email, @OfficePhone, @MobilePhone, @HomePhone, @Fax, @QQ, @Msn, @PwdQuestion, @PwdAnswer, @RegisterDate, @LastLoginIP, @LoginCount, @LastLoginTime, @PreDeposits, @Points, @HoldPreDeposits, @HoldPoints, @TotalConsumeMoney, @TotalTransCount, @IsActive, @CretaedBy, GETDATE(), @UpdatedBy, GETDATE() )  ";
        //DELETE_SQL  删除Member一条记录
        private string SQL_DELETE_MEMBER = "DELETE FROM Member WHERE MEMBERID = @MEMBERID ";
        //UPDATE_SQL 更新Member记录
        private string SQL_UPDATE_MEMBER = "UPDATE Member SET MemberCode = @MemberCode, MemberName = @MemberName, LoginPwd = @LoginPwd, PayPwd = @PayPwd, MemberLevel = @MemberLevel, Sex = @Sex, Birthday = @Birthday, Age = @Age, Minority = @Minority, Trades = @Trades, HomeAddress = @HomeAddress, PostCode = @PostCode, Email = @Email, OfficePhone = @OfficePhone, MobilePhone = @MobilePhone, HomePhone = @HomePhone, Fax = @Fax, QQ = @QQ, Msn = @Msn, PwdQuestion = @PwdQuestion, PwdAnswer = @PwdAnswer, RegisterDate = @RegisterDate, LastLoginIP = @LastLoginIP, LoginCount = @LoginCount, LastLoginTime = @LastLoginTime, PreDeposits = @PreDeposits, Points = @Points, HoldPreDeposits = @HoldPreDeposits, HoldPoints = @HoldPoints, TotalConsumeMoney = @TotalConsumeMoney, TotalTransCount = @TotalTransCount, IsActive = @IsActive, CretaedBy = @CretaedBy, UpdatedBy = @UpdatedBy, UpdatedDate = GETDATE() WHERE MEMBERID = @MEMBERID  ";

        //判断一个MEMBER_ID是否已存在
        private string SQL_CHECK_MEMBER_ID_IS_EXIST = " SELECT COUNT(1) FROM Member WHERE MEMBERID = @MEMBERID ";
        #endregion

        #region 基本方法

        #region 得到Member的所有记录

        /// <summary>
        /// 得到所有的Member记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Member记录</returns>
        public DataSet GetAllMember()
        {
            return DBHelper.ExecuteDataSet(CommandType.Text, SQL_SELECT_ALL_MEMBER);
        }

        /// <summary>
        /// 得到所有的Member记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Member记录</returns>
        public DataSet GetAllMember(Database db, DbTransaction tran)
        {
            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, SQL_SELECT_ALL_MEMBER);
        }

        #endregion

        #region 根据条件查询Member的记录  GetMemberByQueryList()

        /// <summary>
        /// 根据查询条件得到Member记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberQueryEntity">Member查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Member记录</returns>
        public DataSet GetMemberByQueryList(QueryEntity memberQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBER;

            if (memberQuery != null && memberQuery.sqlWhere != null && memberQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberQuery.sqlWhere[i];
                }
            }

            if (!memberQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberQuery.CurrentPage, memberQuery.PageSize, memberQuery.SortField, memberQuery.SortDirection);

            return DBHelper.ExecuteDataSet(CommandType.Text, temp);
        }

        /// <summary>
        /// 根据查询条件得到Member记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberQueryEntity">Member查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Member记录</returns>
        public DataSet GetMemberByQueryList(Database db, DbTransaction tran, QueryEntity memberQuery)
        {
            string temp = SQL_SELECT_ALL_MEMBER;

            if (memberQuery != null && memberQuery.sqlWhere != null && memberQuery.sqlWhere.Count > 0)
            {
                for (int i = 0; i < memberQuery.sqlWhere.Count; i++)
                {
                    temp += " AND " + memberQuery.sqlWhere[i];
                }
            }
            if (!memberQuery.IsGetAll)
                temp = PagingHelper.GetPagingSQL(temp, memberQuery.CurrentPage, memberQuery.PageSize, memberQuery.SortField, memberQuery.SortDirection);

            return DBHelper.ExecuteDataSet(db, tran, CommandType.Text, temp);
        }

        #endregion

        #region  根据ID查询Member的一条记录 GetMemberByID()

        /// <summary>
        /// 根据memberID得到一条Member记录
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberID得到一条Member记录</returns>
        public MemberInfo GetMemberByID(string memberID)
        {
            string sql = SQL_SELECT_ALL_MEMBER + " AND MEMBERID = @MEMBERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@MEMBERID", memberID) };
            MemberInfo memberInfo = null;

            using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            {
                if (reader.Read())
                {
                    memberInfo = InitMemberInfoByDataReader(memberInfo, reader);
                }
            }

            return memberInfo;
        }
        /// <summary>
        /// 根据memberID得到一条Member记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberID">memberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberID得到一条Member记录</returns>
        public MemberInfo GetMemberByID(Database db, DbTransaction tran, string memberID)
        {
            string sql = SQL_SELECT_ALL_MEMBER + " AND MEMBERID = @MEMBERID  ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@MEMBERID", memberID) };
            MemberInfo memberInfo = null;

            IDataReader reader = DBHelper.ExecuteReader(db, tran, CommandType.Text, sql, paras);
            if (reader.Read())
            {
                memberInfo = InitMemberInfoByDataReader(memberInfo, reader);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return memberInfo;
        }
        /// <summary>
        /// 初始化MemberInfo
        /// </summary>
        private MemberInfo InitMemberInfoByDataReader(MemberInfo memberInfo, IDataReader reader)
        {
            memberInfo = new MemberInfo(reader["MemberID"].ToString() != "" ? Int32.Parse(reader["MemberID"].ToString()) : 0,
reader["MemberCode"].ToString(),
reader["MemberName"].ToString(),
reader["LoginPwd"].ToString(),
reader["PayPwd"].ToString(),
reader["MemberLevel"].ToString(),
reader["Sex"].ToString(),
reader["Birthday"].ToString() != "" ? DateTime.Parse(reader["Birthday"].ToString()) : new DateTime(),
reader["Age"].ToString() != "" ? Int32.Parse(reader["Age"].ToString()) : 0,
reader["Minority"].ToString(),
reader["Trades"].ToString(),
reader["HomeAddress"].ToString(),
reader["PostCode"].ToString(),
reader["Email"].ToString(),
reader["OfficePhone"].ToString(),
reader["MobilePhone"].ToString(),
reader["HomePhone"].ToString(),
reader["Fax"].ToString(),
reader["QQ"].ToString(),
reader["Msn"].ToString(),
reader["PwdQuestion"].ToString(),
reader["PwdAnswer"].ToString(),
reader["RegisterDate"].ToString() != "" ? DateTime.Parse(reader["RegisterDate"].ToString()) : new DateTime(),
reader["LastLoginIP"].ToString(),
reader["LoginCount"].ToString() != "" ? Int32.Parse(reader["LoginCount"].ToString()) : 0,
reader["LastLoginTime"].ToString() != "" ? DateTime.Parse(reader["LastLoginTime"].ToString()) : new DateTime(),
reader["PreDeposits"].ToString() != "" ? Decimal.Parse(reader["PreDeposits"].ToString()) : 0,
reader["Points"].ToString() != "" ? Int32.Parse(reader["Points"].ToString()) : 0,
reader["HoldPreDeposits"].ToString() != "" ? Decimal.Parse(reader["HoldPreDeposits"].ToString()) : 0,
reader["HoldPoints"].ToString() != "" ? Int32.Parse(reader["HoldPoints"].ToString()) : 0,
reader["TotalConsumeMoney"].ToString() != "" ? Decimal.Parse(reader["TotalConsumeMoney"].ToString()) : 0,
reader["TotalTransCount"].ToString() != "" ? Int32.Parse(reader["TotalTransCount"].ToString()) : 0,
reader["IsActive"].ToString(),
reader["CretaedBy"].ToString(),
reader["CreatedDate"].ToString() != "" ? DateTime.Parse(reader["CreatedDate"].ToString()) : new DateTime(),
reader["UpdatedBy"].ToString(),
reader["UpdatedDate"].ToString() != "" ? DateTime.Parse(reader["UpdatedDate"].ToString()) : new DateTime());
            return memberInfo;
        }
        #endregion

        #region 向Member增加一条记录 InsertMember()

        /// <summary>
        /// 新增一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMember(MemberInfo memberInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Member_Parameters(memberInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_INSERT_MEMBER, paras);
            }
            return result;
        }

        /// <summary>
        /// 新增一条Member记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="member">Member对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMember(Database db, DbTransaction tran, MemberInfo memberInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Member_Parameters(memberInfo);
            if (paras != null)
            {
                result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_INSERT_MEMBER, paras);
            }
            return result;
        }
        #endregion

        #region 删除Member一条记录 DeleteMember()

        /// <summary>
        /// 删除一条Member记录
        /// </summary>
        /// <param name="memberID">MemberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMember(string memberID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@MEMBERID", memberID) };
            result = DBHelper.ExecuteNonQuery(CommandType.Text, SQL_DELETE_MEMBER, paras);
            return result;
        }

        /// <summary>
        /// 删除一条Member记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberID">MemberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMember(Database db, DbTransaction tran, string memberID)
        {
            int result = 0;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@MEMBERID", memberID) };
            result = DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_DELETE_MEMBER, paras);
            return result;
        }
        #endregion

        #region 更新一条Member记录 UpdateMember()
        /// <summary>
        /// 更新一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMember(MemberInfo memberInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Member_Parameters(memberInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(CommandType.Text, SQL_UPDATE_MEMBER, paras);
            }
            return result;
        }

        /// <summary>
        /// 更新一条Member记录
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="member">Member对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMember(Database db, DbTransaction tran, MemberInfo memberInfo)
        {
            int result = 0;
            SqlParameter[] paras = Set_Member_Parameters(memberInfo);
            if (paras != null)
            {
                result += DBHelper.ExecuteNonQuery(db, tran, CommandType.Text, SQL_UPDATE_MEMBER, paras);
            }
            return result;
        }
        #endregion

        #region 根据MEMBERID判断此ID在表Member中是否已存在

        /// <summary>
        /// 检查MemberID是否已存在
        /// </summary>
        /// <param name="memberID">MemberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberIDIsExist(string memberID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@MEMBERID", memberID) };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, SQL_CHECK_MEMBER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查MemberID是否已存在
        /// </summary>
        /// <param name="db">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberID">memberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberIDIsExist(Database db, DbTransaction tran, string memberID)
        {
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@MEMBERID", memberID) };
            object obj = DBHelper.ExecuteScalar(db, tran, CommandType.Text, SQL_CHECK_MEMBER_ID_IS_EXIST, paras);
            if (obj.ToString() == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region 设置SQL参数表 Set_Member_Parameters()
        /// <summary>
        /// 设置SQL参数表
        /// </summary>
        /// <param name="Member">Member对象</param>
        /// <returns>Member参数数组</returns>
        private SqlParameter[] Set_Member_Parameters(MemberInfo memberInfo)
        {
            SqlParameter[] paramArray = new SqlParameter[] {new SqlParameter("@MemberID",memberInfo.MemberID),
																new SqlParameter("@MemberCode",memberInfo.MemberCode),
																new SqlParameter("@MemberName",memberInfo.MemberName),
																new SqlParameter("@LoginPwd",string.IsNullOrEmpty(memberInfo.LoginPwd)?"":memberInfo.LoginPwd),
																new SqlParameter("@PayPwd",string.IsNullOrEmpty(memberInfo.PayPwd)?"":memberInfo.PayPwd),
																new SqlParameter("@MemberLevel",string.IsNullOrEmpty(memberInfo.MemberLevel)?"":memberInfo.MemberLevel),
																new SqlParameter("@Sex",string.IsNullOrEmpty(memberInfo.Sex)?"":memberInfo.Sex),
																new SqlParameter("@Birthday",memberInfo.Birthday),
																new SqlParameter("@Age",memberInfo.Age),
																new SqlParameter("@Minority",string.IsNullOrEmpty(memberInfo.Minority)?"":memberInfo.Minority),
																new SqlParameter("@Trades",string.IsNullOrEmpty(memberInfo.Trades)?"":memberInfo.Trades),
																new SqlParameter("@HomeAddress",string.IsNullOrEmpty(memberInfo.HomeAddress)?"":memberInfo.HomeAddress),
																new SqlParameter("@PostCode",string.IsNullOrEmpty(memberInfo.PostCode)?"":memberInfo.PostCode),
																new SqlParameter("@Email",memberInfo.Email),
																new SqlParameter("@OfficePhone",string.IsNullOrEmpty(memberInfo.OfficePhone)?"":memberInfo.OfficePhone),
																new SqlParameter("@MobilePhone",memberInfo.MobilePhone),
																new SqlParameter("@HomePhone",string.IsNullOrEmpty(memberInfo.HomePhone)?"":memberInfo.HomePhone),
																new SqlParameter("@Fax",string.IsNullOrEmpty(memberInfo.Fax)?"":memberInfo.Fax),
																new SqlParameter("@QQ",string.IsNullOrEmpty(memberInfo.QQ)?"":memberInfo.QQ),
																new SqlParameter("@Msn",string.IsNullOrEmpty(memberInfo.Msn)?"":memberInfo.Msn),
																new SqlParameter("@PwdQuestion",string.IsNullOrEmpty(memberInfo.PwdQuestion)?"":memberInfo.PwdQuestion),
																new SqlParameter("@PwdAnswer",string.IsNullOrEmpty(memberInfo.PwdAnswer)?"":memberInfo.PwdAnswer),
																new SqlParameter("@RegisterDate",memberInfo.RegisterDate),
																new SqlParameter("@LastLoginIP",string.IsNullOrEmpty(memberInfo.LastLoginIP)?"":memberInfo.LastLoginIP),
																new SqlParameter("@LoginCount",memberInfo.LoginCount),
																new SqlParameter("@LastLoginTime",memberInfo.LastLoginTime),
																new SqlParameter("@PreDeposits",memberInfo.PreDeposits),
																new SqlParameter("@Points",memberInfo.Points),
																new SqlParameter("@HoldPreDeposits",memberInfo.HoldPreDeposits),
																new SqlParameter("@HoldPoints",memberInfo.HoldPoints),
																new SqlParameter("@TotalConsumeMoney",memberInfo.TotalConsumeMoney),
																new SqlParameter("@TotalTransCount",memberInfo.TotalTransCount),
																new SqlParameter("@IsActive",string.IsNullOrEmpty(memberInfo.IsActive)?"":memberInfo.IsActive),
																new SqlParameter("@CretaedBy",string.IsNullOrEmpty(memberInfo.CretaedBy)?"":memberInfo.CretaedBy),
																new SqlParameter("@UpdatedBy",string.IsNullOrEmpty(memberInfo.UpdatedBy)?"":memberInfo.UpdatedBy)
		                                                	};
            return paramArray;
        }
        #endregion
        #endregion

        #region 扩展方法
        #endregion
    }
}
