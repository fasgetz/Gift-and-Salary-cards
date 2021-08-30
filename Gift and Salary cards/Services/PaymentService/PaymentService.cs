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




        public void AddPayment(Payment payment)
        {
            //Payment pay = new Payment()
            //{
            //    Description = model.textPayment,
            //};


        }



    }
}
