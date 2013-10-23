/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IRolefunctionDA
// 文件功能描述：提供Rolefunction数据表操作的方法的定义
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
    public interface IRolefunctionDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Rolefunction记录
        /// </summary>
        /// <returns>所有的Rolefunction记录</returns>
        DataSet GetAllRolefunction();
        /// <summary>
        /// 得到所有的Rolefunction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Rolefunction记录</returns>
        DataSet GetAllRolefunction(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Rolefunction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RolefunctionQueryEntity">Rolefunction查询实体类</param>
        /// <returns>根据查询条件得到Rolefunction记录</returns>
        DataSet GetRolefunctionByQueryList(QueryEntity rolefunctionQuery);
        /// <summary>
        /// 根据查询条件得到Rolefunction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RolefunctionQueryEntity">Rolefunction查询实体类</param>
        /// <returns>根据查询条件得到Rolefunction记录</returns>
        DataSet GetRolefunctionByQueryList(Database db, DbTransaction tran, QueryEntity rolefunctionQuery);

        /// <summary>
        /// 根据rolefunctionID得到一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>根据rolefunctionID得到一条Rolefunction记录</returns>
        RolefunctionInfo GetRolefunctionByID(string rolefunctionID);
        /// <summary>
        /// 根据rolefunctionID得到一条Rolefunction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>根据rolefunctionID得到一条Rolefunction记录</returns>
        RolefunctionInfo GetRolefunctionByID(Database db, DbTransaction tran, string rolefunctionID);

        /// <summary>
        /// 新增一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertRolefunction(RolefunctionInfo rolefunctionInfo);
        /// <summary>
        /// 新增一条Rolefunction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertRolefunction(Database db, DbTransaction tran, RolefunctionInfo rolefunctionInfo);

        /// <summary>
        /// 更新一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateRolefunction(RolefunctionInfo rolefunctionInfo);
        /// <summary>
        /// 更新一条Rolefunction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateRolefunction(Database db, DbTransaction tran, RolefunctionInfo rolefunctionInfo);

        /// <summary>
        /// 删除一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteRolefunction(string rolefunctionID);
        /// <summary>
        /// 删除一条Rolefunction记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteRolefunction(Database db, DbTransaction tran, string rolefunctionID);

        /// <summary>
        /// 检查RolefunctionID是否已存在
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckRolefunctionIDIsExist(string rolefunctionID);
        /// <summary>
        /// 检查RolefunctionID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckRolefunctionIDIsExist(Database db, DbTransaction tran, string rolefunctionID);
        #endregion

        #region 扩展方法
        int DeleteRoleFunctionByRoleID(int roleID);
        #endregion
    }
}
