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
    public abstract class SQLUtil
    {
	    public SQLUtil()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }

        //資料庫連接字符串(web.config)
        
        //Server
        public static readonly string CS = "SERVER=AMIGO;DATABASE=DingYaoERP;UID=WebAP;Password=DingYao2015";

        //Test
        //public static readonly string CS = "SERVER=DESKTOP-PRAAPVV\\WEBAP;DATABASE=DingYaoERP;UID=sa;Password=webap2008$$";
       

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

                                                                                                                                                                                                                                                                                                                                                                                                        #region 由Object取值

        /// <summary>
        /// 取得string值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>字串</returns>
        public static string GetString(object obj)
        {
            return obj.ToString();
        }

        /// <summary>
        /// 取得Int值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>Int or Null</returns>
        public static int? GetInt(object obj)
        {
            if (obj != DBNull.Value)
                return int.Parse(obj.ToString());
            else
                return null;
        }

        /// <summary>
        /// 取得Decimal值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>Decimal or Null</returns>
        public static decimal? GetDecimal(object obj)
        {
            if (obj != DBNull.Value)
                return decimal.Parse(obj.ToString());
            else
                return null;
        }

        /// <summary>
        /// 取得DateTime值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>DateTime or Null</returns>
        public static DateTime? GetDateTime(object obj)
        {
            if (obj != DBNull.Value)
                return DateTime.Parse(obj.ToString());
            else
                return null;
        }

        /// <summary>
        /// 取得bool值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>bool or Null</returns>
        public static bool? GetBool(object obj)
        {
            if (obj.ToString() == "1" || obj.ToString().ToLower() == "true")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 取得bool值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>bool or Null</returns>
        public static bool? GetBoolNullAble(object obj)
        {
            if (obj.ToString() == "1" || obj.ToString().ToLower() == "true")
            {
                return true;
            }

            else if (obj.ToString() == "0" || obj.ToString().ToLower() == "false")
            {
                return false;
            }
            else
            {
                return null;
            }                
        }

        /// <summary>
        /// 取得byte[]
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>byte[] or Null</returns>
        public static Byte[] GetByte(object obj)
        {
            if (obj != DBNull.Value)
            {
                return (Byte[])obj;
            }
            else
                return null;
        }

        /// <summary>
        /// 取得Guid值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>Guid or Guid.Empty</returns>
        public static Guid GetGuid(object obj)
        {
            if (obj != DBNull.Value)
                return new Guid(obj.ToString());
            else
                return Guid.Empty;
        }

    #endregion\

    }
}