/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IInvtransactionDA
// 文件功能描述：提供Invtransaction数据表操作的方法的定义
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
    public interface IInvtransactionDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Invtransaction记录
        /// </summary>
        /// <returns>所有的Invtransaction记录</returns>
        DataSet GetAllInvtransaction();
        /// <summary>
        /// 得到所有的Invtransaction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Invtransaction记录</returns>
        DataSet GetAllInvtransaction(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Invtransaction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InvtransactionQueryEntity">Invtransaction查询实体类</param>
        /// <returns>根据查询条件得到Invtransaction记录</returns>
        DataSet GetInvtransactionByQueryList(QueryEntity invtransactionQuery);
        /// <summary>
        /// 根据查询条件得到Invtransaction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="InvtransactionQueryEntity">Invtransaction查询实体类</param>
        /// <returns>根据查询条件得到Invtransaction记录</returns>
        DataSet GetInvtransactionByQueryList(Database db, DbTransaction tran, QueryEntity invtransactionQuery);

        /// <summary>
        /// 根据invtransactionID得到一条Invtransaction记录
        /// </summary>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <returns>根据invtransactionID得到一条Invtransaction记录</returns>
        InvtransactionInfo GetInvtransactionByID(string invtransactionID);
        /// <summary>
        /// 根据invtransactionID得到一条Invtransaction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <returns>根据invtransactionID得到一条Invtransaction记录</returns>
        InvtransactionInfo GetInvtransactionByID(Database db, DbTransaction tran, string invtransactionID);

        /// <summary>
        /// 新增一条Invtransaction记录
        /// </summary>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertInvtransaction(InvtransactionInfo invtransactionInfo);
        /// <summary>
        /// 新增一条Invtransaction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertInvtransaction(Database db, DbTransaction tran, InvtransactionInfo invtransactionInfo);

        /// <summary>
        /// 更新一条Invtransaction记录
        /// </summary>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateInvtransaction(InvtransactionInfo invtransactionInfo);
        /// <summary>
        /// 更新一条Invtransaction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransaction">Invtransaction对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateInvtransaction(Database db, DbTransaction tran, InvtransactionInfo invtransactionInfo);

        /// <summary>
        /// 删除一条Invtransaction记录
        /// </summary>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteInvtransaction(string invtransactionID);
        /// <summary>
        /// 删除一条Invtransaction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteInvtransaction(Database db, DbTransaction tran, string invtransactionID);

        /// <summary>
        /// 检查InvtransactionID是否已存在
        /// </summary>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckInvtransactionIDIsExist(string invtransactionID);
        /// <summary>
        /// 检查InvtransactionID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="invtransactionID">invtransactionID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckInvtransactionIDIsExist(Database db, DbTransaction tran, string invtransactionID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
