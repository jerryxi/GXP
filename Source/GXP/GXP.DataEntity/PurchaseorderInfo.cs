/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：PurchaseorderInfo
// 文件功能描述：提供Purchaseorder的数据成员
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
    public class PurchaseorderInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 PoID { get; set; }

        [DataMember]
        public System.Int32 SupplierID { get; set; }

        [DataMember]
        public System.DateTime PoDate { get; set; }

        [DataMember]
        public System.String Contact { get; set; }

        [DataMember]
        public System.String ContactPhone { get; set; }

        [DataMember]
        public System.String ContactAddress { get; set; }

        [DataMember]
        public System.String Status { get; set; }

        [DataMember]
        public System.Decimal TotalAmount { get; set; }

        [DataMember]
        public System.Int32 TotalItemCount { get; set; }

        [DataMember]
        public System.String Remark { get; set; }

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
        public PurchaseorderInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public PurchaseorderInfo(
            System.Int32 poID,
            System.Int32 supplierID,
            System.DateTime poDate,
            System.String contact,
            System.String contactPhone,
            System.String contactAddress,
            System.String status,
            System.Decimal totalAmount,
            System.Int32 totalItemCount,
            System.String remark,
            System.Object ts,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            PoID = poID;
            SupplierID = supplierID;
            PoDate = poDate;
            Contact = contact;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            Status = status;
            TotalAmount = totalAmount;
            TotalItemCount = totalItemCount;
            Remark = remark;
            Ts = ts;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
