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
    public class PurchaseOrderController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllPurchaseorder()
        {
            IPurchaseorderService tmpService = UnityHelper.UnityResolve<IPurchaseorderService>();
            var data = tmpService.GetPurchaseorderByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetPurchaseorderInfoByID(string id)
        {
            IPurchaseorderService purchaseorderService = UnityHelper.UnityResolve<IPurchaseorderService>();
            var data = purchaseorderService.GetPurchaseorderByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(PurchaseorderInfo purchaseorderInfo)
        {
            if (purchaseorderInfo.PoID == 0)
            {
                return Insert(purchaseorderInfo);
            }
            else
            {
                return Update(purchaseorderInfo);
            }
        }

        public ActionResult Insert(PurchaseorderInfo purchaseorderInfo)
        {
            try
            {
                purchaseorderInfo.CreatedDate = DateTime.Now;
                purchaseorderInfo.UpdatedDate = DateTime.Now;
                purchaseorderInfo.CreatedBy = CurrentUserInfo.UserCode;
                purchaseorderInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IPurchaseorderService purchaseorderService = UnityHelper.UnityResolve<IPurchaseorderService>();
                var data = purchaseorderService.InsertPurchaseorder(purchaseorderInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert PurchaseorderInfo {0},{1}", LogHelper.ChangeEntityToLog(purchaseorderInfo), data));
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

        public ActionResult Update(PurchaseorderInfo purchaseorderInfo)
        {
            try
            {
                purchaseorderInfo.UpdatedBy = CurrentUserInfo.UserName;
                purchaseorderInfo.UpdatedDate = DateTime.Now;
                IPurchaseorderService purchaseorderService = UnityHelper.UnityResolve<IPurchaseorderService>();
                var data = purchaseorderService.UpdatePurchaseorder(purchaseorderInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update PurchaseorderInfo {0},{1}", LogHelper.ChangeEntityToLog(purchaseorderInfo), data));
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
                IPurchaseorderService purchaseorderService = UnityHelper.UnityResolve<IPurchaseorderService>();
                var data = purchaseorderService.DeletePurchaseorder(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete PurchaseorderInfo {0},{1}", deleteID, data));
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
            IPurchaseorderService purchaseorderService = UnityHelper.UnityResolve<IPurchaseorderService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = purchaseorderService.GetPurchaseorderByQueryList(qe);
            Export2Excel("Purchaseorder.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
