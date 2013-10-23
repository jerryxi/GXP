/*----------------------------------------------------------------
//
// Copyright (C) 2013 
// 
//
// 文件名：IMemberorderdetailService
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
    public interface IMemberorderdetailService
    {
        #region 基本方法
        /// <summary>
        /// 得到所有的Memberorderdetail记录
        /// </summary>
        /// <returns>所有的Memberorderdetail记录</returns>
        DataSet GetAllMemberorderdetail();

        /// <summary>
        /// 根据查询条件得到Memberorderdetail记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="MemberorderdetailQueryEntity">Memberorderdetail查询实体类</param>
        /// <returns>根据查询条件得到Memberorderdetail记录</returns>
        DataSet GetMemberorderdetailByQueryList(QueryEntity memberorderdetailQuery);

        /// <summary>
        /// 根据memberorderdetailID得到一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>根据memberorderdetailID得到一条Memberorderdetail记录</returns>
        MemberorderdetailInfo GetMemberorderdetailByID(string memberorderdetailID);

        /// <summary>
        /// 新增一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        int InsertMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo);

        /// <summary>
        /// 更新一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetail">Memberorderdetail对象</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        int UpdateMemberorderdetail(MemberorderdetailInfo memberorderdetailInfo);

        /// <summary>
        /// 删除一条Memberorderdetail记录
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        int DeleteMemberorderdetail(List<string> memberorderdetailID);

        /// <summary>
        /// 检查MemberorderdetailID是否已存在
        /// </summary>
        /// <param name="memberorderdetailID">memberorderdetailID</param>
        /// <returns>True:存在  False:不存在</returns>
        bool CheckMemberorderdetailIDIsExist(string memberorderdetailID);
        #endregion

        #region 扩展方法
        #endregion
    }
}
