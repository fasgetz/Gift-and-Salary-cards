using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class AccountBankStore
    {
        public int Id { get; set; }
        public string BankBicName { get; set; }
        public string CustAccount { get; set; }
        public string PaymentPurpose { get; set; }
        public int? IdPayment { get; set; }

        public virtual Payment IdPaymentNavigation { get; set; }
    }
}
