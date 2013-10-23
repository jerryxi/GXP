/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SyssettingService
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
    public class SyssettingService : ISyssettingService
    {
        [Dependency]
        public ISyssettingDA syssettingDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Syssetting记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Syssetting记录</returns>
        public DataSet GetAllSyssetting()
        {
            return syssettingDA.GetAllSyssetting();
        }

        /// <summary>
        /// 根据查询条件得到Syssetting记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyssettingQueryEntity">Syssetting查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Syssetting记录</returns>
        public DataSet GetSyssettingByQueryList(QueryEntity syssettingQuery)
        {
            return syssettingDA.GetSyssettingByQueryList(syssettingQuery);
        }

        /// <summary>
        /// 根据syssettingID得到一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据syssettingID得到一条Syssetting记录</returns>
        public SyssettingInfo GetSyssettingByID(string syssettingID)
        {
            return syssettingDA.GetSyssettingByID(syssettingID);
        }

        /// <summary>
        /// 新增一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSyssetting(SyssettingInfo syssettingInfo)
        {
            return syssettingDA.InsertSyssetting(syssettingInfo);
        }

        /// <summary>
        /// 删除一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">SyssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSyssetting(List<string> syssettingID)
        {
            int result = 0;
            if (syssettingID != null && syssettingID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < syssettingID.Count; i++)
                    {
                        result += syssettingDA.DeleteSyssetting(db, dbTran, syssettingID[i]);
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
        /// 更新一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSyssetting(SyssettingInfo syssettingInfo)
        {
            return syssettingDA.UpdateSyssetting(syssettingInfo);
        }

        /// <summary>
        /// 检查SyssettingID是否已存在
        /// </summary>
        /// <param name="syssettingID">SyssettingID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSyssettingIDIsExist(string syssettingID)
        {
            return syssettingDA.CheckSyssettingIDIsExist(syssettingID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
