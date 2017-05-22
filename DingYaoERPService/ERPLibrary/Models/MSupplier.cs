using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Supplier
    /// </summary>
    [Serializable]
    public class MSupplier
    {
        public MSupplier() { }

        /// <summary>
        /// 供應商代碼
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 供應商簡稱
        /// </summary>
        public string SupplierShort { get; set; }

        /// <summary>
        /// 供應商名稱
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 讀音碼
        /// </summary>
        public string SupplierKeyboard { get; set; }

        /// <summary>
        /// 付款條件
        /// </summary>
        public string PaymentTerms { get; set; }

        /// <summary>
        /// 請款方式
        /// </summary>
        public string IncomeMethod { get; set; }

        /// <summary>
        /// 搭贈計算日
        /// </summary>
        public int GiftDate { get; set; }

        /// <summary>
        /// 聯絡人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 負責人
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 介紹人
        /// </summary>
        public string Introducer { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 是否完成新增
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        public string Unifyno { get; set; }

        /// <summary>
        /// 發票抬頭
        /// </summary>
        public string UnifynoTitle { get; set; }

        /// <summary>
        /// 是否開發票
        /// </summary>
        public bool UniformInvoice { get; set; }

        /// <summary>
        /// 發票開立-公司
        /// </summary>
        public bool InvoiceCompany { get; set; }

        /// <summary>
        /// 發票開立-個人
        /// </summary>
        public bool InvoicePersonal { get; set; }

        /// <summary>
        /// 發票開立-公司開始
        /// </summary>
        public int? InvoiceCompanyFrom { get; set; }

        /// <summary>
        /// 發票開立-公司結束
        /// </summary>
        public int? InvoiceCompanyTo { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public decimal Debt { get; set; }

        /// <summary>
        /// 最後一筆付款單號
        /// </summary>
        public string MaxPaymentNo { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }

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
