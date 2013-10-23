/*----------------------------------------------------------------
//
// Copyright (C) 2013
// 
//
// 文件名：RolefunctionService
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
using System.Text;
using System.Data;
using System.Data.Common;
using GXP.IService;
using GXP.IDAL;
using GXP.DataEntity;
using GXP.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GXP.Service
{
    public class RolefunctionService : IRolefunctionService
    {
        [Dependency]
        public IRolefunctionDA rolefunctionDA { get; set; }

        #region 基本方法
        /// <summary>
        /// 得到所有的Rolefunction记录
        /// </summary>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>所有的Rolefunction记录</returns>
        public DataSet GetAllRolefunction()
        {
            return rolefunctionDA.GetAllRolefunction();
        }

        /// <summary>
        /// 根据查询条件得到Rolefunction记录
        /// </summary>
        /// <param name="sqlWhere">查询条件集合</param>
        /// <param name="RolefunctionQueryEntity">Rolefunction查询实体类</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据查询条件得到Rolefunction记录</returns>
        public DataSet GetRolefunctionByQueryList(QueryEntity rolefunctionQuery)
        {
            return rolefunctionDA.GetRolefunctionByQueryList(rolefunctionQuery);
        }

        /// <summary>
        /// 根据rolefunctionID得到一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">rolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>根据rolefunctionID得到一条Rolefunction记录</returns>
        public RolefunctionInfo GetRolefunctionByID(string rolefunctionID)
        {
            return rolefunctionDA.GetRolefunctionByID(rolefunctionID);
        }

        /// <summary>
        /// 新增一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行新增对数据库影响的行数</returns>
        public int InsertRolefunction(RolefunctionInfo rolefunctionInfo)
        {
            return rolefunctionDA.InsertRolefunction(rolefunctionInfo);
        }

        /// <summary>
        /// 删除一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunctionID">RolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行删除对数据库影响的行数</returns>
        public int DeleteRolefunction(List<string> rolefunctionID)
        {
            int result = 0;
            if (rolefunctionID != null && rolefunctionID.Count > 0)
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbConnection dbConn = db.CreateConnection();
                dbConn.Open();
                DbTransaction dbTran = dbConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < rolefunctionID.Count; i++)
                    {
                        result += rolefunctionDA.DeleteRolefunction(db, dbTran, rolefunctionID[i]);
                    }
                    dbTran.Commit();
                }
                catch (Exception ex)
                {
                    result = 0;
                    dbTran.Rollback();
                    LogHelper.LogError(ex, "");
                }
                finally
                {
                    dbConn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 更新一条Rolefunction记录
        /// </summary>
        /// <param name="rolefunction">Rolefunction对象</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>执行更新对数据库影响的行数</returns>
        public int UpdateRolefunction(RolefunctionInfo rolefunctionInfo)
        {
            return rolefunctionDA.UpdateRolefunction(rolefunctionInfo);
        }

        /// <summary>
        /// 检查RolefunctionID是否已存在
        /// </summary>
        /// <param name="rolefunctionID">RolefunctionID</param>
        /// <param name="whLoginID">要查询的仓库的前缀</param>
        /// <returns>True:存在  False:不存在</returns>
        public bool CheckRolefunctionIDIsExist(string rolefunctionID)
        {
            return rolefunctionDA.CheckRolefunctionIDIsExist(rolefunctionID);
        }
        #endregion

        #region 扩展方法
        public int InsertRolefunction(int roleID, string functionID)
        {
            int result = 0;
            string[] functionIDs = functionID.Split(new char[] { ',' });
            rolefunctionDA.DeleteRoleFunctionByRoleID(roleID);
            for (int i = 0; i < functionIDs.Length; i++)
            {
                RolefunctionInfo rf = new RolefunctionInfo();
                rf.RoleID = roleID;
                rf.FunctionID = Int32.Parse(functionIDs[i]);
                rf.CreatedBy = "admin";
                rf.CreatedDate = DateTime.Now;
                result += rolefunctionDA.InsertRolefunction(rf);
            }
            return result;
        }
        #endregion
    }
}
