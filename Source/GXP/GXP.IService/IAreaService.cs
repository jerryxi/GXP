/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IAreaService
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
    public interface IAreaService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Area记录
        /// </summary>
        /// <returns>所有的Area记录</returns>
        DataSet GetAllArea();

        /// <summary>
        /// 根据查询条件得到Area记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="AreaQueryEntity">Area查询实体类</param>
        /// <returns>根据查询条件得到Area记录</returns>
        DataSet GetAreaByQueryList(QueryEntity areaQuery);

        /// <summary>
        /// 根据areaID得到一条Area记录
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <returns>根据areaID得到一条Area记录</returns>
        AreaInfo GetAreaByID(string areaID);

        /// <summary>
        /// 新增一条Area记录
        /// </summary>
        /// <param name="area">Area对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertArea(AreaInfo areaInfo);

        /// <summary>
        /// 更新一条Area记录
        /// </summary>
        /// <param name="area">Area对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateArea(AreaInfo areaInfo);

        /// <summary>
        /// 删除一条Area记录
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteArea(List<string> areaID);

        /// <summary>
        /// 检查AreaID是否已存在
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckAreaIDIsExist(string areaID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
