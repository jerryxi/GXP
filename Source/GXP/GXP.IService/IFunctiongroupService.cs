/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IFunctiongroupService
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
    public interface IFunctiongroupService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Functiongroup记录
        /// </summary>
        /// <returns>所有的Functiongroup记录</returns>
        DataSet GetAllFunctiongroup();

        /// <summary>
        /// 根据查询条件得到Functiongroup记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="FunctiongroupQueryEntity">Functiongroup查询实体类</param>
        /// <returns>根据查询条件得到Functiongroup记录</returns>
        DataSet GetFunctiongroupByQueryList(QueryEntity functiongroupQuery);

        /// <summary>
        /// 根据functiongroupID得到一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <returns>根据functiongroupID得到一条Functiongroup记录</returns>
        FunctiongroupInfo GetFunctiongroupByID(string functiongroupID);

        /// <summary>
        /// 新增一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertFunctiongroup(FunctiongroupInfo functiongroupInfo);

        /// <summary>
        /// 更新一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroup">Functiongroup对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateFunctiongroup(FunctiongroupInfo functiongroupInfo);

        /// <summary>
        /// 删除一条Functiongroup记录
        /// </summary>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteFunctiongroup(List<string> functiongroupID);

        /// <summary>
        /// 检查FunctiongroupID是否已存在
        /// </summary>
        /// <param name="functiongroupID">functiongroupID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckFunctiongroupIDIsExist(string functiongroupID);
        #endregion

        #region 扩展方法
        DataSet GetFunctionGroupByRoleID(int roleID);

        DataSet GetFunctionGroupByUserID(int userID);
        #endregion
    }
}
