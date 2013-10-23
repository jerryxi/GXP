/*----------------------------------------------------------------
//
// Copyright (C) 2013 JerryXi 
// 
//
// 文件名：FunctiongroupInfo
// 文件功能描述：提供Functiongroup的数据成员
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
    public class FunctiongroupInfo
    {
        #region 数据成员

        [DataMember]
        public System.Int32 FunctionID { get; set; }

        [DataMember]
        public System.String ParentID { get; set; }

        [DataMember]
        public System.String FunctionName { get; set; }

        [DataMember]
        public System.Int32 SeqNo { get; set; }

        [DataMember]
        public System.Int32 GroupLevel { get; set; }

        [DataMember]
        public System.String Url { get; set; }

        [DataMember]
        public System.String PageID { get; set; }

        [DataMember]
        public System.String PageName { get; set; }

        [DataMember]
        public System.String IsActive { get; set; }

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
        public FunctiongroupInfo()
        {

        }
        #endregion

        #region 有参构造函数
        public FunctiongroupInfo(
            System.Int32 functionID,
            System.String parentID,
            System.String functionName,
            System.Int32 seqNo,
            System.Int32 groupLevel,
            System.String url,
            System.String pageID,
            System.String pageName,
            System.String isActive,
            System.String udf01,
            System.String udf02,
            System.String udf03,
            System.String udf04,
            System.String udf05
        )
        {
            FunctionID = functionID;
            ParentID = parentID;
            FunctionName = functionName;
            SeqNo = seqNo;
            GroupLevel = groupLevel;
            Url = url;
            PageID = pageID;
            PageName = pageName;
            IsActive = isActive;
            UDF01 = udf01;
            UDF02 = udf02;
            UDF03 = udf03;
            UDF04 = udf04;
            UDF05 = udf05;

        }
        #endregion
    }
}
