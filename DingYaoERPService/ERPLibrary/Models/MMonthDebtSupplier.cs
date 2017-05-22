using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// MonthDebtSupplier
    /// </summary>
    public class MMonthDebtSupplier
    {
        public MMonthDebtSupplier() { }

        /// <summary>
        /// 
        /// </summary>
        public int MonthDebtSupplierID { get; set; }

        /// <summary>
        /// 供應商代碼
        /// </summary>
        public string SupplierID { get; set; }

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
