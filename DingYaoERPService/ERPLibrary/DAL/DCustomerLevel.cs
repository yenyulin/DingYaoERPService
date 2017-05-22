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
    /// 資料存取層 CustomerLevel
    /// </summary>
    public class DCustomerLevel
    {
        public DCustomerLevel() { }

        #region 基本方法

        ///// <summary>
        ///// 新增資料
        ///// </summary>
        //public int Add(Models.MCustomerLevel mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerLevelAdd");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CustomerLevel", SqlDbType.NVarChar).Value = mod.CustomerLevel;
        //    cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
        //    object obj = SQLUtil.ExecuteScalar(cmd);
        //    int intID = 0;
        //    if (obj != null && int.TryParse(obj.ToString(), out intID))
        //    {
        //        mod.CustomerLevelID = intID;
        //    }
        //    return intID;
        //}

        ///// <summary>
        ///// 修改資料
        ///// <summary>
        //public bool Edit(Models.MCustomerLevel mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerLevelEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CustomerLevelID", SqlDbType.Int).Value = mod.CustomerLevelID;
        //    cmd.Parameters.Add("@CustomerLevel", SqlDbType.NVarChar).Value = mod.CustomerLevel;
        //    cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        ///// <summary>
        ///// 刪除資料
        ///// <summary>
        //public bool Del(int intCustomerLevelID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerLevelDel");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CustomerLevelID", SqlDbType.Int).Value = intCustomerLevelID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MCustomerLevel GetModel(int intCustomerLevelID) 
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerLevelGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerLevelID", SqlDbType.Int).Value = intCustomerLevelID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MCustomerLevel mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MCustomerLevel> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerLevelGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MCustomerLevel SetModel(SqlDataReader dr)
        {
            Models.MCustomerLevel mod = new Models.MCustomerLevel();
            while (dr.Read())
            {
                mod.CustomerLevelID = int.Parse(dr["CustomerLevelID"].ToString());
                mod.CustomerLevel = dr["CustomerLevel"].ToString();
                mod.MinAmount = SQLUtil.GetInt(dr["MinAmount"]);
                mod.MaxAmount = SQLUtil.GetInt(dr["MaxAmount"]);
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
        private Models.MCustomerLevel SetModel(DataRow dr)
        {
            Models.MCustomerLevel mod = new Models.MCustomerLevel();
            mod.CustomerLevelID = int.Parse(dr["CustomerLevelID"].ToString());
            mod.CustomerLevel = dr["CustomerLevel"].ToString();
            mod.MinAmount = SQLUtil.GetInt(dr["MinAmount"]);
            mod.MaxAmount = SQLUtil.GetInt(dr["MaxAmount"]);
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MCustomerLevel> GetList(DataSet ds)
        {
            List<Models.MCustomerLevel> li = new List<Models.MCustomerLevel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion


        #region  自訂方法

        ///// <summary>
        ///// 以strCustomerLevelID計算筆數
        ///// </summary>
        //public int GetCountByCustomerLevelID(int intCustomerLevelID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerLeveCountByCustomerLevelID");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CustomerLevelID ", SqlDbType.Int).Value = intCustomerLevelID;
        //    return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        //}

        #endregion
    }
}
