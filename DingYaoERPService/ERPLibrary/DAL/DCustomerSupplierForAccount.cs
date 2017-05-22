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
    public class DCustomerSupplierForAccount
    {
        public DCustomerSupplierForAccount() { }

        #region 自訂

        /// <summary>
        /// 司機績效
        /// </summary>
        public DataSet GetCustomerAndSupplierForAccount()
        {

            SqlCommand cmd = new SqlCommand("STP_GetCustomerAndSupplierForAccount");
            cmd.CommandType = CommandType.StoredProcedure;
            
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;

        }

        #endregion
    }
}
