using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Stock
    /// </summary>
    public class MStock
    {
        public MStock() { }

        /// <summary>
        /// 產品編號
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 廠區代號
        /// </summary>
        public int FactoryID { get; set; }

        /// <summary>
        /// 庫存類別(一般庫存、特價庫存、進貨退回暫存、出貨退回暫存)
        /// </summary>
        public string StockType { get; set; }

        /// <summary>
        /// 生產日期(進貨日、加工日)
        /// </summary>
        public DateTime StockDate { get; set; }

        /// <summary>
        /// 保存期限
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// 庫存量
        /// </summary>
        public decimal StockQty { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string UpdateUser { get; set; }

    }
}
