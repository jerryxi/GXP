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
    public class SupplierController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllSupplier()
        {
            ISupplierService tmpService = UnityHelper.UnityResolve<ISupplierService>();
            var data = tmpService.GetSupplierByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetSupplierInfoByID(string id)
        {
            ISupplierService supplierService = UnityHelper.UnityResolve<ISupplierService>();
            var data = supplierService.GetSupplierByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(SupplierInfo supplierInfo)
        {
            if (supplierInfo.SupplierID == 0)
            {
                return Insert(supplierInfo);
            }
            else
            {
                return Update(supplierInfo);
            }
        }

        public ActionResult Insert(SupplierInfo supplierInfo)
        {
            try
            {
                supplierInfo.CreatedDate = DateTime.Now;
                supplierInfo.UpdatedDate = DateTime.Now;
                supplierInfo.CreatedBy = CurrentUserInfo.UserCode;
                supplierInfo.UpdatedBy = CurrentUserInfo.UserCode;
                ISupplierService supplierService = UnityHelper.UnityResolve<ISupplierService>();
                var data = supplierService.InsertSupplier(supplierInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert SupplierInfo {0},{1}", LogHelper.ChangeEntityToLog(supplierInfo), data));
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

        public ActionResult Update(SupplierInfo supplierInfo)
        {
            try
            {
                supplierInfo.UpdatedBy = CurrentUserInfo.UserName;
                supplierInfo.UpdatedDate = DateTime.Now;
                ISupplierService supplierService = UnityHelper.UnityResolve<ISupplierService>();
                var data = supplierService.UpdateSupplier(supplierInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update SupplierInfo {0},{1}", LogHelper.ChangeEntityToLog(supplierInfo), data));
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
                ISupplierService supplierService = UnityHelper.UnityResolve<ISupplierService>();
                var data = supplierService.DeleteSupplier(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete SupplierInfo {0},{1}", deleteID, data));
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
            ISupplierService supplierService = UnityHelper.UnityResolve<ISupplierService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = supplierService.GetSupplierByQueryList(qe);
            Export2Excel("Supplier.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
