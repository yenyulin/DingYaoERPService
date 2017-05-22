using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// BasketCustomer
    /// </summary> 
    public class MBasketCustomer
    {
        public MBasketCustomer() { }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

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
