/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：OperationlogInfo
// 文件功能描述：提供Operationlog的数据成员
//
// 创建标识：jerryxi 2013/8/20 
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
    public class OperationlogInfo
    {
        #region 数据成员

        [DataMember]
        public System.Decimal Indx { get; set; }

        [DataMember]
        public System.DateTime LogDate { get; set; }

        [DataMember]
        public System.String UserCode { get; set; }

        [DataMember]
        public System.String UserName { get; set; }

        [DataMember]
        public System.String Content { get; set; }

        [DataMember]
        public System.String GroupName { get; set; }

        [DataMember]
        public System.String IsSuccess { get; set; }

        [DataMember]
        public System.String UDF01 { get; set; }

        [DataMember]
        public System.String UDF02 { get; set; }

        [DataMember]
        public System.String UDF03 { get; set; }

        [DataMember]
        public System.String UDF04 { get; set; }

        [DataMember]
        public System.String UDF05 { get; set; }
        #endregion

        #region 无参构造函数
        public OperationlogInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public OperationlogInfo(
            System.Decimal indx,
            System.DateTime logDate,
            System.String userCode,
            System.String userName,
            System.String content,
            System.String groupName,
            System.String isSuccess,
            System.String udf01,
            System.String udf02,
            System.String udf03,
            System.String udf04,
            System.String udf05
        )
        {
            Indx = indx;
            LogDate = logDate;
            UserCode = userCode;
            UserName = userName;
            Content = content;
            GroupName = groupName;
            IsSuccess = isSuccess;
            UDF01 = udf01;
            UDF02 = udf02;
            UDF03 = udf03;
            UDF04 = udf04;
            UDF05 = udf05;

        }
        #endregion
    }
}
