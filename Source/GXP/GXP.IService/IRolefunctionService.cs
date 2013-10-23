/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IRolefunctionService
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
    public interface IRolefunctionService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Rolefunction记录
        /// </summary>
        /// <returns>所有的Rolefunction记录</returns>
        DataSet GetAllRolefunction();

        /// <summary>
        /// 根据查询条件得到Rolefunction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RolefunctionQueryEntity">Rolefunction查询实体类</param>
        /// <returns>根据查询条件得到Rolefunction记录</returns>
        DataSet GetRolefunctionByQueryList(QueryEntity rolefunctionQuery);

        /// <summary>
        /// 根据rolefunctionID得到一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>根据rolefunctionID得到一条Rolefunction记录</returns>
        RolefunctionInfo GetRolefunctionByID(string rolefunctionID);

        /// <summary>
        /// 新增一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertRolefunction(RolefunctionInfo rolefunctionInfo);

        /// <summary>
        /// 更新一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateRolefunction(RolefunctionInfo rolefunctionInfo);

        /// <summary>
        /// 删除一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteRolefunction(List<string> rolefunctionID);

        /// <summary>
        /// 检查RolefunctionID是否已存在
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckRolefunctionIDIsExist(string rolefunctionID);
        #endregion

        #region 扩展方法
        int InsertRolefunction(int roleID, string functionID);
        #endregion
    }
}
