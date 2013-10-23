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
    public class ItemInventoryController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllInventory()
        {
            IInventoryService tmpService = UnityHelper.UnityResolve<IInventoryService>();
            var data = tmpService.GetInventoryByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetInventoryInfoByID(string id)
        {
            IInventoryService inventoryService = UnityHelper.UnityResolve<IInventoryService>();
            var data = inventoryService.GetInventoryByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(InventoryInfo inventoryInfo)
        {
            if (inventoryInfo.ID == 0)
            {
                return Insert(inventoryInfo);
            }
            else
            {
                return Update(inventoryInfo);
            }
        }

        public ActionResult Insert(InventoryInfo inventoryInfo)
        {
            try
            {
                inventoryInfo.CreatedDate = DateTime.Now;
                inventoryInfo.UpdatedDate = DateTime.Now;
                inventoryInfo.CreatedBy = CurrentUserInfo.UserCode;
                inventoryInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IInventoryService inventoryService = UnityHelper.UnityResolve<IInventoryService>();
                var data = inventoryService.InsertInventory(inventoryInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert InventoryInfo {0},{1}", LogHelper.ChangeEntityToLog(inventoryInfo), data));
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

        public ActionResult Update(InventoryInfo inventoryInfo)
        {
            try
            {
                inventoryInfo.UpdatedBy = CurrentUserInfo.UserName;
                inventoryInfo.UpdatedDate = DateTime.Now;
                IInventoryService inventoryService = UnityHelper.UnityResolve<IInventoryService>();
                var data = inventoryService.UpdateInventory(inventoryInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update InventoryInfo {0},{1}", LogHelper.ChangeEntityToLog(inventoryInfo), data));
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
                IInventoryService inventoryService = UnityHelper.UnityResolve<IInventoryService>();
                var data = inventoryService.DeleteInventory(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete InventoryInfo {0},{1}", deleteID, data));
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
            IInventoryService inventoryService = UnityHelper.UnityResolve<IInventoryService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = inventoryService.GetInventoryByQueryList(qe);
            Export2Excel("Inventory.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
