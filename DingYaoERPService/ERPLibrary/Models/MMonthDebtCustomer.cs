using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// MonthDebtCustomer
    /// </summary>
    public class MMonthDebtCustomer
    {
        public MMonthDebtCustomer() { }

        /// <summary>
        /// 
        /// </summary>
        public int MonthDebtCustomerID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public decimal Debt { get; set; }

        /// <summary>
        /// 紀錄時間
        /// </summary>
        public DateTime RecordDate { get; set; }

    }
}
