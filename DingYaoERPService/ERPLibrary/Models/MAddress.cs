using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Address
    /// </summary>
    [Serializable]
    public class MAddress
    {
        public MAddress() { }

        /// <summary>
        /// 地址序號
        /// </summary>
        public int AddressID { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 供應商代碼
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string ZIPCode { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 物流人員代碼(上午)
        /// </summary>
        public string DeliveryManID1 { get; set; }

        /// <summary>
        /// 物流人員代碼(下午)
        /// </summary>
        public string DeliveryManID2 { get; set; }

        /// <summary>
        /// 順序
        /// </summary>
        public int Seq { get; set; }

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
