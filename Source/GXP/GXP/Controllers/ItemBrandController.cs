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
    public class ItemBrandController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllItembrand()
        {
            IItembrandService tmpService = UnityHelper.UnityResolve<IItembrandService>();
            var data = tmpService.GetItembrandByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetItembrandInfoByID(string id)
        {
            IItembrandService itembrandService = UnityHelper.UnityResolve<IItembrandService>();
            var data = itembrandService.GetItembrandByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(ItembrandInfo itembrandInfo)
        {
            if (itembrandInfo.BrandID == 0)
            {
                return Insert(itembrandInfo);
            }
            else
            {
                return Update(itembrandInfo);
            }
        }

        public ActionResult Insert(ItembrandInfo itembrandInfo)
        {
            try
            {
                itembrandInfo.CreatedDate = DateTime.Now;
                itembrandInfo.UpdatedDate = DateTime.Now;
                itembrandInfo.CreatedBy = CurrentUserInfo.UserCode;
                itembrandInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IItembrandService itembrandService = UnityHelper.UnityResolve<IItembrandService>();
                var data = itembrandService.InsertItembrand(itembrandInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert ItembrandInfo {0},{1}", LogHelper.ChangeEntityToLog(itembrandInfo), data));
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

        public ActionResult Update(ItembrandInfo itembrandInfo)
        {
            try
            {
                itembrandInfo.UpdatedBy = CurrentUserInfo.UserName;
                itembrandInfo.UpdatedDate = DateTime.Now;
                IItembrandService itembrandService = UnityHelper.UnityResolve<IItembrandService>();
                var data = itembrandService.UpdateItembrand(itembrandInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update ItembrandInfo {0},{1}", LogHelper.ChangeEntityToLog(itembrandInfo), data));
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
                IItembrandService itembrandService = UnityHelper.UnityResolve<IItembrandService>();
                var data = itembrandService.DeleteItembrand(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete ItembrandInfo {0},{1}", deleteID, data));
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
            IItembrandService itembrandService = UnityHelper.UnityResolve<IItembrandService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = itembrandService.GetItembrandByQueryList(qe);
            Export2Excel("Itembrand.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
