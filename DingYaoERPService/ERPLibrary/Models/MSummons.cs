using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Summons
    /// </summary>
    public class MSummons
    {
        public MSummons() { }

        /// <summary>
        /// 票據序號
        /// </summary>
        public string SummonsID { get; set; }

        /// <summary>
        /// 傳票類型
        /// </summary>
        public string SummonsType { get; set; }

        /// <summary>
        /// 來源編號
        /// </summary>
        public string SummonsSourceNo { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 傳票日期
        /// </summary>
        public DateTime SummonsDate { get; set; }

        /// <summary>
        /// 是否完成上傳
        /// </summary>
        public bool IsUpLoadDone { get; set; }

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
