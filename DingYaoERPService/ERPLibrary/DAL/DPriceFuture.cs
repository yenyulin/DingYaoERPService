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
    /// 資料存取層 PriceFuture
    /// </summary>
    public class DPriceFuture
    {
        public DPriceFuture() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPriceFuture mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@BeginDate", SqlDbType.DateTime).Value = mod.BeginDate;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.PriceFutureID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPriceFuture mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = mod.PriceFutureID;
            cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = mod.PriceGroupID;
            cmd.Parameters.Add("@BeginDate", SqlDbType.DateTime).Value = mod.BeginDate;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPriceFutureID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = intPriceFutureID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPriceFuture GetModel(int intPriceFutureID)
        {
            SqlCommand cmd = new SqlCommand("STP_PriceFutureGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PriceFutureID", SqlDbType.Int).Value = intPriceFutureID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPriceFuture mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MPriceFuture> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_PriceFutureGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MPriceFuture SetModel(SqlDataReader dr)
        {
            Models.MPriceFuture mod = new Models.MPriceFuture();
            while (dr.Read())
            {
                mod.PriceFutureID = int.Parse(dr["PriceFutureID"].ToString());
                mod.PriceGroupID = dr["PriceGroupID"].ToString();
                mod.BeginDate = DateTime.Parse(dr["BeginDate"].ToString());
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
        private Models.MPriceFuture SetModel(DataRow dr)
        {
            Models.MPriceFuture mod = new Models.MPriceFuture();
            mod.PriceFutureID = int.Parse(dr["PriceFutureID"].ToString());
            mod.PriceGroupID = dr["PriceGroupID"].ToString();
            mod.BeginDate = DateTime.Parse(dr["BeginDate"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPriceFuture> GetList(DataSet ds)
        {
            List<Models.MPriceFuture> li = new List<Models.MPriceFuture>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public DataSet GetListByPriceGroupIDAndBeginDate(string strPriceGroupID, string strBeginDateBegin, string strBeginDateEnd)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.Append(" select a.*,PriceGroup,CreateUserName=u1.NickName,UpdateUserName=u2.NickName from [TB_PriceFuture] a ");
            sbTSQL.Append(" left join ");
            sbTSQL.Append(" TB_PriceGroup g1 on a.PriceGroupID=g1.PriceGroupID ");
            sbTSQL.Append(" left join TB_User u1 ");
            sbTSQL.Append(" on a.CreateUser=u1.UserID ");
            sbTSQL.Append(" left join TB_User u2 ");
            sbTSQL.Append(" on a.CreateUser=u2.UserID ");
            sbTSQL.Append(" Where 1=1 ");
            //訂貨日
            if (strPriceGroupID.Length >0)
            { 
                 sbTSQL.Append(" and a.PriceGroupID=@PriceGroupID ");
                 cmd.Parameters.Add("@PriceGroupID", SqlDbType.NVarChar).Value = strPriceGroupID;
            }


            if (strBeginDateBegin.Length > 0)
            {
                sbTSQL.Append(" and BeginDate >= @BeginDateBegin ");
                cmd.Parameters.Add("@BeginDateBegin", SqlDbType.DateTime).Value = Convert.ToDateTime(strBeginDateBegin);
            }
            if (strBeginDateEnd.Length > 0)
            {
                sbTSQL.Append(" and BeginDate <= @BeginDateEnd ");
                cmd.Parameters.Add("@BeginDateEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(strBeginDateEnd);
            }
          
            sbTSQL.Append(" order by BeginDate desc");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        #region  server 使用

        /// <summary>
        /// 取得今天需更新的價格群組
        /// </summary>
        public List<Models.MPriceFuture> GetListBeginDate()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.Append(" select * from [dbo].[TB_PriceFuture] where cast(BeginDate as Date)=cast(GetDate() as Date)  ");

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }


        #endregion

        #endregion
    }
}
