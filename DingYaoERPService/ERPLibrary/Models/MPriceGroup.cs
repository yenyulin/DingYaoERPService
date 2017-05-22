using System;

namespace DingYaoERP.Models
{
    /// <summary>
    /// PriceGroup
    /// </summary>
    public class MPriceGroup
    {
        public MPriceGroup() { }

        private string _PriceGroupID;
        private string _PriceGroup;
        private DateTime _CreateDate;
        private string _CreateUser;
        private DateTime _UpdateDate;
        private string _UpdateUser;

        /// <summary>
        /// 價格群組代號
        /// </summary>
        public string PriceGroupID
        {
            set { _PriceGroupID = value; }
            get { return _PriceGroupID; }
        }

        /// <summary>
        /// 價格群組
        /// </summary>
        public string PriceGroup
        {
            set { _PriceGroup = value; }
            get { return _PriceGroup; }
        }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
        }

        /// <summary>
        /// 建立人員
        /// </summary>
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateDate
        {
            set { _UpdateDate = value; }
            get { return _UpdateDate; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

    }
}
