/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：UserInfo
// 文件功能描述：提供User的数据成员
//
// 创建标识：jerryxi 2013/7/7 
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
    public class UserInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 UserID { get; set; }

        [DataMember]
        public System.String UserCode { get; set; }

        [DataMember]
        public System.String UserName { get; set; }

        [DataMember]
        public System.String LoginPwd { get; set; }

        [DataMember]
        public System.String Sex { get; set; }

        [DataMember]
        public System.Int32 Age { get; set; }

        [DataMember]
        public System.String Department { get; set; }

        [DataMember]
        public System.String JobNum { get; set; }

        [DataMember]
        public System.String Email { get; set; }

        [DataMember]
        public System.String MobilePhone { get; set; }

        [DataMember]
        public System.String IsActive { get; set; }

        [DataMember]
        public System.String UserGroup { get; set; }

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
        public UserInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public UserInfo(
            System.Int32 userID,
            System.String userCode,
            System.String userName,
            System.String loginPwd,
            System.String sex,
            System.Int32 age,
            System.String department,
            System.String jobNum,
            System.String email,
            System.String mobilePhone,
            System.String isActive,
            System.String userGroup,
            System.String createdBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            UserID = userID;
            UserCode = userCode;
            UserName = userName;
            LoginPwd = loginPwd;
            Sex = sex;
            Age = age;
            Department = department;
            JobNum = jobNum;
            Email = email;
            MobilePhone = mobilePhone;
            IsActive = isActive;
            UserGroup = userGroup;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
