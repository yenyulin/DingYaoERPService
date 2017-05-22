using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Customer
    /// </summary>
    public class MCustomer
    {
        public MCustomer() { }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }
              

        /// <summary>
        /// 總公司代碼
        /// </summary>
        public string PCustomerID { get; set; }

        /// <summary>
        /// 顧客類別代號
        /// </summary>
        public string CustomerTypeID { get; set; }

        /// <summary>
        /// 顧客等級代號
        /// </summary>
        public int CustomerLevelID { get; set; }

        /// <summary>
        /// 前次顧客等級代號
        /// </summary>
        public int CustomerLevelIDLast { get; set; }

        /// <summary>
        /// 價格群組代號
        /// </summary>
        public string PriceGroupID { get; set; }

        /// <summary>
        /// 訂單類別序號
        /// </summary>
        public int OrderTypeID { get; set; }

        /// <summary>
        /// 顧客讀音碼
        /// </summary>
        public string CustomerKeyboard { get; set; }

        /// <summary>
        /// 客戶名稱(全名)
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客戶簡稱
        /// </summary>
        public string CustomerShort { get; set; }

        /// <summary>
        /// 客戶密碼
        /// </summary>
        public string CustomerPassword { get; set; }

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
        /// 發票條件
        /// </summary>
        public string UnifynoMethod { get; set; }

        /// <summary>
        /// 發票備註
        /// </summary>
        public string UnifynoRemarks { get; set; }

        /// <summary>
        /// 是否列印發票明細
        /// </summary>
        public bool UnifynoDetail { get; set; }


        /// <summary>
        /// 付款條件序號
        /// </summary>
        public int PaymentTermsID { get; set; }

        /// <summary>
        /// 付款條件
        /// </summary>
        public string PaymentTerms { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 付款日
        /// </summary>
        public int? PaymentDays { get; set; }

        /// <summary>
        /// 負責人
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 聯絡人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 送貨梯次
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 物流人員代碼
        /// </summary>
        public string DeliveryManID { get; set; }

        /// <summary>
        /// 訂單提醒使用Email
        /// </summary>
        public bool RemindEmail { get; set; }

        /// <summary>
        /// 訂單提醒使用簡訊
        /// </summary>
        public bool RemindSMS { get; set; }

        /// <summary>
        /// 訂單提醒 (不提醒 時間提醒 工作日提醒)
        /// </summary>
        public string Remind { get; set; }

        /// <summary>
        /// 提醒天數
        /// </summary>
        public int? RemindDay { get; set; }

        /// <summary>
        /// 提醒時間
        /// </summary>
        public DateTime? RemindTime { get; set; }

        /// <summary>
        /// 是否列印標籤
        /// </summary>
        public bool PrintLabels { get; set; }

        /// <summary>
        /// 注意事項1
        /// </summary>
        public string Note1 { get; set; }

        /// <summary>
        /// 注意事項2
        /// </summary>
        public string Note2 { get; set; }

        /// <summary>
        /// 星級
        /// </summary>
        public string Star { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 是否完成新增
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// 應收款項
        /// </summary>
        public decimal? AccountReceivable { get; set; }

        /// <summary>
        /// 累計未收款出貨天數
        /// </summary>
        public int? AccountReceivableDays { get; set; }

        /// <summary>
        /// 強迫催收周期
        /// </summary>
        public int? TradeDays { get; set; }

        /// <summary>
        /// 催收工作說明
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// 排除開始時間
        /// </summary>
        public DateTime? ExcludeDateBegin { get; set; }

        /// <summary>
        /// 排除結束時間
        /// </summary>
        public DateTime? ExcludeDateEnd { get; set; }

        /// <summary>
        /// 提醒設定狀態(啟用、停用)
        /// </summary>
        public bool RemindStatus { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public decimal Debt { get; set; }

        /// <summary>
        /// 最後一筆收款單號
        /// </summary>
        public string MaxIncomeNo { get; set; }

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
        /// 是否抽紅單
        /// </summary>
        public bool Red { get; set; }

        /// <summary>
        /// 介紹人
        /// </summary>
        public string Referrer { get; set; }

        /// <summary>
        /// 失聯
        /// </summary>
        public bool Disconnected { get; set; }

        /// <summary>
        /// 信用額度
        /// </summary>
        public decimal? Credits { get; set; }

        /// <summary>
        /// 預收款
        /// </summary>
        public decimal? AdvancePayment { get; set; }

        /// <summary>
        /// 是否顯示CAS
        /// </summary>
        public bool IsCAS { get; set; }

        /// <summary>
        /// web 開通狀態 (未開通、開通、過期)
        /// </summary>
        public string UseWebStatus { get; set; }

        /// <summary>
        /// APP開通狀態 (未開通、開通、過期)
        /// </summary>
        public string UseAppStatus { get; set; }

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
