/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IUsersupplierService
// 文件功能描述：
//
// 创建标识：JerryXi 2013/8/20  
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
    public interface IUsersupplierService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Usersupplier记录
        /// </summary>
        /// <returns>所有的Usersupplier记录</returns>
        DataSet GetAllUsersupplier();

        /// <summary>
        /// 根据查询条件得到Usersupplier记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="UsersupplierQueryEntity">Usersupplier查询实体类</param>
        /// <returns>根据查询条件得到Usersupplier记录</returns>
        DataSet GetUsersupplierByQueryList(QueryEntity usersupplierQuery);

        /// <summary>
        /// 根据usersupplierID得到一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <returns>根据usersupplierID得到一条Usersupplier记录</returns>
        UsersupplierInfo GetUsersupplierByID(string usersupplierID);

        /// <summary>
        /// 新增一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertUsersupplier(UsersupplierInfo usersupplierInfo);

        /// <summary>
        /// 更新一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplier">Usersupplier对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateUsersupplier(UsersupplierInfo usersupplierInfo);

        /// <summary>
        /// 删除一条Usersupplier记录
        /// </summary>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteUsersupplier(List<string> usersupplierID);

        /// <summary>
        /// 检查UsersupplierID是否已存在
        /// </summary>
        /// <param name="usersupplierID">usersupplierID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckUsersupplierIDIsExist(string usersupplierID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
