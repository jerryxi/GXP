/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：SalesorderdetailInfo
// 文件功能描述：提供Salesorderdetail的数据成员
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
    public class SalesorderdetailInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 DetailID { get; set; }

        [DataMember]
        public System.Int32 SoID { get; set; }

        [DataMember]
        public System.Int32 ItemID { get; set; }

        [DataMember]
        public System.Int32 Qty { get; set; }

        [DataMember]
        public System.Decimal Price { get; set; }

        [DataMember]
        public System.Decimal TotalAmount { get; set; }

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
        public SalesorderdetailInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public SalesorderdetailInfo(
            System.Int32 detailID,
            System.Int32 soID,
            System.Int32 itemID,
            System.Int32 qty,
            System.Decimal price,
            System.Decimal totalAmount,
            System.String remark,
            System.Object ts,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            DetailID = detailID;
            SoID = soID;
            ItemID = itemID;
            Qty = qty;
            Price = price;
            TotalAmount = totalAmount;
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
