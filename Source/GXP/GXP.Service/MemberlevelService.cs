/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：MemberlevelService
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
    public class MemberlevelService : IMemberlevelService
    {
        [Dependency]
        public IMemberlevelDA memberlevelDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Memberlevel记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Memberlevel记录</returns>
        public DataSet GetAllMemberlevel()
        {
            return memberlevelDA.GetAllMemberlevel();
        }

        /// <summary>
        /// 根据查询条件得到Memberlevel记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberlevelQueryEntity">Memberlevel查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Memberlevel记录</returns>
        public DataSet GetMemberlevelByQueryList(QueryEntity memberlevelQuery)
        {
            return memberlevelDA.GetMemberlevelByQueryList(memberlevelQuery);
        }

        /// <summary>
        /// 根据memberlevelID得到一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据memberlevelID得到一条Memberlevel记录</returns>
        public MemberlevelInfo GetMemberlevelByID(string memberlevelID)
        {
            return memberlevelDA.GetMemberlevelByID(memberlevelID);
        }

        /// <summary>
        /// 新增一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertMemberlevel(MemberlevelInfo memberlevelInfo)
        {
            return memberlevelDA.InsertMemberlevel(memberlevelInfo);
        }

        /// <summary>
        /// 删除一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevelID">MemberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteMemberlevel(List<string> memberlevelID)
        {
            int result = 0;
            if (memberlevelID != null && memberlevelID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < memberlevelID.Count; i++)
                    {
                        result += memberlevelDA.DeleteMemberlevel(db, dbTran, memberlevelID[i]);
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
        /// 更新一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateMemberlevel(MemberlevelInfo memberlevelInfo)
        {
            return memberlevelDA.UpdateMemberlevel(memberlevelInfo);
        }

        /// <summary>
        /// 检查MemberlevelID是否已存在
        /// </summary>
        /// <param name="memberlevelID">MemberlevelID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckMemberlevelIDIsExist(string memberlevelID)
        {
            return memberlevelDA.CheckMemberlevelIDIsExist(memberlevelID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
