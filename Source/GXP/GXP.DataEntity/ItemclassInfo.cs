/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：ItemclassInfo
// 文件功能描述：提供Itemclass的数据成员
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
    public class ItemclassInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 ClassID { get; set; }

        [DataMember]
        public System.String ClassName { get; set; }

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
        public ItemclassInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public ItemclassInfo(
            System.Int32 classID,
            System.String className,
            System.String isActive,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            ClassID = classID;
            ClassName = className;
            IsActive = isActive;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
