using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class CheckPayment
    {
        public int Id { get; set; }
        public int? IdPayment { get; set; }
        public string IdCheckInUkassa { get; set; }
        public string IdCheckCloudCash { get; set; }
        public string FiscalDocumentNumber { get; set; }
        public string FiscalAccumulatorNumber { get; set; }
        public string FiscalAttribute { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string Status { get; set; }

        public virtual Payment IdPaymentNavigation { get; set; }
    }
}
