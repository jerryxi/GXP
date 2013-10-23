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
    public class MemberController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllMember()
        {
            IMemberService tmpService = UnityHelper.UnityResolve<IMemberService>();
            var data = tmpService.GetMemberByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetMemberInfoByID(string id)
        {
            IMemberService memberService = UnityHelper.UnityResolve<IMemberService>();
            var data = memberService.GetMemberByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(MemberInfo memberInfo)
        {
            if (memberInfo.MemberID == 0)
            {
                return Insert(memberInfo);
            }
            else
            {
                return Update(memberInfo);
            }
        }

        public ActionResult Insert(MemberInfo memberInfo)
        {
            try
            {
                memberInfo.CreatedDate = DateTime.Now;
                memberInfo.UpdatedDate = DateTime.Now;
                memberInfo.CretaedBy = CurrentUserInfo.UserCode;
                memberInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IMemberService memberService = UnityHelper.UnityResolve<IMemberService>();
                var data = memberService.InsertMember(memberInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert MemberInfo {0},{1}", LogHelper.ChangeEntityToLog(memberInfo), data));
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

        public ActionResult Update(MemberInfo memberInfo)
        {
            try
            {
                memberInfo.UpdatedBy = CurrentUserInfo.UserName;
                memberInfo.UpdatedDate = DateTime.Now;
                IMemberService memberService = UnityHelper.UnityResolve<IMemberService>();
                var data = memberService.UpdateMember(memberInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update MemberInfo {0},{1}", LogHelper.ChangeEntityToLog(memberInfo), data));
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
                IMemberService memberService = UnityHelper.UnityResolve<IMemberService>();
                var data = memberService.DeleteMember(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete MemberInfo {0},{1}", deleteID, data));
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
            IMemberService memberService = UnityHelper.UnityResolve<IMemberService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = memberService.GetMemberByQueryList(qe);
            Export2Excel("Member.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
