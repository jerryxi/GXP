/*----------------------------------------------------------------
//
// Copyright (C)
// 
//
// 文件名：BaseQuery
// 文件功能描述：提供查询参数公用的一些字段
//
// 创建标识：Jerry 
//
// 修改标识：
// 修改描述：
// 
//----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace GXP.DataEntity
{
    [Serializable]
    [DataContract]
    public class QueryEntity
    {
        public QueryEntity()
        {
            sqlWhere = new List<string>();
        }

        [DataMember]
        public List<string> sqlWhere;               //SQL的Where条件

        [DataMember]
        public string PageSize { get; set; }        //GridView的页大小

        [DataMember]
        public string CurrentPage { get; set; }     //GridView当前页索引

        [DataMember]
        public string SortField { get; set; }       //GridView排序表达式

        [DataMember]
        public string SortDirection { get; set; }   //GridView排序方向 ASC or DESC

        [DataMember]
        public bool IsGetAll { get; set; }          //是否获取所有记录，或者只是当前页的记录
    }
}
