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
    public class ItemPropertyController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllItemproperty()
        {
            IItempropertyService tmpService = UnityHelper.UnityResolve<IItempropertyService>();
            var data = tmpService.GetItempropertyByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetItempropertyInfoByID(string id)
        {
            IItempropertyService itempropertyService = UnityHelper.UnityResolve<IItempropertyService>();
            var data = itempropertyService.GetItempropertyByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(ItempropertyInfo itempropertyInfo)
        {
            if (itempropertyInfo.ItemPropertyID == 0)
            {
                return Insert(itempropertyInfo);
            }
            else
            {
                return Update(itempropertyInfo);
            }
        }

        public ActionResult Insert(ItempropertyInfo itempropertyInfo)
        {
            try
            {
                itempropertyInfo.CreatedDate = DateTime.Now;
                itempropertyInfo.UpdatedDate = DateTime.Now;
                itempropertyInfo.CreatedBy = CurrentUserInfo.UserCode;
                itempropertyInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IItempropertyService itempropertyService = UnityHelper.UnityResolve<IItempropertyService>();
                var data = itempropertyService.InsertItemproperty(itempropertyInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert ItempropertyInfo {0},{1}", LogHelper.ChangeEntityToLog(itempropertyInfo), data));
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

        public ActionResult Update(ItempropertyInfo itempropertyInfo)
        {
            try
            {
                itempropertyInfo.UpdatedBy = CurrentUserInfo.UserName;
                itempropertyInfo.UpdatedDate = DateTime.Now;
                IItempropertyService itempropertyService = UnityHelper.UnityResolve<IItempropertyService>();
                var data = itempropertyService.UpdateItemproperty(itempropertyInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update ItempropertyInfo {0},{1}", LogHelper.ChangeEntityToLog(itempropertyInfo), data));
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
                IItempropertyService itempropertyService = UnityHelper.UnityResolve<IItempropertyService>();
                var data = itempropertyService.DeleteItemproperty(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete ItempropertyInfo {0},{1}", deleteID, data));
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
            IItempropertyService itempropertyService = UnityHelper.UnityResolve<IItempropertyService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = itempropertyService.GetItempropertyByQueryList(qe);
            Export2Excel("Itemproperty.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
