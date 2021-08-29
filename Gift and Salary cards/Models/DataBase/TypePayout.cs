using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class TypePayout
    {
        public int Id { get; set; }
        public short? IdType { get; set; }
        public int? IdDataCardOrBankAccount { get; set; }

        public virtual SynonimCard IdDataCardOrBankAccountNavigation { get; set; }
        public virtual Payout IdNavigation { get; set; }
        public virtual TypesOfPayout IdTypeNavigation { get; set; }
    }
}
