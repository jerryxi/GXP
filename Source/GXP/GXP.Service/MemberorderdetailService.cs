/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberorderdetailService
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
    public class MemberorderdetailService : IMemberorderdetailService
    {
        [Dependency]
        public IMemberorderdetailDA memberorderdetailDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Memberorderdetail记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberorderdetail记录</returns>
        public DataSet GetAllMemberorderdetail()
        {
            return memberorderdetailDA.GetAllMemberorderdetail();
        }

        /// <summary>
        /// 根据查询条件得到Memberorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderdetailQueryEntity">Memberorderdetail查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberorderdetail记录</returns>
        public DataSet GetMemberorderdetailByQueryList(QueryEntity memberorderdetailQuery)
        {
            return memberorderdetailDA.GetMemberorderdetailByQueryList(memberorderdetailQuery);
        }

        /// <summary>
        /// 根据memberorderdetailID得到一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberorderdetailID得到一条Memberorderdetail记录</returns>
        public MemberorderdetailInfo GetMemberorderdetailByID(string memberorderdetailID)
        {
            return memberorderdetailDA.GetMemberorderdetailByID(memberorderdetailID);
        }

        /// <summary>
        /// 新增一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo)
        {
            return memberorderdetailDA.InsertMemberorderdetail(memberorderdetailInfo);
        }

        /// <summary>
        /// 删除一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">MemberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberorderdetail(List<string> memberorderdetailID)
        {
            int result = 0;
            if (memberorderdetailID != null && memberorderdetailID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < memberorderdetailID.Count; i++)
                    {
                        result += memberorderdetailDA.DeleteMemberorderdetail(db, dbTran, memberorderdetailID[i]);
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
        /// 更新一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo)
        {
            return memberorderdetailDA.UpdateMemberorderdetail(memberorderdetailInfo);
        }

        /// <summary>
        /// 检查MemberorderdetailID是否已存在
        /// </summary>
        /// <param name="memberorderdetailID">MemberorderdetailID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberorderdetailIDIsExist(string memberorderdetailID)
        {
            return memberorderdetailDA.CheckMemberorderdetailIDIsExist(memberorderdetailID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
