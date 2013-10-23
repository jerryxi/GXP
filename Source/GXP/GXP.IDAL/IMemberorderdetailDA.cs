/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMemberorderdetailDA
// 文件功能描述：提供Memberorderdetail数据表操作的方法的定义
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
    public interface IMemberorderdetailDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Memberorderdetail记录
        /// </summary>
        /// <returns>所有的Memberorderdetail记录</returns>
        DataSet GetAllMemberorderdetail();
        /// <summary>
        /// 得到所有的Memberorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Memberorderdetail记录</returns>
        DataSet GetAllMemberorderdetail(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Memberorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderdetailQueryEntity">Memberorderdetail查询实体类</param>
        /// <returns>根据查询条件得到Memberorderdetail记录</returns>
        DataSet GetMemberorderdetailByQueryList(QueryEntity memberorderdetailQuery);
        /// <summary>
        /// 根据查询条件得到Memberorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderdetailQueryEntity">Memberorderdetail查询实体类</param>
        /// <returns>根据查询条件得到Memberorderdetail记录</returns>
        DataSet GetMemberorderdetailByQueryList(Database db, DbTransaction tran, QueryEntity memberorderdetailQuery);

        /// <summary>
        /// 根据memberorderdetailID得到一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>根据memberorderdetailID得到一条Memberorderdetail记录</returns>
        MemberorderdetailInfo GetMemberorderdetailByID(string memberorderdetailID);
        /// <summary>
        /// 根据memberorderdetailID得到一条Memberorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>根据memberorderdetailID得到一条Memberorderdetail记录</returns>
        MemberorderdetailInfo GetMemberorderdetailByID(Database db, DbTransaction tran, string memberorderdetailID);

        /// <summary>
        /// 新增一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo);
        /// <summary>
        /// 新增一条Memberorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMemberorderdetail(Database db, DbTransaction tran, MemberorderdetailInfo memberorderdetailInfo);

        /// <summary>
        /// 更新一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo);
        /// <summary>
        /// 更新一条Memberorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMemberorderdetail(Database db, DbTransaction tran, MemberorderdetailInfo memberorderdetailInfo);

        /// <summary>
        /// 删除一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMemberorderdetail(string memberorderdetailID);
        /// <summary>
        /// 删除一条Memberorderdetail记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMemberorderdetail(Database db, DbTransaction tran, string memberorderdetailID);

        /// <summary>
        /// 检查MemberorderdetailID是否已存在
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberorderdetailIDIsExist(string memberorderdetailID);
        /// <summary>
        /// 检查MemberorderdetailID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberorderdetailIDIsExist(Database db, DbTransaction tran, string memberorderdetailID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
