using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// ZIPCode
    /// </summary>
    public class MZIPCode
    {
        public MZIPCode() { }

        private string _ZIPCode;
        private string _City;
        private string _Area;

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string ZIPCode
        {
            set { _ZIPCode = value; }
            get { return _ZIPCode; }
        }

        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set { _City = value; }
            get { return _City; }
        }

        /// <summary>
        /// 地區
        /// </summary>
        public string Area
        {
            set { _Area = value; }
            get { return _Area; }
        }

    }
}
