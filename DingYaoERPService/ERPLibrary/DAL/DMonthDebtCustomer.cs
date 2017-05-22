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
    /// 資料存取層 MonthDebtCustomer
    /// </summary>
    public class DMonthDebtCustomer
    {
        public DMonthDebtCustomer() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MMonthDebtCustomer mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthDebtCustomerAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.MonthDebtCustomerID = intID;
            }
            return intID;
        }

        ///// <summary>
        ///// 修改資料
        ///// <summary>
        //public bool Edit(Models.MMonthDebtCustomer mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtCustomerEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthDebtCustomerID", SqlDbType.Int).Value = mod.MonthDebtCustomerID;
        //    cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
        //    cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
        //    cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 刪除資料
        ///// <summary>
        //public bool Del(int intMonthDebtCustomerID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtCustomerDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthDebtCustomerID", SqlDbType.Int).Value = intMonthDebtCustomerID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MMonthDebtCustomer GetModel(int intMonthDebtCustomerID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtCustomerGetByPK");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthDebtCustomerID", SqlDbType.Int).Value = intMonthDebtCustomerID;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MMonthDebtCustomer mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MMonthDebtCustomer> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtCustomerGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MMonthDebtCustomer SetModel(SqlDataReader dr)
        {
            Models.MMonthDebtCustomer mod = new Models.MMonthDebtCustomer();
            while (dr.Read())
            {
                mod.MonthDebtCustomerID = int.Parse(dr["MonthDebtCustomerID"].ToString());
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.Debt = Decimal.Parse(dr["Debt"].ToString());
                mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MMonthDebtCustomer SetModel(DataRow dr)
        {
            Models.MMonthDebtCustomer mod = new Models.MMonthDebtCustomer();
            mod.MonthDebtCustomerID = int.Parse(dr["MonthDebtCustomerID"].ToString());
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.Debt = Decimal.Parse(dr["Debt"].ToString());
            mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MMonthDebtCustomer> GetList(DataSet ds)
        {
            List<Models.MMonthDebtCustomer> li = new List<Models.MMonthDebtCustomer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法



        #endregion
    }
}
