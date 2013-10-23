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
    public class ItemController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllItem()
        {
            IItemService tmpService = UnityHelper.UnityResolve<IItemService>();
            var data = tmpService.GetItemByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetItemInfoByID(string id)
        {
            IItemService itemService = UnityHelper.UnityResolve<IItemService>();
            var data = itemService.GetItemByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(ItemInfo itemInfo)
        {
            if (itemInfo.ItemID == 0)
            {
                return Insert(itemInfo);
            }
            else
            {
                return Update(itemInfo);
            }
        }

        public ActionResult Insert(ItemInfo itemInfo)
        {
            try
            {
                itemInfo.CreatedDate = DateTime.Now;
                itemInfo.UpdatedDate = DateTime.Now;
                itemInfo.CreatedBy = CurrentUserInfo.UserCode;
                itemInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IItemService itemService = UnityHelper.UnityResolve<IItemService>();
                var data = itemService.InsertItem(itemInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert ItemInfo {0},{1}", LogHelper.ChangeEntityToLog(itemInfo), data));
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

        public ActionResult Update(ItemInfo itemInfo)
        {
            try
            {
                itemInfo.UpdatedBy = CurrentUserInfo.UserName;
                itemInfo.UpdatedDate = DateTime.Now;
                IItemService itemService = UnityHelper.UnityResolve<IItemService>();
                var data = itemService.UpdateItem(itemInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update ItemInfo {0},{1}", LogHelper.ChangeEntityToLog(itemInfo), data));
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
                IItemService itemService = UnityHelper.UnityResolve<IItemService>();
                var data = itemService.DeleteItem(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete ItemInfo {0},{1}", deleteID, data));
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
            IItemService itemService = UnityHelper.UnityResolve<IItemService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = itemService.GetItemByQueryList(qe);
            Export2Excel("Item.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
