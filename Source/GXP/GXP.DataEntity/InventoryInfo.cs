/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：InventoryInfo
// 文件功能描述：提供Inventory的数据成员
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
    public class InventoryInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 ID { get; set; }

        [DataMember]
        public System.Int32 ItemID { get; set; }

        [DataMember]
        public System.Int32 Qty { get; set; }

        [DataMember]
        public System.Int32 OrderQty { get; set; }

        [DataMember]
        public System.Object TS { get; set; }

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
        public InventoryInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public InventoryInfo(
            System.Int32 id,
            System.Int32 itemID,
            System.Int32 qty,
            System.Int32 orderQty,
            System.Object ts,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            ID = id;
            ItemID = itemID;
            Qty = qty;
            OrderQty = orderQty;
            TS = ts;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
