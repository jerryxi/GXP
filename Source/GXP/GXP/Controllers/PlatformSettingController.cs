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
    public class PlatformSettingController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllSyssetting()
        {
            ISyssettingService tmpService = UnityHelper.UnityResolve<ISyssettingService>();
            var data = tmpService.GetSyssettingByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetSyssettingInfoByID(string id)
        {
            ISyssettingService syssettingService = UnityHelper.UnityResolve<ISyssettingService>();
            var data = syssettingService.GetSyssettingByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(SyssettingInfo syssettingInfo)
        {
            if (string.IsNullOrEmpty(syssettingInfo.UpdatedBy))
            {
                return Insert(syssettingInfo);
            }
            else
            {
                return Update(syssettingInfo);
            }
        }

        public ActionResult Insert(SyssettingInfo syssettingInfo)
        {
            try
            {
                syssettingInfo.CreatedDate = DateTime.Now;
                syssettingInfo.UpdatedDate = DateTime.Now;
                syssettingInfo.CreatedBy = CurrentUserInfo.UserCode;
                syssettingInfo.UpdatedBy = CurrentUserInfo.UserCode;
                ISyssettingService syssettingService = UnityHelper.UnityResolve<ISyssettingService>();
                var data = syssettingService.InsertSyssetting(syssettingInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert SyssettingInfo {0},{1}", LogHelper.ChangeEntityToLog(syssettingInfo), data));
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

        public ActionResult Update(SyssettingInfo syssettingInfo)
        {
            try
            {
                syssettingInfo.UpdatedBy = CurrentUserInfo.UserName;
                syssettingInfo.UpdatedDate = DateTime.Now;
                ISyssettingService syssettingService = UnityHelper.UnityResolve<ISyssettingService>();
                var data = syssettingService.UpdateSyssetting(syssettingInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update SyssettingInfo {0},{1}", LogHelper.ChangeEntityToLog(syssettingInfo), data));
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
                ISyssettingService syssettingService = UnityHelper.UnityResolve<ISyssettingService>();
                var data = syssettingService.DeleteSyssetting(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete SyssettingInfo {0},{1}", deleteID, data));
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
            ISyssettingService syssettingService = UnityHelper.UnityResolve<ISyssettingService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = syssettingService.GetSyssettingByQueryList(qe);
            Export2Excel("Syssetting.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }        
    }
}
