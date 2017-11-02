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
    /// 資料存取層 Inventory
    /// </summary>
    public class DInventory
    {
        public DInventory() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MInventory mod)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = mod.FactoryID;
            cmd.Parameters.Add("@InventoryDate", SqlDbType.DateTime).Value = mod.InventoryDate;
            cmd.Parameters.Add("@InventoryType", SqlDbType.NVarChar).Value = mod.InventoryType;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@InventoryStatus", SqlDbType.NVarChar).Value = mod.InventoryStatus;
            cmd.Parameters.Add("@InputUser", SqlDbType.NVarChar).Value = mod.InputUser;
            cmd.Parameters.Add("@InventoryPrint", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.InventoryPrint);
            cmd.Parameters.Add("@InventoryBegin", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.InventoryBegin);
            cmd.Parameters.Add("@InventoryEnd", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.InventoryEnd);
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.InventoryID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MInventory mod)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = mod.InventoryID;
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = mod.FactoryID;
            cmd.Parameters.Add("@InventoryDate", SqlDbType.DateTime).Value = mod.InventoryDate;
            cmd.Parameters.Add("@InventoryType", SqlDbType.NVarChar).Value = mod.InventoryType;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@InventoryStatus", SqlDbType.NVarChar).Value = mod.InventoryStatus;
            cmd.Parameters.Add("@InputUser", SqlDbType.NVarChar).Value = mod.InputUser;
            cmd.Parameters.Add("@InventoryPrint", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.InventoryPrint);
            cmd.Parameters.Add("@InventoryBegin", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.InventoryBegin);
            cmd.Parameters.Add("@InventoryEnd", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.InventoryEnd);
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料(同時刪除TB_InventoryProduct及TB_InventoryUser)
        /// <summary>
        public bool Del(int intInventoryID)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MInventory GetModel(int intInventoryID)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MInventory mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MInventory SetModel(SqlDataReader dr)
        {
            Models.MInventory mod = new Models.MInventory();
            while (dr.Read())
            {
                mod.InventoryID = int.Parse(dr["InventoryID"].ToString());
                mod.FactoryID = int.Parse(dr["FactoryID"].ToString());
                mod.InventoryDate = DateTime.Parse(dr["InventoryDate"].ToString());
                mod.InventoryType = dr["InventoryType"].ToString();
                mod.Remarks = dr["Remarks"].ToString();
                mod.InventoryStatus = dr["InventoryStatus"].ToString();
                mod.InputUser = dr["InputUser"].ToString();
                mod.InventoryPrint = SQLUtil.GetDateTime(dr["InventoryPrint"]);
                mod.InventoryBegin = SQLUtil.GetDateTime(dr["InventoryBegin"]);
                mod.InventoryEnd = SQLUtil.GetDateTime(dr["InventoryEnd"]);
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
        private Models.MInventory SetModel(DataRow dr)
        {
            Models.MInventory mod = new Models.MInventory();
            mod.InventoryID = int.Parse(dr["InventoryID"].ToString());
            mod.FactoryID = int.Parse(dr["FactoryID"].ToString());
            mod.InventoryDate = DateTime.Parse(dr["InventoryDate"].ToString());
            mod.InventoryType = dr["InventoryType"].ToString();
            mod.Remarks = dr["Remarks"].ToString();
            mod.InventoryStatus = dr["InventoryStatus"].ToString();
            mod.InputUser = dr["InputUser"].ToString();
            mod.InventoryPrint = SQLUtil.GetDateTime(dr["InventoryPrint"]);
            mod.InventoryBegin = SQLUtil.GetDateTime(dr["InventoryBegin"]);
            mod.InventoryEnd = SQLUtil.GetDateTime(dr["InventoryEnd"]);
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MInventory> GetList(DataSet ds)
        {
            List<Models.MInventory> li = new List<Models.MInventory>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 依盤點類別及關鍵字取得所有盤點資料
        /// </summary>
        /// <param name="strInventoryType"></param>
        /// <param name="strKeyWords"></param>
        /// <returns></returns>
        public DataTable GetInventoryByConditions(string strInventoryType, string strKeyWords) 
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryGetByConditions");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryType", SqlDbType.NVarChar).Value = strInventoryType;
            cmd.Parameters.Add("@KeyWords", SqlDbType.NVarChar).Value = strKeyWords;
            return SQLUtil.QueryDS(cmd).Tables[0];            
        }

        public SqlDataReader GetInventoryByInventoryID(int intInventoryID) 
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryGetByInventoryID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = intInventoryID;
            SqlDataReader sdr = SQLUtil.QueryDR(cmd);
            return sdr;
        }

        /// <summary>
        /// 依FactoryID及InventoryType取得Inventory資料
        /// </summary>
        public List<Models.MInventory> GetListByFactoryIDInventoryType(int intFactoryID, string strInventoryType)
        {
            SqlCommand cmd = new SqlCommand("STP_InventoryGetByFactoryIDInventoryType");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = intFactoryID;
            cmd.Parameters.Add("@InventoryType", SqlDbType.NVarChar).Value = strInventoryType;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        ///// <summary>
        ///// 依FactoryID及InventoryType取得Inventory資料
        ///// </summary>
        //public List<Models.MInventory> GetListByFactoryIDInventoryType(int intFactoryID, string strInventoryType)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_InventoryGetByFactoryIDInventoryType");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = intFactoryID;
        //    cmd.Parameters.Add("@InventoryType", SqlDbType.NVarChar).Value = strInventoryType;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}


        /// <summary>
        /// 依FactoryID及InventoryType取得Inventory資料
        /// </summary>
        public List<Models.MInventory> GetListByFactoryIDInventoryType(int intFactoryID, string strInventoryType, string strDateBegin, string strDateEnd)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.AppendLine("select * from TB_Inventory ");
            sbTSQL.AppendLine("Where FactoryID=@FactoryID and InventoryType=@InventoryType and InventoryStatus='完成盤點' ");
            sbTSQL.AppendLine("and cast( InventoryPrint as date) >=@DtBegin and cast( InventoryPrint as date)<=@DtEnd ");
            sbTSQL.Append("order by InventoryPrint ");
            
            cmd.Parameters.Add("@FactoryID", SqlDbType.Int).Value = intFactoryID;
            cmd.Parameters.Add("@InventoryType", SqlDbType.NVarChar).Value = strInventoryType;
            cmd.Parameters.Add("@DtBegin", SqlDbType.DateTime).Value = Convert.ToDateTime(strDateBegin);
            cmd.Parameters.Add("@DtEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(strDateEnd);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

      

        #endregion

       

        #region  Service

        /// <summary>
        /// 依FactoryID及InventoryType取得Inventory資料
        /// </summary>
        public List<Models.MInventory> GetAutoStartList()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.AppendLine("select * from TB_Inventory where CAST(InventoryDate as date) = cast(getdate() as date)  ");
            sbTSQL.AppendLine("and InventoryType='月盤點' ");
            sbTSQL.AppendLine("and InventoryStatus='已列印盤點單' ");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        #endregion
    }
}
