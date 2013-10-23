/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMemberDA
// 文件功能描述：提供Member数据表操作的方法的定义
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
    public interface IMemberDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Member记录
        /// </summary>
        /// <returns>所有的Member记录</returns>
        DataSet GetAllMember();
        /// <summary>
        /// 得到所有的Member记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Member记录</returns>
        DataSet GetAllMember(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Member记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberQueryEntity">Member查询实体类</param>
        /// <returns>根据查询条件得到Member记录</returns>
        DataSet GetMemberByQueryList(QueryEntity memberQuery);
        /// <summary>
        /// 根据查询条件得到Member记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberQueryEntity">Member查询实体类</param>
        /// <returns>根据查询条件得到Member记录</returns>
        DataSet GetMemberByQueryList(Database db, DbTransaction tran, QueryEntity memberQuery);

        /// <summary>
        /// 根据memberID得到一条Member记录
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <returns>根据memberID得到一条Member记录</returns>
        MemberInfo GetMemberByID(string memberID);
        /// <summary>
        /// 根据memberID得到一条Member记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberID">memberID</param>
        /// <returns>根据memberID得到一条Member记录</returns>
        MemberInfo GetMemberByID(Database db, DbTransaction tran, string memberID);

        /// <summary>
        /// 新增一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMember(MemberInfo memberInfo);
        /// <summary>
        /// 新增一条Member记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="member">Member对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMember(Database db, DbTransaction tran, MemberInfo memberInfo);

        /// <summary>
        /// 更新一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMember(MemberInfo memberInfo);
        /// <summary>
        /// 更新一条Member记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="member">Member对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMember(Database db, DbTransaction tran, MemberInfo memberInfo);

        /// <summary>
        /// 删除一条Member记录
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMember(string memberID);
        /// <summary>
        /// 删除一条Member记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberID">memberID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMember(Database db, DbTransaction tran, string memberID);

        /// <summary>
        /// 检查MemberID是否已存在
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberIDIsExist(string memberID);
        /// <summary>
        /// 检查MemberID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="memberID">memberID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberIDIsExist(Database db, DbTransaction tran, string memberID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
