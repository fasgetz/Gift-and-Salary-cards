using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yandex.Checkout.V3;
using static Gift_and_Salary_cards.Models.ServiceModels.ResponseRecieptUkassa;

namespace Gift_and_Salary_cards.Services
{

    /// <summary>
    /// Интерфейс сервиса юкассы по платежам
    /// </summary>
    public interface IUkassaServicePayment
    {
        /// <summary>
        /// Создание платежа
        /// </summary>
        /// <param name="model">Данные для платежа</param>
        /// <param name="user">Пользователь Identity</param>
        /// <returns>Платеж, если успешно создан. Иначе null</returns>
        public Payment createPayment(PaymentFormViewModel model, User user);



        /// <summary>
        /// Получить платеж по айди
        /// </summary>
        /// <param name="id_payment">Айди платежа</param>
        /// <returns>Возвращает платеж</returns>
        public Yandex.Checkout.V3.Payment getPayment(string id_payment);


        /// <summary>
        /// Получить список чеков для платежа
        /// </summary>
        /// <param name="payment_id">Айди платежа в юкассе</param>
        /// <returns>Список чеков</returns>
        public Task<IEnumerable<RecieptUkassa>> getReciepts(string payment_id);
    }
}
