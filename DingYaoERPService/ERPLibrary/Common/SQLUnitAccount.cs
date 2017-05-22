using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DingYaoERP.Common
{
    /// <summary>
    /// SQL Utility
    /// </summary>
    public abstract class SQLUnitAccount
    {
        public SQLUnitAccount()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
        //資料庫連接字符串(web.config)

        //Test
        //public static readonly string CS = "SERVER=60.250.64.133,6633;DATABASE=ADMIN;UID=WebAP;Password=webap2008$$";

        //Server
        public static readonly string CS = "SERVER=AMIGO;DATABASE=Admin;UID=WebAP;Password=DingYao2015";


        //顯示設定序號
        public static readonly int intSysTemShow = 1;

        /// <summary>
        /// 執行SQL語句，回傳影響的資料筆數
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static int ExecuteSql(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                cmd.Connection = cn;
                cn.Open();
                int intRows = cmd.ExecuteNonQuery();
                cn.Close();
                return intRows;
            }
        }

        /// <summary>
        /// 執行SQL語句，回傳影響的資料筆數
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static int ExecuteSql(string strConn, SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            {
                cmd.Connection = cn;
                cn.Open();
                int intRows = cmd.ExecuteNonQuery();
                cn.Close();
                return intRows;
            }
        }

        /// <summary>
        /// 執行SQL語句，回傳結果
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static object ExecuteScalar(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                cmd.Connection = cn;
                cn.Open();
                object obj = cmd.ExecuteScalar();
                cn.Close();
                return obj;
            }
        }

        /// <summary>
        /// 執行SQL語句，回傳結果
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static object ExecuteScalar(string strConn, SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            {
                cmd.Connection = cn;
                cn.Open();
                object obj = cmd.ExecuteScalar();
                cn.Close();
                return obj;
            }
        }

        /// <summary>
        /// 執行查詢語句，回傳DataSet
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>DataSet</returns>
        public static DataSet QueryDS(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                cmd.Connection = cn;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 執行查詢語句，回傳DataSet
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>DataSet</returns>
        public static DataSet QueryDS(string strConn, SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            {
                cmd.Connection = cn;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 執行查詢語句，回傳SqlDataReader
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader QueryDR(SqlCommand cmd)
        {
            SqlConnection cn = new SqlConnection(CS);
            SqlDataReader dr;
            try
            {
                cmd.Connection = cn;
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dr;
        }

        /// <summary>
        /// 執行查詢語句，回傳SqlDataReader
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader QueryDR(string strConn, SqlCommand cmd)
        {
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataReader dr;
            try
            {
                cmd.Connection = cn;
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dr;
        }

        /// <summary>
        /// 資料庫輸入值的Check
        /// </summary>
        /// <param name="obj">資料庫輸入值</param>
        /// <returns>確認後的資料庫輸入值</returns>
        public static object CheckDBValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }

    }
}
