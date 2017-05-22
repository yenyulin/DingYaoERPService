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
    public class DSummons
    {
        public DSummons() { }

        #region  自訂方法

        /// <summary>
        /// 取得所有應該上傳至文中的資料
        /// </summary>
        public DataSet GetListNotUpLoad()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append(" select * from TB_Summons where IsUpLoadDone=0 ");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 以SummonsID取得SummonsAccount資料
        /// </summary>
        public DataSet GetListBySummonsID(string strSummonsID)
        {
            SqlCommand cmd = new SqlCommand("STP_SummonsAccountGetBySummonsID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SummonsID", SqlDbType.NVarChar).Value = strSummonsID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
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

        #endregion

    }
}
