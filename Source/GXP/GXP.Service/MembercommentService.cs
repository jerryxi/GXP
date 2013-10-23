/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MembercommentService
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
    public class MembercommentService : IMembercommentService
    {
        [Dependency]
        public IMembercommentDA membercommentDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Membercomment记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Membercomment记录</returns>
        public DataSet GetAllMembercomment()
        {
            return membercommentDA.GetAllMembercomment();
        }

        /// <summary>
        /// 根据查询条件得到Membercomment记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MembercommentQueryEntity">Membercomment查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Membercomment记录</returns>
        public DataSet GetMembercommentByQueryList(QueryEntity membercommentQuery)
        {
            return membercommentDA.GetMembercommentByQueryList(membercommentQuery);
        }

        /// <summary>
        /// 根据membercommentID得到一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据membercommentID得到一条Membercomment记录</returns>
        public MembercommentInfo GetMembercommentByID(string membercommentID)
        {
            return membercommentDA.GetMembercommentByID(membercommentID);
        }

        /// <summary>
        /// 新增一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMembercomment(MembercommentInfo membercommentInfo)
        {
            return membercommentDA.InsertMembercomment(membercommentInfo);
        }

        /// <summary>
        /// 删除一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">MembercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMembercomment(List<string> membercommentID)
        {
            int result = 0;
            if (membercommentID != null && membercommentID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < membercommentID.Count; i++)
                    {
                        result += membercommentDA.DeleteMembercomment(db, dbTran, membercommentID[i]);
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
        /// 更新一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMembercomment(MembercommentInfo membercommentInfo)
        {
            return membercommentDA.UpdateMembercomment(membercommentInfo);
        }

        /// <summary>
        /// 检查MembercommentID是否已存在
        /// </summary>
        /// <param name="membercommentID">MembercommentID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMembercommentIDIsExist(string membercommentID)
        {
            return membercommentDA.CheckMembercommentIDIsExist(membercommentID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
