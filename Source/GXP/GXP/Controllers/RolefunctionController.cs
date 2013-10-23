using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.Mvc;

using GXP.IService;
using GXP.DataEntity;
using GXP.Common;
using Newtonsoft.Json;

namespace GXP.Controllers
{
    public class RolefunctionController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用!";
            return View();
        }

        public string GetAllRolefunction()
        {
            IRolefunctionService tmpService = UnityHelper.UnityResolve<IRolefunctionService>();
            var data = tmpService.GetRolefunctionByQueryList(InitQueryEntity());
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = ConstUtils.CONST_SHOW_DATE_FORMAT;
            var tmpdata = JsonConvert.SerializeObject(data.Tables[2], timeConverter);
            var result = "{\"total\":" + data.Tables[1].Rows[0]["TotalRecordsCount"].ToString() + ",\"rows\":" + tmpdata + " }";
            return result;
        }

        public ActionResult GetRolefunctionInfoByID(string id)
        {
            IRolefunctionService rolefunctionService = UnityHelper.UnityResolve<IRolefunctionService>();
            var data = rolefunctionService.GetRolefunctionByID(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(RolefunctionInfo rolefunctionInfo)
        {
            if (rolefunctionInfo.Indx == 0)
            {
                return Insert(rolefunctionInfo);
            }
            else
            {
                return Update(rolefunctionInfo);
            }
        }

        public ActionResult Insert(RolefunctionInfo rolefunctionInfo)
        {
            try
            {
                rolefunctionInfo.CreatedDate = DateTime.Now;
                //rolefunctionInfo.up = DateTime.Now;
                rolefunctionInfo.CreatedBy = CurrentUserInfo.UserCode;
                //rolefunctionInfo.UpdatedBy = CurrentUserInfo.UserCode;
                IRolefunctionService rolefunctionService = UnityHelper.UnityResolve<IRolefunctionService>();
                var data = rolefunctionService.InsertRolefunction(rolefunctionInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Insert RolefunctionInfo {0},{1}", LogHelper.ChangeEntityToLog(rolefunctionInfo), data));
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

        public ActionResult Update(RolefunctionInfo rolefunctionInfo)
        {
            try
            {
                //rolefunctionInfo.UpdatedBy = CurrentUserInfo.UserName;
                //rolefunctionInfo.UpdatedDate = DateTime.Now;
                IRolefunctionService rolefunctionService = UnityHelper.UnityResolve<IRolefunctionService>();
                var data = rolefunctionService.UpdateRolefunction(rolefunctionInfo);
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Update RolefunctionInfo {0},{1}", LogHelper.ChangeEntityToLog(rolefunctionInfo), data));
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
                IRolefunctionService rolefunctionService = UnityHelper.UnityResolve<IRolefunctionService>();
                var data = rolefunctionService.DeleteRolefunction(deleteID.Split(',').ToList());
                LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete RolefunctionInfo {0},{1}", deleteID, data));
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
            IRolefunctionService rolefunctionService = UnityHelper.UnityResolve<IRolefunctionService>();
            QueryEntity qe = InitQueryEntity();
            qe.IsGetAll = true;
            var data = rolefunctionService.GetRolefunctionByQueryList(qe);
            Export2Excel("Rolefunction.xls", data);
        }

        public ActionResult CheckUnique(string code)
        {
            return Content("PASS");
        }

        public ActionResult GetRolefunction(string roleID)
        {
            Session["selectedRoleID"] = roleID;
            return Content("OK");
        }

        public string GetRolefunction2()
        {
            string roleID = Session["selectedRoleID"] as string;
            IRolefunctionService roleFunction = UnityHelper.UnityResolve<IRolefunctionService>();
            DataSet roleFunctionDS = roleFunction.GetRolefunctionByQueryList(new QueryEntity { IsGetAll = true, sqlWhere = new List<string> { "roleID='" + roleID + "'" } });
            
            IFunctiongroupService tmpService = UnityHelper.UnityResolve<IFunctiongroupService>();
            var data = tmpService.GetFunctionGroupByRoleID(Int32.Parse(roleID));
            DataRow[] drlv1 = data.Tables[0].Select("ParentID=1000");
            StringBuilder sbRole = new StringBuilder();
            for (int i = 0; i < drlv1.Length; i++)
            {
                sbRole.Append("{\"id\":" + drlv1[i]["FunctionID"].ToString() + ",\"text\":\"" + drlv1[i]["UDF01"].ToString() + "\",\"state\":\"closed\",\"children\":[");

                DataRow[] drlv2 = data.Tables[0].Select(string.Format("ParentID='{0}'", drlv1[i]["FunctionID"].ToString()));
                for (int j = 0; j < drlv2.Length; j++)
                {
                    string ischecked = string.Empty;
                    if (!string.IsNullOrEmpty(drlv2[j]["checked_functionID"].ToString()))
                    {
                        ischecked = "true";
                    }
                    else
                    {
                        ischecked = "false";
                    }

                    sbRole.Append("{\"id\":" + drlv2[j]["FunctionID"].ToString() + ",\"text\":\"" + drlv2[j]["UDF01"].ToString() + "\",\"checked\":" + ischecked + "}");
                    if (j != drlv2.Length - 1)
                    {
                        sbRole.Append(",");
                    }
                }
                sbRole.Append("]}");
                if (i != drlv1.Length - 1)
                {
                    sbRole.Append(",");
                }
            }
            var role = "[{\"id\":0,\"text\":\"角色权限\",\"state\":\"open\",\"children\":[" + sbRole.ToString() + "]}]";
            return role;
        }

        public ActionResult SetRoleFunction(string functionID)
        {
            try
            {
                string roleID = Session["selectedRoleID"] as string;
                IRolefunctionService rolefunctionService = UnityHelper.UnityResolve<IRolefunctionService>();
                var data = rolefunctionService.InsertRolefunction(Int32.Parse(roleID), functionID);
                //LogHelper.LogOperation(CurrentUserInfo.UserCode, string.Format("Delete RolefunctionInfo {0},{1}", roleID, data));
                //if (data > 0)
                //{
                return Content("OK");
                //}
                //else
                //{
                //    return Content("Failed");
                //}
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
    }

    public class RoleData
    {
        public string id { get; set; }
        public string text { get; set; }
        public List<children> children { get; set; }
    }
    public class children
    {
        public string id { get; set; }
        public string text { get; set; }
        public string Checked { get; set; }
    }
}
