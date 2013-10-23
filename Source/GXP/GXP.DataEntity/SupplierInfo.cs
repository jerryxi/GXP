/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：SupplierInfo
// 文件功能描述：提供Supplier的数据成员
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
    public class SupplierInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 SupplierID { get; set; }

        [DataMember]
        public System.String SupplierCode { get; set; }

        [DataMember]
        public System.String SupplierName { get; set; }

        [DataMember]
        public System.String LoginPwd { get; set; }

        [DataMember]
        public System.String Email { get; set; }

        [DataMember]
        public System.String ContactAddress { get; set; }

        [DataMember]
        public System.String Contact { get; set; }

        [DataMember]
        public System.String Region { get; set; }

        [DataMember]
        public System.String Stage { get; set; }

        [DataMember]
        public System.String PostCode { get; set; }

        [DataMember]
        public System.String ContactPhone { get; set; }

        [DataMember]
        public System.String MobilePhone { get; set; }

        [DataMember]
        public System.String QQ { get; set; }

        [DataMember]
        public System.String Msn { get; set; }

        [DataMember]
        public System.String Fax { get; set; }

        [DataMember]
        public System.String WebUrl { get; set; }

        [DataMember]
        public System.String Logo { get; set; }

        [DataMember]
        public System.String CompanyIntro { get; set; }

        [DataMember]
        public System.String CompanyCulture { get; set; }

        [DataMember]
        public System.String ArtificialPerson { get; set; }

        [DataMember]
        public System.String Remark { get; set; }

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
        public SupplierInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public SupplierInfo(
            System.Int32 supplierID,
            System.String supplierCode,
            System.String supplierName,
            System.String loginPwd,
            System.String email,
            System.String contactAddress,
            System.String contact,
            System.String region,
            System.String stage,
            System.String postCode,
            System.String contactPhone,
            System.String mobilePhone,
            System.String qq,
            System.String msn,
            System.String fax,
            System.String webUrl,
            System.String logo,
            System.String companyIntro,
            System.String companyCulture,
            System.String artificialPerson,
            System.String remark,
            System.String isActive,
            System.String cretaedBy,
            System.DateTime createdDate,
            System.String updatedBy,
            System.DateTime updatedDate
        )
        {
            SupplierID = supplierID;
            SupplierCode = supplierCode;
            SupplierName = supplierName;
            LoginPwd = loginPwd;
            Email = email;
            ContactAddress = contactAddress;
            Contact = contact;
            Region = region;
            Stage = stage;
            PostCode = postCode;
            ContactPhone = contactPhone;
            MobilePhone = mobilePhone;
            QQ = qq;
            Msn = msn;
            Fax = fax;
            WebUrl = webUrl;
            Logo = logo;
            CompanyIntro = companyIntro;
            CompanyCulture = companyCulture;
            ArtificialPerson = artificialPerson;
            Remark = remark;
            IsActive = isActive;
            CreatedBy = cretaedBy;
            CreatedDate = createdDate;
            UpdatedBy = updatedBy;
            UpdatedDate = updatedDate;

        }
        #endregion
    }
}
