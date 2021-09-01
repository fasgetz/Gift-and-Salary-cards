using Gift_and_Salary_cards.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services
{

    /// <summary>
    /// Интерфейс сервиса платежей
    /// </summary>
    public interface IPaymentService
    {


        /// <summary>
        /// Метод создания выплаты
        /// </summary>
        /// <param name="payment">Данные платежа</param>
        /// <returns>Возвращает true, в случае успешного создания выплаты</returns>
        public bool createPayout(Payment payment);


        /// <summary>
        /// Добавление платежа в базу данных
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>True, в случае успеха. Иначе если платежка не добавилась, то false</returns>
        public bool AddPayment(Payment payment);


        /// <summary>
        /// Поиск платежки по айди юкассы
        /// </summary>
        /// <param name="idUkassa_payment">Айди юкассы</param>
        /// <returns>Возвращает платежку, если она найдена в бд</returns>
        public Payment getPaymentUkassaId(string idUkassa_payment);

        /// <summary>
        /// Обновить информацию о платежке
        /// </summary>
        /// <param name="payment">Данные платежки</param>
        /// <returns>True в случае успешного редактирования</returns>
        public bool updatePayment(Payment payment);
    }
}
