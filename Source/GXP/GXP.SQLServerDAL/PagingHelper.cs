using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXP.SQLServerDAL
{
    public class PagingHelper
    {
        /// <summary>
        /// 得到自定义分页的SQL语句
        /// </summary>
        /// <param name="mainSql">主SQL语句</param>
        /// <param name="currentPage">GridView当前页索引,从1开始</param>
        /// <param name="pageSize">GridView页大小</param>
        /// <returns>自定义分页的SQL</returns>
        public static string GetPagingSQL(string mainSql, string currentPage, string pageSize)
        {
            return GetPagingSQL(mainSql, currentPage, pageSize, null, null);
        }

        /// <summary>
        /// 得到自定义分页的SQL语句
        /// </summary>
        /// <param name="mainSql">主SQL语句</param>
        /// <param name="currentPage">GridView当前页索引,传过来的参数从0开始</param>
        /// <param name="pageSize">GridView页大小</param>
        /// <param name="sortField">排序表达式</param>
        /// <param name="sortDirection">排序方向ASC or DESC</param>
        /// <returns>自定义分页的SQL</returns>
        public static string GetPagingSQL(string mainSql, string currentPage, string pageSize, string sortField, string sortDirection)
        {
            string sqlTable1 = "SELECT 0;";
            StringBuilder sbTable2 = new StringBuilder();
            string from = mainSql.Substring(mainSql.IndexOf("FROM"), mainSql.Length - mainSql.IndexOf("FROM"));
            
            sbTable2.AppendFormat(" SELECT CEILING(COUNT(ROWNUM)/{0}) AS TotalPagesCount ,COUNT(ROWNUM) AS TotalRecordsCount,CAST({1} AS INT)+1 AS CurrentPage FROM (", pageSize, currentPage);
            sbTable2.AppendLine(" SELECT 1 AS ROWNUM");
            sbTable2.AppendLine(" " + from);
            sbTable2.AppendLine(" ) T;");
            
            StringBuilder sbSQL = new StringBuilder();
            string rownum = string.Format("ROW_NUMBER() OVER (ORDER BY {0} {1}) AS ROWNUM,", sortField, sortDirection);            
            sbSQL.AppendLine("SELECT * FROM ( ");
            sbSQL.AppendLine(mainSql.Insert(mainSql.IndexOf('T') + 2, rownum));
            sbSQL.AppendLine(") T ");
            sbSQL.AppendFormat("WHERE ROWNUM BETWEEN {0} AND {1}", ((Int32.Parse(currentPage) - 1) * Int32.Parse(pageSize)) + 1, Int32.Parse(currentPage) * Int32.Parse(pageSize));

            return sqlTable1 + sbTable2.ToString() + sbSQL.ToString();
        }
    }
}
