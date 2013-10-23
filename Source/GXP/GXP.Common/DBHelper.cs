using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GXP.Common
{
    public class DBHelper
    {
        /// <summary>
        /// 根据SQL语句得到一个数据集
        /// </summary>
        /// <param name="sql">SQL语句或存储过程名称</param>
        /// <returns>DataSet数据集</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            DataSet ds = db.ExecuteDataSet(dbcmd);
            return ds;
        }

        /// <summary>
        /// 获取一个DataSet数据集
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>DataSet数据集</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);

            PrepareDbCommand(dbcmd, paras);
            DataSet ds = db.ExecuteDataSet(dbcmd);
            return ds;
        }

        /// <summary>
        /// 根据SQL语句得到一个数据集
        /// </summary>
        /// <param name="sql">SQL语句或存储过程名称</param>
        /// <returns>DataSet数据集</returns>
        public static DataSet ExecuteDataSet(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            DataSet ds = db.ExecuteDataSet(dbcmd, dbTransaction);
            return ds;
        }

        /// <summary>
        /// 获取一个DataSet数据集
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>DataSet数据集</returns>
        public static DataSet ExecuteDataSet(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            PrepareDbCommand(dbcmd, paras);
            DataSet ds = db.ExecuteDataSet(dbcmd, dbTransaction);
            return ds;
        }
        
        /// <summary>
        /// 执行无返回值的查询,如Insert、Update、Delete
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <returns>执行后对数据库影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            int result = db.ExecuteNonQuery(dbcmd);
            return result;
        }

        /// <summary>
        /// 执行无返回值的查询,如Insert、Update、Delete
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>执行后对数据库影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);

            PrepareDbCommand(dbcmd, paras);
            int result = db.ExecuteNonQuery(dbcmd);
            return result;
        }

        /// <summary>
        /// 执行无返回值的查询,如Insert、Update、Delete
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <returns>执行后对数据库影响的行数</returns>
        public static int ExecuteNonQuery(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            int result = db.ExecuteNonQuery(dbcmd, dbTransaction);
            return result;
        }

        /// <summary>
        /// 执行无返回值的查询,如Insert、Update、Delete
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>执行后对数据库影响的行数</returns>
        public static int ExecuteNonQuery(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            PrepareDbCommand(dbcmd, paras);
            int result = db.ExecuteNonQuery(dbcmd, dbTransaction);
            return result;
        }

        /// <summary>
        /// 获取一个DbDataReader对象
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <returns>DbDataReader对象</returns>
        public static IDataReader ExecuteReader(CommandType cmdType, string cmdText)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            IDataReader reader = db.ExecuteReader(dbcmd);
            return reader;
        }

        /// <summary>
        /// 获取一个DbDataReader对象
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>DbDataReader对象</returns>
        public static IDataReader ExecuteReader(CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);

            PrepareDbCommand(dbcmd, paras);
            IDataReader reader = db.ExecuteReader(dbcmd);
            return reader;
        }

        /// <summary>
        /// 获取一个DbDataReader对象
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <returns>DbDataReader对象</returns>
        public static IDataReader ExecuteReader(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            IDataReader reader = db.ExecuteReader(dbcmd, dbTransaction);
            return reader;
        }

        /// <summary>
        /// 获取一个DbDataReader对象
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>DbDataReader对象</returns>
        public static IDataReader ExecuteReader(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            PrepareDbCommand(dbcmd, paras);
            IDataReader reader = db.ExecuteReader(dbcmd, dbTransaction);
            return reader;
        }

        /// <summary>
        /// 执行返回单个值的查询
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <returns>object值</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);

            return db.ExecuteScalar(dbcmd);
        }

        /// <summary>
        /// 执行返回单个值的查询
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>object值</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);

            PrepareDbCommand(dbcmd, paras);
            return db.ExecuteScalar(dbcmd);
        }

        /// <summary>
        /// 执行返回单个值的查询
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <returns>object值</returns>
        public static object ExecuteScalar(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            return db.ExecuteScalar(dbcmd, dbTransaction);
        }

        /// <summary>
        /// 执行返回单个值的查询
        /// </summary>
        /// <param name="cmdType">命令类型,SQL文本或存储过程</param>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="paras">查询参数</param>
        /// <returns>object值</returns>
        public static object ExecuteScalar(Database db, DbTransaction dbTransaction, CommandType cmdType, string cmdText, params DbParameter[] paras)
        {
            DbCommand dbcmd = GetDbCommand(db, cmdType, cmdText);
            PrepareDbCommand(dbcmd, paras);
            return db.ExecuteScalar(dbcmd, dbTransaction);
        }

        /// <summary>
        /// 准备DbCommand命令
        /// </summary>
        /// <param name="dbCmd">数据库命令</param>
        /// <param name="paras">查询参数</param>
        private static void PrepareDbCommand(DbCommand dbCmd, params DbParameter[] paras)
        {
            if (paras != null && paras.Length > 0)
            {
                foreach (DbParameter pa in paras)
                {
                    dbCmd.Parameters.Add(pa);
                }
            }
        }

        /// <summary>
        /// 根据CommandType获得DbCommand,执行SQL语句或执行存储过程的命令
        /// </summary>
        /// <param name="db">Database对象</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>DbCommand</returns>
        private static DbCommand GetDbCommand(Database db, CommandType cmdType, string cmdText)
        {
            DbCommand dbCmd = null;

            if (cmdType == CommandType.Text)
            {
                dbCmd = db.GetSqlStringCommand(cmdText);
            }
            else if (cmdType == CommandType.StoredProcedure)
            {
                dbCmd = db.GetStoredProcCommand(cmdText);
            }
            else
            {
                dbCmd = db.GetSqlStringCommand(cmdText);
            }
            dbCmd.CommandTimeout = 3000;
            return dbCmd;
        }
    }
}
