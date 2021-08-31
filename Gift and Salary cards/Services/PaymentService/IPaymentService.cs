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
        /// Добавление платежа в базу данных
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>True, в случае успеха. Иначе если платежка не добавилась, то false</returns>
        public bool AddPayment(Payment payment);
    }
}
