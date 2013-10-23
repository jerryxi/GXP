/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：MembercommentInfo
// 文件功能描述：提供Membercomment的数据成员
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
    public class MembercommentInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 CommentID { get; set; }

        [DataMember]
        public System.Int32 ItemID { get; set; }

        [DataMember]
        public System.String Title { get; set; }

        [DataMember]
        public System.String Content { get; set; }

        [DataMember]
        public System.Int32 CommentPoints { get; set; }

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
        public MembercommentInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public MembercommentInfo(
            System.Int32 commentID,
            System.Int32 itemID,
            System.String title,
            System.String content,
            System.Int32 commentPoints,
            System.String isActive,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            CommentID = commentID;
            ItemID = itemID;
            Title = title;
            Content = content;
            CommentPoints = commentPoints;
            IsActive = isActive;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
