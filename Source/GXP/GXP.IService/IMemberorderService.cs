/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMemberorderService
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
    public interface IMemberorderService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Memberorder记录
        /// </summary>
        /// <returns>所有的Memberorder记录</returns>
        DataSet GetAllMemberorder();

        /// <summary>
        /// 根据查询条件得到Memberorder记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderQueryEntity">Memberorder查询实体类</param>
        /// <returns>根据查询条件得到Memberorder记录</returns>
        DataSet GetMemberorderByQueryList(QueryEntity memberorderQuery);

        /// <summary>
        /// 根据memberorderID得到一条Memberorder记录
        /// </summary>
        /// <param name="memberorderID">memberorderID</param>
        /// <returns>根据memberorderID得到一条Memberorder记录</returns>
        MemberorderInfo GetMemberorderByID(string memberorderID);

        /// <summary>
        /// 新增一条Memberorder记录
        /// </summary>
        /// <param name="memberorder">Memberorder对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMemberorder(MemberorderInfo memberorderInfo);

        /// <summary>
        /// 更新一条Memberorder记录
        /// </summary>
        /// <param name="memberorder">Memberorder对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMemberorder(MemberorderInfo memberorderInfo);

        /// <summary>
        /// 删除一条Memberorder记录
        /// </summary>
        /// <param name="memberorderID">memberorderID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMemberorder(List<string> memberorderID);

        /// <summary>
        /// 检查MemberorderID是否已存在
        /// </summary>
        /// <param name="memberorderID">memberorderID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberorderIDIsExist(string memberorderID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
