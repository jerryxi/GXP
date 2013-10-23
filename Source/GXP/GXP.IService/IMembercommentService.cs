/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMembercommentService
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
    public interface IMembercommentService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Membercomment记录
        /// </summary>
        /// <returns>所有的Membercomment记录</returns>
        DataSet GetAllMembercomment();

        /// <summary>
        /// 根据查询条件得到Membercomment记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MembercommentQueryEntity">Membercomment查询实体类</param>
        /// <returns>根据查询条件得到Membercomment记录</returns>
        DataSet GetMembercommentByQueryList(QueryEntity membercommentQuery);

        /// <summary>
        /// 根据membercommentID得到一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>根据membercommentID得到一条Membercomment记录</returns>
        MembercommentInfo GetMembercommentByID(string membercommentID);

        /// <summary>
        /// 新增一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMembercomment(MembercommentInfo membercommentInfo);

        /// <summary>
        /// 更新一条Membercomment记录
        /// </summary>
        /// <param name="membercomment">Membercomment对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMembercomment(MembercommentInfo membercommentInfo);

        /// <summary>
        /// 删除一条Membercomment记录
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMembercomment(List<string> membercommentID);

        /// <summary>
        /// 检查MembercommentID是否已存在
        /// </summary>
        /// <param name="membercommentID">membercommentID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMembercommentIDIsExist(string membercommentID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
