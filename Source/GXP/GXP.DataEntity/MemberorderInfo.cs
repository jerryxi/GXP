/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：MemberorderInfo
// 文件功能描述：提供Memberorder的数据成员
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
    public class MemberorderInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 OrderID { get; set; }

        [DataMember]
        public System.DateTime OrderDate { get; set; }

        [DataMember]
        public System.String MemberID { get; set; }

        [DataMember]
        public System.String PayMethod { get; set; }

        [DataMember]
        public System.String Ticket { get; set; }

        [DataMember]
        public System.Decimal TotalAmount { get; set; }

        [DataMember]
        public System.Int32 TotalItemCount { get; set; }

        [DataMember]
        public System.String Status { get; set; }

        [DataMember]
        public System.String Contact { get; set; }

        [DataMember]
        public System.String ContactPhone { get; set; }

        [DataMember]
        public System.String ContactAddress { get; set; }

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
        public MemberorderInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public MemberorderInfo(
            System.Int32 orderID,
            System.DateTime orderDate,
            System.String memberID,
            System.String payMethod,
            System.String ticket,
            System.Decimal totalAmount,
            System.Int32 totalItemCount,
            System.String status,
            System.String contact,
            System.String contactPhone,
            System.String contactAddress,
            System.Object ts,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            OrderID = orderID;
            OrderDate = orderDate;
            MemberID = memberID;
            PayMethod = payMethod;
            Ticket = ticket;
            TotalAmount = totalAmount;
            TotalItemCount = totalItemCount;
            Status = status;
            Contact = contact;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            Ts = ts;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
