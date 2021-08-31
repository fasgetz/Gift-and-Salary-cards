using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class RequestPayout
    {
        public int Id { get; set; }
        public int? IdPayout { get; set; }
        public short? IdStatus { get; set; }
        public string RequestDate { get; set; }
        public string RequestId { get; set; }
        public string ResponseMessage { get; set; }
        public short? ErrorId { get; set; }

        public virtual Payout IdPayoutNavigation { get; set; }
        public virtual StatusPayoutType IdStatusNavigation { get; set; }
        public virtual RequestPayoutBankSynonim RequestPayoutBankSynonim { get; set; }
    }
}
