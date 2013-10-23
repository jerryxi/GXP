/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：RolefunctionInfo
// 文件功能描述：提供Rolefunction的数据成员
//
// 创建标识：jerryxi 2013/7/10 
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace GXP.DataEntity
{
    [DataContract]
    public class RolefunctionInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 Indx { get; set; }

        [DataMember]
        public System.Int32 RoleID { get; set; }

        [DataMember]
        public System.Int32 FunctionID { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public RolefunctionInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public RolefunctionInfo(
            System.Int32 indx,
            System.Int32 roleID,
            System.Int32 functionID,
            System.String createdBy,
            System.DateTime createdDate
        )
        {
            Indx = indx;
            RoleID = roleID;
            FunctionID = functionID;
            CreatedBy = createdBy;
            CreatedDate = createdDate;

        }
        #endregion
    }
}
