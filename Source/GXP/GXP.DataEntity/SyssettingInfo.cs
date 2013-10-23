/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：SyssettingInfo
// 文件功能描述：提供Syssetting的数据成员
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
    public class SyssettingInfo
    {
        #region 数据成员

        [DataMember]
        public System.String SysSettingID { get; set; }

        [DataMember]
        public System.String Description { get; set; }

        [DataMember]
        public System.String Value { get; set; }

        [DataMember]
        public System.String DefaultValue { get; set; }

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
        public SyssettingInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public SyssettingInfo(
            System.String sysSettingID,
            System.String description,
            System.String value,
            System.String defaultValue,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            SysSettingID = sysSettingID;
            Description = description;
            Value = value;
            DefaultValue = defaultValue;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
