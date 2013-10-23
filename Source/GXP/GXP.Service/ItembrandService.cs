/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：ItembrandService
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
    public class ItembrandService : IItembrandService
    {
        [Dependency]
        public IItembrandDA itembrandDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Itembrand记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Itembrand记录</returns>
        public DataSet GetAllItembrand()
        {
            return itembrandDA.GetAllItembrand();
        }

        /// <summary>
        /// 根据查询条件得到Itembrand记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItembrandQueryEntity">Itembrand查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Itembrand记录</returns>
        public DataSet GetItembrandByQueryList(QueryEntity itembrandQuery)
        {
            return itembrandDA.GetItembrandByQueryList(itembrandQuery);
        }

        /// <summary>
        /// 根据itembrandID得到一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据itembrandID得到一条Itembrand记录</returns>
        public ItembrandInfo GetItembrandByID(string itembrandID)
        {
            return itembrandDA.GetItembrandByID(itembrandID);
        }

        /// <summary>
        /// 新增一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertItembrand(ItembrandInfo itembrandInfo)
        {
            return itembrandDA.InsertItembrand(itembrandInfo);
        }

        /// <summary>
        /// 删除一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">ItembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteItembrand(List<string> itembrandID)
        {
            int result = 0;
            if (itembrandID != null && itembrandID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < itembrandID.Count; i++)
                    {
                        result += itembrandDA.DeleteItembrand(db, dbTran, itembrandID[i]);
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
        /// 更新一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateItembrand(ItembrandInfo itembrandInfo)
        {
            return itembrandDA.UpdateItembrand(itembrandInfo);
        }

        /// <summary>
        /// 检查ItembrandID是否已存在
        /// </summary>
        /// <param name="itembrandID">ItembrandID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckItembrandIDIsExist(string itembrandID)
        {
            return itembrandDA.CheckItembrandIDIsExist(itembrandID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
