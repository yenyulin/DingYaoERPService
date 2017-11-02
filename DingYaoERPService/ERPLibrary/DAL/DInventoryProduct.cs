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
    /// 資料存取層 InventoryProduct
    /// </summary>
    public class DInventoryProduct
    {
        public DInventoryProduct() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MInventoryProduct mod)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryProductAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = mod.InventoryID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = mod.ProductCode;
            cmd.Parameters.Add("@CheckQty1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.CheckQty1);
            cmd.Parameters.Add("@CheckQty2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.CheckQty2);
            cmd.Parameters.Add("@StockQtySys1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtySys1);
            cmd.Parameters.Add("@StockQtySys2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtySys2);
            cmd.Parameters.Add("@StockQtyERP1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyERP1);
            cmd.Parameters.Add("@StockQtyERP2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyERP2);
            cmd.Parameters.Add("@StockQtyMonth1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyMonth1);
            cmd.Parameters.Add("@StockQtyMonth2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyMonth2);
            cmd.Parameters.Add("@StockDate1", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.StockDate1);
            cmd.Parameters.Add("@ExpirationDate1", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExpirationDate1);
            cmd.Parameters.Add("@StockDate2", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.StockDate2);
            cmd.Parameters.Add("@ExpirationDate2", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExpirationDate2);
            return SQLUtil.ExecuteSql(cmd);
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MInventoryProduct mod)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryProductEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = mod.InventoryID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = mod.ProductCode;
            cmd.Parameters.Add("@CheckQty1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.CheckQty1);
            cmd.Parameters.Add("@CheckQty2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.CheckQty2);
            cmd.Parameters.Add("@StockQtySys1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtySys1);
            cmd.Parameters.Add("@StockQtySys2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtySys2);
            cmd.Parameters.Add("@StockQtyERP1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyERP1);
            cmd.Parameters.Add("@StockQtyERP2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyERP2);
            cmd.Parameters.Add("@StockQtyMonth1", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyMonth1);
            cmd.Parameters.Add("@StockQtyMonth2", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.StockQtyMonth2);
            cmd.Parameters.Add("@StockDate1", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.StockDate1);
            cmd.Parameters.Add("@ExpirationDate1", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExpirationDate1);
            cmd.Parameters.Add("@StockDate2", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.StockDate2);
            cmd.Parameters.Add("@ExpirationDate2", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExpirationDate2);
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 依InventoryID刪除資料
        /// <summary>
        public bool Del(int intInventoryID)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryProductDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MInventoryProduct GetModel(int intInventoryID, string strProductCode)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryProductGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MInventoryProduct mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MInventoryProduct SetModel(SqlDataReader dr)
        {
            Models.MInventoryProduct mod = new Models.MInventoryProduct();
            while (dr.Read())
            {
                mod.InventoryID = int.Parse(dr["InventoryID"].ToString());
                mod.ProductCode = dr["ProductCode"].ToString();
                mod.CheckQty1 = SQLUtil.GetDecimal(dr["CheckQty1"]);
                mod.CheckQty2 = SQLUtil.GetDecimal(dr["CheckQty2"]);
                mod.StockQtySys1 = SQLUtil.GetDecimal(dr["StockQtySys1"]);
                mod.StockQtySys2 = SQLUtil.GetDecimal(dr["StockQtySys2"]);
                mod.StockQtyERP1 = SQLUtil.GetDecimal(dr["StockQtyERP1"]);
                mod.StockQtyERP2 = SQLUtil.GetDecimal(dr["StockQtyERP2"]);
                mod.StockQtyMonth1 = SQLUtil.GetDecimal(dr["StockQtyMonth1"]);
                mod.StockQtyMonth2 = SQLUtil.GetDecimal(dr["StockQtyMonth2"]);
                mod.StockDate1 = SQLUtil.GetDateTime(dr["StockDate1"]);
                mod.ExpirationDate1 = SQLUtil.GetDateTime(dr["ExpirationDate1"]);
                mod.StockDate2 = SQLUtil.GetDateTime(dr["StockDate2"]);
                mod.ExpirationDate2 = SQLUtil.GetDateTime(dr["ExpirationDate2"]);
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MInventoryProduct SetModel(DataRow dr)
        {
            Models.MInventoryProduct mod = new Models.MInventoryProduct();
            mod.InventoryID = int.Parse(dr["InventoryID"].ToString());
            mod.ProductCode = dr["ProductCode"].ToString();
            mod.CheckQty1 = SQLUtil.GetDecimal(dr["CheckQty1"]);
            mod.CheckQty2 = SQLUtil.GetDecimal(dr["CheckQty2"]);
            mod.StockQtySys1 = SQLUtil.GetDecimal(dr["StockQtySys1"]);
            mod.StockQtySys2 = SQLUtil.GetDecimal(dr["StockQtySys2"]);
            mod.StockQtyERP1 = SQLUtil.GetDecimal(dr["StockQtyERP1"]);
            mod.StockQtyERP2 = SQLUtil.GetDecimal(dr["StockQtyERP2"]);
            mod.StockQtyMonth1 = SQLUtil.GetDecimal(dr["StockQtyMonth1"]);
            mod.StockQtyMonth2 = SQLUtil.GetDecimal(dr["StockQtyMonth2"]);
            mod.StockDate1 = SQLUtil.GetDateTime(dr["StockDate1"]);
            mod.ExpirationDate1 = SQLUtil.GetDateTime(dr["ExpirationDate1"]);
            mod.StockDate2 = SQLUtil.GetDateTime(dr["StockDate2"]);
            mod.ExpirationDate2 = SQLUtil.GetDateTime(dr["ExpirationDate2"]);
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MInventoryProduct> GetList(DataSet ds)
        {
            List<Models.MInventoryProduct> li = new List<Models.MInventoryProduct>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 依InventoryID及ProductCode刪除資料
        /// <summary>
        public bool DelByInventoryIDProductCode(int intInventoryID, string strProductCode)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryProductDelByInventoryIDProductCode");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 依FactoryID取得盤點產品選項
        /// </summary>
        public DataTable GetInventoryProduct(int intFactoryID) 
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryProductGetByFactoryID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = intFactoryID;
            return SQLUtil.QueryDS(cmd).Tables[0];
        }

        /// <summary>
        /// 依InventoryID取得VWInventoryProductStock資料 
        /// </summary>
        public DataSet GetAvgStockInPriceByInventoryID(int intInventoryID)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryGetAvgStockInPriceByInventoryID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }
        #endregion
    }
}
