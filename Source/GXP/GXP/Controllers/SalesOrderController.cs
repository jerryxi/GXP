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
    public class SalesOrderController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllSalesorder()
        {
            ISalesorderService tmpService = UnityHelper.UnityResolve<ISalesorderService>();
            var data = tmpService.GetSalesorderByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetSalesorderInfoByID(string id)
        {
            ISalesorderService salesorderService = UnityHelper.UnityResolve<ISalesorderService>();
            var data = salesorderService.GetSalesorderByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(SalesorderInfo salesorderInfo)
        {
            if (salesorderInfo.SoID == 0)
            {
                return Insert(salesorderInfo);
            }
            else
            {
                return Update(salesorderInfo);
            }
        }

        public ActionResult Insert(SalesorderInfo salesorderInfo)
        {
            try
            {
                salesorderInfo.CreatedDate = DateTime.Now;
                salesorderInfo.UpdatedDate = DateTime.Now;
                salesorderInfo.CreatedBy = CurrentUserInfo.UserCode;
                salesorderInfo.UpdatedBy = CurrentUserInfo.UserCode;
                ISalesorderService salesorderService = UnityHelper.UnityResolve<ISalesorderService>();
                var data = salesorderService.InsertSalesorder(salesorderInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert SalesorderInfo {0},{1}", LogHelper.ChangeEntityToLog(salesorderInfo), data));
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

        public ActionResult Update(SalesorderInfo salesorderInfo)
        {
            try
            {
                salesorderInfo.UpdatedBy = CurrentUserInfo.UserName;
                salesorderInfo.UpdatedDate = DateTime.Now;
                ISalesorderService salesorderService = UnityHelper.UnityResolve<ISalesorderService>();
                var data = salesorderService.UpdateSalesorder(salesorderInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update SalesorderInfo {0},{1}", LogHelper.ChangeEntityToLog(salesorderInfo), data));
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
                ISalesorderService salesorderService = UnityHelper.UnityResolve<ISalesorderService>();
                var data = salesorderService.DeleteSalesorder(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete SalesorderInfo {0},{1}", deleteID, data));
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
            ISalesorderService salesorderService = UnityHelper.UnityResolve<ISalesorderService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = salesorderService.GetSalesorderByQueryList(qe);
            Export2Excel("Salesorder.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
