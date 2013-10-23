/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IUserroleDA
// 文件功能描述：提供Userrole数据表操作的方法的定义
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
    public interface IUserroleDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Userrole记录
        /// </summary>
        /// <returns>所有的Userrole记录</returns>
        DataSet GetAllUserrole();
        /// <summary>
        /// 得到所有的Userrole记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Userrole记录</returns>
        DataSet GetAllUserrole(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Userrole记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserroleQueryEntity">Userrole查询实体类</param>
        /// <returns>根据查询条件得到Userrole记录</returns>
        DataSet GetUserroleByQueryList(QueryEntity userroleQuery);
        /// <summary>
        /// 根据查询条件得到Userrole记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserroleQueryEntity">Userrole查询实体类</param>
        /// <returns>根据查询条件得到Userrole记录</returns>
        DataSet GetUserroleByQueryList(Database db, DbTransaction tran, QueryEntity userroleQuery);

        /// <summary>
        /// 根据userroleID得到一条Userrole记录
        /// </summary>
        /// <param name="userroleID">userroleID</param>
        /// <returns>根据userroleID得到一条Userrole记录</returns>
        UserroleInfo GetUserroleByID(string userroleID);
        /// <summary>
        /// 根据userroleID得到一条Userrole记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userroleID">userroleID</param>
        /// <returns>根据userroleID得到一条Userrole记录</returns>
        UserroleInfo GetUserroleByID(Database db, DbTransaction tran, string userroleID);

        /// <summary>
        /// 新增一条Userrole记录
        /// </summary>
        /// <param name="userrole">Userrole对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertUserrole(UserroleInfo userroleInfo);
        /// <summary>
        /// 新增一条Userrole记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userrole">Userrole对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertUserrole(Database db, DbTransaction tran, UserroleInfo userroleInfo);

        /// <summary>
        /// 更新一条Userrole记录
        /// </summary>
        /// <param name="userrole">Userrole对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateUserrole(UserroleInfo userroleInfo);
        /// <summary>
        /// 更新一条Userrole记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userrole">Userrole对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateUserrole(Database db, DbTransaction tran, UserroleInfo userroleInfo);

        /// <summary>
        /// 删除一条Userrole记录
        /// </summary>
        /// <param name="userroleID">userroleID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteUserrole(string userroleID);
        /// <summary>
        /// 删除一条Userrole记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userroleID">userroleID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteUserrole(Database db, DbTransaction tran, string userroleID);

        /// <summary>
        /// 检查UserroleID是否已存在
        /// </summary>
        /// <param name="userroleID">userroleID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckUserroleIDIsExist(string userroleID);
        /// <summary>
        /// 检查UserroleID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="userroleID">userroleID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckUserroleIDIsExist(Database db, DbTransaction tran, string userroleID);
        #endregion

        #region 扩展方法

        int SetUserRoles(int userID, List<int> roleList, string createdBy);

        List<string> GetUserRoleListByUserID(string userID);

        #endregion
    }
}
