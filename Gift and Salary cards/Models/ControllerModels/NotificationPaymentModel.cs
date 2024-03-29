﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.ControllerModels
{

    /// <summary>
    /// Данные уведомления об оплате
    /// </summary>
    public partial class NotificationPaymentModel
    {
        public class CardData
        {
            public class Amount
            {
                public string value { get; set; }
                public string currency { get; set; }
            }

            public Amount income_amount { get; set; }


            /// <summary>
            /// id платежа
            /// </summary>
            public string id { get; set; }


            /// <summary>
            /// Статус платежа
            /// </summary>
            public string status { get; set; }

            /// <summary>
            /// Оплачен
            /// </summary>
            public bool paid { get; set; }


        }

        public string type { get; set; }

        public CardData Object { get; set; }
    }
}
