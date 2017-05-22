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
    /// 資料存取層 DeliveryManPerformanceMonth
    /// </summary>
    public class DDeliveryManPerformanceMonth
    {
        public DDeliveryManPerformanceMonth() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MDeliveryManPerformanceMonth mod)
        {
            SqlCommand cmd = new SqlCommand("STP_DeliveryManPerformanceMonthAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = mod.UserID;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = mod.Year;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = mod.Month;
            cmd.Parameters.Add("@TotalSumMoney", SqlDbType.Decimal).Value = mod.TotalSumMoney;
            cmd.Parameters.Add("@TotalSumMoneyRank", SqlDbType.Int).Value = mod.TotalSumMoneyRank;
            cmd.Parameters.Add("@OrderTotalWeight", SqlDbType.Decimal).Value = mod.OrderTotalWeight;
            cmd.Parameters.Add("@OrderTotalWeightRank", SqlDbType.Int).Value = mod.OrderTotalWeightRank;
            cmd.Parameters.Add("@OrderTotalCount", SqlDbType.Decimal).Value = mod.OrderTotalCount;
            cmd.Parameters.Add("@OrderTotalCountRank", SqlDbType.Int).Value = mod.OrderTotalCountRank;
            cmd.Parameters.Add("@SubMile", SqlDbType.Decimal).Value = mod.SubMile;
            cmd.Parameters.Add("@SubMileRank", SqlDbType.Int).Value = mod.SubMileRank;
            cmd.Parameters.Add("@SubOil", SqlDbType.Decimal).Value = mod.SubOil;
            cmd.Parameters.Add("@SubOilRank", SqlDbType.Int).Value = mod.SubOilRank;
            cmd.Parameters.Add("@OilMil", SqlDbType.Decimal).Value = mod.OilMil;
            cmd.Parameters.Add("@OilMilRank", SqlDbType.Int).Value = mod.OilMilRank;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.DeliveryManPerformanceMonthID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        //public bool Edit(Models.MDeliveryManPerformanceMonth mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_DeliveryManPerformanceMonthEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@DeliveryManPerformanceMonthID", SqlDbType.Int).Value = mod.DeliveryManPerformanceMonthID;
        //    cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = mod.UserID;
        //    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = mod.Year;
        //    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = mod.Month;
        //    cmd.Parameters.Add("@TotalSumMoney", SqlDbType.Decimal).Value = mod.TotalSumMoney;
        //    cmd.Parameters.Add("@TotalSumMoneyRank", SqlDbType.Int).Value = mod.TotalSumMoneyRank;
        //    cmd.Parameters.Add("@OrderTotalWeight", SqlDbType.Decimal).Value = mod.OrderTotalWeight;
        //    cmd.Parameters.Add("@OrderTotalWeightRank", SqlDbType.Int).Value = mod.OrderTotalWeightRank;
        //    cmd.Parameters.Add("@OrderTotalCount", SqlDbType.Decimal).Value = mod.OrderTotalCount;
        //    cmd.Parameters.Add("@OrderTotalCountRank", SqlDbType.Int).Value = mod.OrderTotalCountRank;
        //    cmd.Parameters.Add("@SubMile", SqlDbType.Decimal).Value = mod.SubMile;
        //    cmd.Parameters.Add("@SubMileRank", SqlDbType.Int).Value = mod.SubMileRank;
        //    cmd.Parameters.Add("@SubOil", SqlDbType.Decimal).Value = mod.SubOil;
        //    cmd.Parameters.Add("@SubOilRank", SqlDbType.Int).Value = mod.SubOilRank;
        //    cmd.Parameters.Add("@OilMil", SqlDbType.Decimal).Value = mod.OilMil;
        //    cmd.Parameters.Add("@OilMilRank", SqlDbType.Int).Value = mod.OilMilRank;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        /// <summary>
        /// 刪除資料
        /// <summary>
        //public bool Del(int intDeliveryManPerformanceMonthID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_DeliveryManPerformanceMonthDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@DeliveryManPerformanceMonthID", SqlDbType.Int).Value = intDeliveryManPerformanceMonthID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MDeliveryManPerformanceMonth GetModel(int intDeliveryManPerformanceMonthID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_DeliveryManPerformanceMonthGetByPK");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@DeliveryManPerformanceMonthID", SqlDbType.Int).Value = intDeliveryManPerformanceMonthID;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MDeliveryManPerformanceMonth mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MDeliveryManPerformanceMonth> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_DeliveryManPerformanceMonthGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MDeliveryManPerformanceMonth SetModel(SqlDataReader dr)
        {
            Models.MDeliveryManPerformanceMonth mod = new Models.MDeliveryManPerformanceMonth();
            while (dr.Read())
            {
                mod.DeliveryManPerformanceMonthID = int.Parse(dr["DeliveryManPerformanceMonthID"].ToString());
                mod.UserID = dr["UserID"].ToString();
                mod.Year = int.Parse(dr["Year"].ToString());
                mod.Month = int.Parse(dr["Month"].ToString());
                mod.TotalSumMoney = Decimal.Parse(dr["TotalSumMoney"].ToString());
                mod.TotalSumMoneyRank = int.Parse(dr["TotalSumMoneyRank"].ToString());
                mod.OrderTotalWeight = Decimal.Parse(dr["OrderTotalWeight"].ToString());
                mod.OrderTotalWeightRank = int.Parse(dr["OrderTotalWeightRank"].ToString());
                mod.OrderTotalCount = Decimal.Parse(dr["OrderTotalCount"].ToString());
                mod.OrderTotalCountRank = int.Parse(dr["OrderTotalCountRank"].ToString());
                mod.SubMile = Decimal.Parse(dr["SubMile"].ToString());
                mod.SubMileRank = int.Parse(dr["SubMileRank"].ToString());
                mod.SubOil = Decimal.Parse(dr["SubOil"].ToString());
                mod.SubOilRank = int.Parse(dr["SubOilRank"].ToString());
                mod.OilMil = Decimal.Parse(dr["OilMil"].ToString());
                mod.OilMilRank = int.Parse(dr["OilMilRank"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MDeliveryManPerformanceMonth SetModel(DataRow dr)
        {
            Models.MDeliveryManPerformanceMonth mod = new Models.MDeliveryManPerformanceMonth();
            mod.DeliveryManPerformanceMonthID = int.Parse(dr["DeliveryManPerformanceMonthID"].ToString());
            mod.UserID = dr["UserID"].ToString();
            mod.Year = int.Parse(dr["Year"].ToString());
            mod.Month = int.Parse(dr["Month"].ToString());
            mod.TotalSumMoney = Decimal.Parse(dr["TotalSumMoney"].ToString());
            mod.TotalSumMoneyRank = int.Parse(dr["TotalSumMoneyRank"].ToString());
            mod.OrderTotalWeight = Decimal.Parse(dr["OrderTotalWeight"].ToString());
            mod.OrderTotalWeightRank = int.Parse(dr["OrderTotalWeightRank"].ToString());
            mod.OrderTotalCount = Decimal.Parse(dr["OrderTotalCount"].ToString());
            mod.OrderTotalCountRank = int.Parse(dr["OrderTotalCountRank"].ToString());
            mod.SubMile = Decimal.Parse(dr["SubMile"].ToString());
            mod.SubMileRank = int.Parse(dr["SubMileRank"].ToString());
            mod.SubOil = Decimal.Parse(dr["SubOil"].ToString());
            mod.SubOilRank = int.Parse(dr["SubOilRank"].ToString());
            mod.OilMil = Decimal.Parse(dr["OilMil"].ToString());
            mod.OilMilRank = int.Parse(dr["OilMilRank"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MDeliveryManPerformanceMonth> GetList(DataSet ds)
        {
            List<Models.MDeliveryManPerformanceMonth> li = new List<Models.MDeliveryManPerformanceMonth>();
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
