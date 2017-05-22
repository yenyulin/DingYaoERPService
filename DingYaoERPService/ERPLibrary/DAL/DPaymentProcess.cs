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
    /// 資料存取層 PaymentProcess
    /// </summary>
    public class DPaymentProcess
    {
        public DPaymentProcess() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaymentProcess mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PaymentProcessAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@PaymentTermsID", SqlDbType.Int).Value = mod.PaymentTermsID;
            cmd.Parameters.Add("@ChargePerson", SqlDbType.NVarChar).Value = mod.ChargePerson;
            cmd.Parameters.Add("@JobDescription", SqlDbType.NVarChar).Value = mod.JobDescription;
            cmd.Parameters.Add("@PaymentProcessStatus", SqlDbType.NVarChar).Value = mod.PaymentProcessStatus;
            cmd.Parameters.Add("@PaymentProcessReamrks", SqlDbType.NVarChar).Value = mod.PaymentProcessReamrks;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.PaymentProcessID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPaymentProcess mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PaymentProcessEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaymentProcessID", SqlDbType.Int).Value = mod.PaymentProcessID;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@PaymentTermsID", SqlDbType.Int).Value = mod.PaymentTermsID;
            cmd.Parameters.Add("@ChargePerson", SqlDbType.NVarChar).Value = mod.ChargePerson;
            cmd.Parameters.Add("@JobDescription", SqlDbType.NVarChar).Value = mod.JobDescription;
            cmd.Parameters.Add("@PaymentProcessStatus", SqlDbType.NVarChar).Value = mod.PaymentProcessStatus;
            cmd.Parameters.Add("@PaymentProcessReamrks", SqlDbType.NVarChar).Value = mod.PaymentProcessReamrks;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPaymentProcessID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaymentProcessDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaymentProcessID", SqlDbType.Int).Value = intPaymentProcessID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPaymentProcess GetModel(int intPaymentProcessID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaymentProcessGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaymentProcessID", SqlDbType.Int).Value = intPaymentProcessID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPaymentProcess mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MPaymentProcess> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_PaymentProcessGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MPaymentProcess SetModel(SqlDataReader dr)
        {
            Models.MPaymentProcess mod = new Models.MPaymentProcess();
            while (dr.Read())
            {
                mod.PaymentProcessID = int.Parse(dr["PaymentProcessID"].ToString());
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.PaymentTermsID = int.Parse(dr["PaymentTermsID"].ToString());
                mod.ChargePerson = dr["ChargePerson"].ToString();
                mod.JobDescription = dr["JobDescription"].ToString();
                mod.PaymentProcessStatus = dr["PaymentProcessStatus"].ToString();
                mod.PaymentProcessReamrks = dr["PaymentProcessReamrks"].ToString();
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
        private Models.MPaymentProcess SetModel(DataRow dr)
        {
            Models.MPaymentProcess mod = new Models.MPaymentProcess();
            mod.PaymentProcessID = int.Parse(dr["PaymentProcessID"].ToString());
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.PaymentTermsID = int.Parse(dr["PaymentTermsID"].ToString());
            mod.ChargePerson = dr["ChargePerson"].ToString();
            mod.JobDescription = dr["JobDescription"].ToString();
            mod.PaymentProcessStatus = dr["PaymentProcessStatus"].ToString();
            mod.PaymentProcessReamrks = dr["PaymentProcessReamrks"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPaymentProcess> GetList(DataSet ds)
        {
            List<Models.MPaymentProcess> li = new List<Models.MPaymentProcess>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        public DataSet GetPaymentProcessList()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.Append(" select a.*,ChargePerson from TB_Customer a left join TB_PaymentTerms b on a.PaymentTermsID=b.PaymentTermsID ");
            //sbTSQL.Append(" select * from [TB_PaymentTerms] ");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        public DataSet GetNotBanlance(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            cmd.CommandType = CommandType.Text;
            //sbTSQL.Append(" select a.*,ChargePerson from TB_Customer a left join TB_PaymentTerms b on a.PaymentTermsID=b.PaymentTermsID ");
            sbTSQL.Append(" select * from");
            sbTSQL.Append(" ( ");
            sbTSQL.Append(" select a.CustomerID,AccountsReceivableNo,AccountsReceivableType,Dt=dueDate from TB_Order");
            sbTSQL.Append(" a left join TB_AccountsReceivable b on a.OrderID=b.AccountsReceivableNo");
            sbTSQL.Append(" where CustomerID=@CustomerID and AccountsReceivableBanlance in ('待沖帳') and AccountsReceivableType='出貨' ");
            //sbTSQL.Append(" --union ");
            //sbTSQL.Append(" --select a.CustomerID,AccountsReceivableNo,AccountsReceivableType,Dt=CustomerRetuenDate from TB_CustomerRetuen  ");
            //sbTSQL.Append(" --a left join TB_AccountsReceivable b on a.CustomerRetuenNo=b.AccountsReceivableNo ");
            //sbTSQL.Append(" --where CustomerID=@CustomerID AccountsReceivableBanlance in ('待沖帳') and AccountsReceivableType='出貨退品' ");
            sbTSQL.Append(" ) info  where not cast( Dt as date) =cast( GETDATE() as date) order by Dt  ");
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
           
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        #endregion
    }
}
