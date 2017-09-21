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
    /// 資料存取層 DayAccount
    /// </summary>
    public class DDayAccount
    {
        public DDayAccount() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MDayAccount mod)
        {
            SqlCommand cmd = new SqlCommand("STP_DayAccountAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DayAccountDate", SqlDbType.DateTime).Value = mod.DayAccountDate;
            cmd.Parameters.Add("@Complete", SqlDbType.Bit).Value = mod.Complete;
            cmd.Parameters.Add("@Upload", SqlDbType.Bit).Value = mod.Upload;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.DayAccountID = intID;
            }
            return intID;
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MDayAccount mod)
        {
            SqlCommand cmd = new SqlCommand("STP_DayAccountEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DayAccountID", SqlDbType.Int).Value = mod.DayAccountID;
            cmd.Parameters.Add("@DayAccountDate", SqlDbType.DateTime).Value = mod.DayAccountDate;
            cmd.Parameters.Add("@Complete", SqlDbType.Bit).Value = mod.Complete;
            cmd.Parameters.Add("@Upload", SqlDbType.Bit).Value = mod.Upload;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intDayAccountID)
        {
            SqlCommand cmd = new SqlCommand("STP_DayAccountDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DayAccountID", SqlDbType.Int).Value = intDayAccountID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MDayAccount GetModel(int intDayAccountID)
        {
            SqlCommand cmd = new SqlCommand("STP_DayAccountGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DayAccountID", SqlDbType.Int).Value = intDayAccountID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MDayAccount mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MDayAccount> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_DayAccountGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MDayAccount SetModel(SqlDataReader dr)
        {
            Models.MDayAccount mod = new Models.MDayAccount();
            while (dr.Read())
            {
                mod.DayAccountID = int.Parse(dr["DayAccountID"].ToString());
                mod.DayAccountDate = DateTime.Parse(dr["DayAccountDate"].ToString());
                mod.Complete = bool.Parse(dr["Complete"].ToString());
                mod.Upload = bool.Parse(dr["Upload"].ToString());
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
        private Models.MDayAccount SetModel(DataRow dr)
        {
            Models.MDayAccount mod = new Models.MDayAccount();
            mod.DayAccountID = int.Parse(dr["DayAccountID"].ToString());
            mod.DayAccountDate = DateTime.Parse(dr["DayAccountDate"].ToString());
            mod.Complete = bool.Parse(dr["Complete"].ToString());
            mod.Upload = bool.Parse(dr["Upload"].ToString());
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MDayAccount> GetList(DataSet ds)
        {
            List<Models.MDayAccount> li = new List<Models.MDayAccount>();
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
        public DataSet GetListByAccountDate(string strDayAccountDateBegin,string strDayAccountDateEnd)
        {
            //select * from dbo.TB_DayAccount a left join 
            //(
            //    select dt=cast(IncomeBalanceDate as Date),IncomeCashSum=Sum(IncomeCash),IncomeCheckSum=Sum(IncomeCheck),IncomeTransferSum=Sum(IncomeTransfer)
            //    from TB_Income where Incomebalance='已沖帳' --and  cast(IncomeBalanceDate as Date)=  cast(a.DayAccountDate as Date)	
            //    group by cast(IncomeBalanceDate as Date)
            //)
            //b on b.dt=a.DayAccountDate
            //left join
            //(
            //    select dt=cast(PaymentBalanceDate as Date),PaymentCashSum=Sum(PaymentCash),PaymentCheckSum=Sum(PaymentCheck),PaymentTransferSum=Sum(PaymentTransfer)
            //    from TB_Payment where PaymentBalance='已沖帳'--and  cast(PaymentBalanceDate as Date)=  cast(@TargetDate as Date)	
            //    group by cast(PaymentBalanceDate as Date)
            //)c on c.dt=a.DayAccountDate
            //where DayAccountDate=('')

            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.Append(" select *,TodayCashBalance= isnull(IncomeCashSum,0)-isnull(PaymentCashSum,0) from dbo.TB_DayAccount a left join ");
            sbTSQL.Append(" ( ");
            //sbTSQL.Append(" select dt=cast(IncomeBalanceDate as Date),IncomeCashSum=Sum(IncomeCash),IncomeCheckSum=Sum(IncomeCheck),IncomeTransferSum=Sum(IncomeTransfer) ");
            sbTSQL.Append(" select dt=cast(IncomeBalanceDate as Date),IncomeCashSum=Sum(IncomeCash),IncomeCheckSum=Sum(IncomeCheckTotal),IncomeTransferSum=Sum(IncomeTransfer) ");
            sbTSQL.Append(" from TB_Income where Incomebalance='已沖帳'  ");
            sbTSQL.Append(" group by cast(IncomeBalanceDate as Date) ");
            sbTSQL.Append(" ) ");
            sbTSQL.Append(" b on b.dt=cast(a.DayAccountDate as Date)   ");
            sbTSQL.Append(" left join ");
            sbTSQL.Append(" ( ");
            sbTSQL.Append(" select dt=cast(PaymentBalanceDate as Date),PaymentCashSum=Sum(PaymentCash),PaymentCheckSum=Sum(PaymentCheckTotal),PaymentTransferSum=Sum(PaymentTransfer) ");
            sbTSQL.Append(" from TB_Payment where PaymentBalance='已沖帳' ");
            sbTSQL.Append(" group by cast(PaymentBalanceDate as Date) ");
            sbTSQL.Append(" )c on c.dt=cast(a.DayAccountDate as Date)   ");
            sbTSQL.Append(" left join ");
            sbTSQL.Append(" (");
            sbTSQL.Append(" SELECT dt=cast(DayAccountID as INT) ,Cash2000 = SUM(Cash2000),Cash1000 =SUM(Cash1000),Cash500 =SUM(Cash500),Cash100 =SUM(Cash200),Cash200 =SUM(Cash100),Cash50 = SUM(Cash50), Cash20 = SUM(Cash20), Cash10 = SUM(Cash10), Cash5 = SUM(Cash5), Cash1 = SUM(Cash1),TotalAmount = SUM(Cash2000 * 2000) + SUM(Cash1000 * 1000) + SUM(Cash500 * 500) + SUM(Cash200 * 200) + SUM(Cash100 * 100) + SUM(Cash50 * 50) + SUM(Cash20 * 20) + SUM(Cash10 * 10) + SUM(Cash5 * 5) + SUM(Cash1 * 1)");
            sbTSQL.Append(" FROM TB_DayAccountUser");
            sbTSQL.Append(" GROUP BY cast(DayAccountID as INT)");
            sbTSQL.Append(" ) t on t.dt=cast(a.DayAccountID as INT)");
            sbTSQL.Append(" Where 1=1 ");
            //訂貨日
            if (strDayAccountDateBegin.Length > 0)
            {
                sbTSQL.Append(" and cast(DayAccountDate as Date) >= cast(@DayAccountDateBegin as Date) ");
                cmd.Parameters.Add("@DayAccountDateBegin", SqlDbType.DateTime).Value = Convert.ToDateTime(strDayAccountDateBegin);
            }
            if (strDayAccountDateEnd.Length > 0)
            {
                sbTSQL.Append(" and cast(DayAccountDate as Date) <= cast(@DayAccountDateEnd as Date) ");
                cmd.Parameters.Add("@DayAccountDateEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(strDayAccountDateEnd);
            }
           
            sbTSQL.Append(" order by DayAccountDate desc");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 以結帳日取得單筆DayAccount資料
        /// <summary>
        public Models.MDayAccount GetModelByDayAccountDate(DateTime dtDayAccountDate)
        {
            SqlCommand cmd = new SqlCommand("STP_DayAccountGetByDayAccountDate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DayAccountDate", SqlDbType.DateTime).Value = dtDayAccountDate;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MDayAccount mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        public List<MDayAccount> GetListByLessDayAccountDate(string strDt)
        { 
              SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append("  select * from [TB_DayAccount] where Complete=0 and CAST(DayAccountDate as date) <= Cast(@DayAccountDate as date)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DayAccountDate", SqlDbType.DateTime).Value = Convert.ToDateTime(strDt);
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        public List<MDayAccount> GetListByAccountDate2(string strDt)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append("  select * from [TB_DayAccount] where Complete=0 and CAST(DayAccountDate as date) = Cast(@DayAccountDate as date)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DayAccountDate", SqlDbType.DateTime).Value = Convert.ToDateTime(strDt);
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        public bool CheckAccountDataIsComplete(DateTime dtDayAccountDate)
        { 
            bool isComplete=false;
            Models.MDayAccount mod =GetModelByDayAccountDate(dtDayAccountDate);
            if (mod != null)
            {
                isComplete = mod.Complete;
            }
            return isComplete;
        }

        public List<MDayAccount> GetByUnUpload()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append("  select * from [TB_DayAccount] where Complete=1 and Upload = 0 ");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        #endregion
    }
}
