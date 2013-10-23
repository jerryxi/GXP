/*----------------------------------------------------------------
//
// Copyright (C) 2013 Jerry
// 
//
// 文件名：IAreaDA
// 文件功能描述：提供Area数据表操作的方法的定义
//
// 创建标识：JerryXi 2013/7/10  
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using GXP.DataEntity;

namespace GXP.IDAL
{
    public interface IAreaDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Area记录
        /// </summary>
        /// <returns>所有的Area记录</returns>
        DataSet GetAllArea();
        /// <summary>
        /// 得到所有的Area记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Area记录</returns>
        DataSet GetAllArea(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Area记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="AreaQueryEntity">Area查询实体类</param>
        /// <returns>根据查询条件得到Area记录</returns>
        DataSet GetAreaByQueryList(QueryEntity areaQuery);
        /// <summary>
        /// 根据查询条件得到Area记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="AreaQueryEntity">Area查询实体类</param>
        /// <returns>根据查询条件得到Area记录</returns>
        DataSet GetAreaByQueryList(Database db, DbTransaction tran, QueryEntity areaQuery);

        /// <summary>
        /// 根据areaID得到一条Area记录
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <returns>根据areaID得到一条Area记录</returns>
        AreaInfo GetAreaByID(string areaID);
        /// <summary>
        /// 根据areaID得到一条Area记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="areaID">areaID</param>
        /// <returns>根据areaID得到一条Area记录</returns>
        AreaInfo GetAreaByID(Database db, DbTransaction tran, string areaID);

        /// <summary>
        /// 新增一条Area记录
        /// </summary>
        /// <param name="area">Area对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertArea(AreaInfo areaInfo);
        /// <summary>
        /// 新增一条Area记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="area">Area对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertArea(Database db, DbTransaction tran, AreaInfo areaInfo);

        /// <summary>
        /// 更新一条Area记录
        /// </summary>
        /// <param name="area">Area对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateArea(AreaInfo areaInfo);
        /// <summary>
        /// 更新一条Area记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="area">Area对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateArea(Database db, DbTransaction tran, AreaInfo areaInfo);

        /// <summary>
        /// 删除一条Area记录
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteArea(string areaID);
        /// <summary>
        /// 删除一条Area记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="areaID">areaID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteArea(Database db, DbTransaction tran, string areaID);

        /// <summary>
        /// 检查AreaID是否已存在
        /// </summary>
        /// <param name="areaID">areaID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckAreaIDIsExist(string areaID);
        /// <summary>
        /// 检查AreaID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="areaID">areaID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckAreaIDIsExist(Database db, DbTransaction tran, string areaID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
