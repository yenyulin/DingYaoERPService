using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// CustomerMonthSubAR
    /// </summary>
    public class MCustomerMonthSubAR
    {
        public MCustomerMonthSubAR() { }

        /// <summary>
        /// 客戶每月銷貨總計序號
        /// </summary>
        public int CustomerMonthSubARID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 訂貨天數
        /// </summary>
        public int? OrderDayCount { get; set; }

        /// <summary>
        /// 購物頻率
        /// </summary>
        public decimal? PurchaseFrequency { get; set; }

        /// <summary>
        /// 月銷貨金額
        /// </summary>
        public decimal OrderAccountsReceivable { get; set; }

        /// <summary>
        /// 月退貨金額
        /// </summary>
        public decimal ReturnAccountsReceivable { get; set; }

        /// <summary>
        /// 月訂單產品總重量
        /// </summary>
        public decimal OrderSubWeight { get; set; }

        /// <summary>
        /// 月退貨產品總重量
        /// </summary>
        public decimal ReturnSubWeight { get; set; }

        /// <summary>
        /// 訂單總數量
        /// </summary>
        public decimal OrderSubQty { get; set; }

        /// <summary>
        /// 退貨總數量
        /// </summary>
        public decimal ReturnSubQty { get; set; }

        /// <summary>
        /// 銷貨總計=訂單金額-退貨
        /// </summary>
        public decimal SubAccountsReceivable { get; set; }

        /// <summary>
        /// 累計金額
        /// </summary>
        public decimal CumulateAmount { get; set; }

        /// <summary>
        /// 顧客等級代號
        /// </summary>
        public int CustomerLevelID { get; set; }

        /// <summary>
        /// 當月排行
        /// </summary>
        public int RecordSeq { get; set; }

        /// <summary>
        /// 紀錄年分
        /// </summary>
        public int RecordYear { get; set; }

        /// <summary>
        /// 紀錄月分
        /// </summary>
        public int RecordMonth { get; set; }

        /// <summary>
        /// 記錄日期
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
