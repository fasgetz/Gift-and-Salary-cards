﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class RequestPayoutBankSynonim
    {
        public int IdRequest { get; set; }
        public string Reason { get; set; }
        public string SkrDestinationCardProductCode { get; set; }
        public string SkrDestinationCardProductName { get; set; }
        public string SkrDestinationCardSynonim { get; set; }
        public string SkrDestinationCardType { get; set; }
        public string SkrCardBin { get; set; }
        public string SkrCardLast4 { get; set; }
        public string SkrDestinationCardCountryCode { get; set; }
        public string SkrDestinationCardBankName { get; set; }
        public string SkrDestinationCardPanmask { get; set; }

        public virtual RequestPayout IdRequestNavigation { get; set; }
    }
}
