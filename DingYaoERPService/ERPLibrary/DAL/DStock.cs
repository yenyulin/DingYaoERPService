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
    /// 資料存取層 Stock
    /// </summary>
    public class DStock
    {
        public DStock() { }

        #region 基本方法

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strProductCode)
        {
            SqlCommand cmd = new SqlCommand("STP_StockDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MStock GetModel(string strProductCode, int intFactoryID, string strStockType, DateTime dtStockDate, DateTime dtExpirationDate)
        {
            SqlCommand cmd = new SqlCommand("STP_StockGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = intFactoryID;
            cmd.Parameters.Add("@StockType", SqlDbType.NVarChar).Value = strStockType;
            cmd.Parameters.Add("@StockDate", SqlDbType.DateTime).Value = dtStockDate;
            cmd.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = dtExpirationDate;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MStock mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MStock> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_StockGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MStock SetModel(SqlDataReader dr)
        {
            Models.MStock mod = new Models.MStock();
            while (dr.Read())
            {
                mod.ProductCode = dr["ProductCode"].ToString();
                mod.FactoryID = int.Parse(dr["FactoryID"].ToString());
                mod.StockType = dr["StockType"].ToString();
                mod.StockDate = DateTime.Parse(dr["StockDate"].ToString());
                mod.ExpirationDate = DateTime.Parse(dr["ExpirationDate"].ToString());
                mod.StockQty = Decimal.Parse(dr["StockQty"].ToString());
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
        private Models.MStock SetModel(DataRow dr)
        {
            Models.MStock mod = new Models.MStock();
            mod.ProductCode = dr["ProductCode"].ToString();
            mod.FactoryID = int.Parse(dr["FactoryID"].ToString());
            mod.StockType = dr["StockType"].ToString();
            mod.StockDate = DateTime.Parse(dr["StockDate"].ToString());
            mod.ExpirationDate = DateTime.Parse(dr["ExpirationDate"].ToString());
            mod.StockQty = Decimal.Parse(dr["StockQty"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MStock> GetList(DataSet ds)
        {
            List<Models.MStock> li = new List<Models.MStock>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法


        /// <summary>
        /// 依ProductCode、FactoryID及StockType取得StockQty的總庫存量 (會回傳null代表沒有庫存過)
        /// </summary>
        public decimal? GetTotalStockQtyWhenNoIsNull(string strProductCode, int intFactoryID, string strStockType)
        {
            SqlCommand cmd = new SqlCommand("STP_StockQtyGetByProductCodeFactoryIDStockTypeWhenNoIsNull");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = strProductCode;
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = intFactoryID;
            cmd.Parameters.Add("@StockType", SqlDbType.NVarChar).Value = strStockType;
            //return Convert.ToDecimal(SQLUtil.ExecuteScalar(cmd));
            return SQLUtil.GetDecimal(SQLUtil.ExecuteScalar(cmd));
        }

        #endregion
    }
}
