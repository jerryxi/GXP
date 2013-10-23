/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISyssettingService
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
    public interface ISyssettingService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Syssetting记录
        /// </summary>
        /// <returns>所有的Syssetting记录</returns>
        DataSet GetAllSyssetting();

        /// <summary>
        /// 根据查询条件得到Syssetting记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SyssettingQueryEntity">Syssetting查询实体类</param>
        /// <returns>根据查询条件得到Syssetting记录</returns>
        DataSet GetSyssettingByQueryList(QueryEntity syssettingQuery);

        /// <summary>
        /// 根据syssettingID得到一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>根据syssettingID得到一条Syssetting记录</returns>
        SyssettingInfo GetSyssettingByID(string syssettingID);

        /// <summary>
        /// 新增一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSyssetting(SyssettingInfo syssettingInfo);

        /// <summary>
        /// 更新一条Syssetting记录
        /// </summary>
        /// <param name="syssetting">Syssetting对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSyssetting(SyssettingInfo syssettingInfo);

        /// <summary>
        /// 删除一条Syssetting记录
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSyssetting(List<string> syssettingID);

        /// <summary>
        /// 检查SyssettingID是否已存在
        /// </summary>
        /// <param name="syssettingID">syssettingID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSyssettingIDIsExist(string syssettingID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
