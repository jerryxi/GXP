/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISyssettingDA
// 文件功能描述：提供Syssetting数据表操作的方法的定义
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
    public interface ISyssettingDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Syssetting记录
        /// </summary>
        /// <returns>所有的Syssetting记录</returns>
        DataSet GetAllSyssetting();
        /// <summary>
        /// 得到所有的Syssetting记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Syssetting记录</returns>
        DataSet GetAllSyssetting(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Syssetting记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyssettingQueryEntity">Syssetting查询实体类</param>
        /// <returns>根据查询条件得到Syssetting记录</returns>
        DataSet GetSyssettingByQueryList(QueryEntity syssettingQuery);
        /// <summary>
        /// 根据查询条件得到Syssetting记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyssettingQueryEntity">Syssetting查询实体类</param>
        /// <returns>根据查询条件得到Syssetting记录</returns>
        DataSet GetSyssettingByQueryList(Database db, DbTransaction tran, QueryEntity syssettingQuery);

        /// <summary>
        /// 根据syssettingID得到一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>根据syssettingID得到一条Syssetting记录</returns>
        SyssettingInfo GetSyssettingByID(string syssettingID);
        /// <summary>
        /// 根据syssettingID得到一条Syssetting记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>根据syssettingID得到一条Syssetting记录</returns>
        SyssettingInfo GetSyssettingByID(Database db, DbTransaction tran, string syssettingID);

        /// <summary>
        /// 新增一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSyssetting(SyssettingInfo syssettingInfo);
        /// <summary>
        /// 新增一条Syssetting记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssetting">Syssetting对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSyssetting(Database db, DbTransaction tran, SyssettingInfo syssettingInfo);

        /// <summary>
        /// 更新一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSyssetting(SyssettingInfo syssettingInfo);
        /// <summary>
        /// 更新一条Syssetting记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssetting">Syssetting对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSyssetting(Database db, DbTransaction tran, SyssettingInfo syssettingInfo);

        /// <summary>
        /// 删除一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSyssetting(string syssettingID);
        /// <summary>
        /// 删除一条Syssetting记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSyssetting(Database db, DbTransaction tran, string syssettingID);

        /// <summary>
        /// 检查SyssettingID是否已存在
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSyssettingIDIsExist(string syssettingID);
        /// <summary>
        /// 检查SyssettingID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSyssettingIDIsExist(Database db, DbTransaction tran, string syssettingID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
