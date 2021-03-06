﻿/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：AreaInfo
// 文件功能描述：提供Area的数据成员
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
    public class AreaInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 ID { get; set; }

        [DataMember]
        public System.String AreaCode { get; set; }

        [DataMember]
        public System.String AreaName { get; set; }

        [DataMember]
        public System.String IsActive { get; set; }

        [DataMember]
        public System.String Remark { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CretaedDate { get; set; }

        [DataMember]
        public System.String UpdatedBy { get; set; }

        [DataMember]
        public System.DateTime UpdatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public AreaInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public AreaInfo(
            System.Int32 id,
            System.String areaCode,
            System.String areaName,
            System.String isActive,
            System.String remark,
            System.String createdBy,
            System.DateTime cretaedDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            ID = id;
            AreaCode = areaCode;
            AreaName = areaName;
            IsActive = isActive;
            Remark = remark;
            CreatedBy = createdBy;
            CretaedDate = cretaedDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
