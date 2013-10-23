/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：PurchaseorderdetailInfo
// 文件功能描述：提供Purchaseorderdetail的数据成员
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
    public class PurchaseorderdetailInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 DetailID { get; set; }

        [DataMember]
        public System.Int32 PoID { get; set; }

        [DataMember]
        public System.Int32 ItemID { get; set; }

        [DataMember]
        public System.Int32 Qty { get; set; }

        [DataMember]
        public System.Decimal Price { get; set; }

        [DataMember]
        public System.String Status { get; set; }

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
        public PurchaseorderdetailInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public PurchaseorderdetailInfo(
            System.Int32 detailID,
            System.Int32 poID,
            System.Int32 itemID,
            System.Int32 qty,
            System.Decimal price,
            System.String status,
            System.String remark,
            System.Object ts,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            DetailID = detailID;
            PoID = poID;
            ItemID = itemID;
            Qty = qty;
            Price = price;
            Status = status;
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
