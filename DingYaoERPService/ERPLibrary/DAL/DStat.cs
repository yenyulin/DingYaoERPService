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
    /// 資料存取層 DStat
    /// </summary>
    public class DStat
    {
        public DStat() { }


        #region 自訂

        /// <summary>
        /// 司機績效
        /// </summary>
        public DataSet GetDeliveryManPerformance3(string strDateBegin, string strDateEnd, int intYear, int intMonth, bool bolInterval, string strOrderBy, string strUserID)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            //if(strOrderBy=="SubMile")
            //{
            //    strOrderBy="y.Mile";
            //}
            //else if(strOrderBy=="SubOil")
            //{
            //    strOrderBy="y.Oil";
            //}
            //else if(strOrderBy=="OilMil")
            //{
            //    strOrderBy="Mile/Oil";
            //}
            sbTSQL.Append(" select *  from ( ");
            sbTSQL.Append(" select  ");

            sbTSQL.Append(" DENSE_RANK() OVER( ORDER BY TotalSumMoney DESC) AS TotalSumMoneySeq, ");
            sbTSQL.Append(" DENSE_RANK() OVER( ORDER BY OrderTotalWeight DESC) AS OrderTotalWeightSeq, ");
            sbTSQL.Append(" DENSE_RANK() OVER( ORDER BY OrderTotalCount DESC) AS OrderTotalCountSeq, ");
            sbTSQL.Append(" DENSE_RANK() OVER( ORDER BY y.Oil DESC) AS OilSeq, ");
            sbTSQL.Append(" DENSE_RANK() OVER( ORDER BY y.Mile DESC) AS MileSeq, ");
            sbTSQL.Append(" DENSE_RANK() OVER( ORDER BY Mile/Oil DESC) AS MileOilSeq, ");


            sbTSQL.Append(" x.*  ");

            sbTSQL.Append(" ,(sum(ISNULL(OrderTotalCount,0)) over ()) as  OrderTotalCountTotalCount  ,(sum(ISNULL(TotalSumMoney,0)) over () ) as TotalTotalSumMoneyCount ");
            sbTSQL.Append(" ,SubOil=ISNULL(y.Oil,0),(SUM (ISNULL(y.Oil,0)) OVER ()) as SubOilTotalCount,SubMile=ISNULL(y.Mile,0),(SUM (ISNULL(y.Mile,0)) OVER ()) as SubMileTotalCount,OilMil= Mile/Oil,u.UserName from ");
            sbTSQL.Append(" ( ");
            sbTSQL.Append(" 	select DeliveryManID,OrderTotalWeight=ISNULL(Sum(TotalWeight),0),sum(ISNULL(Sum(TotalWeight),0)) over () OrderTotalWeightCount ");
            sbTSQL.Append(" 	,OrderTotalCount=ISNULL(Sum(OrderCount),0)");
            sbTSQL.Append(" 	,TotalSumMoney=ISNULL(Sum(SubTotalSumMoney),0)  ");

            sbTSQL.Append(" 	from  ");
            sbTSQL.Append(" 	( ");
            sbTSQL.Append(" 		select DeliveryManID,CarID,CarTaskID from TB_CarTask  ");
            sbTSQL.Append(" 		where  1=1 ");

            if (bolInterval)
            {
                if (strDateBegin.Length > 0)
                {
                    sbTSQL.Append(" and CarTaskDate >= cast( @DateBegin as date)  ");
                }
                if (strDateEnd.Length > 0)
                {
                    sbTSQL.Append(" and CarTaskDate <= cast( @DateEnd as date) ");
                }
            }
            else
            {
                sbTSQL.Append("  and Year(CarTaskDate)=@Year and Month(CarTaskDate)=@Month ");
            }

            sbTSQL.Append(" 	)a left join ");
            sbTSQL.Append(" 	( ");
            //--重量 訂單筆數
            sbTSQL.Append(" 		select CarTaskID,TotalWeight=ISNULL(Sum(TotalWeight),0),OrderCount=Count(*),SubTotalSumMoney=ISNULL(Sum(SumMoney),0) ");
            sbTSQL.Append(" 		from TB_Order o left join TB_AccountsReceivable o2 on o.OrderID=o2.AccountsReceivableNo ");
            sbTSQL.Append(" 		where CarTaskID in  ");
            sbTSQL.Append(" 		( ");
            sbTSQL.Append(" 			select CarTaskID from TB_CarTask  ");
            //sbTSQL.Append(" 			where  Year(CarTaskDate)=@Year and Month(CarTaskDate)=@Month ");
            sbTSQL.Append(" 			where  1=1 ");
            if (bolInterval)
            {
                if (strDateBegin.Length > 0)
                {
                    sbTSQL.Append(" and CarTaskDate >= cast( @DateBegin as date)  ");
                }
                if (strDateEnd.Length > 0)
                {
                    sbTSQL.Append(" and CarTaskDate <= cast( @DateEnd as date) ");
                }
            }
            else
            {
                sbTSQL.Append("  and Year(CarTaskDate)=@Year and Month(CarTaskDate)=@Month ");
            }

            sbTSQL.Append(" 		) ");
            sbTSQL.Append(" 		group by CarTaskID ");
            sbTSQL.Append(" 	)c on a.CarTaskID=c.CarTaskID ");
            sbTSQL.Append(" 	group by DeliveryManID ");
            sbTSQL.Append(" )x left join  ");
            sbTSQL.Append(" ( ");
            //--里程 加油數量
            sbTSQL.Append(" 	select OilUser,Oil=Sum(OilQty*OilAmount),Mile=Sum(MileageEnd-MileageStart)  ");
            sbTSQL.Append(" 	from TB_CarOil  ");
            sbTSQL.Append(" 	where  1=1 ");
            if (bolInterval)
            {
                if (strDateBegin.Length > 0)
                {
                    sbTSQL.Append(" and OilDate >= cast( @DateBegin as date)  ");
                }
                if (strDateEnd.Length > 0)
                {
                    sbTSQL.Append(" and OilDate <= cast( @DateEnd as date) ");
                }
            }
            else
            {
                sbTSQL.Append("  and Year(OilDate)=@Year and Month(OilDate)=@Month ");
            }

            sbTSQL.Append(" 	group by OilUser ");
            sbTSQL.Append(" )y on x.DeliveryManID=y.OilUser ");
            sbTSQL.Append(" left join TB_User u on x.DeliveryManID=u.UserID ");
            //sbTSQL.Append(" order by " + strOrderBy);
            sbTSQL.Append(" ) xx where 1=1 ");
            if (strUserID.Length > 0)
            {
                sbTSQL.Append(" and DeliveryManID=@DeliveryManID ");
                cmd.Parameters.Add("@DeliveryManID", SqlDbType.NVarChar).Value = strUserID;
            }

            if (bolInterval)
            {
                if (strDateBegin.Length > 0)
                {
                    cmd.Parameters.Add("@DateBegin", SqlDbType.DateTime).Value = Convert.ToDateTime(strDateBegin);
                }
                if (strDateEnd.Length > 0)
                {
                    cmd.Parameters.Add("@DateEnd", SqlDbType.DateTime).Value = Convert.ToDateTime(strDateEnd);
                }
            }
            else
            {
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            }


            if (strOrderBy == "TotalSumMoney")
            {
                sbTSQL.Append(" order by TotalSumMoneySeq ");
            }
            else if (strOrderBy == "OrderTotalWeight")
            {
                sbTSQL.Append(" order by OrderTotalWeightSeq ");
            }
            else if (strOrderBy == "OrderTotalCount")
            {
                sbTSQL.Append(" order by OrderTotalCountSeq ");
            }
            else if (strOrderBy == "SubMile")
            {
                sbTSQL.Append(" order by MileSeq ");
            }
            else if (strOrderBy == "SubOil")
            {
                sbTSQL.Append(" order by OilSeq ");
            }
            else if (strOrderBy == "OilMil")
            {
                sbTSQL.Append(" order by MileOilSeq ");
            }


            //cmd.Parameters.Add("@Year", SqlDbType.Int).Value = intYear;
            //cmd.Parameters.Add("@Month", SqlDbType.Int).Value = intMonth;
            //cmd.Parameters.Add("@LastYear", SqlDbType.Int).Value = intLastYear;
            //cmd.Parameters.Add("@LastMonth", SqlDbType.Int).Value = intLastMonth;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return ds;
        }


        #endregion

    }
}