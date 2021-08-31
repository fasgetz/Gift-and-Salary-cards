using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class StatusPayoutType
    {
        public StatusPayoutType()
        {
            RequestPayouts = new HashSet<RequestPayout>();
        }

        public short Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<RequestPayout> RequestPayouts { get; set; }
    }
}
