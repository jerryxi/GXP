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
    public class ItemFeedbackController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllItemfeedback()
        {
            IItemfeedbackService tmpService = UnityHelper.UnityResolve<IItemfeedbackService>();
            var data = tmpService.GetItemfeedbackByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetItemfeedbackInfoByID(string id)
        {
            IItemfeedbackService itemfeedbackService = UnityHelper.UnityResolve<IItemfeedbackService>();
            var data = itemfeedbackService.GetItemfeedbackByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(ItemfeedbackInfo itemfeedbackInfo)
        {
            if (itemfeedbackInfo.ID == 0)
            {
                return Insert(itemfeedbackInfo);
            }
            else
            {
                return Update(itemfeedbackInfo);
            }
        }

        public ActionResult Insert(ItemfeedbackInfo itemfeedbackInfo)
        {
            try
            {
                itemfeedbackInfo.CreatedDate = DateTime.Now;
                itemfeedbackInfo.ReplyBy = CurrentUserInfo.UserCode;
                itemfeedbackInfo.CreatedBy = CurrentUserInfo.UserCode;
                itemfeedbackInfo.ReplyDate = DateTime.Now;
                IItemfeedbackService itemfeedbackService = UnityHelper.UnityResolve<IItemfeedbackService>();
                var data = itemfeedbackService.InsertItemfeedback(itemfeedbackInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert ItemfeedbackInfo {0},{1}", LogHelper.ChangeEntityToLog(itemfeedbackInfo), data));
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

        public ActionResult Update(ItemfeedbackInfo itemfeedbackInfo)
        {
            try
            {
                itemfeedbackInfo.ReplyBy = CurrentUserInfo.UserName;
                itemfeedbackInfo.ReplyDate = DateTime.Now;
                IItemfeedbackService itemfeedbackService = UnityHelper.UnityResolve<IItemfeedbackService>();
                var data = itemfeedbackService.UpdateItemfeedback(itemfeedbackInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update ItemfeedbackInfo {0},{1}", LogHelper.ChangeEntityToLog(itemfeedbackInfo), data));
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
                IItemfeedbackService itemfeedbackService = UnityHelper.UnityResolve<IItemfeedbackService>();
                var data = itemfeedbackService.DeleteItemfeedback(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete ItemfeedbackInfo {0},{1}", deleteID, data));
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
            IItemfeedbackService itemfeedbackService = UnityHelper.UnityResolve<IItemfeedbackService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = itemfeedbackService.GetItemfeedbackByQueryList(qe);
            Export2Excel("Itemfeedback.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
