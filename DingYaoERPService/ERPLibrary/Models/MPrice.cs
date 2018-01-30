using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Price
    /// </summary>
    public class MPrice
    {
        public MPrice() { }

        /// <summary>
        /// 售價序號
        /// </summary>
        public int PriceID { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 價格群組代號
        /// </summary>
        public string PriceGroupID { get; set; }

        /// <summary>
        /// 最低價格數量
        /// </summary>
        public decimal PriceQty { get; set; }

        /// <summary>
        /// 售價
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 提醒方式(價差;毛利)
        /// </summary>
        public string CheckType { get; set; }

        /// <summary>
        /// 提醒最小值
        /// </summary>
        public decimal MinValue { get; set; }

        /// <summary>
        /// 提醒最大值
        /// </summary>
        public decimal MaxValue { get; set; }

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

        /// <summary>
        /// 前次售價
        /// </summary>
        public decimal PriceOld { get; set; }

    }
}
