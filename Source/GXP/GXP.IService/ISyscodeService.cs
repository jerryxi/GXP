/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISyscodeService
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
    public interface ISyscodeService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Syscode记录
        /// </summary>
        /// <returns>所有的Syscode记录</returns>
        DataSet GetAllSyscode();

        /// <summary>
        /// 根据查询条件得到Syscode记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyscodeQueryEntity">Syscode查询实体类</param>
        /// <returns>根据查询条件得到Syscode记录</returns>
        DataSet GetSyscodeByQueryList(QueryEntity syscodeQuery);

        /// <summary>
        /// 根据syscodeID得到一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>根据syscodeID得到一条Syscode记录</returns>
        SyscodeInfo GetSyscodeByID(string syscodeID);

        /// <summary>
        /// 新增一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSyscode(SyscodeInfo syscodeInfo);

        /// <summary>
        /// 更新一条Syscode记录
        /// </summary>
        /// <param name="syscode">Syscode对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSyscode(SyscodeInfo syscodeInfo);

        /// <summary>
        /// 删除一条Syscode记录
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSyscode(List<string> syscodeID);

        /// <summary>
        /// 检查SyscodeID是否已存在
        /// </summary>
        /// <param name="syscodeID">syscodeID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSyscodeIDIsExist(string syscodeID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
