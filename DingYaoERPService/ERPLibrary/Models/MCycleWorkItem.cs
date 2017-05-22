using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// CycleWorkItem
    /// </summary>
    public class MCycleWorkItem
    {
        public MCycleWorkItem() { }

        /// <summary>
        /// 週期工作項序號
        /// </summary>
        public int CycleWorkItemID { get; set; }

        /// <summary>
        /// 固定工作管理設定序號
        /// </summary>
        public int CycleWorkItemSettingID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 負責人員代號
        /// </summary>
        public string ChargePerson { get; set; }

        /// <summary>
        /// 工作說明
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// 工作項狀態(未完成、已完成)
        /// </summary>
        public string CycleWorkItemStatus { get; set; }

        /// <summary>
        /// 作業紀錄
        /// </summary>
        public string CycleWorkItemReamrks { get; set; }

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
