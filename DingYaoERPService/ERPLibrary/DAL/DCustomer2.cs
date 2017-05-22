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
    /// 資料存取層 Customer
    /// </summary>
    public class DCustomer
    {
        public DCustomer() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MCustomer mod)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@PCustomerID", SqlDbType.NVarChar).Value = mod.PCustomerID;
            cmd.Parameters.Add("@CustomerTypeID", SqlDbType.NVarChar).Value = mod.CustomerTypeID;
            cmd.Parameters.Add("@CustomerLevelID", SqlDbType.Int).Value = mod.CustomerLevelID;
            cmd.Parameters.Add("@CustomerLevelIDLast", SqlDbType.Int).Value = mod.CustomerLevelIDLast;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@OrderTypeID", SqlDbType.Int).Value = mod.OrderTypeID;
            cmd.Parameters.Add("@CustomerKeyboard", SqlDbType.NVarChar).Value = mod.CustomerKeyboard;
            cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = mod.CustomerName;
            cmd.Parameters.Add("@CustomerShort", SqlDbType.NVarChar).Value = mod.CustomerShort;
            cmd.Parameters.Add("@CustomerPassword", SqlDbType.NVarChar).Value = Security.Encrypt(mod.CustomerPassword);
            cmd.Parameters.Add("@Unifyno", SqlDbType.NVarChar).Value = mod.Unifyno;
            cmd.Parameters.Add("@UnifynoTitle", SqlDbType.NVarChar).Value = mod.UnifynoTitle;
            cmd.Parameters.Add("@UniformInvoice", SqlDbType.Bit).Value = mod.UniformInvoice;
            cmd.Parameters.Add("@UnifynoMethod", SqlDbType.NVarChar).Value = mod.UnifynoMethod;
            cmd.Parameters.Add("@UnifynoRemarks", SqlDbType.NVarChar).Value = mod.UnifynoRemarks;
            cmd.Parameters.Add("@UnifynoDetail", SqlDbType.Bit).Value = mod.UnifynoDetail;
            cmd.Parameters.Add("@PaymentTermsID", SqlDbType.Int).Value = mod.PaymentTermsID;
            cmd.Parameters.Add("@PaymentTerms", SqlDbType.NVarChar).Value = mod.PaymentTerms;
            cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = mod.PaymentMethod;
            cmd.Parameters.Add("@PaymentDays", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.PaymentDays);
            cmd.Parameters.Add("@Owner", SqlDbType.NVarChar).Value = mod.Owner;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = mod.Contact;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@CarType", SqlDbType.NVarChar).Value = mod.CarType;
            cmd.Parameters.Add("@DeliveryManID", SqlDbType.NVarChar).Value = mod.DeliveryManID;
            cmd.Parameters.Add("@RemindEmail", SqlDbType.Bit).Value = mod.RemindEmail;
            cmd.Parameters.Add("@RemindSMS", SqlDbType.Bit).Value = mod.RemindSMS;
            cmd.Parameters.Add("@Remind", SqlDbType.NVarChar).Value = mod.Remind;
            cmd.Parameters.Add("@RemindDay", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.RemindDay);
            cmd.Parameters.Add("@RemindTime", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.RemindTime);
            cmd.Parameters.Add("@PrintLabels", SqlDbType.Bit).Value = mod.PrintLabels;
            cmd.Parameters.Add("@Note1", SqlDbType.NVarChar).Value = mod.Note1;
            cmd.Parameters.Add("@Note2", SqlDbType.NVarChar).Value = mod.Note2;
            cmd.Parameters.Add("@Star", SqlDbType.NVarChar).Value = mod.Star;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = mod.IsComplete;
            cmd.Parameters.Add("@AccountReceivable", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.AccountReceivable);
            cmd.Parameters.Add("@AccountReceivableDays", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.AccountReceivableDays);
            cmd.Parameters.Add("@TradeDays", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.TradeDays);
            cmd.Parameters.Add("@JobDescription", SqlDbType.NVarChar).Value = mod.JobDescription;
            cmd.Parameters.Add("@ExcludeDateBegin", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExcludeDateBegin);
            cmd.Parameters.Add("@ExcludeDateEnd", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExcludeDateEnd);
            cmd.Parameters.Add("@RemindStatus", SqlDbType.Bit).Value = mod.RemindStatus;
            cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
            cmd.Parameters.Add("@MaxIncomeNo", SqlDbType.NVarChar).Value = mod.MaxIncomeNo;
            cmd.Parameters.Add("@InvoiceCompany", SqlDbType.Bit).Value = mod.InvoiceCompany;
            cmd.Parameters.Add("@InvoicePersonal", SqlDbType.Bit).Value = mod.InvoicePersonal;
            cmd.Parameters.Add("@InvoiceCompanyFrom", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyFrom);
            cmd.Parameters.Add("@InvoiceCompanyTo", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyTo);
            cmd.Parameters.Add("@Red", SqlDbType.Bit).Value = mod.Red;
            cmd.Parameters.Add("@Referrer", SqlDbType.NVarChar).Value = mod.Referrer;
            cmd.Parameters.Add("@Disconnected", SqlDbType.Bit).Value = mod.Disconnected;
            cmd.Parameters.Add("@Credits", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.Credits);
            cmd.Parameters.Add("@AdvancePayment", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.AdvancePayment);
            cmd.Parameters.Add("@IsCAS", SqlDbType.Bit).Value = mod.IsCAS;
            cmd.Parameters.Add("@UseWebStatus", SqlDbType.NVarChar).Value = mod.UseWebStatus;
            cmd.Parameters.Add("@UseAppStatus", SqlDbType.NVarChar).Value = mod.UseAppStatus;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            if (SQLUtil.ExecuteSql(cmd) > 0)
            {
                return mod.CustomerID;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MCustomer mod)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@PCustomerID", SqlDbType.NVarChar).Value = mod.PCustomerID;
            cmd.Parameters.Add("@CustomerTypeID", SqlDbType.NVarChar).Value = mod.CustomerTypeID;
            cmd.Parameters.Add("@CustomerLevelID", SqlDbType.Int).Value = mod.CustomerLevelID;
            cmd.Parameters.Add("@CustomerLevelIDLast", SqlDbType.Int).Value = mod.CustomerLevelIDLast;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@OrderTypeID", SqlDbType.Int).Value = mod.OrderTypeID;
            cmd.Parameters.Add("@CustomerKeyboard", SqlDbType.NVarChar).Value = mod.CustomerKeyboard;
            cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = mod.CustomerName;
            cmd.Parameters.Add("@CustomerShort", SqlDbType.NVarChar).Value = mod.CustomerShort;
            cmd.Parameters.Add("@CustomerPassword", SqlDbType.NVarChar).Value = Security.Encrypt(mod.CustomerPassword);
            cmd.Parameters.Add("@Unifyno", SqlDbType.NVarChar).Value = mod.Unifyno;
            cmd.Parameters.Add("@UnifynoTitle", SqlDbType.NVarChar).Value = mod.UnifynoTitle;
            cmd.Parameters.Add("@UniformInvoice", SqlDbType.Bit).Value = mod.UniformInvoice;
            cmd.Parameters.Add("@UnifynoMethod", SqlDbType.NVarChar).Value = mod.UnifynoMethod;
            cmd.Parameters.Add("@UnifynoRemarks", SqlDbType.NVarChar).Value = mod.UnifynoRemarks;
            cmd.Parameters.Add("@UnifynoDetail", SqlDbType.Bit).Value = mod.UnifynoDetail;
            cmd.Parameters.Add("@PaymentTermsID", SqlDbType.Int).Value = mod.PaymentTermsID;
            cmd.Parameters.Add("@PaymentTerms", SqlDbType.NVarChar).Value = mod.PaymentTerms;
            cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = mod.PaymentMethod;
            cmd.Parameters.Add("@PaymentDays", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.PaymentDays);
            cmd.Parameters.Add("@Owner", SqlDbType.NVarChar).Value = mod.Owner;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = mod.Contact;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@CarType", SqlDbType.NVarChar).Value = mod.CarType;
            cmd.Parameters.Add("@DeliveryManID", SqlDbType.NVarChar).Value = mod.DeliveryManID;
            cmd.Parameters.Add("@RemindEmail", SqlDbType.Bit).Value = mod.RemindEmail;
            cmd.Parameters.Add("@RemindSMS", SqlDbType.Bit).Value = mod.RemindSMS;
            cmd.Parameters.Add("@Remind", SqlDbType.NVarChar).Value = mod.Remind;
            cmd.Parameters.Add("@RemindDay", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.RemindDay);
            cmd.Parameters.Add("@RemindTime", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.RemindTime);
            cmd.Parameters.Add("@PrintLabels", SqlDbType.Bit).Value = mod.PrintLabels;
            cmd.Parameters.Add("@Note1", SqlDbType.NVarChar).Value = mod.Note1;
            cmd.Parameters.Add("@Note2", SqlDbType.NVarChar).Value = mod.Note2;
            cmd.Parameters.Add("@Star", SqlDbType.NVarChar).Value = mod.Star;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = mod.IsComplete;
            cmd.Parameters.Add("@AccountReceivable", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.AccountReceivable);
            cmd.Parameters.Add("@AccountReceivableDays", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.AccountReceivableDays);
            cmd.Parameters.Add("@TradeDays", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.TradeDays);
            cmd.Parameters.Add("@JobDescription", SqlDbType.NVarChar).Value = mod.JobDescription;
            cmd.Parameters.Add("@ExcludeDateBegin", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExcludeDateBegin);
            cmd.Parameters.Add("@ExcludeDateEnd", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExcludeDateEnd);
            cmd.Parameters.Add("@RemindStatus", SqlDbType.Bit).Value = mod.RemindStatus;
            cmd.Parameters.Add("@Debt", SqlDbType.Decimal).Value = mod.Debt;
            cmd.Parameters.Add("@MaxIncomeNo", SqlDbType.NVarChar).Value = mod.MaxIncomeNo;
            cmd.Parameters.Add("@InvoiceCompany", SqlDbType.Bit).Value = mod.InvoiceCompany;
            cmd.Parameters.Add("@InvoicePersonal", SqlDbType.Bit).Value = mod.InvoicePersonal;
            cmd.Parameters.Add("@InvoiceCompanyFrom", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyFrom);
            cmd.Parameters.Add("@InvoiceCompanyTo", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.InvoiceCompanyTo);
            cmd.Parameters.Add("@Red", SqlDbType.Bit).Value = mod.Red;
            cmd.Parameters.Add("@Referrer", SqlDbType.NVarChar).Value = mod.Referrer;
            cmd.Parameters.Add("@Disconnected", SqlDbType.Bit).Value = mod.Disconnected;
            cmd.Parameters.Add("@Credits", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.Credits);
            cmd.Parameters.Add("@AdvancePayment", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.AdvancePayment);
            cmd.Parameters.Add("@IsCAS", SqlDbType.Bit).Value = mod.IsCAS;
            cmd.Parameters.Add("@UseWebStatus", SqlDbType.NVarChar).Value = mod.UseWebStatus;
            cmd.Parameters.Add("@UseAppStatus", SqlDbType.NVarChar).Value = mod.UseAppStatus;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MCustomer GetModel(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MCustomer mod = SetModel(dr);
            dr.Close();
            if (isHasRows)
            {
                return mod;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MCustomer> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MCustomer SetModel(SqlDataReader dr)
        {
            Models.MCustomer mod = new Models.MCustomer();
            while (dr.Read())
            {
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.PCustomerID = dr["PCustomerID"].ToString();
                mod.CustomerTypeID = dr["CustomerTypeID"].ToString();
                mod.CustomerLevelID = int.Parse(dr["CustomerLevelID"].ToString());
                mod.CustomerLevelIDLast = int.Parse(dr["CustomerLevelIDLast"].ToString());
                mod.PriceGroupID = dr["PriceGroupID"].ToString();
                mod.OrderTypeID = int.Parse(dr["OrderTypeID"].ToString());
                mod.CustomerKeyboard = dr["CustomerKeyboard"].ToString();
                mod.CustomerName = dr["CustomerName"].ToString();
                mod.CustomerShort = dr["CustomerShort"].ToString();
                mod.CustomerPassword = Security.Decrypt(dr["CustomerPassword"].ToString());
                mod.Unifyno = dr["Unifyno"].ToString();
                mod.UnifynoTitle = dr["UnifynoTitle"].ToString();
                mod.UniformInvoice = bool.Parse(dr["UniformInvoice"].ToString());
                mod.UnifynoMethod = dr["UnifynoMethod"].ToString();
                mod.UnifynoRemarks = dr["UnifynoRemarks"].ToString();
                mod.UnifynoDetail = bool.Parse(dr["UnifynoDetail"].ToString());
                mod.PaymentTermsID = int.Parse(dr["PaymentTermsID"].ToString());
                mod.PaymentTerms = dr["PaymentTerms"].ToString();
                mod.PaymentMethod = dr["PaymentMethod"].ToString();
                mod.PaymentDays = SQLUtil.GetInt(dr["PaymentDays"]);
                mod.Owner = dr["Owner"].ToString();
                mod.Contact = dr["Contact"].ToString();
                mod.Email = dr["Email"].ToString();
                mod.CarType = dr["CarType"].ToString();
                mod.DeliveryManID = dr["DeliveryManID"].ToString();
                mod.RemindEmail = bool.Parse(dr["RemindEmail"].ToString());
                mod.RemindSMS = bool.Parse(dr["RemindSMS"].ToString());
                mod.Remind = dr["Remind"].ToString();
                mod.RemindDay = SQLUtil.GetInt(dr["RemindDay"]);
                mod.RemindTime = SQLUtil.GetDateTime(dr["RemindTime"]);
                mod.PrintLabels = bool.Parse(dr["PrintLabels"].ToString());
                mod.Note1 = dr["Note1"].ToString();
                mod.Note2 = dr["Note2"].ToString();
                mod.Star = dr["Star"].ToString();
                mod.Remarks = dr["Remarks"].ToString();
                mod.IsComplete = bool.Parse(dr["IsComplete"].ToString());
                mod.AccountReceivable = SQLUtil.GetDecimal(dr["AccountReceivable"]);
                mod.AccountReceivableDays = SQLUtil.GetInt(dr["AccountReceivableDays"]);
                mod.TradeDays = SQLUtil.GetInt(dr["TradeDays"]);
                mod.JobDescription = dr["JobDescription"].ToString();
                mod.ExcludeDateBegin = SQLUtil.GetDateTime(dr["ExcludeDateBegin"]);
                mod.ExcludeDateEnd = SQLUtil.GetDateTime(dr["ExcludeDateEnd"]);
                mod.RemindStatus = bool.Parse(dr["RemindStatus"].ToString());
                mod.Debt = Decimal.Parse(dr["Debt"].ToString());
                mod.MaxIncomeNo = dr["MaxIncomeNo"].ToString();
                mod.InvoiceCompany = bool.Parse(dr["InvoiceCompany"].ToString());
                mod.InvoicePersonal = bool.Parse(dr["InvoicePersonal"].ToString());
                mod.InvoiceCompanyFrom = SQLUtil.GetInt(dr["InvoiceCompanyFrom"]);
                mod.InvoiceCompanyTo = SQLUtil.GetInt(dr["InvoiceCompanyTo"]);
                mod.Red = bool.Parse(dr["Red"].ToString());
                mod.Referrer = dr["Referrer"].ToString();
                mod.Disconnected = bool.Parse(dr["Disconnected"].ToString());
                mod.Credits = SQLUtil.GetDecimal(dr["Credits"]);
                mod.AdvancePayment = SQLUtil.GetDecimal(dr["AdvancePayment"]);
                mod.IsCAS = bool.Parse(dr["IsCAS"].ToString());
                mod.UseWebStatus = dr["UseWebStatus"].ToString();
                mod.UseAppStatus = dr["UseAppStatus"].ToString();
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
        private Models.MCustomer SetModel(DataRow dr)
        {
            Models.MCustomer mod = new Models.MCustomer();
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.PCustomerID = dr["PCustomerID"].ToString();
            mod.CustomerTypeID = dr["CustomerTypeID"].ToString();
            mod.CustomerLevelID = int.Parse(dr["CustomerLevelID"].ToString());
            mod.CustomerLevelIDLast = int.Parse(dr["CustomerLevelIDLast"].ToString());
            mod.PriceGroupID = dr["PriceGroupID"].ToString();
            mod.OrderTypeID = int.Parse(dr["OrderTypeID"].ToString());
            mod.CustomerKeyboard = dr["CustomerKeyboard"].ToString();
            mod.CustomerName = dr["CustomerName"].ToString();
            mod.CustomerShort = dr["CustomerShort"].ToString();
            mod.CustomerPassword = Security.Decrypt(dr["CustomerPassword"].ToString());
            mod.Unifyno = dr["Unifyno"].ToString();
            mod.UnifynoTitle = dr["UnifynoTitle"].ToString();
            mod.UniformInvoice = bool.Parse(dr["UniformInvoice"].ToString());
            mod.UnifynoMethod = dr["UnifynoMethod"].ToString();
            mod.UnifynoRemarks = dr["UnifynoRemarks"].ToString();
            mod.UnifynoDetail = bool.Parse(dr["UnifynoDetail"].ToString());
            mod.PaymentTermsID = int.Parse(dr["PaymentTermsID"].ToString());
            mod.PaymentTerms = dr["PaymentTerms"].ToString();
            mod.PaymentMethod = dr["PaymentMethod"].ToString();
            mod.PaymentDays = SQLUtil.GetInt(dr["PaymentDays"]);
            mod.Owner = dr["Owner"].ToString();
            mod.Contact = dr["Contact"].ToString();
            mod.Email = dr["Email"].ToString();
            mod.CarType = dr["CarType"].ToString();
            mod.DeliveryManID = dr["DeliveryManID"].ToString();
            mod.RemindEmail = bool.Parse(dr["RemindEmail"].ToString());
            mod.RemindSMS = bool.Parse(dr["RemindSMS"].ToString());
            mod.Remind = dr["Remind"].ToString();
            mod.RemindDay = SQLUtil.GetInt(dr["RemindDay"]);
            mod.RemindTime = SQLUtil.GetDateTime(dr["RemindTime"]);
            mod.PrintLabels = bool.Parse(dr["PrintLabels"].ToString());
            mod.Note1 = dr["Note1"].ToString();
            mod.Note2 = dr["Note2"].ToString();
            mod.Star = dr["Star"].ToString();
            mod.Remarks = dr["Remarks"].ToString();
            mod.IsComplete = bool.Parse(dr["IsComplete"].ToString());
            mod.AccountReceivable = SQLUtil.GetDecimal(dr["AccountReceivable"]);
            mod.AccountReceivableDays = SQLUtil.GetInt(dr["AccountReceivableDays"]);
            mod.TradeDays = SQLUtil.GetInt(dr["TradeDays"]);
            mod.JobDescription = dr["JobDescription"].ToString();
            mod.ExcludeDateBegin = SQLUtil.GetDateTime(dr["ExcludeDateBegin"]);
            mod.ExcludeDateEnd = SQLUtil.GetDateTime(dr["ExcludeDateEnd"]);
            mod.RemindStatus = bool.Parse(dr["RemindStatus"].ToString());
            mod.Debt = Decimal.Parse(dr["Debt"].ToString());
            mod.MaxIncomeNo = dr["MaxIncomeNo"].ToString();
            mod.InvoiceCompany = bool.Parse(dr["InvoiceCompany"].ToString());
            mod.InvoicePersonal = bool.Parse(dr["InvoicePersonal"].ToString());
            mod.InvoiceCompanyFrom = SQLUtil.GetInt(dr["InvoiceCompanyFrom"]);
            mod.InvoiceCompanyTo = SQLUtil.GetInt(dr["InvoiceCompanyTo"]);
            mod.Red = bool.Parse(dr["Red"].ToString());
            mod.Referrer = dr["Referrer"].ToString();
            mod.Disconnected = bool.Parse(dr["Disconnected"].ToString());
            mod.Credits = SQLUtil.GetDecimal(dr["Credits"]);
            mod.AdvancePayment = SQLUtil.GetDecimal(dr["AdvancePayment"]);
            mod.IsCAS = bool.Parse(dr["IsCAS"].ToString());
            mod.UseWebStatus = dr["UseWebStatus"].ToString();
            mod.UseAppStatus = dr["UseAppStatus"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MCustomer> GetList(DataSet ds)
        {
            List<Models.MCustomer> li = new List<Models.MCustomer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 由CustomerID計算Customer筆數
        /// </summary>
        public int CountByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerCountByCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

       

        /// <summary>
        /// 修改資料Customer
        /// <summary>
        public bool CustomerIDEdit(string strOldCustomerID, string strNewCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerEditCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strOldCustomerID;
            cmd.Parameters.Add("@NewCustomerID", SqlDbType.NVarChar).Value = strNewCustomerID;
            //cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strOldCustomerID;
            //cmd.Parameters.Add("@NewSupplierID", SqlDbType.NVarChar).Value = strNewCustomerID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得最後一筆資料
        /// <summary>
        public string GetMaxString()
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetMax");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MCustomer mod = SetModel(dr);
            dr.Close();
            if (isHasRows)
            {
                return mod.CustomerID;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public DataSet GetCustomerGetByDebt(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetByDebt");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 由PCustomerID計算Customer筆數
        /// </summary>
        public int CountByPCustomerID(string strPCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerCountByPCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PCustomerID", SqlDbType.NVarChar).Value = strPCustomerID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

        /// <summary>
        /// 以總公司取得分公司所有未沖金額
        /// </summary>
        public DataSet GetNotYetSumByPCustomerID(string strPCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetNotYetSumByPCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PCustomerID", SqlDbType.NVarChar).Value = strPCustomerID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 司機來取得不屬於他的訂單
        /// </summary>
        public DataSet GetCreditsByOrderID(string strOrderID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetCreditsByOrderID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = strOrderID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 以customerid計算所有欠款
        /// </summary>
        public DataSet GetByCreditAndSubTotal(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetByCreditAndSubTotal");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 以customerid取得最後交易日及欠籃數
        /// </summary>
        public DataSet GetLastOrderDateAndLessBasketByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetLastOrderDateAndLessBasketByCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 由帳號與密碼取得客戶資料
        /// </summary>
        public Models.MCustomer GetByUserAccountUserPassword(string strUserAccount, string strUserPassword)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetByUserAccountUserPassword");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserAccount", SqlDbType.NVarChar).Value = strUserAccount;
            cmd.Parameters.Add("@CustomerPassword", SqlDbType.NVarChar).Value = Security.Encrypt(strUserPassword);
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MCustomer mod = SetModel(dr);
            dr.Close();
            if (isHasRows)
            {
                return mod;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region  webservice



        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public DataSet GetCustomerGetByDebt(string strCustomerID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerGetByDebt");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return ds;
        //}

        public DataSet GetMaxDueDateByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            cmd.CommandType = CommandType.Text;
            sbTSQL.Append(" select MaxDate=Max(DueDate) from TB_Order where CustomerID=@CustomerID group by CustomerID");
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;

            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCustomerID"></param>
        /// <returns></returns>
        public DataSet GetDueDateNotBanlanceByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            cmd.CommandType = CommandType.Text;
            sbTSQL.Append(" select DueDate from TB_Order where OrderID in ");
            sbTSQL.Append(" ( ");
            sbTSQL.Append(" select AccountsReceivableNo from  TB_AccountsReceivable ");
            sbTSQL.Append(" where CustomerID=@CustomerID and ");
            sbTSQL.Append(" AccountsReceivableBanlance in ('待沖帳') ");
            sbTSQL.Append(" ) ");
            sbTSQL.Append(" group by DueDate ");
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;

            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCustomerID"></param>
        /// <returns></returns>
        public List<Models.MCustomer> GetUseWeb()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            cmd.CommandType = CommandType.Text;
            sbTSQL.Append(" select * from TB_Customer where UseWebStatus='開通' ");
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        #endregion
    }
}
