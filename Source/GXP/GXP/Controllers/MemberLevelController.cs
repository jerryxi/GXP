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
    public class MemberLevelController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllMemberlevel()
        {
            IMemberlevelService tmpService = UnityHelper.UnityResolve<IMemberlevelService>();
            var data = tmpService.GetMemberlevelByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetMemberlevelInfoByID(string id)
        {
            IMemberlevelService memberlevelService = UnityHelper.UnityResolve<IMemberlevelService>();
            var data = memberlevelService.GetMemberlevelByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(MemberlevelInfo memberlevelInfo)
        {
            if (memberlevelInfo.ID == 0)
            {
                return Insert(memberlevelInfo);
            }
            else
            {
                return Update(memberlevelInfo);
            }
        }

        public ActionResult Insert(MemberlevelInfo memberlevelInfo)
        {
            try
            {
                memberlevelInfo.CreatedDate = DateTime.Now;
                memberlevelInfo.UpdatedDate = DateTime.Now;
                memberlevelInfo.CreatedBy = CurrentUserInfo.UserCode;
                memberlevelInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IMemberlevelService memberlevelService = UnityHelper.UnityResolve<IMemberlevelService>();
                var data = memberlevelService.InsertMemberlevel(memberlevelInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert MemberlevelInfo {0},{1}", LogHelper.ChangeEntityToLog(memberlevelInfo), data));
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

        public ActionResult Update(MemberlevelInfo memberlevelInfo)
        {
            try
            {
                memberlevelInfo.UpdatedBy = CurrentUserInfo.UserName;
                memberlevelInfo.UpdatedDate = DateTime.Now;
                IMemberlevelService memberlevelService = UnityHelper.UnityResolve<IMemberlevelService>();
                var data = memberlevelService.UpdateMemberlevel(memberlevelInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update MemberlevelInfo {0},{1}", LogHelper.ChangeEntityToLog(memberlevelInfo), data));
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
                IMemberlevelService memberlevelService = UnityHelper.UnityResolve<IMemberlevelService>();
                var data = memberlevelService.DeleteMemberlevel(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete MemberlevelInfo {0},{1}", deleteID, data));
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
            IMemberlevelService memberlevelService = UnityHelper.UnityResolve<IMemberlevelService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = memberlevelService.GetMemberlevelByQueryList(qe);
            Export2Excel("Memberlevel.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
