/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItembrandDA
// 文件功能描述：提供Itembrand数据表操作的方法的定义
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
    public interface IItembrandDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Itembrand记录
        /// </summary>
        /// <returns>所有的Itembrand记录</returns>
        DataSet GetAllItembrand();
        /// <summary>
        /// 得到所有的Itembrand记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Itembrand记录</returns>
        DataSet GetAllItembrand(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Itembrand记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItembrandQueryEntity">Itembrand查询实体类</param>
        /// <returns>根据查询条件得到Itembrand记录</returns>
        DataSet GetItembrandByQueryList(QueryEntity itembrandQuery);
        /// <summary>
        /// 根据查询条件得到Itembrand记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItembrandQueryEntity">Itembrand查询实体类</param>
        /// <returns>根据查询条件得到Itembrand记录</returns>
        DataSet GetItembrandByQueryList(Database db, DbTransaction tran, QueryEntity itembrandQuery);

        /// <summary>
        /// 根据itembrandID得到一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>根据itembrandID得到一条Itembrand记录</returns>
        ItembrandInfo GetItembrandByID(string itembrandID);
        /// <summary>
        /// 根据itembrandID得到一条Itembrand记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>根据itembrandID得到一条Itembrand记录</returns>
        ItembrandInfo GetItembrandByID(Database db, DbTransaction tran, string itembrandID);

        /// <summary>
        /// 新增一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItembrand(ItembrandInfo itembrandInfo);
        /// <summary>
        /// 新增一条Itembrand记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrand">Itembrand对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItembrand(Database db, DbTransaction tran, ItembrandInfo itembrandInfo);

        /// <summary>
        /// 更新一条Itembrand记录
        /// </summary>
        /// <param name="itembrand">Itembrand对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItembrand(ItembrandInfo itembrandInfo);
        /// <summary>
        /// 更新一条Itembrand记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrand">Itembrand对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItembrand(Database db, DbTransaction tran, ItembrandInfo itembrandInfo);

        /// <summary>
        /// 删除一条Itembrand记录
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItembrand(string itembrandID);
        /// <summary>
        /// 删除一条Itembrand记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItembrand(Database db, DbTransaction tran, string itembrandID);

        /// <summary>
        /// 检查ItembrandID是否已存在
        /// </summary>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItembrandIDIsExist(string itembrandID);
        /// <summary>
        /// 检查ItembrandID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itembrandID">itembrandID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItembrandIDIsExist(Database db, DbTransaction tran, string itembrandID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
