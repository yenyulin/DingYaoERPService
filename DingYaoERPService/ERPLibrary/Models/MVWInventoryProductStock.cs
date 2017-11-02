using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// VWInventoryProductStock
    /// </summary>
    [Serializable]
    public class MVWInventoryProductStock
    {
        public MVWInventoryProductStock() { }

        /// <summary>
        /// 盤點序號
        /// </summary>
        public int InventoryID { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        public string ProductCode { get; set; }
  
        /// <summary>
        /// 一般盤點量
        /// </summary>
        public decimal? CheckQty1 { get; set; }

        /// <summary>
        /// 特價盤點量
        /// </summary>
        public decimal? CheckQty2 { get; set; }

        /// <summary>
        /// 一般盤點系統紀錄庫存量
        /// </summary>
        public decimal? StockQtySys1 { get; set; }

        /// <summary>
        /// 特價盤點系統紀錄庫存量
        /// </summary>
        public decimal? StockQtySys2 { get; set; }

        /// <summary>
        /// ERP庫存量(一般及市購)
        /// </summary>
        public decimal? StockQtyERP1 { get; set; }

        /// <summary>
        /// ERP庫存量(特價)
        /// </summary>
        public decimal? StockQtyERP2 { get; set; }

        /// <summary>
        /// 月份盤點後庫存量(一般及市購)
        /// </summary>
        public decimal? StockQtyMonth1 { get; set; }

        /// <summary>
        /// 月份盤點後庫存量(特價)
        /// </summary>
        public decimal? StockQtyMonth2 { get; set; }

        /// <summary>
        /// 生產日期(進貨日、加工日) for 一般 市購
        /// </summary>
        public DateTime? StockDate1 { get; set; }

        /// <summary>
        /// 保存期限 for 一般 市購
        /// </summary>
        public DateTime? ExpirationDate1 { get; set; }

        /// <summary>
        /// 生產日期(進貨日、加工日) for 特價
        /// </summary>
        public DateTime? StockDate2 { get; set; }

        /// <summary>
        /// 保存期限 for 特價
        /// </summary>
        public DateTime? ExpirationDate2 { get; set; }

        /// <summary>
        /// 廠區代號
        /// </summary>
        public int FactoryID { get; set; }

        /// <summary>
        /// 產品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 冷凍、冷藏、市溫、常溫、市凍、市藏
        /// </summary>
        public string Pr { get; set; }

        /// <summary>
        /// 一般庫存量
        /// </summary>
        public decimal? StockQty1 { get; set; }

        /// <summary>
        /// 特價庫存量
        /// </summary>
        public decimal? StockQty2 { get; set; }

        /// <summary>
        /// 市購庫存量
        /// </summary>
        public decimal? StockQty3 { get; set; }
        ///// <summary>
        ///// 出貨退回暫存庫存量
        ///// </summary>
        //public decimal StockQty3 { get; set; }

        ///// <summary>
        ///// 進貨退回暫存存庫量
        ///// </summary>
        //public decimal StockQty4 { get; set; }

        ///// <summary>
        ///// 產品01類的售價
        ///// </summary>
        //public decimal Price { get; set; }
    }
}
