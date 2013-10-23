/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItembrandService
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
    public interface IItembrandService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Itembrand记录
        /// </summary>
        /// <returns>所有的Itembrand记录</returns>
        DataSet GetAllItembrand();

        /// <summary>
        /// 根据查询条件得到Itembrand记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItembrandQueryEntity">Itembrand查询实体类</param>
        /// <returns>根据查询条件得到Itembrand记录</returns>
        DataSet GetItembrandByQueryList(QueryEntity itembrandQuery);

        /// <summary>
        /// 根据itembrandID得到一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>根据itembrandID得到一条Itembrand记录</returns>
        ItembrandInfo GetItembrandByID(string itembrandID);

        /// <summary>
        /// 新增一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItembrand(ItembrandInfo itembrandInfo);

        /// <summary>
        /// 更新一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItembrand(ItembrandInfo itembrandInfo);

        /// <summary>
        /// 删除一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItembrand(List<string> itembrandID);

        /// <summary>
        /// 检查ItembrandID是否已存在
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItembrandIDIsExist(string itembrandID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
