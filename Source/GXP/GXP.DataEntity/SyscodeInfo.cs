/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：SyscodeInfo
// 文件功能描述：提供Syscode的数据成员
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
    public class SyscodeInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 CodeID { get; set; }

        [DataMember]
        public System.String GroupID { get; set; }

        [DataMember]
        public System.String CodeName { get; set; }

        [DataMember]
        public System.Int32 SeqNo { get; set; }

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
        public SyscodeInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public SyscodeInfo(
            System.Int32 codeID,
            System.String groupID,
            System.String codeName,
            System.Int32 seqNo,
            System.String isActive,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            CodeID = codeID;
            GroupID = groupID;
            CodeName = codeName;
            SeqNo = seqNo;
            IsActive = isActive;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
