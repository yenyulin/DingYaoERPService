using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// CustomerLevel
    /// </summary>
    public class MCustomerLevel
    {
        public MCustomerLevel() { }

        /// <summary>
        /// 顧客等級代號
        /// </summary>
        public int CustomerLevelID { get; set; }

        /// <summary>
        /// 顧客等級
        /// </summary>
        public string CustomerLevel { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public int? MinAmount { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public int? MaxAmount { get; set; }

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
