using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// SummonsAccount
    /// </summary>
    public class MSummonsAccount
    {
        public MSummonsAccount() { }

        /// <summary>
        /// 票據序號
        /// </summary>
        public string SummonsID { get; set; }

        /// <summary>
        /// 會計科目編號
        /// </summary>
        public object AccountID { get; set; }

        /// <summary>
        /// 會計科目名稱
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 借1/貸2
        /// </summary>
        public string DebitCredit { get; set; }

        /// <summary>
        /// 款項
        /// </summary>
        public decimal SumMoney { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

    }
}
