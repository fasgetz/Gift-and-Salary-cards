using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yandex.Checkout.V3;

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

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly GiftCardsContext db;


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
    }
}
