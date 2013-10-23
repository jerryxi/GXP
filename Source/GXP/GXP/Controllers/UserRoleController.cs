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
    public class UserRoleController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllUserrole()
        {
            IUserroleService tmpService = UnityHelper.UnityResolve<IUserroleService>();
            var data = tmpService.GetUserroleByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetUserroleInfoByID(string id)
        {
            IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
            var data = userroleService.GetUserroleByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(UserroleInfo userroleInfo)
        {
            if (userroleInfo.Indx == 0)
            {
                return Insert(userroleInfo);
            }
            else
            {
                return Update(userroleInfo);
            }
        }

        public ActionResult Insert(UserroleInfo userroleInfo)
        {
            try
            {
                userroleInfo.CreatedDate = DateTime.Now;
                //userroleInfo.UpdatedDate = DateTime.Now;
                userroleInfo.CreatedBy = CurrentUserInfo.UserCode;
                //userroleInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
                var data = userroleService.InsertUserrole(userroleInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert UserroleInfo {0},{1}", LogHelper.ChangeEntityToLog(userroleInfo), data));
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

        public ActionResult Update(UserroleInfo userroleInfo)
        {
            try
            {
                //userroleInfo.UpdatedBy = CurrentUserInfo.UserName;
                //userroleInfo.UpdatedDate = DateTime.Now;
                IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
                var data = userroleService.UpdateUserrole(userroleInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update UserroleInfo {0},{1}", LogHelper.ChangeEntityToLog(userroleInfo), data));
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
                IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
                var data = userroleService.DeleteUserrole(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete UserroleInfo {0},{1}", deleteID, data));
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
            IUserroleService userroleService = UnityHelper.UnityResolve<IUserroleService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = userroleService.GetUserroleByQueryList(qe);
            Export2Excel("Userrole.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
