using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class ComissionService
    {
        public ComissionService()
        {
            Payments = new HashSet<Payment>();
        }

        public short Id { get; set; }
        public decimal? Procent { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
