using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// PriceFuture
    /// </summary>
    public class MPriceFuture
    {
        public MPriceFuture() { }

        /// <summary>
        /// 未來價格序號
        /// </summary>
        public int PriceFutureID { get; set; }

        /// <summary>
        /// 價格群組代號
        /// </summary>
        public string PriceGroupID { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime BeginDate { get; set; }

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
