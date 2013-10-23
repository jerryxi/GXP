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
    public class AreaController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllArea()
        {
            IAreaService tmpService = UnityHelper.UnityResolve<IAreaService>();
            var data = tmpService.GetAreaByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetAreaInfoByID(string id)
        {
            IAreaService areaService = UnityHelper.UnityResolve<IAreaService>();
            var data = areaService.GetAreaByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(AreaInfo areaInfo)
        {
            if (areaInfo.ID == 0)
            {
                return Insert(areaInfo);
            }
            else
            {
                return Update(areaInfo);
            }
        }

        public ActionResult Insert(AreaInfo areaInfo)
        {
            try
            {
                areaInfo.CretaedDate = DateTime.Now;
                areaInfo.UpdatedDate = DateTime.Now;
                areaInfo.CreatedBy = CurrentUserInfo.UserCode;
                areaInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IAreaService areaService = UnityHelper.UnityResolve<IAreaService>();
                var data = areaService.InsertArea(areaInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert AreaInfo {0},{1}", LogHelper.ChangeEntityToLog(areaInfo), data));
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

        public ActionResult Update(AreaInfo areaInfo)
        {
            try
            {
                areaInfo.UpdatedBy = CurrentUserInfo.UserName;
                areaInfo.UpdatedDate = DateTime.Now;
                IAreaService areaService = UnityHelper.UnityResolve<IAreaService>();
                var data = areaService.UpdateArea(areaInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update AreaInfo {0},{1}", LogHelper.ChangeEntityToLog(areaInfo), data));
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
                IAreaService areaService = UnityHelper.UnityResolve<IAreaService>();
                var data = areaService.DeleteArea(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete AreaInfo {0},{1}", deleteID, data));
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
            IAreaService areaService = UnityHelper.UnityResolve<IAreaService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = areaService.GetAreaByQueryList(qe);
            Export2Excel("Area.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
