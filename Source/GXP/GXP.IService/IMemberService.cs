/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMemberService
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
    public interface IMemberService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Member记录
        /// </summary>
        /// <returns>所有的Member记录</returns>
        DataSet GetAllMember();

        /// <summary>
        /// 根据查询条件得到Member记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberQueryEntity">Member查询实体类</param>
        /// <returns>根据查询条件得到Member记录</returns>
        DataSet GetMemberByQueryList(QueryEntity memberQuery);

        /// <summary>
        /// 根据memberID得到一条Member记录
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <returns>根据memberID得到一条Member记录</returns>
        MemberInfo GetMemberByID(string memberID);

        /// <summary>
        /// 新增一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMember(MemberInfo memberInfo);

        /// <summary>
        /// 更新一条Member记录
        /// </summary>
        /// <param name="member">Member对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMember(MemberInfo memberInfo);

        /// <summary>
        /// 删除一条Member记录
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMember(List<string> memberID);

        /// <summary>
        /// 检查MemberID是否已存在
        /// </summary>
        /// <param name="memberID">memberID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberIDIsExist(string memberID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
