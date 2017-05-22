using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// MonthBasketCustomer
    /// </summary>
    public class MMonthBasketCustomer
    {
        public MMonthBasketCustomer() { }

        /// <summary>
        /// 
        /// </summary>
        public int MonthBasketCustomerID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

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
