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
    /// 資料存取層 BasketCustomer
    /// </summary>
    public class DBasketCustomer
    {
        public DBasketCustomer() { }

        #region 基本方法

        /// <summary>
        /// 新增資料(僅匯入)
        /// </summary>
        public string Add(Models.MBasketCustomer mod)
        {
            SqlCommand cmd = new SqlCommand("STP_BasketCustomerAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@BasketQty", SqlDbType.Int).Value = mod.BasketQty;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            return SQLUtil.ExecuteSql(cmd) > 0 ? mod.CustomerID : null;
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private MBasketCustomer SetModel(SqlDataReader dr)
        {
            MBasketCustomer mod = new MBasketCustomer();
            while (dr.Read())
            {
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.BasketQty = int.Parse(dr["BasketQty"].ToString());
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
        private MBasketCustomer SetModel(DataRow dr)
        {
            MBasketCustomer mod = new MBasketCustomer();
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.BasketQty = int.Parse(dr["BasketQty"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MBasketCustomer> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_BasketCustomerGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<MBasketCustomer> GetList(DataSet ds)
        {
            List<MBasketCustomer> li = new List<MBasketCustomer>();
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
