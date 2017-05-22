using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// PriceFutureProduct
    /// </summary>
    public class MPriceFutureProduct
    {
        public MPriceFutureProduct() { }

        /// <summary>
        /// 未來產品價格序號
        /// </summary>
        public int PriceFutureProductID { get; set; }

        /// <summary>
        /// 未來價格序號
        /// </summary>
        public int PriceFutureID { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 最低價格數量
        /// </summary>
        public decimal? PriceQty { get; set; }

        /// <summary>
        /// 售價
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// 提醒方式(價差;毛利)
        /// </summary>
        public string CheckType { get; set; }

        /// <summary>
        /// 提醒最小值
        /// </summary>
        public decimal? MinValue { get; set; }

        /// <summary>
        /// 提醒最大值
        /// </summary>
        public decimal? MaxValue { get; set; }


        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 建立人員
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 更新人員
        /// </summary>
        public string UpdateUser { get; set; }

    }
}
