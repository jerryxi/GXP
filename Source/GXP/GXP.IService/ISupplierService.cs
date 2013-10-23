/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISupplierService
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
using System.Data;
using GXP.DataEntity;

namespace GXP.IService
{
    public interface ISupplierService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Supplier记录
        /// </summary>
        /// <returns>所有的Supplier记录</returns>
        DataSet GetAllSupplier();

        /// <summary>
        /// 根据查询条件得到Supplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SupplierQueryEntity">Supplier查询实体类</param>
        /// <returns>根据查询条件得到Supplier记录</returns>
        DataSet GetSupplierByQueryList(QueryEntity supplierQuery);

        /// <summary>
        /// 根据supplierID得到一条Supplier记录
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <returns>根据supplierID得到一条Supplier记录</returns>
        SupplierInfo GetSupplierByID(string supplierID);

        /// <summary>
        /// 新增一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSupplier(SupplierInfo supplierInfo);

        /// <summary>
        /// 更新一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSupplier(SupplierInfo supplierInfo);

        /// <summary>
        /// 删除一条Supplier记录
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSupplier(List<string> supplierID);

        /// <summary>
        /// 检查SupplierID是否已存在
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSupplierIDIsExist(string supplierID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
