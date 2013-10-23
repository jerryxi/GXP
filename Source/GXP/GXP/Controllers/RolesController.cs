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
    public class RolesController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllRole()
        {
            IRoleService tmpService = UnityHelper.UnityResolve<IRoleService>();
            var data = tmpService.GetRoleByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetRoleInfoByID(string id)
        {
            IRoleService roleService = UnityHelper.UnityResolve<IRoleService>();
            var data = roleService.GetRoleByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(RoleInfo roleInfo)
        {
            if (roleInfo.RoleID == 0)
            {
                return Insert(roleInfo);
            }
            else
            {
                return Update(roleInfo);
            }
        }

        public ActionResult Insert(RoleInfo roleInfo)
        {
            try
            {
                roleInfo.CreatedDate = DateTime.Now;
                roleInfo.UpdatedDate = DateTime.Now;
                roleInfo.CreatedBy = CurrentUserInfo.UserCode;
                roleInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IRoleService roleService = UnityHelper.UnityResolve<IRoleService>();
                var data = roleService.InsertRole(roleInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert RoleInfo {0},{1}", LogHelper.ChangeEntityToLog(roleInfo), data));
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

        public ActionResult Update(RoleInfo roleInfo)
        {
            try
            {
                roleInfo.UpdatedBy = CurrentUserInfo.UserName;
                roleInfo.UpdatedDate = DateTime.Now;
                IRoleService roleService = UnityHelper.UnityResolve<IRoleService>();
                var data = roleService.UpdateRole(roleInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update RoleInfo {0},{1}", LogHelper.ChangeEntityToLog(roleInfo), data));
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
                IRoleService roleService = UnityHelper.UnityResolve<IRoleService>();
                var data = roleService.DeleteRole(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete RoleInfo {0},{1}", deleteID, data));
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
            IRoleService roleService = UnityHelper.UnityResolve<IRoleService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = roleService.GetRoleByQueryList(qe);
            Export2Excel("Role.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
