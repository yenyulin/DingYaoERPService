using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DingYaoERP;
using DingYaoERP.Common;

namespace DingYaoERP.DAL
{
    /// <summary>
    /// 資料存取層 Price
    /// </summary>
    public class DPrice
    {
        public DPrice() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPrice mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = mod.ProductCode;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@PriceQty", SqlDbType.Decimal).Value = mod.PriceQty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = mod.Price;
            cmd.Parameters.Add("@CheckType", SqlDbType.NVarChar).Value = mod.CheckType;
            cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = mod.MinValue;
            cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = mod.MaxValue;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.PriceID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPrice mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = mod.PriceID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = mod.ProductCode;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@PriceQty", SqlDbType.Decimal).Value = mod.PriceQty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = mod.Price;
            cmd.Parameters.Add("@CheckType", SqlDbType.NVarChar).Value = mod.CheckType;
            cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = mod.MinValue;
            cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = mod.MaxValue;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPriceID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPrice GetModel(int intPriceID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPrice mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MPrice> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MPrice SetModel(SqlDataReader dr)
        {
            Models.MPrice mod = new Models.MPrice();
            while (dr.Read())
            {
                mod.PriceID = int.Parse(dr["PriceID"].ToString());
                mod.ProductCode = dr["ProductCode"].ToString();
                mod.PriceGroupID = dr["PriceGroupID"].ToString();
                mod.PriceQty = Decimal.Parse(dr["PriceQty"].ToString());
                mod.Price = Decimal.Parse(dr["Price"].ToString());
                mod.CheckType = dr["CheckType"].ToString();
                mod.MinValue = Decimal.Parse(dr["MinValue"].ToString());
                mod.MaxValue = Decimal.Parse(dr["MaxValue"].ToString());
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
        private Models.MPrice SetModel(DataRow dr)
        {
            Models.MPrice mod = new Models.MPrice();
            mod.PriceID = int.Parse(dr["PriceID"].ToString());
            mod.ProductCode = dr["ProductCode"].ToString();
            mod.PriceGroupID = dr["PriceGroupID"].ToString();
            mod.PriceQty = Decimal.Parse(dr["PriceQty"].ToString());
            mod.Price = Decimal.Parse(dr["Price"].ToString());
            mod.CheckType = dr["CheckType"].ToString();
            mod.MinValue = Decimal.Parse(dr["MinValue"].ToString());
            mod.MaxValue = Decimal.Parse(dr["MaxValue"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPrice> GetList(DataSet ds)
        {
            List<Models.MPrice> li = new List<Models.MPrice>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        ///// <summary>
        ///// 計算是否資料重複
        ///// </summary>
        //public int CountByProductCodePriceGroupIDPriceQty(string strProductCode, string strPriceGroupID, decimal decPriceQty)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_PriceCountByProductCodePriceGroupIDPriceQty");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
        //    cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
        //    cmd.Parameters.Add("@PriceQty", SqlDbType.Decimal).Value = decPriceQty;
        //    return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        //}

        ///// <summary>
        ///// 以群組序號及產品顯示所有量價對應
        ///// </summary>
        //public List<Models.MPrice> GetListByProductCodePriceGroupID(string strProductCode, string strPriceGroupID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_PriceGetByProductCodePriceGroupID");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
        //    cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 以群組序號取得list
        /// </summary>
        public List<Models.MPrice> GetListByPriceGroupID(string strPriceGroupID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGetByPriceGroupID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }
        #endregion
    }
}
