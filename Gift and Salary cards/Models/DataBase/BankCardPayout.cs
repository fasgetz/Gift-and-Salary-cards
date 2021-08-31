using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class BankCardPayout
    {
        public int Id { get; set; }
        public string NumberCard { get; set; }
        public int? IdPayment { get; set; }

        public virtual Payment IdPaymentNavigation { get; set; }
    }
}
