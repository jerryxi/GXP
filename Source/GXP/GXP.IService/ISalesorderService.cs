/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：ISalesorderService
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
    public interface ISalesorderService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Salesorder记录
        /// </summary>
        /// <returns>所有的Salesorder记录</returns>
        DataSet GetAllSalesorder();

        /// <summary>
        /// 根据查询条件得到Salesorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="SalesorderQueryEntity">Salesorder查询实体类</param>
        /// <returns>根据查询条件得到Salesorder记录</returns>
        DataSet GetSalesorderByQueryList(QueryEntity salesorderQuery);

        /// <summary>
        /// 根据salesorderID得到一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>根据salesorderID得到一条Salesorder记录</returns>
        SalesorderInfo GetSalesorderByID(string salesorderID);

        /// <summary>
        /// 新增一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertSalesorder(SalesorderInfo salesorderInfo);

        /// <summary>
        /// 更新一条Salesorder记录
        /// </summary>
        /// <param name="salesorder">Salesorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateSalesorder(SalesorderInfo salesorderInfo);

        /// <summary>
        /// 删除一条Salesorder记录
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteSalesorder(List<string> salesorderID);

        /// <summary>
        /// 检查SalesorderID是否已存在
        /// </summary>
        /// <param name="salesorderID">salesorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckSalesorderIDIsExist(string salesorderID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
