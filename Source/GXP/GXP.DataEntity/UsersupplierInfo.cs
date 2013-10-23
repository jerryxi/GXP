/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：UsersupplierInfo
// 文件功能描述：提供Usersupplier的数据成员
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
    public class UsersupplierInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 Indx { get; set; }

        [DataMember]
        public System.Int32 UserID { get; set; }

        [DataMember]
        public System.Int32 SupplierID { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public UsersupplierInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public UsersupplierInfo(
            System.Int32 indx,
            System.Int32 userID,
            System.Int32 supplierID,
            System.String createdBy,
            System.DateTime createdDate
        )
        {
            Indx = indx;
            UserID = userID;
            SupplierID = supplierID;
            CreatedBy = createdBy;
            CreatedDate = createdDate;

        }
        #endregion
    }
}
