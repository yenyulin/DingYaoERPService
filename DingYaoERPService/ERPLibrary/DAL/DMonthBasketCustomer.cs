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
    /// 資料存取層 MonthBasketCustomer
    /// </summary>
    public class DMonthBasketCustomer
    {
        public DMonthBasketCustomer() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MMonthBasketCustomer mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthBasketCustomerAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@BasketQty", SqlDbType.Int).Value = mod.BasketQty;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.MonthBasketCustomerID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MMonthBasketCustomer mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthBasketCustomerEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MonthBasketCustomerID", SqlDbType.Int).Value = mod.MonthBasketCustomerID;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@BasketQty", SqlDbType.Int).Value = mod.BasketQty;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        ///// <summary>
        ///// 刪除資料
        ///// <summary>
        //public bool Del(int intMonthBasketCustomerID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketCustomerDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthBasketCustomerID", SqlDbType.Int).Value = intMonthBasketCustomerID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MMonthBasketCustomer GetModel(int intMonthBasketCustomerID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketCustomerGetByPK");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthBasketCustomerID", SqlDbType.Int).Value = intMonthBasketCustomerID;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MMonthBasketCustomer mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MMonthBasketCustomer> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketCustomerGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MMonthBasketCustomer SetModel(SqlDataReader dr)
        {
            Models.MMonthBasketCustomer mod = new Models.MMonthBasketCustomer();
            while (dr.Read())
            {
                mod.MonthBasketCustomerID = int.Parse(dr["MonthBasketCustomerID"].ToString());
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.BasketQty = int.Parse(dr["BasketQty"].ToString());
                mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MMonthBasketCustomer SetModel(DataRow dr)
        {
            Models.MMonthBasketCustomer mod = new Models.MMonthBasketCustomer();
            mod.MonthBasketCustomerID = int.Parse(dr["MonthBasketCustomerID"].ToString());
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.BasketQty = int.Parse(dr["BasketQty"].ToString());
            mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MMonthBasketCustomer> GetList(DataSet ds)
        {
            List<Models.MMonthBasketCustomer> li = new List<Models.MMonthBasketCustomer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MMonthBasketCustomer GetModel(string strCustomerID, DateTime dtRecordDate)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthBasketCustomerGetByCustomerIDAndRecordDate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = dtRecordDate;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MMonthBasketCustomer mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        #endregion
    }
}
