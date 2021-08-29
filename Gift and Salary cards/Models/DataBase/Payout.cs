using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class Payout
    {
        public Payout()
        {
            StatusPayouts = new HashSet<StatusPayout>();
        }

        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public short TypePayout { get; set; }
        public decimal? SumToPayoutEmployee { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Payment IdNavigation { get; set; }
        public virtual TypePayout TypePayoutNavigation { get; set; }
        public virtual ICollection<StatusPayout> StatusPayouts { get; set; }
    }
}
