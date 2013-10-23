using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

using Microsoft.Practices.EnterpriseLibrary.Data;
using GXP.IDAL;
using GXP.Common;
using GXP.DataEntity;

namespace GXP.OracleDAL
{
    public class UserDA : IUserDA
    {
        public DataSet GetAllUser()
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllUser(Database db, DbTransaction tran)
        {
            throw new NotImplementedException();
        }

        public DataSet GetUserByQueryList(QueryEntity userQuery)
        {
            throw new NotImplementedException();
        }

        public DataSet GetUserByQueryList(Database db, DbTransaction tran, QueryEntity userQuery)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetUserByID(string userID)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetUserByID(Database db, DbTransaction tran, string userID)
        {
            throw new NotImplementedException();
        }

        public int InsertUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int InsertUser(Database db, DbTransaction tran, UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(Database db, DbTransaction tran, UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(string userID)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(Database db, DbTransaction tran, string userID)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserIDIsExist(string userID)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserIDIsExist(Database db, DbTransaction tran, string userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户ID，Code，手机号，邮箱得到用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UserInfo GetUserByCodePhoneEmail(string code)
        {
            return null;
            //string sql = SQL_SELECT_ALL_USER + " AND (UserID=@code OR UserCode=@code OR Email=@code Or MobilePhone=@code)  ";
            //SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@code", code) };
            //UserInfo userInfo = null;

            //using (IDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, paras))
            //{
            //    if (reader.Read())
            //    {
            //        userInfo = InitUserInfoByDataReader(userInfo, reader);
            //    }
            //}

            //return userInfo;
        }
    }
}
