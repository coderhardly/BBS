using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlHelper : IDisposable
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static string connStr;

        static SqlHelper()
        {
            //初始化连接字符串connStr和SqlConnection对象
            connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }
        public void Dispose()
        {
            Close();
            conn.Dispose();
            cmd.Dispose();
            dr.Dispose();
            da.Dispose();
        }

        #region 打开和关闭连接
        /// <summary>
        /// 取消 Command 执行，并关闭 conn对象的数据连接和释放cmd对象
        /// </summary>
        static void Close()
        {
            cmd.Cancel();
            if (cmd != null)
                cmd.Dispose();
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
        /// <summary>
        /// 打开SqlConnection对象的连接
        /// </summary>
        static void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            else if (conn.State == ConnectionState.Open)
            {

            }
        }
        #endregion

        #region 连接模式
        /// <summary>
        /// 执行增删改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            int result = -1;
            conn = new SqlConnection(connStr);
            using (cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                result = cmd.ExecuteNonQuery();
            }
            //关闭连接
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            return result;
        }
        /// <summary>
        /// 查询返回单一的结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns>返回查询结果的第一行第一列的object对象</returns>
        public static object ExecuteScaler(string sql, params SqlParameter[] parameters)
        {
            object result = null;
            try
            {
                conn = new SqlConnection(connStr);
                cmd = new SqlCommand(sql, conn);
                Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                result = cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                Close();
            }
            return result;
        }
        /// <summary>
        /// 查询返回一个DataTable对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            conn = new SqlConnection(connStr);
            using (cmd = new SqlCommand(sql, conn))
            {
                Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return ConvertSqlDataReaderToDataTable(dr);
        }
        #endregion

        #region 断开模式
        public static DataTable GetTable(string sql, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using (conn=new SqlConnection(connStr))
            {
                using (da = new SqlDataAdapter(sql,conn))
                {
                    if (parameters != null)
                        da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        #endregion

        #region 其他
        /// <summary>
        /// 执行多条语句，执行数据库事务
        /// </summary>
        /// <returns>返回执行是否成功的布尔值</returns>
        public static bool transfer(List<CommandInfo> cmdInfo)
        {
            conn = new SqlConnection(connStr);
            SqlTransaction trans = null;
            try
            {
                Open();
                trans = conn.BeginTransaction();//开始一个事务

                //遍历集合执行所有sql语句
                foreach (CommandInfo item in cmdInfo)
                {
                    //执行某个sql语句
                    using (cmd = new SqlCommand(item.CommandText, conn))
                    {
                        cmd.Transaction = trans;
                        if (item.parameters != null)
                        {
                            cmd.Parameters.AddRange(item.parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();//提交事务
                return true;
            }
            catch (Exception)
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                trans.Dispose();
                Close();
            }
        }
        /// <summary>
        /// 将SqlDataReader对象转换成DataTable对象并关闭SqlDataReader对象
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        public static DataTable ConvertSqlDataReaderToDataTable(SqlDataReader sqlDataReader)
        {
            DataTable dataTable = null;
            try
            {
                if (sqlDataReader != null)
                {
                    dataTable = new DataTable();
                    //动态添加表的数据列
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        DataColumn dc = new DataColumn(sqlDataReader.GetName(i), sqlDataReader.GetFieldType(i));
                        dataTable.Columns.Add(dc);
                    }
                    //用sqlDataReader中的数据填充dataTable
                    while (sqlDataReader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            dataRow[i] = sqlDataReader.GetValue(i);
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                //关闭sqlDataReader对象
                if (!sqlDataReader.IsClosed)
                    dr.Close();
            }
            return dataTable;
        }
        #endregion

    }
}
