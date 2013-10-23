﻿/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IUserService
// 文件功能描述：
//
// 创建标识：JerryXi 2013/4/6  
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
    public interface IUserService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的User记录
        /// </summary>
        /// <returns>所有的User记录</returns>
        DataSet GetAllUser();

        /// <summary>
        /// 根据查询条件得到User记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UserQueryEntity">User查询实体类</param>
        /// <returns>根据查询条件得到User记录</returns>
        DataSet GetUserByQueryList(QueryEntity userQuery);

        /// <summary>
        /// 根据userID得到一条User记录
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>根据userID得到一条User记录</returns>
        UserInfo GetUserByID(string userID);

        /// <summary>
        /// 新增一条User记录
        /// </summary>
        /// <param name="user">User对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertUser(UserInfo userInfo);

        /// <summary>
        /// 更新一条User记录
        /// </summary>
        /// <param name="user">User对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateUser(UserInfo userInfo);

        /// <summary>
        /// 删除一条User记录
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteUser(List<string> userID);

        /// <summary>
        /// 检查UserID是否已存在
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckUserIDIsExist(string userID);
        #endregion

        #region 扩展方法
        UserInfo GetUserByCodePhoneEmail(string code);

        #endregion        
    }
}
