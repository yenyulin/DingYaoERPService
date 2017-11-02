using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// Inventory
    /// </summary>
    public class MInventory
    {
        public MInventory() { }

        /// <summary>
        /// 盤點序號
        /// </summary>
        public int InventoryID { get; set; }

        /// <summary>
        /// 廠區代號
        /// </summary>
        public int FactoryID { get; set; }

        /// <summary>
        /// 盤點時間
        /// </summary>
        public DateTime InventoryDate { get; set; }

        /// <summary>
        /// 月盤點、即時盤點
        /// </summary>
        public string InventoryType { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 盤點狀態(盤點中、完成盤點)
        /// </summary>
        public string InventoryStatus { get; set; }

        /// <summary>
        /// 填表人員
        /// </summary>
        public string InputUser { get; set; }

        /// <summary>
        /// 盤點列印時間
        /// </summary>
        public DateTime? InventoryPrint { get; set; }

        /// <summary>
        /// 盤點開始時間
        /// </summary>
        public DateTime? InventoryBegin { get; set; }

        /// <summary>
        /// 盤點完成時間
        /// </summary>
        public DateTime? InventoryEnd { get; set; }

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
