/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMembercommentDA
// 文件功能描述：提供Membercomment数据表操作的方法的定义
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
    public interface IMembercommentDA
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Membercomment记录
        /// </summary>
        /// <returns>所有的Membercomment记录</returns>
        DataSet GetAllMembercomment();
        /// <summary>
        /// 得到所有的Membercomment记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <returns>所有的Membercomment记录</returns>
        DataSet GetAllMembercomment(Database db, DbTransaction tran);

        /// <summary>
        /// 根据查询条件得到Membercomment记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MembercommentQueryEntity">Membercomment查询实体类</param>
        /// <returns>根据查询条件得到Membercomment记录</returns>
        DataSet GetMembercommentByQueryList(QueryEntity membercommentQuery);
        /// <summary>
        /// 根据查询条件得到Membercomment记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MembercommentQueryEntity">Membercomment查询实体类</param>
        /// <returns>根据查询条件得到Membercomment记录</returns>
        DataSet GetMembercommentByQueryList(Database db, DbTransaction tran, QueryEntity membercommentQuery);

        /// <summary>
        /// 根据membercommentID得到一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>根据membercommentID得到一条Membercomment记录</returns>
        MembercommentInfo GetMembercommentByID(string membercommentID);
        /// <summary>
        /// 根据membercommentID得到一条Membercomment记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>根据membercommentID得到一条Membercomment记录</returns>
        MembercommentInfo GetMembercommentByID(Database db, DbTransaction tran, string membercommentID);

        /// <summary>
        /// 新增一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMembercomment(MembercommentInfo membercommentInfo);
        /// <summary>
        /// 新增一条Membercomment记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercomment">Membercomment对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMembercomment(Database db, DbTransaction tran, MembercommentInfo membercommentInfo);

        /// <summary>
        /// 更新一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMembercomment(MembercommentInfo membercommentInfo);
        /// <summary>
        /// 更新一条Membercomment记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercomment">Membercomment对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMembercomment(Database db, DbTransaction tran, MembercommentInfo membercommentInfo);

        /// <summary>
        /// 删除一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMembercomment(string membercommentID);
        /// <summary>
        /// 删除一条Membercomment记录
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMembercomment(Database db, DbTransaction tran, string membercommentID);

        /// <summary>
        /// 检查MembercommentID是否已存在
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMembercommentIDIsExist(string membercommentID);
        /// <summary>
        /// 检查MembercommentID是否已存在
        /// </summary>
        /// <param name="dataBase">DataBase对象</param>
        /// <param name="tran">一个有效的DbTransaction</param>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMembercommentIDIsExist(Database db, DbTransaction tran, string membercommentID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
