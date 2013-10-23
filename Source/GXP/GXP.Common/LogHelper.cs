using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

using log4net;

namespace GXP.Common
{
    public static class LogHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LogHelper));

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="info">Information</param>
        public static void LogInfo(string info)
        {
            log.Info(info);
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="error">异常信息</param>
        public static void LogError(string error)
        {
            log.Error(error);
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">异常Tilte</param>
        public static void LogError(Exception ex, string error)
        {
            log.Error(error, ex);
        }

        /// <summary>
        /// 记录用户操作日志
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userName"></param>
        /// <param name="groupName"></param>
        /// <param name="isSuccess"></param>
        /// <param name="Content"></param>
        public static void LogOperation(string userCode, string userName, string groupName, string isSuccess, string Content)
        {

        }

        /// <summary>
        /// 记录用户操作日志
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="Content"></param>
        public static void LogOperation(string userCode, string Content)
        {
            try
            {
                string sql = "INSERT INTO [OperationLog] ([LogDate],[UserCode],[UserName],[Content],[GroupName],[IsSuccess],[UDF01],[UDF02],[UDF03],[UDF04],[UDF05]) VALUES (GETDATE(),'{0}','','{1}','','','','','','','')";
                DBHelper.ExecuteNonQuery(System.Data.CommandType.Text, string.Format(sql, userCode, Content));
            }
            catch (Exception ex)
            {
                LogError(ex, "记录操作日志时发生异常");
            }
        }

        /// <summary>
        /// 把实体对象转换为日志内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ChangeEntityToLog<T>(T t)
        {
            string result = string.Empty;
            PropertyInfo[] props = t.GetType().GetProperties();
            if (props != null && props.Length > 0)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    result += string.Format("{0}:{1}/", props[i].Name, props[i].GetValue(t, null));
                }
            }
            return result;
        }
    }
}
