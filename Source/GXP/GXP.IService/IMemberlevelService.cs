/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMemberlevelService
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
    public interface IMemberlevelService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Memberlevel记录
        /// </summary>
        /// <returns>所有的Memberlevel记录</returns>
        DataSet GetAllMemberlevel();

        /// <summary>
        /// 根据查询条件得到Memberlevel记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberlevelQueryEntity">Memberlevel查询实体类</param>
        /// <returns>根据查询条件得到Memberlevel记录</returns>
        DataSet GetMemberlevelByQueryList(QueryEntity memberlevelQuery);

        /// <summary>
        /// 根据memberlevelID得到一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <returns>根据memberlevelID得到一条Memberlevel记录</returns>
        MemberlevelInfo GetMemberlevelByID(string memberlevelID);

        /// <summary>
        /// 新增一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMemberlevel(MemberlevelInfo memberlevelInfo);

        /// <summary>
        /// 更新一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevel">Memberlevel对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMemberlevel(MemberlevelInfo memberlevelInfo);

        /// <summary>
        /// 删除一条Memberlevel记录
        /// </summary>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMemberlevel(List<string> memberlevelID);

        /// <summary>
        /// 检查MemberlevelID是否已存在
        /// </summary>
        /// <param name="memberlevelID">memberlevelID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberlevelIDIsExist(string memberlevelID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
