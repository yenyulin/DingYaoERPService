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
    /// 資料存取層 CustomerMonthSubAR
    /// </summary>
    public class DCustomerMonthSubAR
    {
        public DCustomerMonthSubAR() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MCustomerMonthSubAR mod)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = mod.CustomerID;
            cmd.Parameters.Add("@OrderDayCount", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.OrderDayCount);
            cmd.Parameters.Add("@PurchaseFrequency", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.PurchaseFrequency);
            cmd.Parameters.Add("@OrderAccountsReceivable", SqlDbType.Decimal).Value = mod.OrderAccountsReceivable;
            cmd.Parameters.Add("@ReturnAccountsReceivable", SqlDbType.Decimal).Value = mod.ReturnAccountsReceivable;
            cmd.Parameters.Add("@OrderSubWeight", SqlDbType.Decimal).Value = mod.OrderSubWeight;
            cmd.Parameters.Add("@ReturnSubWeight", SqlDbType.Decimal).Value = mod.ReturnSubWeight;
            cmd.Parameters.Add("@OrderSubQty", SqlDbType.Decimal).Value = mod.OrderSubQty;
            cmd.Parameters.Add("@ReturnSubQty", SqlDbType.Decimal).Value = mod.ReturnSubQty;
            cmd.Parameters.Add("@SubAccountsReceivable", SqlDbType.Decimal).Value = mod.SubAccountsReceivable;
            cmd.Parameters.Add("@CumulateAmount", SqlDbType.Decimal).Value = mod.CumulateAmount;
            cmd.Parameters.Add("@CustomerLevelID", SqlDbType.Int).Value = mod.CustomerLevelID;
            //cmd.Parameters.Add("@RecordSeq", SqlDbType.Int).Value = mod.RecordSeq;
            cmd.Parameters.Add("@RecordYear", SqlDbType.Int).Value = mod.RecordYear;
            cmd.Parameters.Add("@RecordMonth", SqlDbType.Int).Value = mod.RecordMonth;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.CustomerMonthSubARID = intID;
            }
            return intID;
        }
       
        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MCustomerMonthSubAR SetModel(SqlDataReader dr)
        {
            Models.MCustomerMonthSubAR mod = new Models.MCustomerMonthSubAR();
            while (dr.Read())
            {
                mod.CustomerMonthSubARID = int.Parse(dr["CustomerMonthSubARID"].ToString());
                mod.CustomerID = dr["CustomerID"].ToString();
                mod.OrderDayCount = SQLUtil.GetInt(dr["OrderDayCount"]);
                mod.PurchaseFrequency = SQLUtil.GetDecimal(dr["PurchaseFrequency"]);
                mod.OrderAccountsReceivable = Decimal.Parse(dr["OrderAccountsReceivable"].ToString());
                mod.ReturnAccountsReceivable = Decimal.Parse(dr["ReturnAccountsReceivable"].ToString());
                mod.OrderSubWeight = Decimal.Parse(dr["OrderSubWeight"].ToString());
                mod.ReturnSubWeight = Decimal.Parse(dr["ReturnSubWeight"].ToString());
                mod.OrderSubQty = Decimal.Parse(dr["OrderSubQty"].ToString());
                mod.ReturnSubQty = Decimal.Parse(dr["ReturnSubQty"].ToString());
                mod.SubAccountsReceivable = Decimal.Parse(dr["SubAccountsReceivable"].ToString());
                mod.CumulateAmount = Decimal.Parse(dr["CumulateAmount"].ToString());
                mod.CustomerLevelID = int.Parse(dr["CustomerLevelID"].ToString());
                mod.RecordSeq = int.Parse(dr["RecordSeq"].ToString());
                mod.RecordYear = int.Parse(dr["RecordYear"].ToString());
                mod.RecordMonth = int.Parse(dr["RecordMonth"].ToString());
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MCustomerMonthSubAR SetModel(DataRow dr)
        {
            Models.MCustomerMonthSubAR mod = new Models.MCustomerMonthSubAR();
            mod.CustomerMonthSubARID = int.Parse(dr["CustomerMonthSubARID"].ToString());
            mod.CustomerID = dr["CustomerID"].ToString();
            mod.OrderDayCount = SQLUtil.GetInt(dr["OrderDayCount"]);
            mod.PurchaseFrequency = SQLUtil.GetDecimal(dr["PurchaseFrequency"]);
            mod.OrderAccountsReceivable = Decimal.Parse(dr["OrderAccountsReceivable"].ToString());
            mod.ReturnAccountsReceivable = Decimal.Parse(dr["ReturnAccountsReceivable"].ToString());
            mod.OrderSubWeight = Decimal.Parse(dr["OrderSubWeight"].ToString());
            mod.ReturnSubWeight = Decimal.Parse(dr["ReturnSubWeight"].ToString());
            mod.OrderSubQty = Decimal.Parse(dr["OrderSubQty"].ToString());
            mod.ReturnSubQty = Decimal.Parse(dr["ReturnSubQty"].ToString());
            mod.SubAccountsReceivable = Decimal.Parse(dr["SubAccountsReceivable"].ToString());
            mod.CumulateAmount = Decimal.Parse(dr["CumulateAmount"].ToString());
            mod.CustomerLevelID = int.Parse(dr["CustomerLevelID"].ToString());
            mod.RecordSeq = int.Parse(dr["RecordSeq"].ToString());
            mod.RecordYear = int.Parse(dr["RecordYear"].ToString());
            mod.RecordMonth = int.Parse(dr["RecordMonth"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MCustomerMonthSubAR> GetList(DataSet ds)
        {
            List<Models.MCustomerMonthSubAR> li = new List<Models.MCustomerMonthSubAR>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得所有客戶上個月的總銷售金額及叫貨頻率
        /// </summary>
        public DataSet GetLastMonthOrderStaticsAndPurchaseFrequency(int intYear, int intMonth)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerGetLastMonthOrderStaticsAndPurchaseFrequency");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MCustomerMonthSubAR GetModelByCustomerIDAndYearAndMonth(string strCustomerID, int intYear, int intMonth)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetByCustomerIDAndYearAndMonth");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MCustomerMonthSubAR mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }


        /// <summary>
        /// 取得所有客戶上個月的總銷售金額及叫貨頻率
        /// </summary>
        public bool SetSeqByYearAndMonth(int intYear, int intMonth)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARSetSeqByYearAndMonth");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }


        /// <summary>
        /// 以客戶及年份取得今年累計銷售額
        /// <summary>
        public DataSet GetModelGroupByCustomerIDAndYearAndMonth(string strCustomerID, int intYear)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetGroupByCustomerIDAndYear");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
            //SqlDataReader dr = SQLUtil.QueryDR(cmd);
            //bool isHasRows = dr.HasRows;
            //Models.MCustomerMonthSubAR mod = SetModel(dr);
            //dr.Close();
            //return isHasRows ? mod : null;        

        }

        /// <summary>
        /// 取得所有客戶上個月的總銷售金額及叫貨頻率
        /// </summary>
        public DataSet GetByYearAndMonth(int intYear, int intMonth, int intLastYear, int intLastMonth, string strKeyword, string strLevelID, int intRankCount,bool bolShowAll)
        {

            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.Append(" select * from  (");

            sbTSQL.Append(" select ROW_NUMBER() OVER(order by b.RecordSeq,b.CustomerID ) AS ROWID ,b.RecordSeq, b.CustomerID, a.CustomerName,b.PurchaseFrequency,b.SubAccountsReceivable ,lastSeq=lastRecord.RecordSeq,lastLevel= lastRecord.CustomerLevelID,b.CumulateAmount,ThisMonthLevel= lv1.CustomerLevel,LastMonthLevel= lv2.CustomerLevel from ");
            sbTSQL.Append(" (  ");
            sbTSQL.Append(" 	select * from [TB_CustomerMonthSubAR] Where RecordYear =@Year and RecordMonth=@Month  ");
            sbTSQL.Append(" )b  ");
            sbTSQL.Append(" left join  ");
            sbTSQL.Append(" (  ");
            sbTSQL.Append(" 	select * from [TB_CustomerMonthSubAR] Where RecordYear =@LastYear and RecordMonth=@LastMonth  ");
            sbTSQL.Append(" )lastRecord on lastRecord.CustomerID=b.CustomerID  ");
         
            sbTSQL.Append(" left join TB_CustomerLevel lv1 on b.CustomerLevelID=lv1.CustomerLevelID  ");
            sbTSQL.Append(" left join TB_CustomerLevel lv2 on lastRecord.CustomerLevelID=lv2.CustomerLevelID  ");
            sbTSQL.Append(" left join TB_Customer a on b.CustomerID=a.CustomerID ");


            //sbTSQL.Append(" select ROW_NUMBER() OVER(order by b.RecordSeq,a.CustomerID ) AS ROWID ,b.RecordSeq,a.CustomerLevelID, a.CustomerID, a.CustomerName,b.PurchaseFrequency,b.SubAccountsReceivable ,lastSeq=lastRecord.RecordSeq,lastLevel= lastRecord.CustomerLevelID,b.CumulateAmount,ThisMonthLevel= lv1.CustomerLevel,LastMonthLevel= lv2.CustomerLevel from TB_Customer a left join ");
            //sbTSQL.Append(" ( ");
            //sbTSQL.Append(" 	select * from [TB_CustomerMonthSubAR] Where RecordYear =@Year and RecordMonth=@Month ");
            //sbTSQL.Append(" )b on a.CustomerID=b.CustomerID ");
            //sbTSQL.Append(" left join ");
            //sbTSQL.Append(" ( ");
            //sbTSQL.Append(" 	select * from [TB_CustomerMonthSubAR] Where RecordYear =@LastYear and RecordMonth=@LastMonth ");
            //sbTSQL.Append(" )lastRecord on lastRecord.CustomerID=a.CustomerID ");
         
            //sbTSQL.Append(" left join TB_CustomerLevel lv1 on a.CustomerLevelID=lv1.CustomerLevelID ");
            //sbTSQL.Append(" left join TB_CustomerLevel lv2 on lastRecord.CustomerLevelID=lv2.CustomerLevelID ");
            sbTSQL.Append(" where 1=1 ");

            if (strKeyword.Length > 0)
            {
                sbTSQL.Append(" and a.CustomerID in (select CustomerID from TB_Customer where ( CustomerKeyboard like @Keyword or CustomerID like @Keyword or CustomerName like @Keyword or CustomerShort like @Keyword )) ");
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + strKeyword + "%";
            }
            if (strLevelID.Length > 0)
            { 
                 sbTSQL.Append(" and b.CustomerLevelID=@LevelID ");
                 cmd.Parameters.Add("@LevelID", SqlDbType.Int).Value = Convert.ToInt32(strLevelID);
            }
            if (!bolShowAll)
            {
                sbTSQL.Append(" and not b.RecordSeq =0 ");
            }

           
            sbTSQL.Append(" )x where 1=1  ");
            if (intRankCount > 0)
            {
                sbTSQL.Append(" And ROWID <=@RankCount ");
                cmd.Parameters.Add("@RankCount", SqlDbType.Int).Value = intRankCount;
            }


            sbTSQL.Append(" order by ROWID ");

            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            cmd.Parameters.Add("@LastYear", SqlDbType.Int).Value = intLastYear;
            cmd.Parameters.Add("@LastMonth", SqlDbType.Int).Value = intLastMonth;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;

        }


        public DataSet GetRecordYear()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append(" select RecordYear from [TB_CustomerMonthSubAR] ");
            sbTSQL.Append(" group by RecordYear ");
            sbTSQL.Append(" order by RecordYear desc ");

            sbTSQL.Append(" select RecordYear,RecordMonth from [TB_CustomerMonthSubAR] ");
            sbTSQL.Append(" group by RecordYear, RecordMonth ");
            sbTSQL.Append(" order by RecordYear desc,RecordMonth  ");

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }


        /// <summary>
        /// 以年份及月份取得等級統計資料
        /// <summary>
        public DataSet GetLevelStaticByYearAndMonth(int intYear, int intMonth)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetLevelStaticByYearAndMonth");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }


        /// <summary>
        /// 取得年度客戶等級銷售統計
        /// <summary>
        public DataSet GetStaticByYear(int intYear)
        {
            SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetStaticByYear");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }
        #endregion
    }
}
