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
    public class MemberOrderController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllMemberorder()
        {
            IMemberorderService tmpService = UnityHelper.UnityResolve<IMemberorderService>();
            var data = tmpService.GetMemberorderByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetMemberorderInfoByID(string id)
        {
            IMemberorderService memberorderService = UnityHelper.UnityResolve<IMemberorderService>();
            var data = memberorderService.GetMemberorderByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(MemberorderInfo memberorderInfo)
        {
            if (string.IsNullOrEmpty(memberorderInfo.UpdatedBy))
            {
                return Insert(memberorderInfo);
            }
            else
            {
                return Update(memberorderInfo);
            }
        }

        public ActionResult Insert(MemberorderInfo memberorderInfo)
        {
            try
            {
                memberorderInfo.CreatedDate = DateTime.Now;
                memberorderInfo.UpdatedDate = DateTime.Now;
                memberorderInfo.CreatedBy = CurrentUserInfo.UserCode;
                memberorderInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IMemberorderService memberorderService = UnityHelper.UnityResolve<IMemberorderService>();
                var data = memberorderService.InsertMemberorder(memberorderInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert MemberorderInfo {0},{1}", LogHelper.ChangeEntityToLog(memberorderInfo), data));
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

        public ActionResult Update(MemberorderInfo memberorderInfo)
        {
            try
            {
                memberorderInfo.UpdatedBy = CurrentUserInfo.UserName;
                memberorderInfo.UpdatedDate = DateTime.Now;
                IMemberorderService memberorderService = UnityHelper.UnityResolve<IMemberorderService>();
                var data = memberorderService.UpdateMemberorder(memberorderInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update MemberorderInfo {0},{1}", LogHelper.ChangeEntityToLog(memberorderInfo), data));
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
                IMemberorderService memberorderService = UnityHelper.UnityResolve<IMemberorderService>();
                var data = memberorderService.DeleteMemberorder(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete MemberorderInfo {0},{1}", deleteID, data));
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
            IMemberorderService memberorderService = UnityHelper.UnityResolve<IMemberorderService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = memberorderService.GetMemberorderByQueryList(qe);
            Export2Excel("Memberorder.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
