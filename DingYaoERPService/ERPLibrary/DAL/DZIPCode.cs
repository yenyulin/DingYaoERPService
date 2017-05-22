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
    /// 資料存取層 ZIPCode
    /// </summary>
    public class DZIPCode
    {
        public DZIPCode() { }

        #region 基本方法
        
        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MZIPCode GetModel(string strZIPCode)
        {
            SqlCommand cmd = new SqlCommand("STP_ZIPCodeGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ZIPCode", SqlDbType.NVarChar).Value = strZIPCode;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MZIPCode mod = SetModel(dr);
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
        public List<Models.MZIPCode> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_ZIPCodeGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MZIPCode SetModel(SqlDataReader dr)
        {
            Models.MZIPCode mod = new Models.MZIPCode();
            while (dr.Read())
            {
                mod.ZIPCode = dr["ZIPCode"].ToString();
                mod.City = dr["City"].ToString();
                mod.Area = dr["Area"].ToString();
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MZIPCode SetModel(DataRow dr)
        {
            Models.MZIPCode mod = new Models.MZIPCode();
            mod.ZIPCode = dr["ZIPCode"].ToString();
            mod.City = dr["City"].ToString();
            mod.Area = dr["Area"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MZIPCode> GetList(DataSet ds)
        {
            List<Models.MZIPCode> li = new List<Models.MZIPCode>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得所有city
        /// </summary>
        public List<Models.MZIPCode> GetCity()
        {
            //string TSQL = "select City from TB_ZIPCode group by City";
            //SqlCommand cmd = new SqlCommand(TSQL);
            //cmd.CommandType = CommandType.Text;
            SqlCommand cmd = new SqlCommand("STP_ZIPCodeGetCity");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }


        #endregion
    }
}
