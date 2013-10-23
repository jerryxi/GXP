using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;

using GXP.IService;
using GXP.DataEntity;
using GXP.Common;
using Newtonsoft.Json;

namespace GXP.Controllers
{
    public class UserInfoController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }
        
        public string GetAllUserInfos()
        {            
            IUserService userService = UnityHelper.UnityResolve<IUserService>();
            var data = userService.GetUserByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetUserInfoByID(string id)
        {
            IUserService userService = UnityHelper.UnityResolve<IUserService>();
            var data = userService.GetUserByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(UserInfo userInfo)
        {
            if (userInfo.UserID == 0)
            {
                return Insert(userInfo);
            }
            else
            {
                return Update(userInfo);
            }
        }

        public ActionResult Insert(UserInfo userInfo)
        {            
            try
            {
                userInfo.CreatedDate = DateTime.Now;
                userInfo.UpdatedDate = DateTime.Now;
                userInfo.CreatedBy = CurrentUserInfo.UserCode;
                userInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IUserService userService = UnityHelper.UnityResolve<IUserService>();
                var data = userService.InsertUser(userInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("新增用户{0},{1}", LogHelper.ChangeEntityToLog(userInfo), data));
                if (data > 0)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("Failed");
                }
            }
            catch (BusinessException bex)
            {
                return Content(bex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "");
                return Content(ex.Message);
            }
        }

        public ActionResult Update(UserInfo userInfo)
        {
            try
            {
                userInfo.UpdatedBy = CurrentUserInfo.UserName;
                userInfo.UpdatedDate = DateTime.Now;
                IUserService userService = UnityHelper.UnityResolve<IUserService>();
                var data = userService.UpdateUser(userInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("更新用户{0},{1}", LogHelper.ChangeEntityToLog(userInfo), data));
                if (data > 0)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("Failed");
                }
            }
            catch (BusinessException bex)
            {
                return Content(bex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "");
                return Content(ex.Message);
            }
        }

        public ActionResult Delete(string deleteID)
        {
            try
            {
                IUserService userService = UnityHelper.UnityResolve<IUserService>();
                var data = userService.DeleteUser(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("删除用户{0},{1}", deleteID, data));
                if (data > 0)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("Failed");
                }                
            }
            catch (BusinessException bex)
            {
                return Content(bex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "");
                return Content(ex.Message);
            }
        }

        public void Export()
        {
            IUserService userService = UnityHelper.UnityResolve<IUserService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = userService.GetUserByQueryList(qe);
            Export2Excel("123.xls", data);
        }
        
        public ActionResult CheckUnique(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                IUserService userService = UnityHelper.UnityResolve<IUserService>();
                var data = userService.GetUserByCodePhoneEmail(code);
                if (data != null)
                {
                    return Content("NO");
                }
                else
                {
                    return Content("PASS");
                }
            }
            else
            {
                return Content("PASS");
            }
        }

        /*
        [HttpPost]
        public ActionResult SetRole(int userID)
        {
            //var currentSetRoleUser = _userInfoService.LoadEntities(c => c.ID == ID).FirstOrDefault();
            ////把当前要设置角色的用户传递到前台
            //ViewData.Model = currentSetRoleUser;
            ////前台需要所有的角色的信息，这时候我们就需要引用到所有的角色信息，便要定义角色类型
            ////得到枚举中的没有被删除的信息
            //const int deleteNorMal = (int)DeletionStateCodeEnum.Normal;
            //var allRoles = _roleInfoService.LoadEntities(c => c.DeletionStateCode == deleteNorMal).ToList();
            ////动态的MVC特性，传递角色的全部信息
            //ViewBag.AllRoles = allRoles;
            ////往前台传递用户已经关联了的角色信息
            //if (currentSetRoleUser != null)
            //    ViewBag.ExtIsRoleIDS = (from r in currentSetRoleUser.R_UserInfo_Role
            //                            //当前用户和角色中间表的集合数据
            //                            select r.RoleID).ToList();
            ViewBag.AllRoles = "1,2".Split(new char[] { ',' }).ToList();
            ViewBag.ExtIsRoleIDS = "";
            return View();
        }
        
        public ActionResult SetRole123()
        {
            return Content("OK");
        }

        public ActionResult SetRole2(int userID)
        {
            //return Content("OK");
            return Json("{id:1,name:234}", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserInfoByID2(string id)
        {
            IUserService userService = UnityHelper.UnityResolve<IUserService>();
            var data = userService.GetUserByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        */

        /// <summary>
        /// 为用户设置角色
        /// </summary>
        /// <param name="ID">获取当前选择的用户的ID</param>
        /// <returns>返回根据这个ID查到的用户信息</returns>
        public ActionResult SetRole(string ID)
        {
            IUserService userService = UnityHelper.UnityResolve<IUserService>();
            var currentSetRoleUser = userService.GetUserByID(ID);
            ViewData.Model = currentSetRoleUser;
            IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
            ViewBag.ExtIsRoleIDS = userroleService.GetUserRoleListByUserID(ID);
            
            IRoleService roleService = UnityHelper.UnityResolve<IRoleService>();
            var allRoles = roleService.GetAllRoleList();
            ViewBag.AllRoles = allRoles;
            return View();
        }

        /// <summary>
        /// 给用户设置角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetRole()
        {
            var userID = Request["hdnUserID"] == null ? 0 : int.Parse(Request["hdnUserID"]);


            //首先获取设置角色的用户ID,查询出用户的信息
            //var userId = Request["HideUserID"] == null ? 0 : int.Parse(Request["HideUserID"]);
            //var currentSetUser = _userInfoService.LoadEntities(c => c.ID == userId).FirstOrDefault();
            //if (currentSetUser != null)
            //{
            //    //给当前用户设置角色，从前台拿到所有的 角色 sru_3，从请求的表单里面拿到所有的以sru_开头的key。
            //    //第一种方法
            //    //foreach (var allKey in Request.Form.AllKeys)
            //    //{
            //    //}
            //    //第二种写法
            var allKeys = from key in Request.Form.AllKeys
                          where key.StartsWith("sru_")
                          select key;
            //首先顶一个list集合存放传递过来的key，也就是角色的ID
            var roleIDs = new List<int>();
            //循环将角色的ID加入到集合中
            if (userID > 0)
            {
                foreach (var key in allKeys)
                {
                    roleIDs.Add(int.Parse(key.Replace("sru_", "")));
                }
            }

            IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
            userroleService.SetUserRoles(userID, roleIDs, CurrentUserInfo.UserID.ToString());

            //_userInfoService.SetBaseUserRole(userId, roleIDs, Session["UserInfo"] as BaseUser);
            //}

            return Content("OK");
        }
    }

    public class UserRole23
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
