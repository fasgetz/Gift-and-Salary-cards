using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class PaymentStatus
    {
        public int Id { get; set; }
        public int? PaymentId { get; set; }
        public short? StatusPaymentId { get; set; }
        public DateTime? DateStatus { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual StatusPaymentType StatusPayment { get; set; }
    }
}
