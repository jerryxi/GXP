/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IRoleDA
// 文件功能描述：提供Role数据表操作的方法的定义
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
    public interface IRoleDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Role记录
        /// </summary>
        /// <returns>所有的Role记录</returns>
        DataSet GetAllRole();
        /// <summary>
        /// 得到所有的Role记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Role记录</returns>
        DataSet GetAllRole(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Role记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RoleQueryEntity">Role查询实体类</param>
        /// <returns>根据查询条件得到Role记录</returns>
        DataSet GetRoleByQueryList(QueryEntity roleQuery);
        /// <summary>
        /// 根据查询条件得到Role记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RoleQueryEntity">Role查询实体类</param>
        /// <returns>根据查询条件得到Role记录</returns>
        DataSet GetRoleByQueryList(Database db, DbTransaction tran, QueryEntity roleQuery);

        /// <summary>
        /// 根据roleID得到一条Role记录
        /// </summary>
        /// <param name="roleID">roleID</param>
        /// <returns>根据roleID得到一条Role记录</returns>
        RoleInfo GetRoleByID(string roleID);
        /// <summary>
        /// 根据roleID得到一条Role记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="roleID">roleID</param>
        /// <returns>根据roleID得到一条Role记录</returns>
        RoleInfo GetRoleByID(Database db, DbTransaction tran, string roleID);

        /// <summary>
        /// 新增一条Role记录
        /// </summary>
        /// <param name="role">Role对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertRole(RoleInfo roleInfo);
        /// <summary>
        /// 新增一条Role记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="role">Role对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertRole(Database db, DbTransaction tran, RoleInfo roleInfo);

        /// <summary>
        /// 更新一条Role记录
        /// </summary>
        /// <param name="role">Role对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateRole(RoleInfo roleInfo);
        /// <summary>
        /// 更新一条Role记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="role">Role对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateRole(Database db, DbTransaction tran, RoleInfo roleInfo);

        /// <summary>
        /// 删除一条Role记录
        /// </summary>
        /// <param name="roleID">roleID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteRole(string roleID);
        /// <summary>
        /// 删除一条Role记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="roleID">roleID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteRole(Database db, DbTransaction tran, string roleID);

        /// <summary>
        /// 检查RoleID是否已存在
        /// </summary>
        /// <param name="roleID">roleID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckRoleIDIsExist(string roleID);
        /// <summary>
        /// 检查RoleID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="roleID">roleID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckRoleIDIsExist(Database db, DbTransaction tran, string roleID);
        #endregion

        #region 扩展方法

        List<RoleInfo> GetAllRoleList();

        #endregion
    }
}
