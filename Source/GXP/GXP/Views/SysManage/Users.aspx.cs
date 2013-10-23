using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace GXP.SysManage
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["action"] == null ? Request.Form["action"] : Request.QueryString["action"];
            action = action ?? "";
            switch (action)
            {
                case "GetAllUserInfos":
                    GetDataSource();
                    break;
                default:
                    break;
            }
        }

        private void GetDataSource()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);


            ////SearchName,SearchMail
            string searchName = Request["SearchName"];
            string searchMail = Request["SearchMail"];

            //封装一个业务逻辑层，来处理分页过滤的事件
            //GetModelQuery userInfoQuery = new GetModelQuery();
            //userInfoQuery.pageIndex = pageIndex;
            //userInfoQuery.pageSize = pageSize;
            //userInfoQuery.Name = searchName;
            //userInfoQuery.Mail = searchMail;
            //userInfoQuery.total = 0;

            ////放置依赖刷新
            //var data = from u in _userInfoService.LoadSearchData(userInfoQuery)
            //           select new { u.ID, u.UName, u.Phone, u.Pwd, u.Mail, u.LastModifiedOn, u.SubTime };

            //var data = _userInfoService.LoadPagerEntities(pageSize, pageIndex, out total, u => true, true, u => u.ID);

            //var result = new { total = 10, rows = data };

            
        }
    }
}