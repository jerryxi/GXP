/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：ItemInfo
// 文件功能描述：提供Item的数据成员
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
    public class ItemInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 ItemID { get; set; }

        [DataMember]
        public System.Int32 SupplierID { get; set; }

        [DataMember]
        public System.String ItemCode { get; set; }

        [DataMember]
        public System.String ItemName { get; set; }

        [DataMember]
        public System.String ItemDescription { get; set; }

        [DataMember]
        public System.String ItemSynopsis { get; set; }

        [DataMember]
        public System.String ItemCharacter { get; set; }

        [DataMember]
        public System.String ItemClassID { get; set; }

        [DataMember]
        public System.String ItemBrandID { get; set; }

        [DataMember]
        public System.Decimal GrossWgt { get; set; }

        [DataMember]
        public System.Decimal NetWgt { get; set; }

        [DataMember]
        public System.Decimal Length { get; set; }

        [DataMember]
        public System.Decimal Width { get; set; }

        [DataMember]
        public System.Decimal Height { get; set; }

        [DataMember]
        public System.Decimal Cube { get; set; }

        [DataMember]
        public System.String UomID { get; set; }

        [DataMember]
        public System.String AreaID { get; set; }

        [DataMember]
        public System.Decimal CostPrice { get; set; }

        [DataMember]
        public System.Decimal MarketPrice { get; set; }

        [DataMember]
        public System.Decimal AdvicePrice { get; set; }

        [DataMember]
        public System.Decimal SalesPrice { get; set; }

        [DataMember]
        public System.String ItemStyle { get; set; }

        [DataMember]
        public System.String ItemColor { get; set; }

        [DataMember]
        public System.String ItemSize { get; set; }

        [DataMember]
        public System.Int32 PresentPoints { get; set; }

        [DataMember]
        public System.String PhotoUrl { get; set; }

        [DataMember]
        public System.String Remark { get; set; }

        [DataMember]
        public System.String IsActive { get; set; }

        [DataMember]
        public System.String IsAudited { get; set; }

        [DataMember]
        public System.String BillingType { get; set; }

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
        public ItemInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public ItemInfo(
            System.Int32 itemID,
            System.Int32 supplierID,
            System.String itemCode,
            System.String itemName,
            System.String itemDescription,
            System.String itemSynopsis,
            System.String itemCharacter,
            System.String itemClassID,
            System.String itemBrandID,
            System.Decimal grossWgt,
            System.Decimal netWgt,
            System.Decimal length,
            System.Decimal width,
            System.Decimal height,
            System.Decimal cube,
            System.String uomID,
            System.String areaID,
            System.Decimal costPrice,
            System.Decimal marketPrice,
            System.Decimal advicePrice,
            System.Decimal salesPrice,
            System.String itemStyle,
            System.String itemColor,
            System.String itemSize,
            System.Int32 presentPoints,
            System.String photoUrl,
            System.String remark,
            System.String isActive,
            System.String isAudited,
            System.String billingType,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            ItemID = itemID;
            SupplierID = supplierID;
            ItemCode = itemCode;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemSynopsis = itemSynopsis;
            ItemCharacter = itemCharacter;
            ItemClassID = itemClassID;
            ItemBrandID = itemBrandID;
            GrossWgt = grossWgt;
            NetWgt = netWgt;
            Length = length;
            Width = width;
            Height = height;
            Cube = cube;
            UomID = uomID;
            AreaID = areaID;
            CostPrice = costPrice;
            MarketPrice = marketPrice;
            AdvicePrice = advicePrice;
            SalesPrice = salesPrice;
            ItemStyle = itemStyle;
            ItemColor = itemColor;
            ItemSize = itemSize;
            PresentPoints = presentPoints;
            PhotoUrl = photoUrl;
            Remark = remark;
            IsActive = isActive;
            IsAudited = isAudited;
            BillingType = billingType;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
