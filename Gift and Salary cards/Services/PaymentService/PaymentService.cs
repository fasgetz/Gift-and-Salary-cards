using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services
{

    /// <summary>
    /// Реализация сервиса платежей
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly GiftCardsContext db;

        public PaymentService(GiftCardsContext db)
        {
            this.db = db;
        }



        /// <summary>
        /// Добавление платежа в базу данных
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>True, в случае успеха. Иначе если платежка не добавилась, то false</returns>
        public bool AddPayment(Payment payment)
        {
            db.Add(payment);
            db.SaveChanges();

            return true;

        }



    }
}
