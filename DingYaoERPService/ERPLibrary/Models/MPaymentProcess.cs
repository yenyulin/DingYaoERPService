using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// PaymentProcess
    /// </summary>
    public class MPaymentProcess
    {
        public MPaymentProcess() { }

        /// <summary>
        /// 催收工作序號
        /// </summary>
        public int PaymentProcessID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 付款條件序號
        /// </summary>
        public int PaymentTermsID { get; set; }

        /// <summary>
        /// 負責人員代號
        /// </summary>
        public string ChargePerson { get; set; }

        /// <summary>
        /// 催收說明
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// 催收工作狀態(未完成、已完成)
        /// </summary>
        public string PaymentProcessStatus { get; set; }

        /// <summary>
        /// 作業紀錄
        /// </summary>
        public string PaymentProcessReamrks { get; set; }

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
