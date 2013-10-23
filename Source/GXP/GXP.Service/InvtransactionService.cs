/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：InvtransactionService
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
    public class InvtransactionService : IInvtransactionService
    {
        [Dependency]
        public IInvtransactionDA invtransactionDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Invtransaction记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Invtransaction记录</returns>
        public DataSet GetAllInvtransaction()
        {
            return invtransactionDA.GetAllInvtransaction();
        }

        /// <summary>
        /// 根据查询条件得到Invtransaction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InvtransactionQueryEntity">Invtransaction查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Invtransaction记录</returns>
        public DataSet GetInvtransactionByQueryList(QueryEntity invtransactionQuery)
        {
            return invtransactionDA.GetInvtransactionByQueryList(invtransactionQuery);
        }

        /// <summary>
        /// 根据invtransactionID得到一条Invtransaction记录
        /// </summary>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据invtransactionID得到一条Invtransaction记录</returns>
        public InvtransactionInfo GetInvtransactionByID(string invtransactionID)
        {
            return invtransactionDA.GetInvtransactionByID(invtransactionID);
        }

        /// <summary>
        /// 新增一条Invtransaction记录
        /// </summary>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertInvtransaction(InvtransactionInfo invtransactionInfo)
        {
            return invtransactionDA.InsertInvtransaction(invtransactionInfo);
        }

        /// <summary>
        /// 删除一条Invtransaction记录
        /// </summary>
        /// <param name="invtransactionID">InvtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteInvtransaction(List<string> invtransactionID)
        {
            int result = 0;
            if (invtransactionID != null && invtransactionID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < invtransactionID.Count; i++)
                    {
                        result += invtransactionDA.DeleteInvtransaction(db, dbTran, invtransactionID[i]);
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
        /// 更新一条Invtransaction记录
        /// </summary>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateInvtransaction(InvtransactionInfo invtransactionInfo)
        {
            return invtransactionDA.UpdateInvtransaction(invtransactionInfo);
        }

        /// <summary>
        /// 检查InvtransactionID是否已存在
        /// </summary>
        /// <param name="invtransactionID">InvtransactionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckInvtransactionIDIsExist(string invtransactionID)
        {
            return invtransactionDA.CheckInvtransactionIDIsExist(invtransactionID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
