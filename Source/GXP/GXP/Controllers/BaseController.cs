using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using System.Web.UI;
using GXP.DataEntity;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;

namespace GXP.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 定义一个基类的UserInfo对象
        /// </summary>
        public UserInfo CurrentUserInfo { get; set; }

        /// <summary>
        /// 重写基类在Action之前执行的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            #region -----校验用户是否登录进入网站的-----
            base.OnActionExecuting(filterContext);
            CurrentUserInfo = Session["UserInfo"] as UserInfo;

            //检验用户是否已经登录，如果登录则不执行，否则则执行下面的跳转代码
            if (CurrentUserInfo == null)
            {
                Response.Redirect("/Home/Logon");
            }
            else
            {
                //留个接口------
                if (CurrentUserInfo.UserName == "admin")
                {
                    return;
                }
            }
            #endregion

            /*
            #region -------检验用户是否有访问此地址的权利----
            //先将当前的请求，到权限表里面去找对应的数据
            //拿到当前请求的URL地址
            string requestUrl = filterContext.HttpContext.Request.Path;
            //拿到当前请求的类型
            string requestType = filterContext.HttpContext.Request.RequestType.ToLower().Equals("get") ? "HttpGet" : "HttpPost";
            //然后和权限表进行对比，如果取出来则通过请求，否则不通过
            //取出当前权限的数据
            var currentAction = null;//_actioninfoService.LoadEntities(c => c.RequestUrl.Equals(requestUrl, StringComparison.InvariantCultureIgnoreCase) && c.RequestHttpType.Equals(requestType)).FirstOrDefault();
            //如果没有权限对应当前请求的话，直接干掉
            if (currentAction == null)
            {
                EndRequest();
            }
            //想去用户权限表里面查询有没有数据
            //分析第一条线路 UserInfo->R_UserInfo_ActionInfo->ActionInfo
            //拿到当前的用户信息
            var userCurrent = null;//_userInfoService.LoadEntities(u => u.ID == CurrentUserInfo.ID).FirstOrDefault();
            var temp = (from r in userCurrent.R_UserInfo_ActionInfo
                        where r.ActionInfoID == currentAction.ID
                        select r).FirstOrDefault();
            if (temp != null)
            {
                if (temp.HasPermation)
                {
                    return;
                }
                else
                {
                    EndRequest();
                }
            }

            //分析第二条线路 UserInfo->ActionGroup->ActionInfo
            var groups = from n in userCurrent.ActionGroup //拿到当前用户所有的组
                         select n;
            //根据组信息遍历出权限信息  
            bool isPass = (from g in groups
                           from a in g.ActionInfo
                           select a.ID).Contains(currentAction.ID);
            if (isPass)   //11，23，34不包含4
            {
                return;
            }

            //分析第三条线路 分为两个
            //1)UserInfo->R_UserInfo_Role->Role->ActionInfo

            //先拿到用户对应的所有的角色
            var UserRoles = from r in userCurrent.R_UserInfo_Role
                            select r.Role;
            //拿到角色对应的所有权限
            var Rolesaction = (from r in UserRoles
                               from a in r.ActionInfo
                               select a.ID);
            if (Rolesaction.Contains(currentAction.ID))
            {
                return;
            }

            //2)UserInfo->R_UserInfo_Role->Role->ActionGroup->ActionInfo
            //拿到组信息
            var RoleGroupActions = from r in UserRoles
                                   from g in r.ActionGroup
                                   select g;
            //拿到所有的组信息
            var groupActions = from r in RoleGroupActions
                               from g in r.ActionInfo
                               select g.ID;
            if (groupActions.Contains(currentAction.ID))
            {
                return;
            }
            #endregion
            */
        }

        public void EndRequest()
        {
            Response.Redirect("/Error.html");
        }

        public void Export2Excel(string fileName, DataSet data)
        {
            MemoryStream ms = new MemoryStream();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)hssfworkbook.CreateSheet();
            #region 文件属性
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "xi";
            hssfworkbook.DocumentSummaryInformation = dsi;
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Author = "xi";
            si.ApplicationName = "xi";
            si.LastAuthor = "xi";
            si.CreateDateTime = DateTime.Now;
            hssfworkbook.SummaryInformation = si;
            #endregion

            #region Excel单元格格式
            int rowIndex = 0;
            HSSFRow headRow = null;
            HSSFRow titleRow = null;
            HSSFRow dataRow = null;
            HSSFCell cell = null;

            HSSFCellStyle headStyle = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            headStyle.Alignment = HorizontalAlignment.CENTER;
            headStyle.VerticalAlignment = VerticalAlignment.CENTER;
            HSSFFont headfont = (HSSFFont)hssfworkbook.CreateFont();
            headStyle.SetFont(headfont);

            HSSFCellStyle titleStyle = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            titleStyle.Alignment = HorizontalAlignment.CENTER;
            HSSFFont titlefont = (HSSFFont)hssfworkbook.CreateFont();
            headStyle.SetFont(titlefont);

            HSSFCellStyle cellDateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat cellDateFormat = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
            if ("Y" == "Y")
                cellDateStyle.DataFormat = cellDateFormat.GetFormat("yyyy-MM-dd HH:mm");
            else
                cellDateStyle.DataFormat = cellDateFormat.GetFormat("yyyy-MM-dd");

            //数量小数格式化字符串
            HSSFCellStyle cellNumStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat cellNumFormat = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
            string formatValue = "0";
            string formatStr = string.Empty;
            switch (formatValue)
            {
                #region 格式化
                case "0":
                    formatStr = "0";
                    break;
                case "1":
                    formatStr = "0.0";
                    break;
                case "2":
                    formatStr = "0.00";
                    break;
                case "3":
                    formatStr = "0.000";
                    break;
                case "4":
                    formatStr = "0.0000";
                    break;
                case "5":
                    formatStr = "0.00000";
                    break;
                default:
                    formatStr = "{0:0}";
                    break;
                #endregion
            }
            if (formatStr == "0" || formatStr == "0.00")
            {
                cellNumStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(formatStr);
            }
            else
            {
                cellNumStyle.DataFormat = cellNumFormat.GetFormat(formatStr);
            }

            //日期格式字符串
            string dateFormat = "yyyy-MM-dd";
            if ("Y" == "Y")
            {
                dateFormat += " " + "HH:mm";
            }
            #endregion

            foreach (DataRow row in data.Tables[0].Rows)
            {
                #region 新建sheet 填写表头 列头
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)hssfworkbook.CreateSheet();
                    }

                    #region 列头
                    titleRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    for (int i = 0; i < data.Tables[0].Columns.Count; i++)
                    {
                        titleRow.CreateCell(i).SetCellValue(data.Tables[0].Columns[i].ColumnName);
                        titleRow.GetCell(i).CellStyle = titleStyle;
                    }
                    rowIndex++;
                    #endregion
                }
                #endregion
           
                #region 明细
                dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                for (int i = 0; i < data.Tables[0].Columns.Count; i++)
                {
                    cell = (HSSFCell)dataRow.CreateCell(i);
                    string value = row[data.Tables[0].Columns[i].ColumnName].ToString();

                    switch (data.Tables[0].Columns[i].DataType.FullName)
                    {
                        case "System.String":
                            cell.SetCellValue(value);
                            break;
                        case "System.DateTime":
                            DateTime datevalue;
                            DateTime.TryParse(value, out datevalue);
                            if (datevalue != new DateTime())
                            {
                                cell.CellStyle = cellDateStyle;
                                cell.SetCellValue(DateTime.Parse(datevalue.ToString(dateFormat)));
                            }
                            else
                            {
                                cell.SetCellValue("");
                            }
                            break;
                        case "System.Boolean":
                            bool boolvalue = false;
                            bool.TryParse(value, out boolvalue);
                            cell.SetCellValue(boolvalue);
                            break;
                        case "System.Int16":
                            Int16 int16 = 0;
                            Int16.TryParse(value, out int16);
                            cell.SetCellValue(int16);
                            break;
                        case "System.Int32":
                            Int32 int32 = 0;
                            Int32.TryParse(value, out int32);
                            cell.SetCellValue(int32);
                            break;
                        case "System.Int64":
                            Int64 int64 = 0;
                            Int64.TryParse(value, out int64);
                            cell.SetCellValue(int64);
                            break;
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(value, out intV);
                            cell.SetCellValue(intV);
                            break;
                        case "System.Decimal":
                            double decV = 0;
                            double.TryParse(value, out decV);
                            cell.SetCellValue(decV);
                            cell.CellStyle = cellNumStyle;
                            break;
                        case "System.Single":
                            float floatV = 0;
                            float.TryParse(value, out floatV);
                            cell.SetCellValue(floatV);
                            cell.CellStyle = cellNumStyle;
                            break;
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(value, out doubV);
                            cell.SetCellValue(doubV);
                            cell.CellStyle = cellNumStyle;
                            break;
                        case "System.DBNull":
                            cell.SetCellValue("");
                            break;
                        default:
                            cell.SetCellValue(value);
                            break;
                    }
                }
                #endregion
                
                rowIndex++;
            }
            hssfworkbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "GB2312";
            HttpContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            HttpContext.Response.BinaryWrite(ms.ToArray());
            HttpContext.Response.End();

            ms.Close();
            sheet = null;
            hssfworkbook = null;
            ms = null;
        }

        protected Sheet GetExportSheet(HSSFWorkbook hssfworkbook,object data)
        {
            //是否自动调整列宽，0：不自动调整  1：自动调整
            bool autoSizeColumn = "0" == "1" ? true : false;

            Sheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sWriter);
            //gv.RenderControl(writer);
            string renderResult = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + writer.InnerWriter.ToString();

            //处理Gridview生成的html字符串：
            //去除 &nbsp; 字符
            //以后如果发现还有其他特殊的字符，也要做特别的处理          
            renderResult = renderResult.Replace("&nbsp;", "").Replace("&", "&amp;").Replace("'", "&apos;");
            renderResult = System.Text.RegularExpressions.Regex.Replace(renderResult, "id=\"?[^\"]+\"", "");
            //通过xml组织数据
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(renderResult);

            //得到所有的 tr 子节点
            XmlNodeList nodes = doc.SelectSingleNode("div").SelectSingleNode("table").ChildNodes;

            for (int i = 0; i < nodes.Count; i++)
            {
                Row excelRow = sheet1.CreateRow(i);
                for (int j = 0; j < nodes[i].ChildNodes.Count; j++)
                {
                    if (nodes[i].ChildNodes[j].ChildNodes.Count > 0 && nodes[i].ChildNodes[j].ChildNodes[0].Name.ToUpper() == "INPUT")
                        excelRow.CreateCell(j).SetCellValue(nodes[i].ChildNodes[j].ChildNodes[0].Attributes["value"].Value);
                    else
                        excelRow.CreateCell(j).SetCellValue(nodes[i].ChildNodes[j].InnerText);
                }
            }
            return sheet1;
        }

        public QueryEntity InitQueryEntity()
        {
            QueryEntity qe = new QueryEntity();
            qe.IsGetAll = false;
            qe.CurrentPage = Request["page"] == null ? "1" : Request["page"];
            qe.PageSize = Request["rows"] == null ? "10" : Request["rows"];
            qe.SortDirection = Request["order"] == null ? "" : Request["order"];
            qe.SortField = Request["sort"] == null ? "" : Request["sort"];

            for (int i = 0; i < Request.Form.AllKeys.Length; i++)
            {
                if (Request.Form.AllKeys[i].StartsWith("Q_"))
                {
                    if (!string.IsNullOrEmpty(Request[Request.Form.AllKeys[i]]))
                    {
                        qe.sqlWhere.Add(string.Format("{0} like '%{1}%'", Request.Form.AllKeys[i].Substring(2, Request.Form.AllKeys[i].Length - 2), Request[Request.Form.AllKeys[i]]));
                    }
                }
            }
            return qe;
        }
    }
}
