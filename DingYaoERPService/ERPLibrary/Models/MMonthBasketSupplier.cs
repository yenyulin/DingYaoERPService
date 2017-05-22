using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// MonthBasketSupplier
    /// </summary>
    public class MMonthBasketSupplier
    {
        public MMonthBasketSupplier() { }

        /// <summary>
        /// 
        /// </summary>
        public int MonthBasketSupplierID { get; set; }

        /// <summary>
        /// 供應商代碼
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 籃子數量
        /// </summary>
        public int BasketQty { get; set; }

        /// <summary>
        /// 紀錄時間
        /// </summary>
        public DateTime RecordDate { get; set; }

    }
}
