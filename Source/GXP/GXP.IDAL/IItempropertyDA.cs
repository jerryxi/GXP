/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IItempropertyDA
// 文件功能描述：提供Itemproperty数据表操作的方法的定义
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
    public interface IItempropertyDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Itemproperty记录
        /// </summary>
        /// <returns>所有的Itemproperty记录</returns>
        DataSet GetAllItemproperty();
        /// <summary>
        /// 得到所有的Itemproperty记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Itemproperty记录</returns>
        DataSet GetAllItemproperty(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Itemproperty记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItempropertyQueryEntity">Itemproperty查询实体类</param>
        /// <returns>根据查询条件得到Itemproperty记录</returns>
        DataSet GetItempropertyByQueryList(QueryEntity itempropertyQuery);
        /// <summary>
        /// 根据查询条件得到Itemproperty记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="ItempropertyQueryEntity">Itemproperty查询实体类</param>
        /// <returns>根据查询条件得到Itemproperty记录</returns>
        DataSet GetItempropertyByQueryList(Database db, DbTransaction tran, QueryEntity itempropertyQuery);

        /// <summary>
        /// 根据itempropertyID得到一条Itemproperty记录
        /// </summary>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <returns>根据itempropertyID得到一条Itemproperty记录</returns>
        ItempropertyInfo GetItempropertyByID(string itempropertyID);
        /// <summary>
        /// 根据itempropertyID得到一条Itemproperty记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <returns>根据itempropertyID得到一条Itemproperty记录</returns>
        ItempropertyInfo GetItempropertyByID(Database db, DbTransaction tran, string itempropertyID);

        /// <summary>
        /// 新增一条Itemproperty记录
        /// </summary>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItemproperty(ItempropertyInfo itempropertyInfo);
        /// <summary>
        /// 新增一条Itemproperty记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertItemproperty(Database db, DbTransaction tran, ItempropertyInfo itempropertyInfo);

        /// <summary>
        /// 更新一条Itemproperty记录
        /// </summary>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItemproperty(ItempropertyInfo itempropertyInfo);
        /// <summary>
        /// 更新一条Itemproperty记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itemproperty">Itemproperty对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateItemproperty(Database db, DbTransaction tran, ItempropertyInfo itempropertyInfo);

        /// <summary>
        /// 删除一条Itemproperty记录
        /// </summary>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItemproperty(string itempropertyID);
        /// <summary>
        /// 删除一条Itemproperty记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteItemproperty(Database db, DbTransaction tran, string itempropertyID);

        /// <summary>
        /// 检查ItempropertyID是否已存在
        /// </summary>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItempropertyIDIsExist(string itempropertyID);
        /// <summary>
        /// 检查ItempropertyID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="itempropertyID">itempropertyID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckItempropertyIDIsExist(Database db, DbTransaction tran, string itempropertyID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
