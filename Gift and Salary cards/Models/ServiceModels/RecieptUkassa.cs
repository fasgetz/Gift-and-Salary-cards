using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.ServiceModels
{



    public class ResponseRecieptUkassa
    {
        public class RecieptUkassa
        {
            public string id { get; set; }
            public string type { get; set; }
            public string payment_id { get; set; }
            public string status { get; set; }
            public string fiscal_document_number { get; set; }
            public string fiscal_storage_number { get; set; }
            public string fiscal_attribute { get; set; }
            public DateTime registered_at { get; set; }
            public string fiscal_provider_id { get; set; }


        }

        public string type { get; set; }

        public List<RecieptUkassa> items { get; set; }
    }
}
