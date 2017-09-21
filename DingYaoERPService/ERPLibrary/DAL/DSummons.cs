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
    /// 資料存取層 Summons
    /// </summary>
    public class DSummons
    {
        public DSummons() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MSummons mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsType", SqlDbType.NVarChar).Value = mod.SummonsType;
            cmd.Parameters.Add("@SummonsSourceNo", SqlDbType.NVarChar).Value = mod.SummonsSourceNo;
            //cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = mod.SummonsID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@SummonsDate", SqlDbType.DateTime).Value = mod.SummonsDate;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            return SQLUtil.ExecuteScalar(cmd).ToString();
            //return SQLUtil.ExecuteSql(cmd) > 0 ? mod.SummonsID : null;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        public string AddByDate(Models.MSummons mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAddByDate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsType", SqlDbType.NVarChar).Value = mod.SummonsType;
            cmd.Parameters.Add("@SummonsSourceNo", SqlDbType.NVarChar).Value = mod.SummonsSourceNo;
            //cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = mod.SummonsID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@SummonsDate", SqlDbType.DateTime).Value = mod.SummonsDate;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            return SQLUtil.ExecuteScalar(cmd).ToString();
            //return SQLUtil.ExecuteSql(cmd) > 0 ? mod.SummonsID : null;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MSummons mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = mod.SummonsID;
            cmd.Parameters.Add("@SummonsType", SqlDbType.NVarChar).Value = mod.SummonsType;
            cmd.Parameters.Add("@SummonsSourceNo", SqlDbType.NVarChar).Value = mod.SummonsSourceNo;
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = mod.Remarks;
            cmd.Parameters.Add("@SummonsDate", SqlDbType.DateTime).Value = mod.SummonsDate;
            cmd.Parameters.Add("@IsUpLoadDone", SqlDbType.Bit).Value = mod.IsUpLoadDone;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MSummons GetModel(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MSummons mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MSummons> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_SummonsGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MSummons SetModel(SqlDataReader dr)
        {
            Models.MSummons mod = new Models.MSummons();
            while (dr.Read())
            {
                mod.SummonsID = dr["SummonsID"].ToString();
                mod.SummonsType = dr["SummonsType"].ToString();
                mod.Remarks = dr["Remarks"].ToString();
                mod.SummonsDate = DateTime.Parse(dr["SummonsDate"].ToString());
                mod.IsUpLoadDone = bool.Parse(dr["IsUpLoadDone"].ToString());
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
        private Models.MSummons SetModel(DataRow dr)
        {
            Models.MSummons mod = new Models.MSummons();
            mod.SummonsID = dr["SummonsID"].ToString();
            mod.SummonsType = dr["SummonsType"].ToString();
            mod.Remarks = dr["Remarks"].ToString();
            mod.SummonsDate = DateTime.Parse(dr["SummonsDate"].ToString());
            mod.IsUpLoadDone = bool.Parse(dr["IsUpLoadDone"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MSummons> GetList(DataSet ds)
        {
            List<Models.MSummons> li = new List<Models.MSummons>();
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
        public DataSet GetListByDateTypeAndKeyword(string strDueDateBegin, string strDueDateEnd, string strSummonsType, string strKeyword)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            //sbTSQL.Append(" select * from TB_Summons ");
            sbTSQL.Append(" select a.*,SummonsSource=SourceNoAll,Summary from TB_Summons ");
            sbTSQL.Append(" a left join  ");
            sbTSQL.Append(" ( ");
            sbTSQL.Append(" select SummonsID ");
            sbTSQL.Append(" ,SourceNoAll=STUFF(cast((SELECT '、'+SourceNo from TB_SummonsSource where SummonsID = a.SummonsID FOR XML PATH('')) as nvarchar(1000)) ,1,1,'') ");
            sbTSQL.Append(" from TB_SummonsSource a  ");
            sbTSQL.Append(" Group by SummonsID ");
            sbTSQL.Append(" )b on a.SummonsID=b.SummonsID ");
            sbTSQL.Append(" left join ");
            sbTSQL.Append(" ( ");
            sbTSQL.Append(" select  ItemIndex = ROW_NUMBER() OVER(PARTITION BY SummonsID ORDER BY SummonsID),* from TB_SummonsAccount ");
            sbTSQL.Append(" )Accounts on a.SummonsID=Accounts.SummonsID and ItemIndex=1 ");
            sbTSQL.Append(" where 1=1 ");
            //建立日
            if (strDueDateBegin.Length > 0)
            {
                sbTSQL.Append(" and  cast (SummonsDate  as date) >= @DueDateBegin ");
                cmd.Parameters.Add("@DueDateBegin", SqlDbType.DateTime).Value = Convert.ToDateTime(strDueDateBegin);
            }
            if (strDueDateEnd.Length > 0)
            {
                sbTSQL.Append(" and  cast (SummonsDate  as date) <= @DueDateEnd ");
                cmd.Parameters.Add("@DueDateEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(strDueDateEnd);
            }
            if (strSummonsType.Length > 0)
            {
                sbTSQL.Append(" and SummonsType=@SummonsType ");
                cmd.Parameters.Add("@SummonsType", SqlDbType.NVarChar).Value = strSummonsType;
            }
            if (strKeyword != "")
            {
                sbTSQL.Append(" and (a.SummonsID like @Keyword or SourceNoAll like @Keyword or Summary like @Keyword )");
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + strKeyword + "%";
            }


            sbTSQL.Append(" order by a.SummonsID desc");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;

        }

        /// <summary>
        /// 取得所有應該上傳至文中的資料
        /// </summary>
        public DataSet GetListNotUpLoad(string strDt)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append("  select * from TB_Summons where IsUpLoadDone=0 and CAST(SummonsDate as date) <= Cast(@SummonsDate as date)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SummonsDate", SqlDbType.DateTime).Value = Convert.ToDateTime(strDt);
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;

        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool UpdateForOpen(string strDate, string strUpdateUserID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsUpdateForOpen");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsDate", SqlDbType.DateTime).Value = Convert.ToDateTime(strDate);
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = strUpdateUserID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }


        /// <summary>
        /// 以id取得資料並更新為已上傳資料
        /// <summary>
        public bool EditUpload(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsEditUpload");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }


        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MSummons GetModelByTypeAndNo(string strSummonsType, string strSummonsSourceNo)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsGetByTypeAndNo");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsType", SqlDbType.NVarChar).Value = strSummonsType;
            cmd.Parameters.Add("@SummonsSourceNo", SqlDbType.NVarChar).Value = strSummonsSourceNo;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MSummons mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        #endregion
    }
}
