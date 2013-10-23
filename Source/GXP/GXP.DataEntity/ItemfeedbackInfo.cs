/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：ItemfeedbackInfo
// 文件功能描述：提供Itemfeedback的数据成员
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
    public class ItemfeedbackInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 ID { get; set; }

        [DataMember]
        public System.String SupplierID { get; set; }

        [DataMember]
        public System.String ItemID { get; set; }

        [DataMember]
        public System.String Title { get; set; }

        [DataMember]
        public System.String Content { get; set; }

        [DataMember]
        public System.String Reply { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }

        [DataMember]
        public System.String ReplyBy { get; set; }

        [DataMember]
        public System.DateTime ReplyDate { get; set; }
        #endregion

        #region 无参构造函数
        public ItemfeedbackInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public ItemfeedbackInfo(
            System.Int32 id,
            System.String supplierID,
            System.String itemID,
            System.String title,
            System.String content,
            System.String reply,
            System.String createdBy,
            System.DateTime createdDate,
            System.String replyBy,
            System.DateTime replyDate
        )
        {
            ID = id;
            SupplierID = supplierID;
            ItemID = itemID;
            Title = title;
            Content = content;
            Reply = reply;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ReplyBy = replyBy;
            ReplyDate = replyDate;

        }
        #endregion
    }
}
