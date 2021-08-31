using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class Payout
    {
        public Payout()
        {
            RequestPayouts = new HashSet<RequestPayout>();
        }

        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public decimal? SumToPayoutEmployee { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Payment IdNavigation { get; set; }
        public virtual ICollection<RequestPayout> RequestPayouts { get; set; }
    }
}
