/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberorderService
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
    public class MemberorderService : IMemberorderService
    {
        [Dependency]
        public IMemberorderDA memberorderDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Memberorder记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberorder记录</returns>
        public DataSet GetAllMemberorder()
        {
            return memberorderDA.GetAllMemberorder();
        }

        /// <summary>
        /// 根据查询条件得到Memberorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderQueryEntity">Memberorder查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberorder记录</returns>
        public DataSet GetMemberorderByQueryList(QueryEntity memberorderQuery)
        {
            return memberorderDA.GetMemberorderByQueryList(memberorderQuery);
        }

        /// <summary>
        /// 根据memberorderID得到一条Memberorder记录
        /// </summary>
        /// <param name="memberorderID">memberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberorderID得到一条Memberorder记录</returns>
        public MemberorderInfo GetMemberorderByID(string memberorderID)
        {
            return memberorderDA.GetMemberorderByID(memberorderID);
        }

        /// <summary>
        /// 新增一条Memberorder记录
        /// </summary>
        /// <param name="memberorder">Memberorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberorder(MemberorderInfo memberorderInfo)
        {
            return memberorderDA.InsertMemberorder(memberorderInfo);
        }

        /// <summary>
        /// 删除一条Memberorder记录
        /// </summary>
        /// <param name="memberorderID">MemberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberorder(List<string> memberorderID)
        {
            int result = 0;
            if (memberorderID != null && memberorderID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < memberorderID.Count; i++)
                    {
                        result += memberorderDA.DeleteMemberorder(db, dbTran, memberorderID[i]);
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
        /// 更新一条Memberorder记录
        /// </summary>
        /// <param name="memberorder">Memberorder对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberorder(MemberorderInfo memberorderInfo)
        {
            return memberorderDA.UpdateMemberorder(memberorderInfo);
        }

        /// <summary>
        /// 检查MemberorderID是否已存在
        /// </summary>
        /// <param name="memberorderID">MemberorderID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberorderIDIsExist(string memberorderID)
        {
            return memberorderDA.CheckMemberorderIDIsExist(memberorderID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
