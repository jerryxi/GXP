/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：SalesorderInfo
// 文件功能描述：提供Salesorder的数据成员
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
    public class SalesorderInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 SoID { get; set; }

        [DataMember]
        public System.Int32 MemberID { get; set; }

        [DataMember]
        public System.DateTime SoDate { get; set; }

        [DataMember]
        public System.Int32 SupplierID { get; set; }

        [DataMember]
        public System.String Status { get; set; }

        [DataMember]
        public System.Decimal TotalAmount { get; set; }

        [DataMember]
        public System.Int32 TotalItemCount { get; set; }

        [DataMember]
        public System.String Contact { get; set; }

        [DataMember]
        public System.String ContactPhone { get; set; }

        [DataMember]
        public System.String ContactAddress { get; set; }

        [DataMember]
        public System.String PayMethod { get; set; }

        [DataMember]
        public System.Object Ts { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }

        [DataMember]
        public System.String UpdatedBy { get; set; }

        [DataMember]
        public System.DateTime UpdatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public SalesorderInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public SalesorderInfo(
            System.Int32 soID,
            System.Int32 memberID,
            System.DateTime soDate,
            System.Int32 supplierID,
            System.String status,
            System.Decimal totalAmount,
            System.Int32 totalItemCount,
            System.String contact,
            System.String contactPhone,
            System.String contactAddress,
            System.String payMethod,
            System.Object ts,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            SoID = soID;
            MemberID = memberID;
            SoDate = soDate;
            SupplierID = supplierID;
            Status = status;
            TotalAmount = totalAmount;
            TotalItemCount = totalItemCount;
            Contact = contact;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            PayMethod = payMethod;
            Ts = ts;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
