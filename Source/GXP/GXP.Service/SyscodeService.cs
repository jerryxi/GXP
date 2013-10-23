/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SyscodeService
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
    public class SyscodeService : ISyscodeService
    {
        [Dependency]
        public ISyscodeDA syscodeDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Syscode记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Syscode记录</returns>
        public DataSet GetAllSyscode()
        {
            return syscodeDA.GetAllSyscode();
        }

        /// <summary>
        /// 根据查询条件得到Syscode记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyscodeQueryEntity">Syscode查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Syscode记录</returns>
        public DataSet GetSyscodeByQueryList(QueryEntity syscodeQuery)
        {
            return syscodeDA.GetSyscodeByQueryList(syscodeQuery);
        }

        /// <summary>
        /// 根据syscodeID得到一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据syscodeID得到一条Syscode记录</returns>
        public SyscodeInfo GetSyscodeByID(string syscodeID)
        {
            return syscodeDA.GetSyscodeByID(syscodeID);
        }

        /// <summary>
        /// 新增一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSyscode(SyscodeInfo syscodeInfo)
        {
            return syscodeDA.InsertSyscode(syscodeInfo);
        }

        /// <summary>
        /// 删除一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">SyscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSyscode(List<string> syscodeID)
        {
            int result = 0;
            if (syscodeID != null && syscodeID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < syscodeID.Count; i++)
                    {
                        result += syscodeDA.DeleteSyscode(db, dbTran, syscodeID[i]);
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
        /// 更新一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSyscode(SyscodeInfo syscodeInfo)
        {
            return syscodeDA.UpdateSyscode(syscodeInfo);
        }

        /// <summary>
        /// 检查SyscodeID是否已存在
        /// </summary>
        /// <param name="syscodeID">SyscodeID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSyscodeIDIsExist(string syscodeID)
        {
            return syscodeDA.CheckSyscodeIDIsExist(syscodeID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
