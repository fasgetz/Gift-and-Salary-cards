using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class CardBank
    {
        public int Id { get; set; }
        public string NumberCard { get; set; }

        public virtual Payment IdNavigation { get; set; }
    }
}
