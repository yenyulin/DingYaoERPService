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
    /// 資料存取層 VWInventoryProductStock
    /// </summary>
    public class DVWInventoryProductStock
    {
        public DVWInventoryProductStock() { }

        #region 基本方法
        
        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MVWInventoryProductStock SetModel(SqlDataReader dr)
        {
            Models.MVWInventoryProductStock mod = new Models.MVWInventoryProductStock();
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
                mod.FactoryID = int.Parse(dr["FactoryID"].ToString());
                mod.ProductName = dr["ProductName"].ToString();
                mod.Pr = dr["Pr"].ToString();
                mod.StockQty1 = SQLUtil.GetDecimal(dr["StockQty1"]);
                mod.StockQty2 = SQLUtil.GetDecimal(dr["StockQty2"]);
                mod.StockQty3 = SQLUtil.GetDecimal(dr["StockQty3"]);
                //mod.StockQty3 = Decimal.Parse(dr["StockQty3"].ToString());
                //mod.StockQty4 = Decimal.Parse(dr["StockQty4"].ToString());
                //mod.Price = Decimal.Parse(dr["Price"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MVWInventoryProductStock SetModel(DataRow dr)
        {
            Models.MVWInventoryProductStock mod = new Models.MVWInventoryProductStock();
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
            mod.FactoryID = int.Parse(dr["FactoryID"].ToString());
            mod.ProductName = dr["ProductName"].ToString();
            mod.Pr = dr["Pr"].ToString();
            mod.StockQty1 = SQLUtil.GetDecimal(dr["StockQty1"]);
            mod.StockQty2 = SQLUtil.GetDecimal(dr["StockQty2"]);
            mod.StockQty3 = SQLUtil.GetDecimal(dr["StockQty3"]);
            //mod.StockQty1 = Decimal.Parse(dr["StockQty1"].ToString());
            //mod.StockQty2 = Decimal.Parse(dr["StockQty2"].ToString());
            //mod.StockQty3 = Decimal.Parse(dr["StockQty3"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MVWInventoryProductStock> GetList(DataSet ds)
        {
            List<Models.MVWInventoryProductStock> li = new List<Models.MVWInventoryProductStock>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 依InventoryID取得VWInventoryProductStock資料 
        /// </summary>
        public List<Models.MVWInventoryProductStock> GetListByInventoryID(int intInventoryID)
        {
            SqlCommand cmd = new SqlCommand("STP_VWInventoryProductStockGetByInventoryID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        #endregion
    }
}
