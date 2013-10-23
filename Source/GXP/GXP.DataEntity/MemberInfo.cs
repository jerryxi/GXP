/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：MemberInfo
// 文件功能描述：提供Member的数据成员
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
    public class MemberInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 MemberID { get; set; }

        [DataMember]
        public System.String MemberCode { get; set; }

        [DataMember]
        public System.String MemberName { get; set; }

        [DataMember]
        public System.String LoginPwd { get; set; }

        [DataMember]
        public System.String PayPwd { get; set; }

        [DataMember]
        public System.String MemberLevel { get; set; }

        [DataMember]
        public System.String Sex { get; set; }

        [DataMember]
        public System.DateTime Birthday { get; set; }

        [DataMember]
        public System.Int32 Age { get; set; }

        [DataMember]
        public System.String Minority { get; set; }

        [DataMember]
        public System.String Trades { get; set; }

        [DataMember]
        public System.String HomeAddress { get; set; }

        [DataMember]
        public System.String PostCode { get; set; }

        [DataMember]
        public System.String Email { get; set; }

        [DataMember]
        public System.String OfficePhone { get; set; }

        [DataMember]
        public System.String MobilePhone { get; set; }

        [DataMember]
        public System.String HomePhone { get; set; }

        [DataMember]
        public System.String Fax { get; set; }

        [DataMember]
        public System.String QQ { get; set; }

        [DataMember]
        public System.String Msn { get; set; }

        [DataMember]
        public System.String PwdQuestion { get; set; }

        [DataMember]
        public System.String PwdAnswer { get; set; }

        [DataMember]
        public System.DateTime RegisterDate { get; set; }

        [DataMember]
        public System.String LastLoginIP { get; set; }

        [DataMember]
        public System.Int32 LoginCount { get; set; }

        [DataMember]
        public System.DateTime LastLoginTime { get; set; }

        [DataMember]
        public System.Decimal PreDeposits { get; set; }

        [DataMember]
        public System.Int32 Points { get; set; }

        [DataMember]
        public System.Decimal HoldPreDeposits { get; set; }

        [DataMember]
        public System.Int32 HoldPoints { get; set; }

        [DataMember]
        public System.Decimal TotalConsumeMoney { get; set; }

        [DataMember]
        public System.Int32 TotalTransCount { get; set; }

        [DataMember]
        public System.String IsActive { get; set; }

        [DataMember]
        public System.String CretaedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedDate { get; set; }

        [DataMember]
        public System.String UpdatedBy { get; set; }

        [DataMember]
        public System.DateTime UpdatedDate { get; set; }
        #endregion

        #region 无参构造函数
        public MemberInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public MemberInfo(
            System.Int32 memberID,
            System.String memberCode,
            System.String memberName,
            System.String loginPwd,
            System.String payPwd,
            System.String memberLevel,
            System.String sex,
            System.DateTime birthday,
            System.Int32 age,
            System.String minority,
            System.String trades,
            System.String homeAddress,
            System.String postCode,
            System.String email,
            System.String officePhone,
            System.String mobilePhone,
            System.String homePhone,
            System.String fax,
            System.String qq,
            System.String msn,
            System.String pwdQuestion,
            System.String pwdAnswer,
            System.DateTime registerDate,
            System.String lastLoginIP,
            System.Int32 loginCount,
            System.DateTime lastLoginTime,
            System.Decimal preDeposits,
            System.Int32 points,
            System.Decimal holdPreDeposits,
            System.Int32 holdPoints,
            System.Decimal totalConsumeMoney,
            System.Int32 totalTransCount,
            System.String isActive,
            System.String cretaedBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            MemberID = memberID;
            MemberCode = memberCode;
            MemberName = memberName;
            LoginPwd = loginPwd;
            PayPwd = payPwd;
            MemberLevel = memberLevel;
            Sex = sex;
            Birthday = birthday;
            Age = age;
            Minority = minority;
            Trades = trades;
            HomeAddress = homeAddress;
            PostCode = postCode;
            Email = email;
            OfficePhone = officePhone;
            MobilePhone = mobilePhone;
            HomePhone = homePhone;
            Fax = fax;
            QQ = qq;
            Msn = msn;
            PwdQuestion = pwdQuestion;
            PwdAnswer = pwdAnswer;
            RegisterDate = registerDate;
            LastLoginIP = lastLoginIP;
            LoginCount = loginCount;
            LastLoginTime = lastLoginTime;
            PreDeposits = preDeposits;
            Points = points;
            HoldPreDeposits = holdPreDeposits;
            HoldPoints = holdPoints;
            TotalConsumeMoney = totalConsumeMoney;
            TotalTransCount = totalTransCount;
            IsActive = isActive;
            CretaedBy = cretaedBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
