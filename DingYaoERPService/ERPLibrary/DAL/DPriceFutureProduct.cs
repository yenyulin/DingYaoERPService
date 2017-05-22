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
    /// 資料存取層 PriceFutureProduct
    /// </summary>
    public class DPriceFutureProduct
    {
        public DPriceFutureProduct() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPriceFutureProduct mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureProductAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = mod.PriceFutureID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = mod.ProductCode;
            cmd.Parameters.Add("@PriceQty", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.PriceQty);
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.Price);
            cmd.Parameters.Add("@CheckType", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.CheckType);
            cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.MinValue);
            cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.MaxValue);
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.PriceFutureProductID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPriceFutureProduct mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureProductEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureProductID", SqlDbType.Int).Value = mod.PriceFutureProductID;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = mod.PriceFutureID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = mod.ProductCode;
            cmd.Parameters.Add("@PriceQty", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.PriceQty);
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.Price);
            cmd.Parameters.Add("@CheckType", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.CheckType);
            cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.MinValue);
            cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.MaxValue);
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPriceFutureProductID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureProductDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureProductID", SqlDbType.Int).Value = intPriceFutureProductID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPriceFutureProduct GetModel(int intPriceFutureProductID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureProductGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureProductID", SqlDbType.Int).Value = intPriceFutureProductID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPriceFutureProduct mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MPriceFutureProduct> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_PriceFutureProductGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MPriceFutureProduct SetModel(SqlDataReader dr)
        {
            Models.MPriceFutureProduct mod = new Models.MPriceFutureProduct();
            while (dr.Read())
            {
                mod.PriceFutureProductID = int.Parse(dr["PriceFutureProductID"].ToString());
                mod.PriceFutureID = int.Parse(dr["PriceFutureID"].ToString());
                mod.ProductCode = dr["ProductCode"].ToString();
                mod.PriceQty = SQLUtil.GetDecimal(dr["PriceQty"]);
                mod.Price = SQLUtil.GetDecimal(dr["Price"]);
                mod.CheckType = SQLUtil.GetString(dr["CheckType"]);
                mod.MinValue = SQLUtil.GetDecimal(dr["MinValue"]);
                mod.MaxValue = SQLUtil.GetDecimal(dr["MaxValue"]);
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
                mod.UpdateUser = dr["UpdateUser"].ToString();
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MPriceFutureProduct SetModel(DataRow dr)
        {
            Models.MPriceFutureProduct mod = new Models.MPriceFutureProduct();
            mod.PriceFutureProductID = int.Parse(dr["PriceFutureProductID"].ToString());
            mod.PriceFutureID = int.Parse(dr["PriceFutureID"].ToString());
            mod.ProductCode = dr["ProductCode"].ToString();
            mod.PriceQty = SQLUtil.GetDecimal(dr["PriceQty"]);
            mod.Price = SQLUtil.GetDecimal(dr["Price"]);
            mod.CheckType = SQLUtil.GetString(dr["CheckType"]);
            mod.MinValue = SQLUtil.GetDecimal(dr["MinValue"]);
            mod.MaxValue = SQLUtil.GetDecimal(dr["MaxValue"]);
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPriceFutureProduct> GetList(DataSet ds)
        {
            List<Models.MPriceFutureProduct> li = new List<Models.MPriceFutureProduct>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以intPriceFutureID取得所有資料
        /// </summary>
        public List<Models.MPriceFutureProduct> GetListByPriceFutureID(int intPriceFutureID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureProductGetByPriceFutureID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = intPriceFutureID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 計算是否資料重複
        /// </summary>
        public int CountByProductCodePriceFutureIDPriceQty(string strProductCode, int intPriceFutureID, decimal decPriceQty)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureProductCountByProductCodePriceFutureIDPriceQty");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = intPriceFutureID;
            cmd.Parameters.Add("@PriceQty", SqlDbType.Decimal).Value = decPriceQty;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

        #endregion
    }
}
