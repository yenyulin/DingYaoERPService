﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DingYaoERP.Common;
using DingYaoERP.DAL;
using DingYaoERP.Models;
using ERPServiceTest.LZWZIP;

using NPOI.SS.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace ERPServiceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SetZipCode();

            DataSet ds = new DCycleWorkItem().GetProcessWorkItemSetting();
            DateTime dtNow = DateTime.Now;

            //textBox1.Text = ds.Tables[0].Rows.Count.ToString();

            try
            {
                //SetCycleWork();
                //UpdateMonthRecord();
                //UpdateAccountsSummonsAccounts();
                //SetZipCode();
                //SetCycleWork();
                //SetPaymentProcess();

                //DateTime dt = DateTime.Now.AddMonths(-1);
                //SetDeliveryManPerformanceMonth(Convert.ToInt32(dt.Year),Convert.ToInt32(dt.Month));

                //CreateCustomerAndSupplierExcel();
                UpdateCustomerMonthSumMoneyAndPurchaseFrequency();
                //UpdateSupplierMonthSumMoneyAndPurchaseFrequency();

                //SetDeliveryManPerformanceMonth();

                textBox1.Text = "Done";
            }
            catch (Exception ex)
            { textBox1.Text = ex.ToString(); }
        }

        #region  更新供應商總訂購金額叫貨頻率進貨重量退貨重量

        protected void UpdateSupplierMonthSumMoneyAndPurchaseFrequency()
        {
            try
            {
                //預設
                //DateTime dt = DateTime.Now;
                DateTime dt = Convert.ToDateTime("2017/5/1");
                

                DateTime dtNow = Convert.ToDateTime(dt.AddMonths(-1).ToString("yyyy/MM/dd"));
                int intYear = Convert.ToInt32(dtNow.ToString("yyyy"));
                int intMonth = Convert.ToInt32(dtNow.ToString("MM"));
                DataSet ds = new DSupplierMonthSubAP().GetLastMonthOrderStaticsAndPurchaseFrequency(intYear, intMonth);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string strSupplierID=dr["SupplierID"].ToString();
                    //string strSumMoney = dr["SumMoney"].ToString();
                    string strOrderDueDateCount = dr["OrderDueDateCount"].ToString();
                    string strOrderCount = dr["OrderCount"].ToString();


                    string strSumMoney1 =dr["SumMoney1"].ToString();
                    string strSumMoney2 =dr["SumMoney2"].ToString();
                    string strSubTotal =dr["SubTotal"].ToString();
                    string strStockInWeight1 = dr["StockInWeight1"].ToString();
                    string strStockInWeight2 = dr["StockInWeight2"].ToString();

                    if (strSumMoney1.Length == 0)
                    { 
                        strSumMoney1 = "0";
                    }
                    if (strSumMoney2.Length == 0)
                    { 
                        strSumMoney2 = "0";
                    }
                    if (strStockInWeight1.Length == 0)
                    {
                        strStockInWeight1 = "0";
                    }
                    if (strStockInWeight2.Length == 0)
                    {
                        strStockInWeight2 = "0";
                    }

                    if (strSubTotal.Length == 0)
                    {
                        strSubTotal = "0";
                    }
                    decimal decAccountsPayable = Convert.ToDecimal(strSubTotal);

                    if (strOrderCount.Length == 0)
                    {
                        strOrderCount = "0";
                    }

                    MSupplierMonthSubAP mod = new MSupplierMonthSubAP();
                    mod.SupplierID = strSupplierID;

                    if (strOrderDueDateCount.Length == 0)
                    {
                        mod.OrderFrequency = null;
                        mod.OrderDayCount = null;
                    }
                    else
                    {
                        mod.OrderFrequency = Convert.ToDecimal(strOrderDueDateCount);
                        mod.OrderDayCount = Convert.ToInt32(strOrderCount);
                    }
                    mod.StockInAmount = Convert.ToDecimal(strSumMoney1); ;
                    mod.StockInAmountReturn = Convert.ToDecimal(strSumMoney2);
                    mod.SubAccountsPayable = decAccountsPayable;

                    decimal decTotal = 0;
                    DataSet dsSubTotal = new DSupplierMonthSubAP().GetModelGroupBySupplierIDAndYear(strSupplierID, intYear);
                    foreach (DataRow drSubTotal in dsSubTotal.Tables[0].Rows)
                    {
                        if (drSubTotal["SubTotal"].ToString().Length > 0)
                        {
                            decTotal = Convert.ToDecimal(drSubTotal["SubTotal"].ToString());
                        }
                    }
                    mod.CumulateAmount = decAccountsPayable + decTotal;

                    mod.StockInWeight = Convert.ToDecimal(strStockInWeight1);
                    mod.ReturnWeight = Convert.ToDecimal(strStockInWeight2);

                    mod.RecordYear = intYear;
                    mod.RecordMonth = intMonth;
                    new DSupplierMonthSubAP().Add(mod);

                }

                new DSupplierMonthSubAP().SetSeqByYearAndMonth(intYear, intMonth);
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "供應商取上月資料更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 405);
            }

        }

        #endregion

        #region  更新客戶總銷售金額及叫貨頻率及排名

        protected void UpdateCustomerMonthSumMoneyAndPurchaseFrequency()
        {
            try
            {
                //預設
                //DateTime dt = DateTime.Now;

                DateTime dt = Convert.ToDateTime("2017/4/1");

                List<MCustomerLevel> liLevel = new DCustomerLevel().GetList();

                int intMinLevel = 10;
                foreach (MCustomerLevel mCuLevle in liLevel)
                {
                    if (mCuLevle.MinAmount == 0)
                    {
                        intMinLevel = mCuLevle.CustomerLevelID;
                    }
                }


                DateTime dtNow = Convert.ToDateTime(dt.AddMonths(-1).ToString("yyyy/MM/dd"));                
                int intYear=Convert.ToInt32(dtNow.ToString("yyyy"));
                int intMonth=Convert.ToInt32(dtNow.ToString("MM"));
                DataSet ds = new DCustomerMonthSubAR().GetLastMonthOrderStaticsAndPurchaseFrequency(intYear, intMonth);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                   

                    string strCustomerID=dr["CustomerID"].ToString();
                    string strCustomerLevelID=dr["CustomerLevelID"].ToString();
                    string strSumMoney=dr["SumMoney"].ToString();
                    string strOrderDueDateCount=dr["OrderDueDateCount"].ToString();
                    string strOrderDayCount = dr["OrderDayCount"].ToString();

                    string strOrderAccountsReceivable = dr["OrderAccountsReceivable"].ToString();
                    string strReturnAccountsReceivable = dr["ReturnAccountsReceivable"].ToString();
                    string strOrderSubQty = dr["OrderSubQty"].ToString();
                    string strOrderSubWeight = dr["OrderSubWeight"].ToString();
                    string strReturnSubQty = dr["ReturnSubQty"].ToString();
                    string strReturnSubWeight = dr["ReturnSubWeight"].ToString();
                    

                    MCustomer mCu = new DCustomer().GetModel(strCustomerID);
                    mCu.CustomerLevelIDLast = Convert.ToInt32(strCustomerLevelID);
                    mCu.CustomerLevelID = intMinLevel;
                    
                    if (strSumMoney.Length== 0)
                    {
                        strSumMoney = "0";
                    }
                    decimal decSubAccountsReceivable = Convert.ToDecimal(strSumMoney);

                    if (strOrderDayCount.Length == 0)
                    {
                        strOrderDayCount = "0";
                    }

                    if (strOrderAccountsReceivable.Length == 0)
                    {
                        strOrderAccountsReceivable = "0";
                    }

                    if (strReturnAccountsReceivable.Length == 0)
                    {
                        strReturnAccountsReceivable = "0";
                    }

                    if (strOrderSubQty.Length == 0)
                    {
                        strOrderSubQty = "0";
                    }
                    if (strOrderSubWeight.Length == 0)
                    {
                        strOrderSubWeight = "0";
                    }
                    if (strReturnSubQty.Length == 0)
                    {
                        strReturnSubQty = "0";
                    }
                    if (strReturnSubWeight.Length == 0)
                    {
                        strReturnSubWeight = "0";
                    }
                    
                    MCustomerMonthSubAR mod = new MCustomerMonthSubAR();
                    mod.CustomerID = strCustomerID;
                  
                    if (strOrderDueDateCount.Length == 0)
                    {
                        mod.PurchaseFrequency = null;
                        mod.OrderDayCount = null;
                    }
                    else
                    {
                        mod.PurchaseFrequency = Convert.ToDecimal(strOrderDueDateCount);
                        mod.OrderDayCount = Convert.ToInt32(strOrderDayCount);
                    }
                    mod.SubAccountsReceivable = decSubAccountsReceivable;

                    mod.OrderAccountsReceivable = Convert.ToDecimal(strOrderAccountsReceivable);
                    mod.ReturnAccountsReceivable = Convert.ToDecimal(strReturnAccountsReceivable);
                    mod.OrderSubQty = Convert.ToDecimal(strOrderSubQty);
                    mod.OrderSubWeight = Convert.ToDecimal(strOrderSubWeight);
                    mod.ReturnSubQty = Convert.ToDecimal(strReturnSubQty);
                    mod.ReturnSubWeight = Convert.ToDecimal(strReturnSubWeight);

                    decimal decTotal=0;
                    DataSet dsSubTotal = new DCustomerMonthSubAR().GetModelGroupByCustomerIDAndYearAndMonth(strCustomerID,intYear);
                    foreach(DataRow drSubTotal in dsSubTotal.Tables[0].Rows)
                    {
                        if (drSubTotal["SubTotal"].ToString().Length > 0)
                        {
                            decTotal = Convert.ToDecimal(drSubTotal["SubTotal"].ToString());
                        }
                    }
                    mod.CumulateAmount = decSubAccountsReceivable + decTotal;

                            

                    #region  判斷levelid

                    foreach (MCustomerLevel mCuLevle in liLevel)
                    {
                        //最大值
                        if (mCuLevle.MinAmount != null && mCuLevle.MaxAmount == null)
                        {
                            if (Convert.ToDecimal(mCuLevle.MinAmount) < decSubAccountsReceivable)
                            {
                                mCu.CustomerLevelID = mCuLevle.CustomerLevelID;
                                intMinLevel = mCuLevle.CustomerLevelID;
                            }
                        }
                        else
                        {
                            if (mCuLevle.MinAmount != null && mCuLevle.MaxAmount != null)
                            {
                                if (Convert.ToDecimal(mCuLevle.MinAmount) <= decSubAccountsReceivable && Convert.ToDecimal(mCuLevle.MaxAmount) > decSubAccountsReceivable)
                                {
                                    mCu.CustomerLevelID = mCuLevle.CustomerLevelID;
                                    intMinLevel = mCuLevle.CustomerLevelID;
                                }
                            }
                        }
                    }

                    new DCustomer().Edit(mCu);

                    #endregion


                    mod.CustomerLevelID = intMinLevel;

                    mod.RecordYear = intYear;
                    mod.RecordMonth = intMonth;
                    new DCustomerMonthSubAR().Add(mod);

                }
                  
                new DCustomerMonthSubAR().SetSeqByYearAndMonth(intYear,intMonth);
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "客戶取上月資料更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 405);
            }

        }

        #endregion

        #region 建立客戶供應商excel

        /// <summary>
        /// 驗證數字
        /// </summary>
        /// <param name="strNumber">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsNumber(string strValue)
        {
            return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strValue);
        }

        protected void CreateCustomerAndSupplierExcel()
        {
            try
            {
                FolderCheck();
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("客戶供應商檔");
                IRow iRow;
                ICell iCell;

                #region 樣式設定
                
                //儲存格樣式-標題
                ICellStyle icsTitle = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Center, IndexedColors.White.Index, IndexedColors.Black.Index, true, "", false, false, 12);
                //儲存格樣式-欄位名稱
                ICellStyle icsHeader = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Center, IndexedColors.Black.Index, IndexedColors.White.Index, false, "");
                //儲存格樣式-文字置左
                ICellStyle icsTxtLeft = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Left, IndexedColors.White.Index, IndexedColors.Black.Index, false, "");
                //儲存格樣式-文字置中
                ICellStyle icsTxtCenter = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Center, IndexedColors.White.Index, IndexedColors.Black.Index, false, "");
                //儲存格樣式-文字置右
                ICellStyle icsTxtRight = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Right, IndexedColors.White.Index, IndexedColors.Black.Index, false, "");
                //儲存格樣式-整數
                ICellStyle icsNumberRight = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Right, IndexedColors.White.Index, IndexedColors.Black.Index, false, "#,##0");
                //儲存格樣式-日期
                ICellStyle icsDate = NOPICellStyle.SetStyle(workbook, NPOI.SS.UserModel.HorizontalAlignment.Center, IndexedColors.White.Index, IndexedColors.Black.Index, false, "yyyy/MM/dd");

                //設定欄位寬度
                sheet.SetColumnWidth(0, 20 * 180);
                sheet.SetColumnWidth(1, 20 * 180);
                sheet.SetColumnWidth(2, 20 * 180);
                sheet.SetColumnWidth(3, 20 * 180);
                sheet.SetColumnWidth(4, 20 * 180);
                sheet.SetColumnWidth(5, 20 * 180);
                sheet.SetColumnWidth(6, 20 * 180);
                sheet.SetColumnWidth(7, 20 * 300);
                sheet.SetColumnWidth(8, 20 * 300);
                sheet.SetColumnWidth(9, 20 * 180);
                sheet.SetColumnWidth(10, 20 * 180);
                sheet.SetColumnWidth(11, 20 * 180);
                sheet.SetColumnWidth(12, 20 * 180);

               

                #endregion
                int intRow = 0;
                iRow = sheet.CreateRow(intRow);


                String[] strTitle="客戶供應商代號|客戶供應商類別|客戶供應商簡稱|客戶供應商全稱|行業別|類別科目代號|統一編號|稅籍編號|郵遞區號|發票地址|聯絡地址|送貨地址|電話(發票地址)|電話(公司地址)|電話(送貨地址)|傳真|數據機種類|傳呼機號碼|行動電話|網址|負責人|聯絡人|備註(30C)|銷售折數|等級|區域|進貨折數|部門\\工地編號|業務員代號|服務人員|建立日期|最近交易日|信用額度|保證額度|抵押額度|已用額度|開立發票方式|收款方式|匯款銀行代號|匯款帳號|結帳方式(作廢不使用)|銷貨後幾個月結帳|銷貨後逢幾日結帳|結帳後幾個月收款|結帳後逢幾日收款|收款後幾個月兌現|收款後逢幾日兌現|進貨後幾個月結帳|進貨後逢幾日結帳|結帳後幾個月付款|結帳後逢幾日付款|付款後幾個月兌現|付款後逢幾日兌現|郵遞區號(聯絡地址)|郵遞區號(送貨地址)|職稱|專案\\項目編號|請款客戶|EAMIL ADDRS|收款/付款方式(描述)|交貨/收貨方式|進出口交易方式|交易幣別|英文負責人|英文聯絡人|電子發票通知方式|發票預設捐贈|預設發票捐贈對象|自定義欄位一|自定義欄位二|自定義欄位三|自定義欄位四|自定義欄位五|自定義欄位六|自定義欄位七|自定義欄位八|自定義欄位九|自定義欄位十|自定義欄位十一|自定義欄位十二|會員卡號|客供商英文名稱|客戶英文地址|銷貨結帳終止日|進貨結帳終止日|銷貨收款週期選項|進貨付款週期選項|進貨收付條件|客供商英文聯絡電話|匯款戶名|使用電子發票|單價含稅否|批次結帳|發票服務平台登入密碼|聯絡地址經度|聯絡地址緯度|列印紙本電子發票|電子發票資料不上傳|發票交付方式".Split('|');


                int intCell = 0;
                #region 第二行 header

                //IRow headerRow = sheet.CreateRow(1);

                foreach(string str in strTitle)
                {
                    iCell = iRow.CreateCell(intCell);
                    iCell.SetCellValue(str);
                    iCell.CellStyle = icsHeader;
                    intCell++;
                }
                
	 					

                #endregion

                #region 必填
                #endregion

                DataSet ds = new DCustomerSupplierForAccount().GetCustomerAndSupplierForAccount();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    intRow++;
                    iRow = sheet.CreateRow(intRow);

                    #region 必填
                    
                    //////////////////////////////////////////

                    //必填 0客戶供應商代號	1客戶供應商類別	2客戶供應商簡稱	3客戶供應商全稱 57請款客戶

                    iCell = iRow.CreateCell(0);
                    iCell.SetCellValue(dr["ShopID"].ToString());
                    iCell.CellStyle = icsTxtCenter;

                    iCell = iRow.CreateCell(1);
                    iCell.SetCellValue(dr["ShopType"].ToString());
                    iCell.CellStyle = icsTxtCenter;

                    string strShort = dr["ShopShort"].ToString();
                    if (strShort.Length > 6)
                    {
                        strShort = strShort.Substring(0, 6);
                    }
                   

                    iCell = iRow.CreateCell(2);
                    iCell.SetCellValue(strShort);
                    iCell.CellStyle = icsTxtCenter;

                    iCell = iRow.CreateCell(3);
                    iCell.SetCellValue(dr["ShopName"].ToString());
                    iCell.CellStyle = icsTxtCenter;


                    iCell = iRow.CreateCell(57);
                    iCell.SetCellValue(dr["ShopID"].ToString());
                    iCell.CellStyle = icsTxtCenter;

                    #endregion

                    //非必填
                    #region 非必填
                    
                    ////////////////////////////////////////////
                    iCell = iRow.CreateCell(6);
                    iCell.SetCellValue(dr["Unifyno"].ToString());
                    iCell.CellStyle = icsTxtCenter;

                    iCell = iRow.CreateCell(20);
                    iCell.SetCellValue(dr["Owner"].ToString());
                    iCell.CellStyle = icsTxtCenter;

                    iCell = iRow.CreateCell(21);
                    iCell.SetCellValue(dr["Contact"].ToString());
                    iCell.CellStyle = icsTxtCenter;

                    string strAddress = dr["AddressInfo"].ToString();
                    if (strAddress.Length > 0)
                    {
                        strAddress = strAddress.Replace("**********", "|");
                        string[] str = strAddress.Split('|');

                        //33499桃園市八德區茄東里9鄰鴉仔店2之5號**********24357新北市泰山區24357台北縣泰山鄉泰林路二段21號**********
                        //IsNumber

                        string strAddInfo = str[0];

                        if (strAddInfo.Length > 0)
                        {
                            int intRemoveLength = 0;

                            if(IsNumber(strAddInfo.Substring(0, 5)))
                            {
                                intRemoveLength=5;
                            }
                            else if(IsNumber(strAddInfo.Substring(0, 3)))
                            {
                                intRemoveLength=3;
                            }
                            string strZipCode = strAddInfo.Substring(0, intRemoveLength);

                            strAddInfo = strAddInfo.Remove(0, intRemoveLength);

                            //郵遞區號
                            iCell = iRow.CreateCell(8);
                            iCell.SetCellValue(strZipCode);
                            iCell.CellStyle = icsTxtCenter;

                            iCell = iRow.CreateCell(9);
                            iCell.SetCellValue(strAddInfo);
                            iCell.CellStyle = icsTxtCenter;
                        }
                    }


                    string strTelInfo = dr["TelInfo"].ToString();
                    if (strTelInfo.Length > 0)
                    {
                        strTelInfo = strTelInfo.Replace("**********", "|");
                        string[] str = strTelInfo.Split('|');

                        string strTelInfo2 = str[0];

                        if (strTelInfo2.Length > 0)
                        {
                            //郵遞區號
                            iCell = iRow.CreateCell(12);
                            iCell.SetCellValue(strTelInfo2);
                            iCell.CellStyle = icsTxtCenter;
                        }
                    }

                    #endregion

                }



                string strFileName = @"文中客戶廠商資料匯入.xlsx";
                FileStream file = new FileStream(strDataInterchange + strFileName, FileMode.Create);//產生檔案
                workbook.Write(file);
                sheet = null;
                workbook = null;
                file.Close();
                
                File.Copy(strDataInterchange + strFileName, strERPTransToAccount + strFileName, true);
                File.Delete(strDataInterchange + strFileName);
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "網路客戶更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 405);
            }

        }

        //D:\DataInterchange  這是檢查是否有order後組成txt要存的位置
        public static string strDataInterchange = @"D:\DataInterchange\";

        public static string strERPTransToAccount = @"D:\ERPTransToAccount\";

        /// <summary>
        /// 檢查目錄是否存在
        /// </summary>
        private void FolderCheck()
        {
            //檢查DataInterchange
            if (!System.IO.Directory.Exists(strDataInterchange))
            {
                //建立目錄
                System.IO.Directory.CreateDirectory(strDataInterchange);
            }
            //檢查strERPTransToAccount
            if (!System.IO.Directory.Exists(strERPTransToAccount))
            {
                //建立目錄
                System.IO.Directory.CreateDirectory(strERPTransToAccount);
            }
        }

        /// <summary>
        /// NOPICellStyle 的摘要描述
        /// </summary>
        public class NOPICellStyle
        {
            public NOPICellStyle()
            {
                //
                // TODO: 在這裡新增建構函式邏輯
                //
            }

            /// <summary>
            /// 自訂樣式
            /// </summary>
            /// <param name="workbook">HSSFWorkbook</param>
            /// <param name="hv">水平位置(靠左、置中、靠右)</param>
            /// <param name="backgroundColor">背景顏色</param>
            /// <param name="fontColor">字型顏色</param>
            /// <param name="isBold">是否粗體</param>
            /// <param name="format">儲存格資料格式</param>
            /// <param name="isWrap">是否自動換行</param>
            /// <param name="isBorder">是否要框線</param>
            /// <param name="fontSize">字體大小</param>
            /// <param name="strFontName">字體名稱</param>
            /// <returns>儲存格樣式</returns>
            public static ICellStyle SetStyle(XSSFWorkbook workbook, NPOI.SS.UserModel.HorizontalAlignment hv, short backgroundColor, short fontColor
                , bool isBold, string format, bool isWrap = false, bool isBorder = true, short fontSize = 10, string strFontName = "新細明體")
            {
                ICellStyle ics = workbook.CreateCellStyle();
                ics.Alignment = hv;
                ics.VerticalAlignment = VerticalAlignment.Center;
                ics.WrapText = isWrap;
                if (isBorder)
                {
                    ics.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    ics.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    ics.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    ics.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    ics.BottomBorderColor = IndexedColors.Black.Index;
                    ics.LeftBorderColor = IndexedColors.Black.Index;
                    ics.RightBorderColor = IndexedColors.Black.Index;
                    ics.TopBorderColor = IndexedColors.Black.Index;
                }
                ics.FillPattern = FillPattern.SolidForeground;
                ics.FillBackgroundColor = backgroundColor;
                ics.FillForegroundColor = backgroundColor;
                IFont iFont = workbook.CreateFont();
                iFont.FontHeightInPoints = fontSize;
                iFont.Color = fontColor;
                iFont.FontName = strFontName;
                iFont.Boldweight = isBold ? (short)NPOI.SS.UserModel.FontBoldWeight.Bold : (short)NPOI.SS.UserModel.FontBoldWeight.Normal;
                ics.SetFont(iFont);
                if (format.Length > 0)
                {
                    IDataFormat dataformat = workbook.CreateDataFormat();
                    ics.DataFormat = dataformat.GetFormat(format);
                }
                return ics;
            }
        }

        #endregion

        #region  更新WEB客戶

        protected void UpdateCustomerWeb()
        {
            try
            {
                List<MCustomer> liCu = new DCustomer().GetUseWeb();
                foreach (MCustomer mod in liCu)
                {
                    string strMaxOrderDate = "";
                    DataSet ds = new DCustomer().GetLastOrderDateAndLessBasketByCustomerID(mod.CustomerID);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        strMaxOrderDate = dr["MaxOrderDate"].ToString();
                    }
                    if (strMaxOrderDate != "")
                    {

                        DateTime date1 = Convert.ToDateTime(strMaxOrderDate);
                        DateTime date2 = DateTime.Now;
                        TimeSpan s = new TimeSpan(date2.Month - date1.Month);
                        if (s.TotalDays > 180)
                        {
                            mod.UseWebStatus = "過期";
                            new DCustomer().Edit(mod);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "網路客戶更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 405);
            }

        }
        
        #endregion

        #region  上傳會計傳票

        protected void UpdateAccountsSummonsAccounts()
        {
            try
            {
                //EventLog.WriteEntry("DingYaoERPServer", "上傳會計傳票", EventLogEntryType.Information, 203);

                int intUploadCount = 0;
                DSummons dal = new DSummons();
                DataSet ds = dal.GetListNotUpLoad();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    DataSet dsAccounts=dal.GetListBySummonsID(dr["SummonsID"].ToString());

                    #region  會計傳票
                    

                    StringBuilder sbSummons = new StringBuilder();

                    sbSummons.Append("insert into [WD4MFGLA] ([MFGL001],[MFGL002],[MFGL003],[MFGL004]");
                    sbSummons.Append(",[MFGL005],[MFGL006],[MFGL007],[MFGL008],[MFGL009]");
                    sbSummons.Append(",[MFGL010],[MFGL011],[MFGL012],[MFGL013],[MFGL014]");
                    sbSummons.Append(",[MFGL015],[MFGL016],[MFGL017],[MFGL018],[MFGL019]");
                    sbSummons.Append(",[MFGL020],[MFGL021],[MFGL022],[MFGL023],[MFGL024]");
                    sbSummons.Append(",[MFGL801],[MFGL802],[MFGL803],[MFGL804],[MFGL805]");
                    sbSummons.Append(",[MFGL806],[MFGL807],[MFGL808],[MFGL809],[MFGL810]");
                    sbSummons.Append(",[MFGL811],[MFGL812],[MFGL821],[MFGL822],[MFGL980]");
                    sbSummons.Append(",[MFGL982],[MFGL983],[MFGL984],[MFGL985],[MFGL986]");
                    sbSummons.Append(",[MFGL987],[MFGL988],[MFGL989],[MFGL900])");
                    sbSummons.Append("values (@MFGL001,@MFGL002,@MFGL003,@MFGL004");
                    sbSummons.Append(",@MFGL005,@MFGL006,@MFGL007,@MFGL008,@MFGL009");
                    sbSummons.Append(",@MFGL010,@MFGL011,@MFGL012,@MFGL013,@MFGL014");
                    sbSummons.Append(",@MFGL015,@MFGL016,@MFGL017,@MFGL018,@MFGL019");
                    sbSummons.Append(",@MFGL020,@MFGL021,@MFGL022,@MFGL023,@MFGL024");
                    sbSummons.Append(",@MFGL801,@MFGL802,@MFGL803,@MFGL804,@MFGL805");
                    sbSummons.Append(",@MFGL806,@MFGL807,@MFGL808,@MFGL809,@MFGL810");
                    sbSummons.Append(",@MFGL811,@MFGL812,@MFGL821,@MFGL822,@MFGL980");
                    sbSummons.Append(",@MFGL982,@MFGL983,@MFGL984,@MFGL985,@MFGL986");
                    sbSummons.Append(",@MFGL987,@MFGL988,@MFGL989,@MFGL900)");


                    //年度
                    string strYear = (Convert.ToInt32(Convert.ToDateTime(dr["CreateDate"].ToString()).ToString("yyyy")) - 1911).ToString();

                    //傳票種類 固定三
                    string strUmmonsType = "3";//傳票種類 固定3;

                    SqlCommand cmd = new SqlCommand(sbSummons.ToString());
                    cmd.Parameters.Add("@MFGL001", SqlDbType.VarChar).Value = dr["SummonsID"].ToString();
                    cmd.Parameters.Add("@MFGL002", SqlDbType.VarChar).Value = strYear;
                    cmd.Parameters.Add("@MFGL003", SqlDbType.VarChar).Value = dr["SummonsID"].ToString();
                    cmd.Parameters.Add("@MFGL004", SqlDbType.VarChar).Value = strUmmonsType;
                    cmd.Parameters.Add("@MFGL005", SqlDbType.Float).Value = DBNull.Value;//這部份要確認
                    cmd.Parameters.Add("@MFGL006", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL007", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL008", SqlDbType.Float).Value = 1;//匯率
                    cmd.Parameters.Add("@MFGL009", SqlDbType.VarChar).Value = "N";
                    cmd.Parameters.Add("@MFGL010", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL011", SqlDbType.DateTime).Value = Convert.ToDateTime(dr["CreateDate"].ToString());//建立時間
                    cmd.Parameters.Add("@MFGL012", SqlDbType.VarChar).Value = dr["CreateUser"].ToString();//建立人員
                    cmd.Parameters.Add("@MFGL013", SqlDbType.DateTime).Value = Convert.ToDateTime(dr["UpdateDate"].ToString()); ;//更新時間
                    cmd.Parameters.Add("@MFGL014", SqlDbType.VarChar).Value = dr["UpdateUser"].ToString(); ;//更新人員
                    cmd.Parameters.Add("@MFGL015", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL016", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL017", SqlDbType.VarChar).Value = "TR";//來源別 TR:總帳
                    cmd.Parameters.Add("@MFGL018", SqlDbType.SmallInt).Value = 0;//附件數
                    cmd.Parameters.Add("@MFGL019", SqlDbType.VarChar).Value = "SF";//來源單別: SF 自行輸入
                    cmd.Parameters.Add("@MFGL020", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL021", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL022", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL023", SqlDbType.VarChar).Value = "N";
                    cmd.Parameters.Add("@MFGL024", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL801", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL802", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL803", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL804", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL805", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@MFGL806", SqlDbType.Float).Value = 0;
                    cmd.Parameters.Add("@MFGL807", SqlDbType.Float).Value = 0;
                    cmd.Parameters.Add("@MFGL808", SqlDbType.Float).Value = 0;
                    cmd.Parameters.Add("@MFGL809", SqlDbType.Float).Value = 0;
                    cmd.Parameters.Add("@MFGL810", SqlDbType.Float).Value = 0;
                    cmd.Parameters.Add("@MFGL811", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL812", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL821", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL822", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL980", SqlDbType.Image).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL982", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL983", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL984", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL985", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL986", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL987", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL988", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL989", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@MFGL900", SqlDbType.VarChar).Value = "0";
                    cmd.CommandType = CommandType.Text;
                    SQLUnitAccount.ExecuteSql(cmd);

                    #endregion
                    //insert into TB_IDCode values(@ID,@Code)
                    //WD4MFGLA 傳票
                   
                    int intCount=1;
                    #region  會計科目
                    foreach (DataRow drAccounts in dsAccounts.Tables[0].Rows)
                    {
                        //WD4DTGLA 會計科目

                        StringBuilder sbSummonsAccount = new StringBuilder();
                        
                        //sbSummonsAccount.Append("insert into [WD4DTGLA]  values (@DTGL001,@DTGL002,@DTGL003,@DTGL004");
                        //sbSummonsAccount.Append(",@DTGL005,@DTGL006,@DTGL007,@DTGL008,@DTGL009");
                        //sbSummonsAccount.Append(",@DTGL010,@DTGL011,@DTGL012,@DTGL013,@DTGL014");
                        //sbSummonsAccount.Append(",@DTGL015,@DTGL016,@DTGL017,@DTGL018,@DTGL019");
                        //sbSummonsAccount.Append(",@DTGL020,@DTGL021,@DTGL022,@DTGL023,@DTGL024");
                        //sbSummonsAccount.Append(",@DTGL025,@DTGL026,@DTGL027,@DTGL028,@DTGL029");
                        //sbSummonsAccount.Append(",@DTGL030,@DTGL031,@DTGL032,@DTGL033,@DTGL034");
                        //sbSummonsAccount.Append(",@DTGL801,@DTGL802,@DTGL803,@DTGL804,@DTGL805");
                        //sbSummonsAccount.Append(",@DTGL806,@DTGL807,@DTGL808,@DTGL809,@DTGL810");
                        //sbSummonsAccount.Append(",@DTGL811,@DTGL812,@DTGL900)");


                        sbSummonsAccount.Append("insert into [WD4DTGLA] ([DTGL001],[DTGL002],[DTGL003],[DTGL004]");
                        sbSummonsAccount.Append(",[DTGL005],[DTGL006],[DTGL007],[DTGL008],[DTGL009]");
                        sbSummonsAccount.Append(",[DTGL010],[DTGL011],[DTGL012],[DTGL013],[DTGL014]");
                        sbSummonsAccount.Append(",[DTGL015],[DTGL016],[DTGL017],[DTGL018],[DTGL019]");
                        sbSummonsAccount.Append(",[DTGL020],[DTGL021],[DTGL022],[DTGL023],[DTGL024]");
                        sbSummonsAccount.Append(",[DTGL025],[DTGL026],[DTGL027],[DTGL028],[DTGL029]");
                        sbSummonsAccount.Append(",[DTGL030],[DTGL031],[DTGL032],[DTGL033],[DTGL034]");
                        sbSummonsAccount.Append(",[DTGL801],[DTGL802],[DTGL803],[DTGL804],[DTGL805]");
                        sbSummonsAccount.Append(",[DTGL806],[DTGL807],[DTGL808],[DTGL809],[DTGL810]");
                        sbSummonsAccount.Append(",[DTGL811],[DTGL812],[DTGL900])");
                        sbSummonsAccount.Append("values (@DTGL001,@DTGL002,@DTGL003,@DTGL004");
                        sbSummonsAccount.Append(",@DTGL005,@DTGL006,@DTGL007,@DTGL008,@DTGL009");
                        sbSummonsAccount.Append(",@DTGL010,@DTGL011,@DTGL012,@DTGL013,@DTGL014");
                        sbSummonsAccount.Append(",@DTGL015,@DTGL016,@DTGL017,@DTGL018,@DTGL019");
                        sbSummonsAccount.Append(",@DTGL020,@DTGL021,@DTGL022,@DTGL023,@DTGL024");
                        sbSummonsAccount.Append(",@DTGL025,@DTGL026,@DTGL027,@DTGL028,@DTGL029");
                        sbSummonsAccount.Append(",@DTGL030,@DTGL031,@DTGL032,@DTGL033,@DTGL034");
                        sbSummonsAccount.Append(",@DTGL801,@DTGL802,@DTGL803,@DTGL804,@DTGL805");
                        sbSummonsAccount.Append(",@DTGL806,@DTGL807,@DTGL808,@DTGL809,@DTGL810");
                        sbSummonsAccount.Append(",@DTGL811,@DTGL812,@DTGL900)");
                        SqlCommand cmd2 = new SqlCommand(sbSummonsAccount.ToString());


                        string strCount = intCount.ToString().PadLeft(4, '0');
                        cmd2.Parameters.Add("@DTGL001", SqlDbType.VarChar).Value = drAccounts["SummonsID"].ToString() + "-" + intCount.ToString();
                        cmd2.Parameters.Add("@DTGL002", SqlDbType.VarChar).Value = drAccounts["SummonsID"].ToString();
                        cmd2.Parameters.Add("@DTGL003", SqlDbType.VarChar).Value = strYear;
                        cmd2.Parameters.Add("@DTGL004", SqlDbType.VarChar).Value = drAccounts["SummonsID"].ToString();
                        cmd2.Parameters.Add("@DTGL005", SqlDbType.VarChar).Value = strCount; //序號(seq
                        cmd2.Parameters.Add("@DTGL006", SqlDbType.VarChar).Value = strUmmonsType;
                        cmd2.Parameters.Add("@DTGL007", SqlDbType.Float).Value = DBNull.Value;//42190 奇怪的
                        cmd2.Parameters.Add("@DTGL008", SqlDbType.VarChar).Value = drAccounts["AccountID"].ToString();
                        cmd2.Parameters.Add("@DTGL009", SqlDbType.VarChar).Value = "";//客戶編號(可不填)
                        cmd2.Parameters.Add("@DTGL010", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL011", SqlDbType.VarChar).Value = drAccounts["Summary"].ToString();
                        cmd2.Parameters.Add("@DTGL012", SqlDbType.VarChar).Value = drAccounts["DebitCredit"].ToString();// 借:1 貸:2
                        cmd2.Parameters.Add("@DTGL013", SqlDbType.Float).Value = Convert.ToDouble(drAccounts["SumMoney"].ToString());//金額
                        cmd2.Parameters.Add("@DTGL014", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL015", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL016", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL017", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL018", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL019", SqlDbType.VarChar).Value = "N";//立沖否
                        cmd2.Parameters.Add("@DTGL020", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL021", SqlDbType.Float).Value = Convert.ToDouble(drAccounts["SumMoney"].ToString()); ;
                        cmd2.Parameters.Add("@DTGL022", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL023", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL024", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL025", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL026", SqlDbType.VarChar).Value = "N";
                        cmd2.Parameters.Add("@DTGL027", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL028", SqlDbType.Float).Value = 1;
                        cmd2.Parameters.Add("@DTGL029", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL030", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL031", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL032", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL033", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL034", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL801", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL802", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL803", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL804", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL805", SqlDbType.VarChar).Value = "";
                        cmd2.Parameters.Add("@DTGL806", SqlDbType.Float).Value = 0;
                        cmd2.Parameters.Add("@DTGL807", SqlDbType.Float).Value = 0;
                        cmd2.Parameters.Add("@DTGL808", SqlDbType.Float).Value = 0;
                        cmd2.Parameters.Add("@DTGL809", SqlDbType.Float).Value = 0;
                        cmd2.Parameters.Add("@DTGL810", SqlDbType.Float).Value = 0;
                        cmd2.Parameters.Add("@DTGL811", SqlDbType.DateTime).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL812", SqlDbType.DateTime).Value = DBNull.Value;
                        cmd2.Parameters.Add("@DTGL900", SqlDbType.VarChar).Value = 0;
                        SQLUnitAccount.ExecuteSql(cmd2);


                        intCount++;
                        //insert into [WD4DTGLA] ([DTGL001],[DTGL002],[DTGL003],[DTGL004]
                        //,[DTGL005],[DTGL006],[DTGL007],[DTGL008],[DTGL009]
                        //,[DTGL010],[DTGL011],[DTGL012],[DTGL013],[DTGL014]
                        //,[DTGL015],[DTGL016],[DTGL017],[DTGL018],[DTGL019]
                        //,[DTGL020],[DTGL021],[DTGL022],[DTGL023],[DTGL024]
                        //,[DTGL025],[DTGL026],[DTGL027],[DTGL028],[DTGL029]
                        //,[DTGL030],[DTGL031],[DTGL032],[DTGL033],[DTGL034]
                        //,[DTGL801],[DTGL802],[DTGL803],[DTGL804],[DTGL805]
                        //,[DTGL806],[DTGL807],[DTGL808],[DTGL809],[DTGL810]
                        //,[DTGL811],[DTGL812],[DTGL900])

                    }

                    #endregion
                    //最後更新為已上傳
                    dal.EditUpload(dr["SummonsID"].ToString());
                }
                if (intUploadCount > 0)
                {
                    //EventLog.WriteEntry("DingYaoERPServer", "會計傳票上傳完成", EventLogEntryType.Information, 210);
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "會計傳票更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 411);
            }
            
        }


        #endregion

        #region  月初記錄

        protected void UpdateMonthRecord()
        {
            try
            {
                List<MBasketCustomer> libC = new DBasketCustomer().GetList();
                foreach (MBasketCustomer mod in libC)
                { 
                    MMonthBasketCustomer mmbc = new MMonthBasketCustomer();
                    mmbc.CustomerID=mod.CustomerID;
                    mmbc.BasketQty=mod.BasketQty;
                    mmbc.RecordDate=Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                    new DMonthBasketCustomer().Add(mmbc);
                }


                List<MBasketSupplier> libS = new DBasketSupplier().GetList();
                foreach (MBasketSupplier mod in libS)
                {
                    MMonthBasketSupplier mmbs = new MMonthBasketSupplier();
                    mmbs.SupplierID = mod.SupplierID;
                    mmbs.BasketQty=mod.BasketQty;
                    mmbs.RecordDate=Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                    new DMonthBasketSupplier().Add(mmbs);
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "月初記錄更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 411);
            }

        }
        #endregion

        #region  價格更新

        protected void UpdatePrice()
        {
            try
            {
                List<MPriceFuture> liPF = new DPriceFuture().GetListBeginDate();
                foreach (MPriceFuture mpf in liPF)
                {
                    //先刪除全部屬於此群組的價格
                    List<MPrice> liPrice = new DPrice().GetListByPriceGroupID(mpf.PriceGroupID);
                    foreach (MPrice mPrice in liPrice)
                    {
                        new DPrice().Del(mPrice.PriceID);
                    }

                    //取得所有預設價格
                    List<MPriceFutureProduct> liProductPrice = new DPriceFutureProduct().GetListByPriceFutureID(mpf.PriceFutureID);
                    foreach (MPriceFutureProduct mFutureProduct in liProductPrice)
                    {
                        MPrice mod = new MPrice();

                        mod.ProductCode = mFutureProduct.ProductCode;
                        mod.PriceGroupID = mpf.PriceGroupID;
                        mod.PriceQty = Convert.ToDecimal(mFutureProduct.PriceQty);
                        mod.Price = Convert.ToDecimal(mFutureProduct.Price);
                        mod.CheckType = mFutureProduct.CheckType;
                        mod.MinValue = Convert.ToDecimal(mFutureProduct.MinValue);
                        mod.MaxValue = Convert.ToDecimal(mFutureProduct.MaxValue);
                        mod.CreateUser = "admin";
                        new DPrice().Add(mod);
                    }
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "價格更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 405);
            }

        }

        #endregion

        #region  催收工作

        /// <summary>
        /// 催收工作
        /// </summary>
        protected void SetPaymentProcess()
        {
            DateTime dtNow = DateTime.Now;

            //取得今天星期幾
            string strWeek = dtNow.DayOfWeek.ToString("d");//tmp2 = 4 
            //取得今天幾號
            int intDay = Convert.ToInt32(dtNow.ToString("dd"));

            DataSet ds = new DPaymentProcess().GetPaymentProcessList();            
            foreach (DataRow dr in ds.Tables[0].Rows)
            { 
                string strCustomerID=dr["CustomerID"].ToString();
                string strPaymentTermsID=dr["PaymentTermsID"].ToString();
                string strPaymentTerms=dr["PaymentTerms"].ToString();
                string strChargePerson=dr["ChargePerson"].ToString();
                List<string> liOrderID  = new List<string>();

                //取得總計
                decimal decDebtTotal = GetDebtTotal(strCustomerID);
                bool bolNeedAdd = false;
                //總計大於0代表有欠款
                if (decDebtTotal > 0)
                {
                    bolNeedAdd = true;
                }

                if (strPaymentTerms == "貨到付現" & bolNeedAdd)
                {
                    liOrderID = GetOrderListNormal(strCustomerID);
                }
                else if (strPaymentTerms == "周一結" & bolNeedAdd)
                {
                    if (Convert.ToInt32(strWeek) == 2)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "周二結" & bolNeedAdd)
                {
                    if (Convert.ToInt32(strWeek) == 3)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "周三結" & bolNeedAdd)
                {
                    if (Convert.ToInt32(strWeek) == 4)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "周四結" & bolNeedAdd)
                {
                    if (Convert.ToInt32(strWeek) == 5)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }                
                }
                else if (strPaymentTerms == "周五結" & bolNeedAdd)
                {
                    if (Convert.ToInt32(strWeek) == 6)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "周六結" & bolNeedAdd)
                {
                    //Alex個人認為照原本說法是週日建立 但星期日不上班
                    //if (Convert.ToInt32(strWeek) == 1)
                    //{
                    //    liOrderID = GetOrderListNormal(strCustomerID);
                    //}
                    liOrderID = GetOrderListNormal(strCustomerID);
                }
                else if (strPaymentTerms == "半月結" & bolNeedAdd)
                {
                    if (intDay == 1 | intDay == 16)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "月結(1~31)" & bolNeedAdd)
                {
                    if (intDay == 1)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "月結(21~20)" & bolNeedAdd)
                {
                    if (intDay == 21)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "月結(26~25)" & bolNeedAdd)
                {
                    if (intDay == 26)
                    {
                        liOrderID = GetOrderListNormal(strCustomerID);
                    }
                }
                else if (strPaymentTerms == "特結1" & bolNeedAdd)
                {
                    GetOrderListSpecial1(strCustomerID, dr["AccountReceivable"].ToString(), dr["TradeDays"].ToString(), decDebtTotal);
                }
                else if (strPaymentTerms == "特結2" & bolNeedAdd)
                {
                    GetOrderListSpecial2(strCustomerID, dr["TradeDays"].ToString(), dr["AccountReceivableDays"].ToString());
                }
                else if (strPaymentTerms == "預付匯款" & bolNeedAdd)
                {
                    liOrderID = GetOrderListNormal(strCustomerID);
                }
                else if (strPaymentTerms == "抵帳" & bolNeedAdd)
                {
                    liOrderID = GetOrderListNormal(strCustomerID);
                }

                AddPaymentProcess(strCustomerID, Convert.ToInt32(strPaymentTermsID), strChargePerson, liOrderID);
            }        
        }

        /// <summary>
        /// 一般收款方式
        /// </summary>
        protected List<string> GetOrderListNormal(string strCustomerID)
        {
            List<string> liOrder = new List<string>();
            DataSet ds = new DPaymentProcess().GetNotBanlance(strCustomerID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                liOrder.Add(dr["AccountsReceivableNo"].ToString());
            }           
            return liOrder;
        }

        /// <summary>
        /// 特結一收款
        /// </summary>
        protected List<string> GetOrderListSpecial1(string strCustomerID, string strAccountReceivable, string strTradeDays, decimal decDebtTotal)
        {
            List<string> liOrder = new List<string>();
            //比較強迫催收天數
            #region  催收天數
            bool boolOverDay=false;
            string strMaxDueDate="";
            if(strTradeDays.Length>0)
            {
                DataSet dsMaxDate=new DCustomer().GetMaxDueDateByCustomerID(strCustomerID);
                foreach(DataRow dr in dsMaxDate.Tables[0].Rows)
                {
                    strMaxDueDate=dr["MaxDate"].ToString();
                }
                if(strMaxDueDate.Length>0 & Convert.ToInt32(strTradeDays)>0)
                {
                    //取得相差天數
                    int intDay=new TimeSpan(DateTime.Now.Ticks - Convert.ToDateTime(strMaxDueDate).Ticks).Days;

                    if (intDay > Convert.ToInt32(strTradeDays))
                    {
                        boolOverDay = true;
                    }
                }

            }

            #endregion

            bool bolOverAccountReceivable=false;
            //比較應收款
            if (strAccountReceivable.Length > 0)
            { 
                if(Convert.ToDecimal(strAccountReceivable)>decDebtTotal)
                {
                    bolOverAccountReceivable=true;
                }
            }

       
            if(boolOverDay | bolOverAccountReceivable)
            {
                DataSet ds = new DPaymentProcess().GetNotBanlance(strCustomerID);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    liOrder.Add(dr["AccountsReceivableNo"].ToString());
                }
            }
            return liOrder;
        }

        /// <summary>
        /// 特結二收款
        /// </summary>
        protected List<string> GetOrderListSpecial2(string strCustomerID, string strTradeDays, string strAccountReceivableDays)
        {
            List<string> liOrder = new List<string>();
            //比較強迫催收天數
            #region  催收天數
            bool boolOverDay = false;
            string strMaxDueDate = "";
            if (strTradeDays.Length > 0)
            {
                DataSet dsMaxDate = new DCustomer().GetMaxDueDateByCustomerID(strCustomerID);
                foreach (DataRow dr in dsMaxDate.Tables[0].Rows)
                {
                    strMaxDueDate = dr["MaxDate"].ToString();
                }
                if (strMaxDueDate.Length > 0 & Convert.ToInt32(strTradeDays) > 0)
                {
                    //取得相差天數
                    int intDay = new TimeSpan(DateTime.Now.Ticks - Convert.ToDateTime(strMaxDueDate).Ticks).Days;

                    if (intDay > Convert.ToInt32(strTradeDays))
                    {
                        boolOverDay = true;
                    }
                }

            }

            #endregion

            bool bolOverAccountReceivableDays = false;
            //比較押趟(同一天出貨算一趟)

            //取得未收款趟數
            DataSet dsMaxDueDate =new DCustomer().GetDueDateNotBanlanceByCustomerID(strCustomerID);
            int intCount = dsMaxDueDate.Tables[0].Rows.Count;
            if (strAccountReceivableDays.Length > 0)
            {
                if (Convert.ToInt32(strAccountReceivableDays) > intCount)
                {
                    bolOverAccountReceivableDays = true;
                }
            }


            if (boolOverDay | bolOverAccountReceivableDays)
            {
                DataSet ds = new DPaymentProcess().GetNotBanlance(strCustomerID);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    liOrder.Add(dr["AccountsReceivableNo"].ToString());
                }
            }
            return liOrder;
        }



        /// <summary>
        /// 
        /// </summary>
        protected decimal GetDebtTotal(string strCustomerID)
        {
            DataSet ds = new DCustomer().GetCustomerGetByDebt(strCustomerID);
            decimal decSumOrderPrice = 0;
            decimal decDebtTotal = 0;
            decimal decPDebt = 0;
            decimal decAdvancePayment = 0;
            decimal decDebt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["SumOrderPrice"].ToString().Length > 0)
                {
                    decSumOrderPrice = Convert.ToDecimal(dr["SumOrderPrice"].ToString());
                }
                if (dr["PDebt"].ToString().Length > 0)
                {
                    decPDebt = Convert.ToDecimal(dr["PDebt"].ToString());
                }
                if (dr["AdvancePayment"].ToString().Length > 0)
                {
                    decAdvancePayment = Convert.ToDecimal(dr["AdvancePayment"].ToString());
                }
                if (dr["Debt"].ToString().Length > 0)
                {
                    decDebt = Convert.ToDecimal(dr["Debt"].ToString());
                }
            }
            decDebtTotal = decDebt + decSumOrderPrice;

            return decDebtTotal;
        }


        /// <summary>
        /// 新增催收工作
        /// </summary>
        protected void AddPaymentProcess(string strCustomerID,int intPaymentTermsID,string strChargePerson,List<string> liOrderID)
        { 
            if(liOrderID.Count>0)
            {
                string strOrderIDs="";
                foreach(string strOrderID in liOrderID)
                {
                    strOrderIDs=strOrderIDs+"、"+strOrderID;
                }
                if(strOrderIDs.Length>0)
                {
                    strOrderIDs=strOrderIDs.Substring(1,strOrderIDs.Length-1);
                }

                MPaymentProcess mod = new MPaymentProcess();
                mod.CustomerID=strCustomerID;            
	            mod.PaymentTermsID=intPaymentTermsID;
	            mod.ChargePerson=strChargePerson;
	            mod.JobDescription=strOrderIDs;
	            mod.PaymentProcessStatus="未完成";
	            mod.PaymentProcessReamrks="";
	            mod.CreateUser="admin";
                new DPaymentProcess().Add(mod);
            }
        }

        #endregion

        #region  週期工作
        
        /// <summary>
        /// 週期
        /// </summary>
        protected void SetCycleWork()
        {
            DataSet ds=new DCycleWorkItem().GetProcessWorkItemSetting();
            DateTime dtNow = DateTime.Now;

            //取得今天星期幾

            string strWeek = dtNow.DayOfWeek.ToString("d");//tmp2 = 4 
            
            //string strWeek1 = Convert.ToDateTime("2016/04/18").DayOfWeek.ToString("d");//tmp2 = 4 
            //string strWeek2 = Convert.ToDateTime("2016/04/19").DayOfWeek.ToString("d");//tmp2 = 4 
            
            //取得今天幾號
            int intDay = Convert.ToInt32(dtNow.ToString("dd"));
            //月份
            int intMonth = Convert.ToInt32(dtNow.ToString("MM"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int intCycleWorkItemSettingID=Convert.ToInt32(dr["CycleWorkItemSettingID"].ToString());
                string strCustomerID=dr["CustomerID"].ToString();
                string strChargePerson=dr["ChargePerson"].ToString();
                string strExcludeDateBegin=dr["ExcludeDateBegin"].ToString();
                string strExcludeDateEnd=dr["ExcludeDateEnd"].ToString();
                string strJobDescription = dr["JobDescription"].ToString();
                if (dr["RemindType"].ToString() == "星期")
                {
                    string strDrWeekTxt = "Week" + strWeek;
                    //星期符合
                    if (Convert.ToBoolean(dr[strDrWeekTxt].ToString()))
                    {
                        if (strExcludeDateBegin.Length > 0 & strExcludeDateEnd.Length > 0)
                        {
                            if (dtNow < Convert.ToDateTime(strExcludeDateBegin) | dtNow > Convert.ToDateTime(strExcludeDateEnd))
                            {
                                AddItem(intCycleWorkItemSettingID, strCustomerID, strChargePerson, strJobDescription);
                            }
                        }
                        else
                        {
                            AddItem(intCycleWorkItemSettingID, strCustomerID, strChargePerson, strJobDescription);
                        }                          
                    }
                    //dr["Week1"].ToString();
                    //dr["Week2"].ToString();
                    //dr["Week3"].ToString();
                    //dr["Week4"].ToString();
                    //dr["Week5"].ToString();
                    //dr["Week6"].ToString();
                }
                else if (dr["RemindType"].ToString() == "月份")
                {
                    int intMonth1=dr["Month1"].ToString().Length==0?0:Convert.ToInt32(dr["Month1"].ToString());
                    int intMonth2=dr["Month2"].ToString().Length==0?0:Convert.ToInt32(dr["Month2"].ToString());
                    int intMonth3=dr["Month3"].ToString().Length==0?0:Convert.ToInt32(dr["Month3"].ToString());
                    int intMonth4=dr["Month4"].ToString().Length==0?0:Convert.ToInt32(dr["Month4"].ToString());
                    int intMonth5=dr["Month5"].ToString().Length==0?0:Convert.ToInt32(dr["Month5"].ToString());

                    if (strExcludeDateBegin.Length > 0 & strExcludeDateEnd.Length > 0)
                    {
                        if (dtNow < Convert.ToDateTime(strExcludeDateBegin) | dtNow > Convert.ToDateTime(strExcludeDateEnd))
                        {
                            if (intDay == intMonth1 | intDay == intMonth2 | intDay == intMonth3 | intDay == intMonth4 | intDay == intMonth5)
                            {
                                AddItem(intCycleWorkItemSettingID, strCustomerID, strChargePerson, strJobDescription);
                            }
                        }
                    }
                    else
                    {
                        if (intDay == intMonth1 | intDay == intMonth2 | intDay == intMonth3 | intDay == intMonth4 | intDay == intMonth5)
                        {
                            AddItem(intCycleWorkItemSettingID, strCustomerID, strChargePerson, strJobDescription);
                        }                        
                    }           
                }
                else if (dr["RemindType"].ToString() == "指定")
                {
                    #region 指定

                    int intMonth1 = dr["SpecifyMonth1"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyMonth1"].ToString());
                    int intDay1 = dr["SpecifyDay1"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyDay1"].ToString());

                    int intMonth2 = dr["SpecifyMonth2"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyMonth2"].ToString());
                    int intDay2 = dr["SpecifyDay2"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyDay2"].ToString());

                    int intMonth3 = dr["SpecifyMonth3"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyMonth3"].ToString());
                    int intDay3 = dr["SpecifyDay3"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyDay3"].ToString());

                    int intMonth4 = dr["SpecifyMonth4"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyMonth4"].ToString());
                    int intDay4 = dr["SpecifyDay4"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyDay4"].ToString());

                    int intMonth5 = dr["SpecifyMonth5"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyMonth5"].ToString());
                    int intDay5 = dr["SpecifyDay5"].ToString().Length == 0 ? 0 : Convert.ToInt32(dr["SpecifyDay5"].ToString());


                    if (strExcludeDateBegin.Length > 0 & strExcludeDateEnd.Length > 0)
                    {
                        if (dtNow < Convert.ToDateTime(strExcludeDateBegin) | dtNow > Convert.ToDateTime(strExcludeDateEnd))
                        {
                            if ((intMonth == intMonth1 && intDay == intDay1) | (intMonth == intMonth2 && intDay == intDay2) | (intMonth == intMonth3 && intDay == intDay3) |
                                (intMonth == intMonth4 && intDay == intDay4) | (intMonth == intMonth5 && intDay == intDay5))
                            {
                                AddItem(intCycleWorkItemSettingID, strCustomerID, strChargePerson, strJobDescription);
                            }
                        }
                    }
                    else
                    {
                        if ((intMonth == intMonth1 && intDay == intDay1) | (intMonth == intMonth2 && intDay == intDay2) | (intMonth == intMonth3 && intDay == intDay3) |
                                 (intMonth == intMonth4 && intDay == intDay4) | (intMonth == intMonth5 && intDay == intDay5))
                        {
                            AddItem(intCycleWorkItemSettingID, strCustomerID, strChargePerson, strJobDescription);
                        }
                    }

                    #endregion
                }
                else
                {
                    //純文字
                }

                   
            }
        }

        /// <summary>
        /// item新增
        /// </summary>
        protected void AddItem(int CycleWorkItemSettingID, string strCustomerID, string strChargePerson, string strJobDescription)
        { 
            MCycleWorkItem mod = new MCycleWorkItem();
            mod.CycleWorkItemSettingID=CycleWorkItemSettingID;
            mod.CustomerID=strCustomerID;
            mod.ChargePerson=strChargePerson;
            mod.JobDescription = strJobDescription;
            mod.CycleWorkItemStatus="未完成";
            mod.CycleWorkItemReamrks="";
            mod.CreateUser="admin";
            new DCycleWorkItem().Add(mod);
        }
        
        #endregion

        #region 儲存績效表

        protected void SetDeliveryManPerformanceMonth()
        {
            try 
            {
                DateTime dt = DateTime.Now;
                //DateTime dt = Convert.ToDateTime("2017/5/1");
                DateTime dtNow = Convert.ToDateTime(dt.AddMonths(-1).ToString("yyyy/MM/dd"));
                int intYear = Convert.ToInt32(dtNow.ToString("yyyy"));
                int intMonth = Convert.ToInt32(dtNow.ToString("MM"));

                //金額累計
                DataSet dsTotalSumMoney = new DStat().GetDeliveryManPerformance3("", "", intYear, intMonth, false, "TotalSumMoney", "");

                foreach (DataRow dr in dsTotalSumMoney.Tables[0].Rows)
                {
                    MDeliveryManPerformanceMonth mod = new MDeliveryManPerformanceMonth();
                    mod.UserID = dr["DeliveryManID"].ToString();
                    mod.Year = intYear;
                    mod.Month = intMonth;
                    mod.TotalSumMoney = Convert.ToDecimal(dr["TotalSumMoney"]);
                    mod.TotalSumMoneyRank = Convert.ToInt32(dr["TotalSumMoneySeq"].ToString());

                    mod.OrderTotalWeight = 0;
                    mod.OrderTotalWeightRank = 0;
                    //總包裝重量
                    if (dr["OrderTotalWeight"].ToString().Length > 0)
                    {
                        mod.OrderTotalWeight = Convert.ToDecimal(dr["OrderTotalWeight"]);
                    }
                    mod.OrderTotalWeightRank = Convert.ToInt32(dr["OrderTotalWeightSeq"].ToString());


                    mod.OrderTotalCount = 0;
                    mod.OrderTotalCountRank = 0; 
                    //累計筆數
                    if (dr["OrderTotalCount"].ToString().Length > 0)
                    {
                        mod.OrderTotalCount = Convert.ToDecimal(dr["OrderTotalCount"]);                    
                    }
                    mod.OrderTotalCountRank = Convert.ToInt32(dr["OrderTotalCountSeq"].ToString());

                    mod.SubMile = 0;
                    mod.SubMileRank = 0; 
                    //里程
                    if (dr["SubMile"].ToString().Length > 0)
                    {
                        mod.SubMile = Convert.ToDecimal(dr["SubMile"]);                    
                    }
                    mod.SubMileRank = Convert.ToInt32(dr["MileSeq"].ToString());

                    mod.SubOil = 0;
                    mod.SubOilRank = 0;
                    if (dr["SubOil"].ToString().Length > 0)
                    {
                        mod.SubOil = Convert.ToDecimal(dr["SubOil"]);
                    }
                    mod.SubOilRank = Convert.ToInt32(dr["OilSeq"].ToString());

                     mod.OilMil = 0;
                     mod.OilMilRank = 0;
                    //里程/公升
                    if (dr["OilMil"].ToString().Length > 0)
                    {
                        mod.OilMil = Convert.ToDecimal(dr["OilMil"]);                   
                    }
                    mod.OilMilRank = Convert.ToInt32(dr["MileOilSeq"].ToString());

                    new DDeliveryManPerformanceMonth().Add(mod);

                }
                //EventLog.WriteEntry("DingYaoERPServer", "機績效月儲存成功", EventLogEntryType.Warning, 200);
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("DingYaoERPServer", "司機績效月儲存更新錯誤" + ex.ToString(), EventLogEntryType.Warning, 408);
            }
        }
        #endregion

        protected void SetZipCode()
        {

            List<MZIPCode> liZip = new DZIPCode().GetList();
            LZWZIP.LZWZIP zip = new LZWZIP.LZWZIP();
            List<MAddress> li = new DAddress().GetListProcessAddress();
            foreach (MAddress mod in li)
            {
                mod.ZIPCode = Check32ZipCode(zip.GetZipCode(GetCityAndAreaTxt(liZip,mod.ZIPCode) + mod.Address));

                new DAddress().Edit(mod);
            }
        }

        /// <summary>
        /// 檢查zipcode 並將不足五碼加'9'
        /// </summary>
        /// <param name="strZipCode"></param>
        /// <returns></returns>
        public static string Check32ZipCode(string strZipCode)
        {
            if (strZipCode.Length == 3)
            {
                strZipCode = strZipCode.PadRight(5, '9');
            }
            return strZipCode;
        }

        /// <summary>
        /// 以zipcode取得城市地區
        /// </summary>
        protected string GetCityAndAreaTxt(List<MZIPCode>liZip, string strZip)
        {
            string str = "";

            if (strZip.Length > 3)
            {
                strZip = strZip.Substring(0, 3);
            }
            IEnumerable<MZIPCode> ie = from zipcode in liZip
                                       where zipcode.ZIPCode == strZip
                                       select zipcode;
            foreach (MZIPCode mod in ie)
            {
                str = mod.City + mod.Area;
            }
            return str;
        }
        
    }
}
