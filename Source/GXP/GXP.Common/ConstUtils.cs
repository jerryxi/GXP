using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace GXP.Common
{
    public class ConstUtils
    {
        /// <summary>
        /// 日期格式
        /// </summary>
        public static readonly string CONST_SHOW_DATE_FORMAT = ConfigurationManager.AppSettings["SHOW_DATE_FORMAT"];
        public static readonly string CONST_FULL_DATE_FORMAT = ConfigurationManager.AppSettings["FULL_DATE_FORMAT"];

        public static readonly string CONST_PAGE_SIZE = "10"; 

        /// <summary>
        /// 系统语言值
        /// </summary>
        public const string CONST_LANG_ZH = "ZH";
        public const string CONST_LANG_EN = "EN";
    }
}
