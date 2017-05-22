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
    /// 資料存取層 CycleWorkItem
    /// </summary>
    public class DCycleWorkItem
    {
        public DCycleWorkItem() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MCycleWorkItem mod)
        {
            SqlCommand cmd = new SqlCommand("STP_CycleWorkItemAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CycleWorkItemSettingID", SqlDbType.Int).Value = mod.CycleWorkItemSettingID;
            //cmd.Parameters.Add("@CycleWorkItemSetting1ID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.CycleWorkItemSetting1ID);
            //cmd.Parameters.Add("@CycleWorkItemSetting2ID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.CycleWorkItemSetting2ID);
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@ChargePerson", SqlDbType.NVarChar).Value = mod.ChargePerson;
            cmd.Parameters.Add("@JobDescription", SqlDbType.NVarChar).Value = mod.JobDescription;
            cmd.Parameters.Add("@CycleWorkItemStatus", SqlDbType.NVarChar).Value = mod.CycleWorkItemStatus;
            cmd.Parameters.Add("@CycleWorkItemReamrks", SqlDbType.NVarChar).Value = mod.CycleWorkItemReamrks;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.CycleWorkItemID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MCycleWorkItem mod)
        {
            SqlCommand cmd = new SqlCommand("STP_CycleWorkItemEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CycleWorkItemID", SqlDbType.Int).Value = mod.CycleWorkItemID;
            cmd.Parameters.Add("@CycleWorkItemSettingID", SqlDbType.Int).Value = mod.CycleWorkItemSettingID;
            //cmd.Parameters.Add("@CycleWorkItemSetting1ID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.CycleWorkItemSetting1ID);
            //cmd.Parameters.Add("@CycleWorkItemSetting2ID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.CycleWorkItemSetting2ID);
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@ChargePerson", SqlDbType.NVarChar).Value = mod.ChargePerson;
            cmd.Parameters.Add("@JobDescription", SqlDbType.NVarChar).Value = mod.JobDescription;
            cmd.Parameters.Add("@CycleWorkItemStatus", SqlDbType.NVarChar).Value = mod.CycleWorkItemStatus;
            cmd.Parameters.Add("@CycleWorkItemReamrks", SqlDbType.NVarChar).Value = mod.CycleWorkItemReamrks;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intCycleWorkItemID)
        {
            SqlCommand cmd = new SqlCommand("STP_CycleWorkItemDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CycleWorkItemID", SqlDbType.Int).Value = intCycleWorkItemID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MCycleWorkItem GetModel(int intCycleWorkItemID)
        {
            SqlCommand cmd = new SqlCommand("STP_CycleWorkItemGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CycleWorkItemID", SqlDbType.Int).Value = intCycleWorkItemID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MCycleWorkItem mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MCycleWorkItem> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_CycleWorkItemGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MCycleWorkItem SetModel(SqlDataReader dr)
        {
            Models.MCycleWorkItem mod = new Models.MCycleWorkItem();
            while (dr.Read())
            {
                mod.CycleWorkItemID = int.Parse(dr["CycleWorkItemID"].ToString());
                mod.CycleWorkItemSettingID = int.Parse(dr["CycleWorkItemSettingID"].ToString());
                //mod.CycleWorkItemSetting1ID = SQLUtil.GetInt(dr["CycleWorkItemSetting1ID"]);
                //mod.CycleWorkItemSetting2ID = SQLUtil.GetInt(dr["CycleWorkItemSetting2ID"]);
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.ChargePerson = dr["ChargePerson"].ToString();
                mod.JobDescription = dr["JobDescription"].ToString();
                mod.CycleWorkItemStatus = dr["CycleWorkItemStatus"].ToString();
                mod.CycleWorkItemReamrks = dr["CycleWorkItemReamrks"].ToString();
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
        private Models.MCycleWorkItem SetModel(DataRow dr)
        {
            Models.MCycleWorkItem mod = new Models.MCycleWorkItem();
            mod.CycleWorkItemID = int.Parse(dr["CycleWorkItemID"].ToString());
            mod.CycleWorkItemSettingID = int.Parse(dr["CycleWorkItemSettingID"].ToString());
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.ChargePerson = dr["ChargePerson"].ToString();
            mod.JobDescription = dr["JobDescription"].ToString();
            mod.CycleWorkItemStatus = dr["CycleWorkItemStatus"].ToString();
            mod.CycleWorkItemReamrks = dr["CycleWorkItemReamrks"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MCycleWorkItem> GetList(DataSet ds)
        {
            List<Models.MCycleWorkItem> li = new List<Models.MCycleWorkItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// CycleWorkItem作業紀錄修改
        /// <summary>
        public bool CycleWorkItemRemarksEdit(Models.MCycleWorkItem mod)
        {
            SqlCommand cmd = new SqlCommand("STP_CycleWorkItemRemarksEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CycleWorkItemID", SqlDbType.Int).Value = mod.CycleWorkItemID;
            //cmd.Parameters.Add("@CycleWorkItemSetting1ID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.CycleWorkItemSetting1ID);
            //cmd.Parameters.Add("@CycleWorkItemSetting2ID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.CycleWorkItemSetting2ID);
            //cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            //cmd.Parameters.Add("@ChargePerson", SqlDbType.NVarChar).Value = mod.ChargePerson;
            cmd.Parameters.Add("@CycleWorkItemStatus", SqlDbType.NVarChar).Value = mod.CycleWorkItemStatus;
            cmd.Parameters.Add("@CycleWorkItemReamrks", SqlDbType.NVarChar).Value = mod.CycleWorkItemReamrks;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        public DataSet GetProcessWorkItemSetting()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.Append(" select * from [dbo].[TB_CycleWorkItemSetting] ");
            sbTSQL.Append(" a left join TB_CycleWorkItemType b on a.CycleWorkItemTypeID=b.CycleWorkItemTypeID ");
            sbTSQL.Append(" where a.CycleWorkItemStatus='啟用' ");
            //sbTSQL.Append(" and not CycleWorkItemSettingID in ");
            //sbTSQL.Append(" (select CycleWorkItemSettingID from TB_CycleWorkItem where  convert(date,CreateDate) =   convert(date,GETDATE())) ");

            //sbTSQL.Append(" order by CustomerRetuenDate desc ");

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        #endregion
    }
}
