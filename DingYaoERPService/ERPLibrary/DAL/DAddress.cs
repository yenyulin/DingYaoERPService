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
    /// 資料存取層 Address
    /// </summary>
    public class DAddress
    {
        public DAddress() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MAddress mod)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
            cmd.Parameters.Add("@ZIPCode", SqlDbType.NVarChar).Value = mod.ZIPCode;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@DeliveryManID1", SqlDbType.NVarChar).Value = mod.DeliveryManID1;
            cmd.Parameters.Add("@DeliveryManID2", SqlDbType.NVarChar).Value = mod.DeliveryManID2;
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = mod.Seq;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.AddressID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MAddress mod)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = mod.AddressID;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
            cmd.Parameters.Add("@ZIPCode", SqlDbType.NVarChar).Value = mod.ZIPCode;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@DeliveryManID1", SqlDbType.NVarChar).Value = mod.DeliveryManID1;
            cmd.Parameters.Add("@DeliveryManID2", SqlDbType.NVarChar).Value = mod.DeliveryManID2;
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = mod.Seq;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            //cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intAddressID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = intAddressID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MAddress GetModel(int intAddressID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = intAddressID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MAddress mod = SetModel(dr);
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
        public List<Models.MAddress> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_AddressGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MAddress SetModel(SqlDataReader dr)
        {
            Models.MAddress mod = new Models.MAddress();
            while (dr.Read())
            {
                mod.AddressID = int.Parse(dr["AddressID"].ToString());
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.SupplierID = dr["SupplierID"].ToString();
                mod.ZIPCode = dr["ZIPCode"].ToString();
                mod.Address = dr["Address"].ToString();
                mod.DeliveryManID1 = dr["DeliveryManID1"].ToString();
                mod.DeliveryManID2 = dr["DeliveryManID2"].ToString();
                mod.Seq = int.Parse(dr["Seq"].ToString());
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
        private Models.MAddress SetModel(DataRow dr)
        {
            Models.MAddress mod = new Models.MAddress();
            mod.AddressID = int.Parse(dr["AddressID"].ToString());
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.SupplierID = dr["SupplierID"].ToString();
            mod.ZIPCode = dr["ZIPCode"].ToString();
            mod.Address = dr["Address"].ToString();
            mod.DeliveryManID1 = dr["DeliveryManID1"].ToString();
            mod.DeliveryManID2 = dr["DeliveryManID2"].ToString();
            mod.Seq = int.Parse(dr["Seq"].ToString());
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
        private List<Models.MAddress> GetList(DataSet ds)
        {
            List<Models.MAddress> li = new List<Models.MAddress>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以CustomerID取得所有資料
        /// </summary>
        public List<Models.MAddress> GetListByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressGetByCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 以SupplierID取得所有資料
        /// </summary>
        public List<Models.MAddress> GetListBySupplierID(string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressGetBySupplierID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }


        /// <summary>
        /// intAddress順序變更
        /// <summary>
        public bool AddressSeqEditBySupplier(int intAddressID, bool isSeqUp)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressRowSeqEditBySupplier");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = intAddressID;
            cmd.Parameters.Add("@SeqUp", SqlDbType.Bit).Value = isSeqUp;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// intAddress順序變更
        /// <summary>
        public bool AddressSeqEditByCustomerID(int intAddressID, bool isSeqUp)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressRowSeqEditByCustomer");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = intAddressID;
            cmd.Parameters.Add("@SeqUp", SqlDbType.Bit).Value = isSeqUp;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// intAddress(刪除時)順序變更(Customer)
        /// <summary>
        public bool AddressDelSeqEditByCustomer(int intAddressID, string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressDelSeqEditByCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = intAddressID;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// intAddress(刪除時)順序變更
        /// <summary>
        public bool AddressDelSeqEditBySupplier(int intAddressID, string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressDelSeqEditBySupplierID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AddressID", SqlDbType.Int).Value = intAddressID;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 計算有幾筆default
        /// </summary>
        public int GetCountDefaultValueByCustomerID(string strCustomerID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressCountDefaultByCustomerID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

        /// <summary>
        /// 計算有幾筆default
        /// </summary>
        public int GetCountDefaultValueBySupplierID(string strSupplierID)
        {
            SqlCommand cmd = new SqlCommand("STP_AddressCountDefaultBySupplierID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Models.MAddress> GetListBySupplierID()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.AppendLine(" select * from ");
            sbTSQL.AppendLine(" ( ");
            sbTSQL.AppendLine(" select * ,zipLength =len(ZIPCode) from TB_Address ");
            sbTSQL.AppendLine(" )a ");
            sbTSQL.AppendLine(" where zipLength=5 ");
            sbTSQL.AppendLine(" and substring(Convert(varchar(5),ZIPCode),4,2)='99' ");

            cmd.CommandText = sbTSQL.ToString();
            //return QueryDS(cmd);
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }


        /// <summary>
        /// 
        /// </summary>
        public List<Models.MAddress> GetListProcessAddress()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.AppendLine(" select  * from TB_Address a left join TB_ZipCode b on  Substring(a.ZIPCode,1,3)=b.zipcode ");
            sbTSQL.AppendLine("where len(a.ZIPCode)=3 ");
            

            cmd.CommandText = sbTSQL.ToString();
            //return QueryDS(cmd);
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        #endregion
    }
}
