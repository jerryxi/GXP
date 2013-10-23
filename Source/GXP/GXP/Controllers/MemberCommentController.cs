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
    public class MemberCommentController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllMembercomment()
        {
            IMembercommentService tmpService = UnityHelper.UnityResolve<IMembercommentService>();
            var data = tmpService.GetMembercommentByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetMembercommentInfoByID(string id)
        {
            IMembercommentService membercommentService = UnityHelper.UnityResolve<IMembercommentService>();
            var data = membercommentService.GetMembercommentByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(MembercommentInfo membercommentInfo)
        {
            if (membercommentInfo.CommentID == 0)
            {
                return Insert(membercommentInfo);
            }
            else
            {
                return Update(membercommentInfo);
            }
        }

        public ActionResult Insert(MembercommentInfo membercommentInfo)
        {
            try
            {
                membercommentInfo.CreatedDate = DateTime.Now;
                membercommentInfo.UpdatedDate = DateTime.Now;
                membercommentInfo.CreatedBy = CurrentUserInfo.UserCode;
                membercommentInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IMembercommentService membercommentService = UnityHelper.UnityResolve<IMembercommentService>();
                var data = membercommentService.InsertMembercomment(membercommentInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert MembercommentInfo {0},{1}", LogHelper.ChangeEntityToLog(membercommentInfo), data));
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

        public ActionResult Update(MembercommentInfo membercommentInfo)
        {
            try
            {
                membercommentInfo.UpdatedBy = CurrentUserInfo.UserName;
                membercommentInfo.UpdatedDate = DateTime.Now;
                IMembercommentService membercommentService = UnityHelper.UnityResolve<IMembercommentService>();
                var data = membercommentService.UpdateMembercomment(membercommentInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update MembercommentInfo {0},{1}", LogHelper.ChangeEntityToLog(membercommentInfo), data));
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
                IMembercommentService membercommentService = UnityHelper.UnityResolve<IMembercommentService>();
                var data = membercommentService.DeleteMembercomment(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete MembercommentInfo {0},{1}", deleteID, data));
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
            IMembercommentService membercommentService = UnityHelper.UnityResolve<IMembercommentService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = membercommentService.GetMembercommentByQueryList(qe);
            Export2Excel("Membercomment.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }
    }
}
