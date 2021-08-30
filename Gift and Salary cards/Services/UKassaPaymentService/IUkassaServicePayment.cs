using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yandex.Checkout.V3;

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
    }
}
