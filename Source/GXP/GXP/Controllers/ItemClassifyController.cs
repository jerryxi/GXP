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
    public class ItemClassifyController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllItemclass()
        {
            IItemclassService tmpService = UnityHelper.UnityResolve<IItemclassService>();
            var data = tmpService.GetItemclassByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetItemclassInfoByID(string id)
        {
            IItemclassService itemclassService = UnityHelper.UnityResolve<IItemclassService>();
            var data = itemclassService.GetItemclassByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(ItemclassInfo itemclassInfo)
        {
            if (itemclassInfo.ClassID == 0)
            {
                return Insert(itemclassInfo);
            }
            else
            {
                return Update(itemclassInfo);
            }
        }

        public ActionResult Insert(ItemclassInfo itemclassInfo)
        {
            try
            {
                itemclassInfo.CreatedDate = DateTime.Now;
                itemclassInfo.UpdatedDate = DateTime.Now;
                itemclassInfo.CreatedBy = CurrentUserInfo.UserCode;
                itemclassInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IItemclassService itemclassService = UnityHelper.UnityResolve<IItemclassService>();
                var data = itemclassService.InsertItemclass(itemclassInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert ItemclassInfo {0},{1}", LogHelper.ChangeEntityToLog(itemclassInfo), data));
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

        public ActionResult Update(ItemclassInfo itemclassInfo)
        {
            try
            {
                itemclassInfo.UpdatedBy = CurrentUserInfo.UserName;
                itemclassInfo.UpdatedDate = DateTime.Now;
                IItemclassService itemclassService = UnityHelper.UnityResolve<IItemclassService>();
                var data = itemclassService.UpdateItemclass(itemclassInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update ItemclassInfo {0},{1}", LogHelper.ChangeEntityToLog(itemclassInfo), data));
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
                IItemclassService itemclassService = UnityHelper.UnityResolve<IItemclassService>();
                var data = itemclassService.DeleteItemclass(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete ItemclassInfo {0},{1}", deleteID, data));
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
            IItemclassService itemclassService = UnityHelper.UnityResolve<IItemclassService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = itemclassService.GetItemclassByQueryList(qe);
            Export2Excel("Itemclass.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
