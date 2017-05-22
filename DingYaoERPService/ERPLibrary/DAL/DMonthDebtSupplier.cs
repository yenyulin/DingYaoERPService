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
    /// 資料存取層 MonthDebtSupplier
    /// </summary>
    public class DMonthDebtSupplier
    {
        public DMonthDebtSupplier() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MMonthDebtSupplier mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MonthDebtSupplierAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
            cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
            cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.MonthDebtSupplierID = intID;
            }
            return intID;
        }

        ///// <summary>
        ///// 修改資料
        ///// <summary>
        //public bool Edit(Models.MMonthDebtSupplier mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtSupplierEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthDebtSupplierID", SqlDbType.Int).Value = mod.MonthDebtSupplierID;
        //    cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
        //    cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
        //    cmd.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = mod.RecordDate;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 刪除資料
        ///// <summary>
        //public bool Del(int intMonthDebtSupplierID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtSupplierDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthDebtSupplierID", SqlDbType.Int).Value = intMonthDebtSupplierID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MMonthDebtSupplier GetModel(int intMonthDebtSupplierID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtSupplierGetByPK");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@MonthDebtSupplierID", SqlDbType.Int).Value = intMonthDebtSupplierID;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MMonthDebtSupplier mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MMonthDebtSupplier> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MonthDebtSupplierGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MMonthDebtSupplier SetModel(SqlDataReader dr)
        {
            Models.MMonthDebtSupplier mod = new Models.MMonthDebtSupplier();
            while (dr.Read())
            {
                mod.MonthDebtSupplierID = int.Parse(dr["MonthDebtSupplierID"].ToString());
                mod.SupplierID = dr["SupplierID"].ToString();
                mod.Debt = Decimal.Parse(dr["Debt"].ToString());
                mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MMonthDebtSupplier SetModel(DataRow dr)
        {
            Models.MMonthDebtSupplier mod = new Models.MMonthDebtSupplier();
            mod.MonthDebtSupplierID = int.Parse(dr["MonthDebtSupplierID"].ToString());
            mod.SupplierID = dr["SupplierID"].ToString();
            mod.Debt = Decimal.Parse(dr["Debt"].ToString());
            mod.RecordDate = DateTime.Parse(dr["RecordDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MMonthDebtSupplier> GetList(DataSet ds)
        {
            List<Models.MMonthDebtSupplier> li = new List<Models.MMonthDebtSupplier>();
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
