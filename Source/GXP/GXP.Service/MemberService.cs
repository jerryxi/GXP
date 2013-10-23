/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberService
// 文件功能描述：
//
// 创建标识：JerryXi 2013/8/20  
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using GXP.IService;
using GXP.IDAL;
using GXP.DataEntity;
using GXP.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GXP.Service
{
    public class MemberService : IMemberService
    {
        [Dependency]
        public IMemberDA memberDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Member记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Member记录</returns>
        public DataSet GetAllMember()
        {
            return memberDA.GetAllMember();
        }

        /// <summary>
        /// 根据查询条件得到Member记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberQueryEntity">Member查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Member记录</returns>
        public DataSet GetMemberByQueryList(QueryEntity memberQuery)
        {
            return memberDA.GetMemberByQueryList(memberQuery);
        }

        /// <summary>
        /// 根据memberID得到一条Member记录
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberID得到一条Member记录</returns>
        public MemberInfo GetMemberByID(string memberID)
        {
            return memberDA.GetMemberByID(memberID);
        }

        /// <summary>
        /// 新增一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMember(MemberInfo memberInfo)
        {
            return memberDA.InsertMember(memberInfo);
        }

        /// <summary>
        /// 删除一条Member记录
        /// </summary>
        /// <param name="memberID">MemberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMember(List<string> memberID)
        {
            int result = 0;
            if (memberID != null && memberID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < memberID.Count; i++)
                    {
                        result += memberDA.DeleteMember(db, dbTran, memberID[i]);
                    }
                    dbTran.Commit();
                }
                catch (Exception ex)
                {
                    result = 0;
                    dbTran.Rollback();
                    LogHelper.LogError(ex, "");
                }
                finally
                {
                    dbConn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 更新一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMember(MemberInfo memberInfo)
        {
            return memberDA.UpdateMember(memberInfo);
        }

        /// <summary>
        /// 检查MemberID是否已存在
        /// </summary>
        /// <param name="memberID">MemberID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberIDIsExist(string memberID)
        {
            return memberDA.CheckMemberIDIsExist(memberID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
