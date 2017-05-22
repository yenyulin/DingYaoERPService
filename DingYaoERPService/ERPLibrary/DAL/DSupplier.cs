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
    /// 資料存取層 Supplier
    /// </summary>
    public class DSupplier
    {
        public DSupplier() { }

        #region 基本方法

        ///// <summary>
        ///// 新增資料
        ///// </summary>
        //public string Add(Models.MSupplier mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_SupplierAdd");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
        //    cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
        //    cmd.Parameters.Add("@SupplierShort", SqlDbType.NVarChar).Value = mod.SupplierShort;
        //    cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = mod.SupplierName;
        //    cmd.Parameters.Add("@SupplierKeyboard", SqlDbType.NVarChar).Value = mod.SupplierKeyboard;
        //    cmd.Parameters.Add("@PaymentTerms", SqlDbType.NVarChar).Value = mod.PaymentTerms;
        //    cmd.Parameters.Add("@IncomeMethod", SqlDbType.NVarChar).Value = mod.IncomeMethod;
        //    cmd.Parameters.Add("@GiftDate", SqlDbType.Int).Value = mod.GiftDate;
        //    cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = mod.Contact;
        //    cmd.Parameters.Add("@Owner", SqlDbType.NVarChar).Value = mod.Owner;
        //    cmd.Parameters.Add("@Introducer", SqlDbType.NVarChar).Value = mod.Introducer;
        //    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
        //    cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = mod.IsComplete;
        //    cmd.Parameters.Add("@Unifyno", SqlDbType.NVarChar).Value = mod.Unifyno;
        //    cmd.Parameters.Add("@UnifynoTitle", SqlDbType.NVarChar).Value = mod.UnifynoTitle;
        //    cmd.Parameters.Add("@UniformInvoice", SqlDbType.Bit).Value = mod.UniformInvoice;
        //    cmd.Parameters.Add("@InvoiceCompany", SqlDbType.Bit).Value = mod.InvoiceCompany;
        //    cmd.Parameters.Add("@InvoicePersonal", SqlDbType.Bit).Value = mod.InvoicePersonal;
        //    cmd.Parameters.Add("@InvoiceCompanyFrom", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyFrom);
        //    cmd.Parameters.Add("@InvoiceCompanyTo", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyTo);
        //    cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
        //    cmd.Parameters.Add("@MaxPaymentNo", SqlDbType.NVarChar).Value = mod.MaxPaymentNo;
        //    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
        //    cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
        //    return SQLUtil.ExecuteSql(cmd) > 0 ? mod.SupplierID : null;
        //}

        ///// <summary>
        ///// 修改資料
        ///// <summary>
        //public bool Edit(Models.MSupplier mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_SupplierEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
        //    cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
        //    cmd.Parameters.Add("@SupplierShort", SqlDbType.NVarChar).Value = mod.SupplierShort;
        //    cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = mod.SupplierName;
        //    cmd.Parameters.Add("@SupplierKeyboard", SqlDbType.NVarChar).Value = mod.SupplierKeyboard;
        //    cmd.Parameters.Add("@PaymentTerms", SqlDbType.NVarChar).Value = mod.PaymentTerms;
        //    cmd.Parameters.Add("@IncomeMethod", SqlDbType.NVarChar).Value = mod.IncomeMethod;
        //    cmd.Parameters.Add("@GiftDate", SqlDbType.Int).Value = mod.GiftDate;
        //    cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = mod.Contact;
        //    cmd.Parameters.Add("@Owner", SqlDbType.NVarChar).Value = mod.Owner;
        //    cmd.Parameters.Add("@Introducer", SqlDbType.NVarChar).Value = mod.Introducer;
        //    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
        //    cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = mod.IsComplete;
        //    cmd.Parameters.Add("@Unifyno", SqlDbType.NVarChar).Value = mod.Unifyno;
        //    cmd.Parameters.Add("@UnifynoTitle", SqlDbType.NVarChar).Value = mod.UnifynoTitle;
        //    cmd.Parameters.Add("@UniformInvoice", SqlDbType.Bit).Value = mod.UniformInvoice;
        //    cmd.Parameters.Add("@InvoiceCompany", SqlDbType.Bit).Value = mod.InvoiceCompany;
        //    cmd.Parameters.Add("@InvoicePersonal", SqlDbType.Bit).Value = mod.InvoicePersonal;
        //    cmd.Parameters.Add("@InvoiceCompanyFrom", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyFrom);
        //    cmd.Parameters.Add("@InvoiceCompanyTo", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyTo);
        //    cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
        //    cmd.Parameters.Add("@MaxPaymentNo", SqlDbType.NVarChar).Value = mod.MaxPaymentNo;
        //    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
        //    cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 刪除資料
        ///// <summary>
        //public bool Del(string strSupplierID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_SupplierDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MSupplier GetModel(string strSupplierID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_SupplierGetByPK");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MSupplier mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MSupplier> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MSupplier SetModel(SqlDataReader dr)
        {
            Models.MSupplier mod = new Models.MSupplier();
            while (dr.Read())
            {
                mod.SupplierID = dr["SupplierID"].ToString();
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.SupplierShort = dr["SupplierShort"].ToString();
                mod.SupplierName = dr["SupplierName"].ToString();
                mod.SupplierKeyboard = dr["SupplierKeyboard"].ToString();
                mod.PaymentTerms = dr["PaymentTerms"].ToString();
                mod.IncomeMethod = dr["IncomeMethod"].ToString();
                mod.GiftDate = int.Parse(dr["GiftDate"].ToString());
                mod.Contact = dr["Contact"].ToString();
                mod.Owner = dr["Owner"].ToString();
                mod.Introducer = dr["Introducer"].ToString();
                mod.Email = dr["Email"].ToString();
                mod.IsComplete = bool.Parse(dr["IsComplete"].ToString());
                mod.Unifyno = dr["Unifyno"].ToString();
                mod.UnifynoTitle = dr["UnifynoTitle"].ToString();
                mod.UniformInvoice = bool.Parse(dr["UniformInvoice"].ToString());
                mod.InvoiceCompany = bool.Parse(dr["InvoiceCompany"].ToString());
                mod.InvoicePersonal = bool.Parse(dr["InvoicePersonal"].ToString());
                mod.InvoiceCompanyFrom = SQLUtil.GetInt(dr["InvoiceCompanyFrom"]);
                mod.InvoiceCompanyTo = SQLUtil.GetInt(dr["InvoiceCompanyTo"]);
                mod.Debt = Decimal.Parse(dr["Debt"].ToString());
                mod.MaxPaymentNo = dr["MaxPaymentNo"].ToString();
                mod.Remarks = dr["Remarks"].ToString();
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
        private Models.MSupplier SetModel(DataRow dr)
        {
            Models.MSupplier mod = new Models.MSupplier();
            mod.SupplierID = dr["SupplierID"].ToString();
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.SupplierShort = dr["SupplierShort"].ToString();
            mod.SupplierName = dr["SupplierName"].ToString();
            mod.SupplierKeyboard = dr["SupplierKeyboard"].ToString();
            mod.PaymentTerms = dr["PaymentTerms"].ToString();
            mod.IncomeMethod = dr["IncomeMethod"].ToString();
            mod.GiftDate = int.Parse(dr["GiftDate"].ToString());
            mod.Contact = dr["Contact"].ToString();
            mod.Owner = dr["Owner"].ToString();
            mod.Introducer = dr["Introducer"].ToString();
            mod.Email = dr["Email"].ToString();
            mod.IsComplete = bool.Parse(dr["IsComplete"].ToString());
            mod.Unifyno = dr["Unifyno"].ToString();
            mod.UnifynoTitle = dr["UnifynoTitle"].ToString();
            mod.UniformInvoice = bool.Parse(dr["UniformInvoice"].ToString());
            mod.InvoiceCompany = bool.Parse(dr["InvoiceCompany"].ToString());
            mod.InvoicePersonal = bool.Parse(dr["InvoicePersonal"].ToString());
            mod.InvoiceCompanyFrom = SQLUtil.GetInt(dr["InvoiceCompanyFrom"]);
            mod.InvoiceCompanyTo = SQLUtil.GetInt(dr["InvoiceCompanyTo"]);
            mod.Debt = Decimal.Parse(dr["Debt"].ToString());
            mod.MaxPaymentNo = dr["MaxPaymentNo"].ToString();
            mod.Remarks = dr["Remarks"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MSupplier> GetList(DataSet ds)
        {
            List<Models.MSupplier> li = new List<Models.MSupplier>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion


        #region  自訂方法

        /// <summary>
        /// 由SupplierID計算Supplier筆數
        /// </summary>
        public int CountBySupplierID(string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierCountBySupplierID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }


        /// <summary>
        /// 以關鍵字取得所有資料
        /// </summary>
        public List<Models.MSupplier> GetListByKeyword(string strKeyword)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetByKeyword");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + strKeyword + "%";
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 以產品群組序號取得所有資料
        /// </summary>
        public List<Models.MSupplier> GetByGroup1ID(int intGroup1ID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetBGetByGroup1ID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Group1ID", SqlDbType.Int).Value = intGroup1ID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }


        /// <summary>
        /// 修改資料Supplier
        /// <summary>
        public bool SupplierIDEdit(string strOldSupplierID, string strNewSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierEditSupplierID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strOldSupplierID;
            cmd.Parameters.Add("@NewSupplierID", SqlDbType.NVarChar).Value = strNewSupplierID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 由ComparativePricesID取得資料
        /// </summary>
        public List<Models.MSupplier> GetByComparativePricesID(string strComparativePricesID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetByComparativePricesID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComparativePricesID", SqlDbType.NVarChar).Value = strComparativePricesID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 由ComparativePricesID取得資料(有比價交易數量，轉採購單用)
        /// </summary>
        public List<Models.MSupplier> GetByComparativePricesID2(string strComparativePricesID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetByComparativePricesID2");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComparativePricesID", SqlDbType.NVarChar).Value = strComparativePricesID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }


        /// <summary>
        /// 取得最後一筆資料
        /// <summary>
        public string GetMaxString()
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetMax");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MSupplier mod = SetModel(dr);
            dr.Close();
            if (isHasRows)
            {
                return mod.SupplierID;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public DataSet GetByDebt(string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetByDebt");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MSupplier GetFirstModelByType(int intSupplierTypeID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetFirstModelByType");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierTypeID", SqlDbType.Int).Value = intSupplierTypeID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MSupplier mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public DataSet GetSupplierGetDebt(string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetByDebt");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MSupplier GetModelByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetByCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MSupplier mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 以SupplierID取得最後交易日及欠籃數
        /// </summary>
        public DataSet GetLastPOrderDateAndLessBasketBySupplierID(string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetLastPOrderDateAndLessBasketBySupplierID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }
        #endregion
    }
}
