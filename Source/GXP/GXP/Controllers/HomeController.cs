using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;

using GXP.DataEntity;
using GXP.Common;
using GXP.IService;

namespace GXP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Logon()
        {
            var UName = Request.Cookies["UName"] == null ? "" : Request.Cookies["UName"].Value;
            ViewBag.UName = UName;
            return View();
        }

        public ActionResult CheckUserLogin(string UName, string  Pwd, string Code)
        {
            //这里验证用户输入的验证码和系统的验证码是否相同
            string sessionCode = Session["ValidateCode"] == null ? new Guid().ToString() : Session["ValidateCode"].ToString();
            //将验证码去掉，避免暴力破解
            Session["ValidateCode"] = new Guid();
            if (sessionCode != Code)
            {
                return Content("请输入正确的验证码");
            }

            //检验用户名密码是否正确
            IUserService userService = UnityHelper.UnityResolve<IUserService>();
            UserInfo uinfo = userService.GetUserByCodePhoneEmail(UName);
            if (uinfo.LoginPwd != Pwd)
            {
                return Content("用户名或密码不正确");
            }
            //uinfo.Username = "Administrator";
            //uinfo.Loginpwd = "admin";
            //uinfo.Userid = 1;

            //如果有用户名的话将用户名存放到Cookie中
            if (uinfo.UserCode != null)
            {
                Response.Cookies["UName"].Value = uinfo.UserCode;
                Response.Cookies["UName"].Expires = DateTime.Now.AddDays(7);
            }
            if (uinfo != null)
            {
                //提供Session接口方便后面判断用户登录
                Session["UserInfo"] = uinfo;
                //CurrentUserInfo = uinfo;
                return Content("OK");
            }
            else
            {
                return Content("用户名密码错误，请您检查!");
            }
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎!";
            ViewBag.UserName = ((UserInfo)Session["UserInfo"]).UserName;
            return View();
        }

        /// <summary>
        /// 查询出数据显示在菜单栏目中
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadMenuData()
        {            
            /*
            List<MenuData> mlist = new List<MenuData>();

            MenuData m = new MenuData();
            m.GroupID = 101;
            m.GroupName = "系统管理";

            IList<MenuItem> itemlist = new List<MenuItem>();

            MenuItem m1 = new MenuItem();
            m1.Id = 111;
            m1.MenuName = "角色管理";
            m1.Url = "../WebForm1.aspx";
            itemlist.Add(m1);

            MenuItem m2 = new MenuItem();
            m2.Id = 112;
            m2.MenuName = "角色管理123";
            m2.Url = "../Inventory/WebForm2.aspx";
            itemlist.Add(m2);

            MenuItem m3 = new MenuItem();
            m3.Id = 113;
            m3.MenuName = "用户管理";
            m3.Url = "/UserInfo/Index";
            itemlist.Add(m3);

            m.MenuItems = itemlist;

            mlist.Add(m);
            */

            List<MenuData> mlist = new List<MenuData>();
            IFunctiongroupService functiongroupService = UnityHelper.UnityResolve<IFunctiongroupService>();
            DataSet functionDS = functiongroupService.GetFunctionGroupByUserID(((UserInfo)Session["UserInfo"]).UserID);
            if (functionDS != null && functionDS.Tables.Count > 0 && functionDS.Tables[0].Rows.Count > 0)
            {
                DataRow[] level1 = functionDS.Tables[0].Select("ParentID='1000'", "FunctionID");
                for (int i = 0; i < level1.Length; i++)
                {
                    MenuData m = new MenuData();
                    m.GroupID = Int32.Parse(level1[i]["FunctionID"].ToString());
                    m.GroupName = level1[i]["UDF01"].ToString();

                    IList<MenuItem> itemlist = new List<MenuItem>();

                    DataRow[] level2 = functionDS.Tables[0].Select(string.Format("ParentID='{0}'", level1[i]["FunctionID"].ToString()), "FunctionID");
                    for (int j = 0; j < level2.Length; j++)
                    {
                        MenuItem m1 = new MenuItem();
                        m1.Id = Int32.Parse(level2[j]["FunctionID"].ToString());
                        m1.MenuName = level2[j]["UDF01"].ToString();
                        m1.Url = level2[j]["Url"].ToString();
                        itemlist.Add(m1);
                    }
                    m.MenuItems = itemlist;
                    mlist.Add(m);
                }
            }

            JsonResult jr = Json(mlist, JsonRequestBehavior.AllowGet);
            return jr;
        }

        /// <summary>
        /// 验证码的校验
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }

    public class MenuData
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public IList<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
    }
}
