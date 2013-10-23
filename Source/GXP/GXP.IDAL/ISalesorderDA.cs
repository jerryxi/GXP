/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISalesorderDA
// 文件功能描述：提供Salesorder数据表操作的方法的定义
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
    public interface ISalesorderDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Salesorder记录
        /// </summary>
        /// <returns>所有的Salesorder记录</returns>
        DataSet GetAllSalesorder();
        /// <summary>
        /// 得到所有的Salesorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Salesorder记录</returns>
        DataSet GetAllSalesorder(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Salesorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderQueryEntity">Salesorder查询实体类</param>
        /// <returns>根据查询条件得到Salesorder记录</returns>
        DataSet GetSalesorderByQueryList(QueryEntity salesorderQuery);
        /// <summary>
        /// 根据查询条件得到Salesorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderQueryEntity">Salesorder查询实体类</param>
        /// <returns>根据查询条件得到Salesorder记录</returns>
        DataSet GetSalesorderByQueryList(Database db, DbTransaction tran, QueryEntity salesorderQuery);

        /// <summary>
        /// 根据salesorderID得到一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>根据salesorderID得到一条Salesorder记录</returns>
        SalesorderInfo GetSalesorderByID(string salesorderID);
        /// <summary>
        /// 根据salesorderID得到一条Salesorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>根据salesorderID得到一条Salesorder记录</returns>
        SalesorderInfo GetSalesorderByID(Database db, DbTransaction tran, string salesorderID);

        /// <summary>
        /// 新增一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSalesorder(SalesorderInfo salesorderInfo);
        /// <summary>
        /// 新增一条Salesorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorder">Salesorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSalesorder(Database db, DbTransaction tran, SalesorderInfo salesorderInfo);

        /// <summary>
        /// 更新一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSalesorder(SalesorderInfo salesorderInfo);
        /// <summary>
        /// 更新一条Salesorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorder">Salesorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSalesorder(Database db, DbTransaction tran, SalesorderInfo salesorderInfo);

        /// <summary>
        /// 删除一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSalesorder(string salesorderID);
        /// <summary>
        /// 删除一条Salesorder记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSalesorder(Database db, DbTransaction tran, string salesorderID);

        /// <summary>
        /// 检查SalesorderID是否已存在
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSalesorderIDIsExist(string salesorderID);
        /// <summary>
        /// 检查SalesorderID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSalesorderIDIsExist(Database db, DbTransaction tran, string salesorderID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
