/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：InvtransactionInfo
// 文件功能描述：提供Invtransaction的数据成员
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
    public class InvtransactionInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 TransID { get; set; }

        [DataMember]
        public System.Int32 ItemID { get; set; }

        [DataMember]
        public System.Int32 SupplierID { get; set; }

        [DataMember]
        public System.String TransType { get; set; }

        [DataMember]
        public System.Int32 Qty { get; set; }

        [DataMember]
        public System.String PoID { get; set; }

        [DataMember]
        public System.String PoLineID { get; set; }

        [DataMember]
        public System.String SoID { get; set; }

        [DataMember]
        public System.String SoLineID { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public InvtransactionInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public InvtransactionInfo(
            System.Int32 transID,
            System.Int32 itemID,
            System.Int32 supplierID,
            System.String transType,
            System.Int32 qty,
            System.String poID,
            System.String poLineID,
            System.String soID,
            System.String soLineID,
            System.String createdBy,
            System.DateTime createdDate
        )
        {
            TransID = transID;
            ItemID = itemID;
            SupplierID = supplierID;
            TransType = transType;
            Qty = qty;
            PoID = poID;
            PoLineID = poLineID;
            SoID = soID;
            SoLineID = soLineID;
            CreatedBy = createdBy;
            CreatedDate = createdDate;

        }
        #endregion
    }
}
