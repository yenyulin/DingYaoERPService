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
    /// 資料存取層 PriceGroup
    /// </summary>
    public class DPriceGroup
    {
        public DPriceGroup() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MPriceGroup mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGroupAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@PriceGroup", SqlDbType.NVarChar).Value = mod.PriceGroup;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            //cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            if (SQLUtil.ExecuteSql(cmd) > 0)
            {
                return mod.PriceGroupID;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPriceGroup mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGroupEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@PriceGroup", SqlDbType.NVarChar).Value = mod.PriceGroup;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strPriceGroupID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGroupDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPriceGroup GetModel(string strPriceGroupID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGroupGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPriceGroup mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MPriceGroup> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGroupGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MPriceGroup SetModel(SqlDataReader dr)
        {
            Models.MPriceGroup mod = new Models.MPriceGroup();
            while (dr.Read())
            {
                mod.PriceGroupID = dr["PriceGroupID"].ToString();
                mod.PriceGroup = dr["PriceGroup"].ToString();
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
        private Models.MPriceGroup SetModel(DataRow dr)
        {
            Models.MPriceGroup mod = new Models.MPriceGroup();
            mod.PriceGroupID = dr["PriceGroupID"].ToString();
            mod.PriceGroup = dr["PriceGroup"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPriceGroup> GetList(DataSet ds)
        {
            List<Models.MPriceGroup> li = new List<Models.MPriceGroup>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 計算用價格群組代號取得所有價格群組資料筆數
        /// </summary>
        public int GetCountByPriceGroupID(string strPriceGroupID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceGroupCountByFactoryID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

        #endregion
    }
}
