using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// DeliveryManPerformanceMonth
    /// </summary>
    public class MDeliveryManPerformanceMonth
    {
        public MDeliveryManPerformanceMonth() { }

        /// <summary>
        /// 
        /// </summary>
        public int DeliveryManPerformanceMonthID { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 累計金額
        /// </summary>
        public decimal TotalSumMoney { get; set; }

        /// <summary>
        /// 累計金額排名
        /// </summary>
        public int TotalSumMoneyRank { get; set; }

        /// <summary>
        /// 總包裝重量
        /// </summary>
        public decimal OrderTotalWeight { get; set; }

        /// <summary>
        /// 總包裝重量排名
        /// </summary>
        public int OrderTotalWeightRank { get; set; }

        /// <summary>
        /// 累計筆數
        /// </summary>
        public decimal OrderTotalCount { get; set; }

        /// <summary>
        /// 累計筆數排名
        /// </summary>
        public int OrderTotalCountRank { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        public decimal SubMile { get; set; }

        /// <summary>
        /// 里程排名
        /// </summary>
        public int SubMileRank { get; set; }

        /// <summary>
        /// 加油數量
        /// </summary>
        public decimal SubOil { get; set; }

        /// <summary>
        /// 加油數量排名
        /// </summary>
        public int SubOilRank { get; set; }

        /// <summary>
        /// 里程/公升
        /// </summary>
        public decimal OilMil { get; set; }

        /// <summary>
        /// 里程/公升排名
        /// </summary>
        public int OilMilRank { get; set; }

    }
}
