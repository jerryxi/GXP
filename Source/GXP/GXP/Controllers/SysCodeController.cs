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
    public class SyscodeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllSyscode()
        {
            ISyscodeService tmpService = UnityHelper.UnityResolve<ISyscodeService>();
            var data = tmpService.GetSyscodeByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetSyscodeInfoByID(string id)
        {
            ISyscodeService syscodeService = UnityHelper.UnityResolve<ISyscodeService>();
            var data = syscodeService.GetSyscodeByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(SyscodeInfo syscodeInfo)
        {
            if (syscodeInfo.CodeID == 0)
            {
                return Insert(syscodeInfo);
            }
            else
            {
                return Update(syscodeInfo);
            }
        }

        public ActionResult Insert(SyscodeInfo syscodeInfo)
        {
            try
            {
                syscodeInfo.CreatedDate = DateTime.Now;
                syscodeInfo.UpdatedDate = DateTime.Now;
                syscodeInfo.CreatedBy = CurrentUserInfo.UserCode;
                syscodeInfo.UpdatedBy = CurrentUserInfo.UserCode;
                ISyscodeService syscodeService = UnityHelper.UnityResolve<ISyscodeService>();
                var data = syscodeService.InsertSyscode(syscodeInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert SyscodeInfo {0},{1}", LogHelper.ChangeEntityToLog(syscodeInfo), data));
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

        public ActionResult Update(SyscodeInfo syscodeInfo)
        {
            try
            {
                syscodeInfo.UpdatedBy = CurrentUserInfo.UserName;
                syscodeInfo.UpdatedDate = DateTime.Now;
                ISyscodeService syscodeService = UnityHelper.UnityResolve<ISyscodeService>();
                var data = syscodeService.UpdateSyscode(syscodeInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update SyscodeInfo {0},{1}", LogHelper.ChangeEntityToLog(syscodeInfo), data));
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
                ISyscodeService syscodeService = UnityHelper.UnityResolve<ISyscodeService>();
                var data = syscodeService.DeleteSyscode(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete SyscodeInfo {0},{1}", deleteID, data));
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
            ISyscodeService syscodeService = UnityHelper.UnityResolve<ISyscodeService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = syscodeService.GetSyscodeByQueryList(qe);
            Export2Excel("Syscode.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
