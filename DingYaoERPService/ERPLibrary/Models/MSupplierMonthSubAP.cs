using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// SupplierMonthSubAP
    /// </summary>
    public class MSupplierMonthSubAP
    {
        public MSupplierMonthSubAP() { }

        /// <summary>
        /// 客戶每月銷貨總計序號
        /// </summary>
        public int SupplierMonthSubAPID { get; set; }

        /// <summary>
        /// 供應商代碼
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 叫貨天數
        /// </summary>
        public int? OrderDayCount { get; set; }

        /// <summary>
        /// 購物頻率
        /// </summary>
        public decimal? OrderFrequency { get; set; }

        /// <summary>
        /// 單月進貨額
        /// </summary>
        public decimal StockInAmount { get; set; }

        /// <summary>
        /// 單月進貨退回金額總計
        /// </summary>
        public decimal StockInAmountReturn { get; set; }

        /// <summary>
        /// 銷貨總計=進貨金額-進貨退回金額
        /// </summary>
        public decimal SubAccountsPayable { get; set; }

        /// <summary>
        /// 累計金額
        /// </summary>
        public decimal CumulateAmount { get; set; }

        /// <summary>
        /// 進貨重量
        /// </summary>
        public decimal StockInWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ReturnWeight { get; set; }

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
