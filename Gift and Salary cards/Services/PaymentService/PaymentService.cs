﻿using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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


        /// <summary>
        /// Поиск платежки по айди юкассы
        /// </summary>
        /// <param name="idUkassa_payment">Айди юкассы</param>
        /// <returns>Возвращает платежку, если она найдена в бд</returns>
        public Payment getPaymentUkassaId(string idUkassa_payment)
        {
            var payment = db.Payments.Include("PaymentStatuses").FirstOrDefault(i => i.IdUkassa == idUkassa_payment);

            return payment;
        }



        /// <summary>
        /// Обновить информацию о платежке
        /// </summary>
        /// <param name="payment">Данные платежки</param>
        /// <returns>True в случае успешного редактирования</returns>
        public bool updatePayment(Payment payment)
        {
            db.Payments.Update(payment);
            db.SaveChanges();

            return true;
        }



        /// <summary>
        /// Метод создания выплаты
        /// </summary>
        /// <param name="payment">Данные платежа</param>
        /// <returns>Возвращает true, в случае успешного создания выплаты</returns>
        public bool createPayout(Payment payment)
        {
            Employee emp = new Employee()
            {
                NameEmployee = payment.NameEmp,
                AddressPaymentShip = payment.AddressEmp,
                SeriesAndNumbPasspEmployee = payment.DocNumberEmp,
                DateBirthEmployee = payment.DateBirthEmp,
                DateOfIssueEmployee = payment.DocIssueDateEmp,
                CitizenshipCodeEmployee = payment.CountryEmp,
                CityPaymentShip = payment.CityEmp,
                FamilyEmployee = payment.FamilyEmp,
                PhoneEmployee = payment.PhoneNumberEmp,
                PostCodePaymentShip = payment.PostcodeEmp,
                SurnameEmployee = payment.SurnameEmp,
                Payouts = new List<Payout>()
                {
                    new Payout()
                    {
                        DateCreate = DateTime.Now,
                        Description = payment.Description,
                        SumToPayoutEmployee = payment.MoneyPayEmployee,
                        Id = payment.Id
                    }
                }

            };


            db.Employees.Add(emp);
            db.SaveChanges();


            return true;

        }

    }
}
