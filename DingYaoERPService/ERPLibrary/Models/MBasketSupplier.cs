using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// BasketSupplier
    /// </summary>
    public class MBasketSupplier 
    {
        public MBasketSupplier() { }

        /// <summary>
        /// 供應商代碼
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 籃子數量
        /// </summary>
        public int BasketQty { get; set; }

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
