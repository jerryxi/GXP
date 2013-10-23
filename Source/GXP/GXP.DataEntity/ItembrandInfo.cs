/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：ItembrandInfo
// 文件功能描述：提供Itembrand的数据成员
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
    public class ItembrandInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 BrandID { get; set; }

        [DataMember]
        public System.String BrandName { get; set; }

        [DataMember]
        public System.String IsActive { get; set; }

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
        public ItembrandInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public ItembrandInfo(
            System.Int32 brandID,
            System.String brandName,
            System.String isActive,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            BrandID = brandID;
            BrandName = brandName;
            IsActive = isActive;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
