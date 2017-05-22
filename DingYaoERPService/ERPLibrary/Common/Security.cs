using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace DingYaoERP.Common
{
    /// <summary>
    /// Security 的摘要描述
    /// </summary>
    public class Security
    {
	    public Security()
	    {
		    //
		    // TODO: 在此加入建構函式的程式碼
		    //
	    }
	    //宣告資料加密標準 (DES) 演算法的秘密金鑰。
	    static string mstrKey = "20150101";
	    //宣告對稱演算法的初始化向量 (IV)。
        static string mstrIV = "2015Kerwin";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strValue">原始字串</param>
        /// <returns>DES加密後字串</returns> 
	    public static string Encrypt(string strValue)
	    {

		    //將加密字串、Key與IV轉為所指定的由 base 64 數字所組成之值的 String 表示轉換為相等的 8 位元不帶正負號的整數陣列。
		    byte[] buffer = Encoding.Default.GetBytes(strValue);
		    byte[] key = Encoding.Default.GetBytes(mstrKey);
		    byte[] iv = Encoding.Default.GetBytes(mstrIV);

		    //宣告ms為記憶體為資料來源的資料流。
		    MemoryStream ms = new MemoryStream();

		    //定義包裝函式 (Wrapper) 物件，以存取資料加密標準 (DES) 演算法的密碼編譯服務供應者 (CSP) 版本。
		    DESCryptoServiceProvider des = new DESCryptoServiceProvider();

		    //使用指定的 Key 和初始化向量 (IV)，建立對稱資料加密標準 (DES) 加密子物件。
		    ICryptoTransform transform = des.CreateEncryptor(key, iv);

		    //定義連結資料流到密碼編譯轉換的資料流。建構函式==>CryptoStream(要在其上執行密碼編譯轉換的資料流,要在資料流上執行的密碼編譯轉換,密碼編譯資料流的模式)
		    CryptoStream encStream = new CryptoStream(ms, transform, CryptoStreamMode.Write);

		    //encStream.Write(從 buffer 複製 count 位元組到目前資料流,開始複製位元組到目前資料流的 buffer 的位元組位移,寫入目前資料流的位元組數目)
		    encStream.Write(buffer, 0, buffer.Length);

		    //以緩衝區的目前狀態更新基礎資料來源或存放庫，並接著清除緩衝區。
		    encStream.FlushFinalBlock();

		    //將 8 位元不帶正負號的整數陣列的值，轉換為由 base 64 數字所組成的相等 String 表示。
		    return Convert.ToBase64String(ms.ToArray());

	    }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strValue">DES加密後字串</param>
        /// <returns>原始字串</returns> 
	    public static string Decrypt(string strValue)
        {

		    //將加密字串、Key與IV轉為所指定的由 base 64 數字所組成之值的 String 表示轉換為相等的 8 位元不帶正負號的整數陣列。
		    byte[] buffer = Convert.FromBase64String(strValue);
		    byte[] key = Encoding.Default.GetBytes(mstrKey);
		    byte[] iv = Encoding.Default.GetBytes(mstrIV);

		    //宣告ms為記憶體為資料來源的資料流。
		    MemoryStream ms = new MemoryStream();

		    //定義包裝函式 (Wrapper) 物件，以存取資料加密標準 (DES) 演算法的密碼編譯服務供應者 (CSP) 版本。
		    DESCryptoServiceProvider des = new DESCryptoServiceProvider();

		    //使用指定的 Key 和初始化向量 (IV)，建立對稱資料加密標準 (DES) 解密子物件。
		    ICryptoTransform transform = des.CreateDecryptor(key, iv);

		    //定義連結資料流到密碼編譯轉換的資料流。建構函式==>CryptoStream(要在其上執行密碼編譯轉換的資料流,要在資料流上執行的密碼編譯轉換,密碼編譯資料流的模式)
		    CryptoStream encStream = new CryptoStream(ms, transform, CryptoStreamMode.Write);

		    //encStream.Write(從 buffer 複製 count 位元組到目前資料流 ,開始複製位元組到目前資料流的 buffer 的位元組位移,寫入目前資料流的位元組數目)
		    encStream.Write(buffer, 0, buffer.Length);

		    //以緩衝區的目前狀態更新基礎資料來源或存放庫，並接著清除緩衝區。
		    encStream.FlushFinalBlock();

		    //將 8 位元不帶正負號的整數陣列的值，轉換為由 base 64 數字所組成的相等 String 表示。
		    return Encoding.Default.GetString(ms.ToArray());

	    }

        /// <summary>
        /// DM5加密
        /// </summary>
        /// <param name="strValue">原始字串</param>
        /// <returns>MD5加密後字串</returns> 
        public static string MD5Encrypt(string strValue)
        {
            //將字串來源轉為Byte[] 
            byte[] byteValue = Encoding.Default.GetBytes(strValue); 
            //使用MD5 
            MD5 s1 = MD5.Create(); 
            //進行加密 
            byte[] Change = s1.ComputeHash(byteValue);
            //將加密後的字串從byte[]轉回string
           return Convert.ToBase64String(Change);
        }


    }
}