/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：UserroleInfo
// 文件功能描述：提供Userrole的数据成员
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
    public class UserroleInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 Indx { get; set; }

        [DataMember]
        public System.Int32 UserID { get; set; }

        [DataMember]
        public System.Int32 RoleID { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public UserroleInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public UserroleInfo(
            System.Int32 indx,
            System.Int32 userID,
            System.Int32 roleID,
            System.String createdBy,
            System.DateTime createdDate
        )
        {
            Indx = indx;
            UserID = userID;
            RoleID = roleID;
            CreatedBy = createdBy;
            CreatedDate = createdDate;

        }
        #endregion
    }
}
