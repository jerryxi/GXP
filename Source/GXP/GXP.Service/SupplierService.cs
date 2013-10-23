/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：SupplierService
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
    public class SupplierService : ISupplierService
    {
        [Dependency]
        public ISupplierDA supplierDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Supplier记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Supplier记录</returns>
        public DataSet GetAllSupplier()
        {
            return supplierDA.GetAllSupplier();
        }

        /// <summary>
        /// 根据查询条件得到Supplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SupplierQueryEntity">Supplier查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Supplier记录</returns>
        public DataSet GetSupplierByQueryList(QueryEntity supplierQuery)
        {
            return supplierDA.GetSupplierByQueryList(supplierQuery);
        }

        /// <summary>
        /// 根据supplierID得到一条Supplier记录
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据supplierID得到一条Supplier记录</returns>
        public SupplierInfo GetSupplierByID(string supplierID)
        {
            return supplierDA.GetSupplierByID(supplierID);
        }

        /// <summary>
        /// 新增一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertSupplier(SupplierInfo supplierInfo)
        {
            return supplierDA.InsertSupplier(supplierInfo);
        }

        /// <summary>
        /// 删除一条Supplier记录
        /// </summary>
        /// <param name="supplierID">SupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteSupplier(List<string> supplierID)
        {
            int result = 0;
            if (supplierID != null && supplierID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < supplierID.Count; i++)
                    {
                        result += supplierDA.DeleteSupplier(db, dbTran, supplierID[i]);
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
        /// 更新一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateSupplier(SupplierInfo supplierInfo)
        {
            return supplierDA.UpdateSupplier(supplierInfo);
        }

        /// <summary>
        /// 检查SupplierID是否已存在
        /// </summary>
        /// <param name="supplierID">SupplierID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckSupplierIDIsExist(string supplierID)
        {
            return supplierDA.CheckSupplierIDIsExist(supplierID);
        }
        #endregion

        #region 扩展方法
        #endregion
    }
}
