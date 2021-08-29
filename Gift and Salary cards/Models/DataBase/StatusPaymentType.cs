using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class StatusPaymentType
    {
        public StatusPaymentType()
        {
            PaymentStatuses = new HashSet<PaymentStatus>();
        }

        public short Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<PaymentStatus> PaymentStatuses { get; set; }
    }
}
