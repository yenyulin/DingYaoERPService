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
    /// 資料存取層 MonthBasketSupplier
    /// </summary>
    public class DMonthBasketSupplier
    {
        public DMonthBasketSupplier() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MMonthBasketSupplier mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthBasketSupplierAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
            cmd.Parameters.Add("@BasketQty", SqlDbType.Int).Value = mod.BasketQty;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.MonthBasketSupplierID = intID;
            }
            return intID;
        }

        ///// <summary>
        ///// 修改資料
        ///// <summary>
        //public bool Edit(Models.MMonthBasketSupplier mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketSupplierEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthBasketSupplierID", SqlDbType.Int).Value = mod.MonthBasketSupplierID;
        //    cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
        //    cmd.Parameters.Add("@BasketQty", SqlDbType.Int).Value = mod.BasketQty;
        //    cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 刪除資料
        ///// <summary>
        //public bool Del(int intMonthBasketSupplierID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketSupplierDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthBasketSupplierID", SqlDbType.Int).Value = intMonthBasketSupplierID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MMonthBasketSupplier GetModel(int intMonthBasketSupplierID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketSupplierGetByPK");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthBasketSupplierID", SqlDbType.Int).Value = intMonthBasketSupplierID;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MMonthBasketSupplier mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MMonthBasketSupplier> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthBasketSupplierGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MMonthBasketSupplier SetModel(SqlDataReader dr)
        {
            Models.MMonthBasketSupplier mod = new Models.MMonthBasketSupplier();
            while (dr.Read())
            {
                mod.MonthBasketSupplierID = int.Parse(dr["MonthBasketSupplierID"].ToString());
                mod.SupplierID = dr["SupplierID"].ToString();
                mod.BasketQty = int.Parse(dr["BasketQty"].ToString());
                mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MMonthBasketSupplier SetModel(DataRow dr)
        {
            Models.MMonthBasketSupplier mod = new Models.MMonthBasketSupplier();
            mod.MonthBasketSupplierID = int.Parse(dr["MonthBasketSupplierID"].ToString());
            mod.SupplierID = dr["SupplierID"].ToString();
            mod.BasketQty = int.Parse(dr["BasketQty"].ToString());
            mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MMonthBasketSupplier> GetList(DataSet ds)
        {
            List<Models.MMonthBasketSupplier> li = new List<Models.MMonthBasketSupplier>();
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
        public Models.MMonthBasketSupplier GetModel(string strSupplierID, DateTime dtRecordDate)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthBasketSupplierGetBySupplierIDAndRecordDate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = dtRecordDate;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MMonthBasketSupplier mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        #endregion
    }
}
