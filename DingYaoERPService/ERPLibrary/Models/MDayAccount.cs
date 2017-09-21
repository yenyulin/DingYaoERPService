using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// DayAccount
    /// </summary>
    public class MDayAccount
    {
        public MDayAccount() { }

        /// <summary>
        /// 每日結帳序號
        /// </summary>
        public int DayAccountID { get; set; }

        /// <summary>
        /// 結帳日
        /// </summary>
        public DateTime DayAccountDate { get; set; }

        /// <summary>
        /// 關帳
        /// </summary>
        public bool Complete { get; set; }

        /// <summary>
        /// 上傳至文中
        /// </summary>
        public bool Upload { get; set; }

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
