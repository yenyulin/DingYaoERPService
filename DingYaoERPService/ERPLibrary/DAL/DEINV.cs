using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DingYaoERP.Models;
using DingYaoERP.Common;
using DingYaoERP.DAL;
/// <summary>
/// DEINV 的摘要描述
/// </summary>
public class DEINV
{
	public DEINV()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    /*
    //統編
    readonly string strSellerIdentifier = "22161107";
    //公司名稱
    readonly string strSellerName = "鼎耀食品股份有限公司";

    /// <summary>
    /// 上傳電子發票
    /// </summary>
    public DateTime? InvoiceAdd(int inInvoiceID)
    {
        DateTime dt = DateTime.Now;
        try
        {
            MInvoice mInvoice = new DInvoice().GetModel(inInvoiceID);
            SqlCommand cmd = new SqlCommand("STP_EINV_C0401MAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mguid", SqlDbType.NVarChar).Value = mInvoice.Mguid;
            cmd.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@ProcessStatus", SqlDbType.VarChar).Value = "0";
            cmd.Parameters.Add("@ProcessFailReason", SqlDbType.NVarChar).Value ="";
            cmd.Parameters.Add("@TransStatus", SqlDbType.VarChar).Value = "0";
            cmd.Parameters.Add("@TransFileReason", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = mInvoice.InvoiceNumber;
            cmd.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = mInvoice.InvoiceDate.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@InvoiceTime", SqlDbType.VarChar).Value = mInvoice.InvoiceDate.ToString("HH:mm:ss");
            cmd.Parameters.Add("@SellerIdentifier", SqlDbType.VarChar).Value = strSellerIdentifier;
            cmd.Parameters.Add("@SellerName", SqlDbType.NVarChar).Value = strSellerName;
            cmd.Parameters.Add("@SellerAddress", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@SellerPersonInCharge", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@SellerTelephoneNumber", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@SellerFacsimileNumber", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@SellerEmailAddress", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@BuyerIdentifier", SqlDbType.VarChar).Value = mInvoice.BuyerIdentifier;
            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = mInvoice.BuyerName;
            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@BuyerPersonInCharge", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@BuyerTelephoneNumber", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@BuyerFacsimileNumber", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@BuyerEmailAddress", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@MainRemark", SqlDbType.NVarChar).Value = mInvoice.MainRemark;
            cmd.Parameters.Add("@CustomsClearanceMark", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@InvoiceType", SqlDbType.VarChar).Value = mInvoice.InvoiceType;
            cmd.Parameters.Add("@DonateMark", SqlDbType.VarChar).Value = mInvoice.DonateMark;
            cmd.Parameters.Add("@CarrierType", SqlDbType.VarChar).Value = mInvoice.CarrierType;
            cmd.Parameters.Add("@CarrierId1", SqlDbType.VarChar).Value = mInvoice.CarrierId1;
            cmd.Parameters.Add("@CarrierId2", SqlDbType.VarChar).Value = mInvoice.CarrierId2;
            cmd.Parameters.Add("@PrintMark", SqlDbType.VarChar).Value = mInvoice.PrintMark;
            cmd.Parameters.Add("@NPOBAN", SqlDbType.VarChar).Value = mInvoice.NPOBAN;
            cmd.Parameters.Add("@RandomNumber", SqlDbType.VarChar).Value = mInvoice.RandomNumber;
            cmd.Parameters.Add("@SalesAmount", SqlDbType.Float).Value = mInvoice.SalesAmount;
            cmd.Parameters.Add("@FreeTaxSalesAmount", SqlDbType.Float).Value = mInvoice.FreeTaxSalesAmount;
            cmd.Parameters.Add("@ZeroTaxSalesAmount", SqlDbType.Float).Value = "0";
            cmd.Parameters.Add("@TaxType", SqlDbType.VarChar).Value = mInvoice.TaxType;
            cmd.Parameters.Add("@TaxRate", SqlDbType.Float).Value = mInvoice.TaxRate;
            cmd.Parameters.Add("@TaxAmount", SqlDbType.Float).Value = mInvoice.TaxAmount;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = mInvoice.TotalAmount;
            cmd.Parameters.Add("@OriginalCurrencyAmount", SqlDbType.Float).Value = DBNull.Value;
            cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = DBNull.Value;
            cmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@BondedAreaConfirm", SqlDbType.VarChar).Value = "";
            SQLUtil.ExecuteScalar(cmd);

            List<MInvoiceItem> li=new DInvoiceItem().GetByInvoiecID(inInvoiceID);
            cmd.CommandText = "STP_EINV_C0401DAdd";
            foreach (MInvoiceItem mInvoiceItem in li)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Mguid", SqlDbType.VarChar).Value = mInvoice.Mguid;
                cmd.Parameters.Add("@InvoiceNumber",SqlDbType.VarChar).Value = mInvoice.InvoiceNumber;
                cmd.Parameters.Add("@InvoiceDate",SqlDbType.VarChar).Value = mInvoice.InvoiceDate;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =mInvoiceItem.Description;
                cmd.Parameters.Add("@Quantity", SqlDbType.Float).Value = mInvoiceItem.Quantity;
                cmd.Parameters.Add("@Unit", SqlDbType.VarChar).Value = mInvoiceItem.Unit;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = mInvoiceItem.UnitPrice;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = mInvoiceItem.Amount;
                cmd.Parameters.Add("@SequenceNumber", SqlDbType.VarChar).Value = mInvoiceItem.SequenceNumber;
                cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@RelateNumber", SqlDbType.VarChar).Value = "";
                SQLUtil.ExecuteScalar(cmd);
            }
            return dt;
        }
        catch(Exception ex)
        {
            return null;
        }
        
    }

    /// <summary>
    /// 列印電子發票
    /// </summary>
    public DateTime? InvoicePrint(int inInvoiecPrintID) 
    {
        DateTime dt = DateTime.Now;
        try
        {            
            MInvoicePrint mInvoicePrint = new DInvoicePrint().GetModel(inInvoiecPrintID);
            MInvoice mInvoice = new DInvoice().GetModel(mInvoicePrint.InvoiecID);
            SqlCommand cmd = new SqlCommand("STP_EINV_PC0401MAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mguid", SqlDbType.VarChar).Value = mInvoicePrint.Mguid;
            cmd.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@ProcessStatus", SqlDbType.VarChar).Value = "0";
            cmd.Parameters.Add("@ProcessFailReason", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = mInvoice.InvoiceNumber;
            cmd.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = mInvoice.InvoiceDate.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@InvoiceTime", SqlDbType.VarChar).Value = mInvoice.InvoiceDate.ToString("HH:mm:ss");
            cmd.Parameters.Add("@SalesBill", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@SellerIdentifier", SqlDbType.VarChar).Value = strSellerIdentifier;
            cmd.Parameters.Add("@SellerName", SqlDbType.NVarChar).Value = strSellerName;
            cmd.Parameters.Add("@SellerAddress", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@SellerTelephoneNumber", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@SellerLogo", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@BuyerIdentifier", SqlDbType.VarChar).Value = mInvoice.BuyerIdentifier;
            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = mInvoice.BuyerName;
            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@MainRemark", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@InvoiceType", SqlDbType.VarChar).Value = mInvoice.InvoiceType;
            cmd.Parameters.Add("@RandomNumber", SqlDbType.VarChar).Value = mInvoice.RandomNumber;
            cmd.Parameters.Add("@SalesAmount", SqlDbType.Float).Value = mInvoice.SalesAmount;
            cmd.Parameters.Add("@FreeTaxSalesAmount", SqlDbType.Float).Value = mInvoice.FreeTaxSalesAmount;
            cmd.Parameters.Add("@ZeroTaxSalesAmount", SqlDbType.Float).Value = 0;
            cmd.Parameters.Add("@TaxType", SqlDbType.VarChar).Value = mInvoice.TaxType;
            cmd.Parameters.Add("@TaxRate", SqlDbType.Float).Value = mInvoice.TaxRate;
            cmd.Parameters.Add("@TaxAmount", SqlDbType.Float).Value = mInvoice.TaxAmount;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = mInvoice.TotalAmount;
            cmd.Parameters.Add("@Reprint", SqlDbType.VarChar).Value = mInvoicePrint.Reprint;
            cmd.Parameters.Add("@PageStyle", SqlDbType.Int).Value = mInvoicePrint.PageStyle;
            cmd.Parameters.Add("@QRCodeTextBelow1", SqlDbType.VarChar).Value = mInvoicePrint.QRCodeTextBelow1;
            cmd.Parameters.Add("@QRCodeTextBelow2", SqlDbType.VarChar).Value = mInvoicePrint.QRCodeTextBelow2;
            cmd.Parameters.Add("@PrintDirected", SqlDbType.VarChar).Value = mInvoicePrint.PrintDirected;
            cmd.Parameters.Add("@ProcessMode", SqlDbType.NVarChar).Value = mInvoicePrint.ProcessMode;
            cmd.Parameters.Add("@MailAddress", SqlDbType.NVarChar).Value = mInvoicePrint.MailAddress;

            SQLUtil.ExecuteScalar(cmd);
            List<MInvoiceItem> li = new DInvoiceItem().GetByInvoiecID(mInvoicePrint.InvoiecID);
            cmd.CommandText = "STP_EINV_PC0401DAdd";
            foreach (MInvoiceItem mInvoiceItem in li)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Mguid", SqlDbType.VarChar).Value = mInvoicePrint.Mguid;
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = mInvoice.InvoiceNumber;
                cmd.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = mInvoice.InvoiceDate;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = mInvoiceItem.Description;
                cmd.Parameters.Add("@Quantity", SqlDbType.Float).Value = mInvoiceItem.Quantity;
                cmd.Parameters.Add("@Unit", SqlDbType.VarChar).Value = mInvoiceItem.Unit;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = mInvoiceItem.UnitPrice;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = mInvoiceItem.Amount;
                cmd.Parameters.Add("@SequenceNumber", SqlDbType.VarChar).Value = mInvoiceItem.SequenceNumber;
                cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = "";
                SQLUtil.ExecuteScalar(cmd);
            }
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    /// 作廢電子發票
    /// </summary>
    public DateTime? InvoiceCancellation(int inInvoiceCancellationID)
    {
        DateTime dt = DateTime.Now;
        try
        {
            MInvoiceCancellation mInvoiceCancellation = new DInvoiceCancellation().GetModel(inInvoiceCancellationID);
            MInvoice mInvoice = new DInvoice().GetModel(mInvoiceCancellation.InvoiecID);
            SqlCommand cmd = new SqlCommand("STP_EINV_C0501Add");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@ProcessStatus", SqlDbType.VarChar).Value = "0";
            cmd.Parameters.Add("@ProcessFailReason", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@TransStatus", SqlDbType.VarChar).Value = "0";
            cmd.Parameters.Add("@TransFileReason", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@CancelInvoiceNumber", SqlDbType.VarChar).Value = mInvoice.InvoiceNumber;
            cmd.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = mInvoice.InvoiceDate;
            cmd.Parameters.Add("@BuyerId", SqlDbType.VarChar).Value = mInvoice.BuyerIdentifier;
            cmd.Parameters.Add("@SellerId", SqlDbType.VarChar).Value = strSellerIdentifier;
            cmd.Parameters.Add("@CancelDate", SqlDbType.VarChar).Value = mInvoiceCancellation.CancelDate.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@CancelTime", SqlDbType.VarChar).Value = mInvoiceCancellation.CancelDate.ToString("HH:mm:ss");
            cmd.Parameters.Add("@CancelReason", SqlDbType.VarChar).Value = mInvoiceCancellation.CancelReason;
            cmd.Parameters.Add("@ReturnTaxDocumentNumber", SqlDbType.VarChar).Value = mInvoiceCancellation.ReturnTaxDocumentNumber;
            SQLUtil.ExecuteScalar(cmd);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
        
    }
     * 
    */
    /// <summary>
    /// 更新發票資訊
    /// </summary>
    public bool InvoiceUpdateFromEINV_DB()
    {
        SqlCommand cmd = new SqlCommand("STP_InvoiceUpdateFromEINV_DB");
        cmd.CommandType = CommandType.StoredProcedure;
        return SQLUtil.ExecuteSql(cmd) > 0;
    }


}