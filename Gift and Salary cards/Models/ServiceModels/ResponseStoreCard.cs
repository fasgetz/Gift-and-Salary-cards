using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.ServiceModels
{

    /// <summary>
    /// Ответ на запрос получения синонима карты
    /// </summary>
    public partial class ResponseStoreCard
    {
        public class storeCardData
        {
            public string reason { get; set; }
            public string skr_destinationCardProductCode { get; set; }
            public string skr_destinationCardProductName { get; set; }
            public string skr_destinationCardSynonim { get; set; }
            public string skr_destinationCardType { get; set; }
            public string skr_cardBin { get; set; }
            public string skr_cardLast4 { get; set; }
            public string skr_destinationCardCountryCode { get; set; }
            public string skr_destinationCardBankName { get; set; }
            public string skr_destinationCardPanmask { get; set; }
        }


        public storeCardData storeCard { get; set; }
    }
}
