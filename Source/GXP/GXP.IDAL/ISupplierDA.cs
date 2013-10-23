/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISupplierDA
// 文件功能描述：提供Supplier数据表操作的方法的定义
//
// 创建标识：JerryXi 2013/7/10  
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using GXP.DataEntity;

namespace GXP.IDAL
{
    public interface ISupplierDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Supplier记录
        /// </summary>
        /// <returns>所有的Supplier记录</returns>
        DataSet GetAllSupplier();
        /// <summary>
        /// 得到所有的Supplier记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Supplier记录</returns>
        DataSet GetAllSupplier(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Supplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SupplierQueryEntity">Supplier查询实体类</param>
        /// <returns>根据查询条件得到Supplier记录</returns>
        DataSet GetSupplierByQueryList(QueryEntity supplierQuery);
        /// <summary>
        /// 根据查询条件得到Supplier记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SupplierQueryEntity">Supplier查询实体类</param>
        /// <returns>根据查询条件得到Supplier记录</returns>
        DataSet GetSupplierByQueryList(Database db, DbTransaction tran, QueryEntity supplierQuery);

        /// <summary>
        /// 根据supplierID得到一条Supplier记录
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <returns>根据supplierID得到一条Supplier记录</returns>
        SupplierInfo GetSupplierByID(string supplierID);
        /// <summary>
        /// 根据supplierID得到一条Supplier记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplierID">supplierID</param>
        /// <returns>根据supplierID得到一条Supplier记录</returns>
        SupplierInfo GetSupplierByID(Database db, DbTransaction tran, string supplierID);

        /// <summary>
        /// 新增一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSupplier(SupplierInfo supplierInfo);
        /// <summary>
        /// 新增一条Supplier记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplier">Supplier对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSupplier(Database db, DbTransaction tran, SupplierInfo supplierInfo);

        /// <summary>
        /// 更新一条Supplier记录
        /// </summary>
        /// <param name="supplier">Supplier对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSupplier(SupplierInfo supplierInfo);
        /// <summary>
        /// 更新一条Supplier记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplier">Supplier对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSupplier(Database db, DbTransaction tran, SupplierInfo supplierInfo);

        /// <summary>
        /// 删除一条Supplier记录
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSupplier(string supplierID);
        /// <summary>
        /// 删除一条Supplier记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplierID">supplierID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSupplier(Database db, DbTransaction tran, string supplierID);

        /// <summary>
        /// 检查SupplierID是否已存在
        /// </summary>
        /// <param name="supplierID">supplierID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSupplierIDIsExist(string supplierID);
        /// <summary>
        /// 检查SupplierID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="supplierID">supplierID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSupplierIDIsExist(Database db, DbTransaction tran, string supplierID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
