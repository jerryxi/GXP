/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IOperationlogDA
// 文件功能描述：提供Operationlog数据表操作的方法的定义
//
// 创建标识：JerryXi 2013/8/20  
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
    public interface IOperationlogDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Operationlog记录
        /// </summary>
        /// <returns>所有的Operationlog记录</returns>
        DataSet GetAllOperationlog();
        /// <summary>
        /// 得到所有的Operationlog记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Operationlog记录</returns>
        DataSet GetAllOperationlog(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Operationlog记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="OperationlogQueryEntity">Operationlog查询实体类</param>
        /// <returns>根据查询条件得到Operationlog记录</returns>
        DataSet GetOperationlogByQueryList(QueryEntity operationlogQuery);
        /// <summary>
        /// 根据查询条件得到Operationlog记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="OperationlogQueryEntity">Operationlog查询实体类</param>
        /// <returns>根据查询条件得到Operationlog记录</returns>
        DataSet GetOperationlogByQueryList(Database db, DbTransaction tran, QueryEntity operationlogQuery);

        /// <summary>
        /// 根据operationlogID得到一条Operationlog记录
        /// </summary>
        /// <param name="operationlogID">operationlogID</param>
        /// <returns>根据operationlogID得到一条Operationlog记录</returns>
        OperationlogInfo GetOperationlogByID(string operationlogID);
        /// <summary>
        /// 根据operationlogID得到一条Operationlog记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlogID">operationlogID</param>
        /// <returns>根据operationlogID得到一条Operationlog记录</returns>
        OperationlogInfo GetOperationlogByID(Database db, DbTransaction tran, string operationlogID);

        /// <summary>
        /// 新增一条Operationlog记录
        /// </summary>
        /// <param name="operationlog">Operationlog对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertOperationlog(OperationlogInfo operationlogInfo);
        /// <summary>
        /// 新增一条Operationlog记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlog">Operationlog对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertOperationlog(Database db, DbTransaction tran, OperationlogInfo operationlogInfo);

        /// <summary>
        /// 更新一条Operationlog记录
        /// </summary>
        /// <param name="operationlog">Operationlog对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateOperationlog(OperationlogInfo operationlogInfo);
        /// <summary>
        /// 更新一条Operationlog记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlog">Operationlog对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateOperationlog(Database db, DbTransaction tran, OperationlogInfo operationlogInfo);

        /// <summary>
        /// 删除一条Operationlog记录
        /// </summary>
        /// <param name="operationlogID">operationlogID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteOperationlog(string operationlogID);
        /// <summary>
        /// 删除一条Operationlog记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlogID">operationlogID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteOperationlog(Database db, DbTransaction tran, string operationlogID);

        /// <summary>
        /// 检查OperationlogID是否已存在
        /// </summary>
        /// <param name="operationlogID">operationlogID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckOperationlogIDIsExist(string operationlogID);
        /// <summary>
        /// 检查OperationlogID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="operationlogID">operationlogID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckOperationlogIDIsExist(Database db, DbTransaction tran, string operationlogID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
