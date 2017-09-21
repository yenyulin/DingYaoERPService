using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DingYaoERP.Models;
using DingYaoERP.Common;

namespace DingYaoERP.DAL
{
    /// <summary>
    /// 資料存取層 SummonsAccount
    /// </summary>
    public class DSummonsAccount
    {
        public DSummonsAccount() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MSummonsAccount mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = mod.SummonsID;
            cmd.Parameters.Add("@AccountID", SqlDbType.NChar).Value = mod.AccountID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = mod.AccountName;
            cmd.Parameters.Add("@DebitCredit", SqlDbType.NVarChar).Value = mod.DebitCredit;
            cmd.Parameters.Add("@SumMoney", SqlDbType.Decimal).Value = mod.SumMoney;
            cmd.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = mod.Summary;
            return SQLUtil.ExecuteSql(cmd) > 0 ? mod.SummonsID : null;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MSummonsAccount mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = mod.SummonsID;
            cmd.Parameters.Add("@AccountID", SqlDbType.NChar).Value = mod.AccountID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = mod.AccountName;
            cmd.Parameters.Add("@DebitCredit", SqlDbType.NVarChar).Value = mod.DebitCredit;
            cmd.Parameters.Add("@SumMoney", SqlDbType.Decimal).Value = mod.SumMoney;
            cmd.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = mod.Summary;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strSummonsID, string strAccountID, string strDebitCredit)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            cmd.Parameters.Add("@AccountID", SqlDbType.NChar).Value =strAccountID;
            cmd.Parameters.Add("@DebitCredit", SqlDbType.NVarChar).Value = strDebitCredit;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MSummonsAccount GetModel(string strSummonsID, string strAccountID, string strDebitCredit)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            cmd.Parameters.Add("@AccountID", SqlDbType.NChar).Value = strAccountID;
            cmd.Parameters.Add("@DebitCredit", SqlDbType.NVarChar).Value = strDebitCredit;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MSummonsAccount mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MSummonsAccount> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_SummonsAccountGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MSummonsAccount SetModel(SqlDataReader dr)
        {
            Models.MSummonsAccount mod = new Models.MSummonsAccount();
            while (dr.Read())
            {
                mod.SummonsID = dr["SummonsID"].ToString();
                mod.AccountID = dr["AccountID"].ToString();
                mod.AccountName = dr["AccountName"].ToString();
                mod.DebitCredit = dr["DebitCredit"].ToString();
                mod.SumMoney = Decimal.Parse(dr["SumMoney"].ToString());
                mod.Summary = dr["Summary"].ToString();
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MSummonsAccount SetModel(DataRow dr)
        {
            Models.MSummonsAccount mod = new Models.MSummonsAccount();
            mod.SummonsID = dr["SummonsID"].ToString();
            mod.AccountID = dr["AccountID"].ToString();
            mod.AccountName = dr["AccountName"].ToString();
            mod.DebitCredit = dr["DebitCredit"].ToString();
            mod.SumMoney = Decimal.Parse(dr["SumMoney"].ToString());
            mod.Summary = dr["Summary"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MSummonsAccount> GetList(DataSet ds)
        {
            List<Models.MSummonsAccount> li = new List<Models.MSummonsAccount>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以SummonsID取得SummonsAccount資料
        /// </summary>
        public List<Models.MSummonsAccount> GetListBySummonsID(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountGetBySummonsID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool DelBySummonsID(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountDelBySummonsID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 以SummonsID取得計算貸-借方資料
        /// </summary>
        public DataSet GetSubBySummonsID(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountGetSubBySummonsID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 以SummonsID取得SummonsAccount資料
        /// </summary>
        public DataSet GetListBySummonsID2(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountGetBySummonsID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 修改會計科目
        /// <summary>
        public bool Edit2(Models.MSummonsAccount mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountEdit2");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = mod.SummonsID;
            cmd.Parameters.Add("@AccountID", SqlDbType.NChar).Value = mod.AccountID;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = mod.AccountName;
            cmd.Parameters.Add("@DebitCredit", SqlDbType.NVarChar).Value = mod.DebitCredit;
            cmd.Parameters.Add("@SumMoney", SqlDbType.Decimal).Value = mod.SumMoney;
            cmd.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = mod.Summary;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }
        #endregion
    }
}
