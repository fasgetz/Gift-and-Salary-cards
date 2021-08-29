using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class StatusPayoutType
    {
        public StatusPayoutType()
        {
            StatusPayouts = new HashSet<StatusPayout>();
        }

        public short Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<StatusPayout> StatusPayouts { get; set; }
    }
}
