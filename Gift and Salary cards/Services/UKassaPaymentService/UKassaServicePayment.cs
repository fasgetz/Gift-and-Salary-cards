using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ServiceModels;
using Gift_and_Salary_cards.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yandex.Checkout.V3;
using static Gift_and_Salary_cards.Models.ServiceModels.ResponseRecieptUkassa;

namespace Gift_and_Salary_cards.Services
{

    /// <summary>
    /// Реализация сервиса юкассы по платежам
    /// </summary>
    public class UKassaServicePayment : IUkassaServicePayment
    {
        /// <summary>
        /// Клиент по работе с апи платежей юкассы
        /// </summary>
        private readonly Client client;

        private readonly IConfiguration config;

        public UKassaServicePayment(IConfiguration config)
        {
            this.config = config;

            // Биндинги
            var secretKey = config.GetValue<string>("ukassaSettings:paymentSettings:secretKey");
            var shopId = config.GetValue<string>("ukassaSettings:paymentSettings:shopId");

            // Инициализируем клиент
            client = new Yandex.Checkout.V3.Client(shopId: shopId, secretKey: secretKey);
        }

        /// <summary>
        /// Получить список чеков для платежа
        /// </summary>
        /// <param name="payment_id">Айди платежа в юкассе</param>
        /// <returns>Список чеков</returns>
        public async Task<IEnumerable<RecieptUkassa>> getReciepts(string payment_id)
        {
            // Биндинги
            var secretKey = config.GetValue<string>("ukassaSettings:paymentSettings:secretKey");
            var shopId = config.GetValue<string>("ukassaSettings:paymentSettings:shopId");

            using (var httpClient = new HttpClient())
            {
                using (var requests = new HttpRequestMessage(new HttpMethod("GET"), "https://api.yookassa.ru/v3/receipts?payment_id=" + payment_id))
                {
                    var base64authorizations = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{shopId}:{secretKey}"));
                    requests.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorizations}");

                    var responses = await httpClient.SendAsync(requests);

                    // Если ответ успешный, то в JSON
                    if (responses.IsSuccessStatusCode)
                    {
                        var data = await responses.Content.ReadAsStringAsync();


                        var obj = JsonConvert.DeserializeObject<ResponseRecieptUkassa>(data);


                        return obj.items;
                    }
                    
                }
            }

            return null;
        }


        /// <summary>
        /// Создание платежа
        /// </summary>
        /// <param name="model">Данные для платежа</param>
        /// <param name="user">Пользователь Identity</param>
        /// <returns>Платеж, если успешно создан. Иначе null</returns>
        public Yandex.Checkout.V3.Payment createPayment(PaymentFormViewModel model, User user)
        {
            // 1. Создайте платеж и получите ссылку для оплаты
            var newPayment = new NewPayment
            {
                Amount = new Amount { Value = model.moneyPayProcent, Currency = "RUB" },
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,
                    ReturnUrl = config.GetValue<string>("ukassaSettings:paymentSettings:returnUrl")
                },
                Description = model.textPayment,
                Capture = true,
                Receipt = new Receipt()
                {
                    Email = user.Email,
                    Phone = user.phone,
                    Items = new System.Collections.Generic.List<ReceiptItem>()
                    {
                        new ReceiptItem()
                        {
                            Amount = new Amount()
                            {
                                Currency = "RUB",
                                Value = model.moneyPayProcent
                            },
                            Description = model.textPayment,
                            Quantity = 1,
                            VatCode = VatCode.NoVat
                        }
                    }
                }
            };

            // Создаем платеж
            Yandex.Checkout.V3.Payment payment = client.CreatePayment(newPayment);

            return payment;

        }


        /// <summary>
        /// Получить платеж по айди
        /// </summary>
        /// <param name="id_payment">Айди платежа</param>
        /// <returns>Возвращает платеж</returns>
        public Yandex.Checkout.V3.Payment getPayment(string id_payment)
        {
            var payment = client.GetPayment(id_payment);

            return payment;
        }
    }
}
