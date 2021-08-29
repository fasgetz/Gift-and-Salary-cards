using Gift_and_Salary_cards.Models.ServiceModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services
{

    /// <summary>
    /// Сервис по работе с юкассой
    /// </summary>
    public class UKassaService : IUKassaService
    {

        /// <summary>
        /// Метод, необходимый для получения синонима банковской карты
        /// </summary>
        ///<remarks>
        /// Перед отправкой запроса на выплату, необходимо получить синоним банковской карты!
        /// </remarks>
        /// <param name="cardNumber">Номер банковской карты</param>
        /// <param name="method">Метод получения банковской карты (по умолчанию json)</param>
        public ResponseStoreCard GetSynonimCard(string cardNumber, string method = "json")
        {
            var client = new RestClient("https://paymentcard.yoomoney.ru/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("gates/card/storeCard");
            request.AddParameter("skr_destinationCardNumber", cardNumber);
            request.AddParameter("skr_responseFormat", method);
            //request.AddHeader("header", "value");


            var response2 = client.Post<ResponseStoreCard>(request);

            var obj = response2.Data;

            if (obj.storeCard.reason == "success")
            {
                return obj;
            }


            return null;
        }
    }
}
