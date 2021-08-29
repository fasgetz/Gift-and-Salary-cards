using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class Payment
    {
        public Payment()
        {
            CheckPayments = new HashSet<CheckPayment>();
            PaymentStatuses = new HashSet<PaymentStatus>();
        }

        public int Id { get; set; }
        public string IdUkassa { get; set; }
        public string PaymentUserId { get; set; }
        public short IdComission { get; set; }
        public decimal SumPayment { get; set; }
        public string Description { get; set; }
        public string PayerEmail { get; set; }
        public string PayerPhone { get; set; }

        public virtual ComissionService IdComissionNavigation { get; set; }
        public virtual Payout Payout { get; set; }
        public virtual ICollection<CheckPayment> CheckPayments { get; set; }
        public virtual ICollection<PaymentStatus> PaymentStatuses { get; set; }
    }
}
