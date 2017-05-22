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
    /// 資料存取層 SupplierMonthSubAP
    /// </summary>
    public class DSupplierMonthSubAP
    {
        public DSupplierMonthSubAP() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MSupplierMonthSubAP mod)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierMonthSubAPAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = mod.SupplierID;
            cmd.Parameters.Add("@OrderDayCount", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.OrderDayCount);
            cmd.Parameters.Add("@OrderFrequency", SqlDbType.Decimal).Value = SQLUtil.CheckDBValue(mod.OrderFrequency);
            cmd.Parameters.Add("@StockInAmount", SqlDbType.Decimal).Value = mod.StockInAmount;
            cmd.Parameters.Add("@StockInAmountReturn", SqlDbType.Decimal).Value = mod.StockInAmountReturn;
            cmd.Parameters.Add("@SubAccountsPayable", SqlDbType.Decimal).Value = mod.SubAccountsPayable;
            cmd.Parameters.Add("@CumulateAmount", SqlDbType.Decimal).Value = mod.CumulateAmount;
            cmd.Parameters.Add("@StockInWeight", SqlDbType.Decimal).Value = mod.StockInWeight;
            cmd.Parameters.Add("@ReturnWeight", SqlDbType.Decimal).Value = mod.ReturnWeight;
            //cmd.Parameters.Add("@RecordSeq", SqlDbType.Int).Value = mod.RecordSeq;
            cmd.Parameters.Add("@RecordYear", SqlDbType.Int).Value = mod.RecordYear;
            cmd.Parameters.Add("@RecordMonth", SqlDbType.Int).Value = mod.RecordMonth;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.SupplierMonthSubAPID = intID;
            }
            return intID;
        }


       /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MSupplierMonthSubAP SetModel(SqlDataReader dr)
        {
            Models.MSupplierMonthSubAP mod = new Models.MSupplierMonthSubAP();
            while (dr.Read())
            {
                mod.SupplierMonthSubAPID =  int.Parse(dr["SupplierMonthSubAPID"].ToString());
                mod.SupplierID =  dr["SupplierID"].ToString();
                mod.OrderFrequency = SQLUtil.GetDecimal(dr["OrderFrequency"]);
                mod.StockInAmount =  Decimal.Parse(dr["StockInAmount"].ToString());
                mod.StockInAmountReturn =  Decimal.Parse(dr["StockInAmountReturn"].ToString());
                mod.SubAccountsPayable =  Decimal.Parse(dr["SubAccountsPayable"].ToString());
                mod.CumulateAmount =  Decimal.Parse(dr["CumulateAmount"].ToString());
                mod.StockInWeight =  Decimal.Parse(dr["StockInWeight"].ToString());
                mod.ReturnWeight =  Decimal.Parse(dr["ReturnWeight"].ToString());
                mod.RecordSeq =  int.Parse(dr["RecordSeq"].ToString());
                mod.RecordYear =  int.Parse(dr["RecordYear"].ToString());
                mod.RecordMonth =  int.Parse(dr["RecordMonth"].ToString());
                mod.CreateDate =  DateTime.Parse(dr["CreateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MSupplierMonthSubAP SetModel(DataRow dr)
        {
        Models.MSupplierMonthSubAP mod = new Models.MSupplierMonthSubAP();
            mod.SupplierMonthSubAPID =  int.Parse(dr["SupplierMonthSubAPID"].ToString());
            mod.SupplierID =  dr["SupplierID"].ToString();
            mod.OrderFrequency = SQLUtil.GetDecimal(dr["OrderFrequency"]);
            mod.StockInAmount =  Decimal.Parse(dr["StockInAmount"].ToString());
            mod.StockInAmountReturn =  Decimal.Parse(dr["StockInAmountReturn"].ToString());
            mod.SubAccountsPayable =  Decimal.Parse(dr["SubAccountsPayable"].ToString());
            mod.CumulateAmount =  Decimal.Parse(dr["CumulateAmount"].ToString());
            mod.StockInWeight =  Decimal.Parse(dr["StockInWeight"].ToString());
            mod.ReturnWeight =  Decimal.Parse(dr["ReturnWeight"].ToString());
            mod.RecordSeq =  int.Parse(dr["RecordSeq"].ToString());
            mod.RecordYear =  int.Parse(dr["RecordYear"].ToString());
            mod.RecordMonth =  int.Parse(dr["RecordMonth"].ToString());
            mod.CreateDate =  DateTime.Parse(dr["CreateDate"].ToString());
            return mod;
        }

        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MSupplierMonthSubAP> GetList(DataSet ds)
        {
            List<Models.MSupplierMonthSubAP> li = new List<Models.MSupplierMonthSubAP>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }


        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得所有供應商上個月的總訂購金額及叫貨頻率
        /// </summary>
        public DataSet GetLastMonthOrderStaticsAndPurchaseFrequency(int intYear, int intMonth)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierGetLastMonthOrderStaticsAndOrderFrequency");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        ///// <summary>
        ///// 取得單筆資料
        ///// <summary>
        //public Models.MSupplierMonthSubAP GetModelByCustomerIDAndYearAndMonth(string strCustomerID, int intYear, int intMonth)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetByCustomerIDAndYearAndMonth");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = strCustomerID;
        //    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
        //    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
        //    SqlDataReader dr = SQLUtil.QueryDR(cmd);
        //    bool isHasRows = dr.HasRows;
        //    Models.MSupplierMonthSubAP mod = SetModel(dr);
        //    dr.Close();
        //    return isHasRows ? mod : null;
        //}


        /// <summary>
        /// 取得所有客戶上個月的總銷售金額及叫貨頻率
        /// </summary>
        public bool SetSeqByYearAndMonth(int intYear, int intMonth)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierMonthSubAPSetSeqByYearAndMonth");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }


        /// <summary>
        /// 以客戶及年份取得今年累計銷售額
        /// <summary>
        public DataSet GetModelGroupBySupplierIDAndYear(string strSupplierID, int intYear)
        {
            SqlCommand cmd = new SqlCommand("STP_SupplierMonthSubAPGetGroupBySupplierIDAndYear");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.NVarChar).Value = strSupplierID;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        ///// <summary>
        ///// 取得所有客戶上個月的總銷售金額及叫貨頻率
        ///// </summary>
        //public DataSet SetSeqByYearAndMonth(int intYear, int intMonth, int intLastYear, int intLastMonth, string strKeyword, string strLevelID, int intRankCount, bool bolShowAll)
        //{

        //    SqlCommand cmd = new SqlCommand();
        //    StringBuilder sbTSQL = new StringBuilder();

        //    sbTSQL.Append(" select * from  (");

        //    sbTSQL.Append(" select ROW_NUMBER() OVER(order by b.RecordSeq,b.CustomerID ) AS ROWID ,b.RecordSeq, b.CustomerID, a.CustomerName,b.PurchaseFrequency,b.SubAccountsReceivable ,lastSeq=lastRecord.RecordSeq,lastLevel= lastRecord.CustomerLevelID,b.CumulateAmount,ThisMonthLevel= lv1.CustomerLevel,LastMonthLevel= lv2.CustomerLevel from ");
        //    sbTSQL.Append(" (  ");
        //    sbTSQL.Append(" 	select * from [TB_CustomerMonthSubAR] Where RecordYear =@Year and RecordMonth=@Month  ");
        //    sbTSQL.Append(" )b  ");
        //    sbTSQL.Append(" left join  ");
        //    sbTSQL.Append(" (  ");
        //    sbTSQL.Append(" 	select * from [TB_CustomerMonthSubAR] Where RecordYear =@LastYear and RecordMonth=@LastMonth  ");
        //    sbTSQL.Append(" )lastRecord on lastRecord.CustomerID=b.CustomerID  ");

        //    sbTSQL.Append(" left join TB_CustomerLevel lv1 on b.CustomerLevelID=lv1.CustomerLevelID  ");
        //    sbTSQL.Append(" left join TB_CustomerLevel lv2 on lastRecord.CustomerLevelID=lv2.CustomerLevelID  ");
        //    sbTSQL.Append(" left join TB_Customer a on b.CustomerID=a.CustomerID ");

        //    sbTSQL.Append(" where 1=1 ");

        //    if (strKeyword.Length > 0)
        //    {
        //        sbTSQL.Append(" and a.CustomerID in (select CustomerID from TB_Customer where ( CustomerKeyboard like @Keyword or CustomerID like @Keyword or CustomerName like @Keyword or CustomerShort like @Keyword )) ");
        //        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + strKeyword + "%";
        //    }
        //    if (strLevelID.Length > 0)
        //    {
        //        sbTSQL.Append(" and b.CustomerLevelID=@LevelID ");
        //        cmd.Parameters.Add("@LevelID", SqlDbType.Int).Value = Convert.ToInt32(strLevelID);
        //    }
        //    if (!bolShowAll)
        //    {
        //        sbTSQL.Append(" and not b.RecordSeq =0 ");
        //    }


        //    sbTSQL.Append(" )x where 1=1  ");
        //    if (intRankCount > 0)
        //    {
        //        sbTSQL.Append(" And ROWID <=@RankCount ");
        //        cmd.Parameters.Add("@RankCount", SqlDbType.Int).Value = intRankCount;
        //    }


        //    sbTSQL.Append(" order by ROWID ");

        //    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
        //    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
        //    cmd.Parameters.Add("@LastYear", SqlDbType.Int).Value = intLastYear;
        //    cmd.Parameters.Add("@LastMonth", SqlDbType.Int).Value = intLastMonth;

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = sbTSQL.ToString();
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return ds;

        //}


        public DataSet GetRecordYear()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append(" select RecordYear from [TB_CustomerMonthSubAR] ");
            sbTSQL.Append(" group by RecordYear ");
            sbTSQL.Append(" order by RecordYear desc ");

            sbTSQL.Append(" select RecordYear,RecordMonth from [TB_SupplierMonthSubAP] ");
            sbTSQL.Append(" group by RecordYear, RecordMonth ");
            sbTSQL.Append(" order by RecordYear desc,RecordMonth  ");

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }


        ///// <summary>
        ///// 以年份及月份取得等級統計資料
        ///// <summary>
        //public DataSet GetLevelStaticByYearAndMonth(int intYear, int intMonth)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetLevelStaticByYearAndMonth");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
        //    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return ds;
        //}


        ///// <summary>
        ///// 取得年度客戶等級銷售統計
        ///// <summary>
        //public DataSet GetStaticByYear(int intYear)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_CustomerMonthSubARGetStaticByYear");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return ds;
        //}

        #endregion
    }
}
