/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISyscodeDA
// 文件功能描述：提供Syscode数据表操作的方法的定义
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
    public interface ISyscodeDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Syscode记录
        /// </summary>
        /// <returns>所有的Syscode记录</returns>
        DataSet GetAllSyscode();
        /// <summary>
        /// 得到所有的Syscode记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Syscode记录</returns>
        DataSet GetAllSyscode(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Syscode记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyscodeQueryEntity">Syscode查询实体类</param>
        /// <returns>根据查询条件得到Syscode记录</returns>
        DataSet GetSyscodeByQueryList(QueryEntity syscodeQuery);
        /// <summary>
        /// 根据查询条件得到Syscode记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyscodeQueryEntity">Syscode查询实体类</param>
        /// <returns>根据查询条件得到Syscode记录</returns>
        DataSet GetSyscodeByQueryList(Database db, DbTransaction tran, QueryEntity syscodeQuery);

        /// <summary>
        /// 根据syscodeID得到一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>根据syscodeID得到一条Syscode记录</returns>
        SyscodeInfo GetSyscodeByID(string syscodeID);
        /// <summary>
        /// 根据syscodeID得到一条Syscode记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>根据syscodeID得到一条Syscode记录</returns>
        SyscodeInfo GetSyscodeByID(Database db, DbTransaction tran, string syscodeID);

        /// <summary>
        /// 新增一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSyscode(SyscodeInfo syscodeInfo);
        /// <summary>
        /// 新增一条Syscode记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscode">Syscode对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSyscode(Database db, DbTransaction tran, SyscodeInfo syscodeInfo);

        /// <summary>
        /// 更新一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSyscode(SyscodeInfo syscodeInfo);
        /// <summary>
        /// 更新一条Syscode记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscode">Syscode对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSyscode(Database db, DbTransaction tran, SyscodeInfo syscodeInfo);

        /// <summary>
        /// 删除一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSyscode(string syscodeID);
        /// <summary>
        /// 删除一条Syscode记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSyscode(Database db, DbTransaction tran, string syscodeID);

        /// <summary>
        /// 检查SyscodeID是否已存在
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSyscodeIDIsExist(string syscodeID);
        /// <summary>
        /// 检查SyscodeID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSyscodeIDIsExist(Database db, DbTransaction tran, string syscodeID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
