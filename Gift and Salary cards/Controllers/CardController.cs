using Gift_and_Salary_cards.Models.Identity;
using Gift_and_Salary_cards.Models.ViewModels;
using Gift_and_Salary_cards.Services;
using Gift_and_Salary_cards.Services.ComissionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Yandex.Checkout.V3;

namespace Gift_and_Salary_cards.Controllers
{


    public class CardController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IUKassaServicePayout ukassaServicePayout;
        private readonly IUkassaServicePayment ukassaServicePayment;
        private readonly IPaymentService paymentService;
        private readonly IComissionService comissionService;



        public CardController(IPaymentService paymentService, IUKassaServicePayout ukassaServicePayout, UserManager<User> userManager, IUkassaServicePayment ukassaServicePayment, IComissionService comissionService)
        {
            this.paymentService = paymentService;
            this.ukassaServicePayout = ukassaServicePayout;
            _userManager = userManager;
            this.ukassaServicePayment = ukassaServicePayment;
            this.comissionService = comissionService;
        }


        /// <summary>
        /// Страница зарплатной карты
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult SalaryCard()
        {
            return View();
        }


        /// <summary>
        /// Пополнение банковской карты сотрудника
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PaymentBankCard(PaymentFormViewModel model)
        {

            // Если данные на форме введены успешно, то необходимо приступить к дальнейшей логике
            if (ModelState.IsValid)
            {
                // Получаем синоним банковской карты
                var synonimCard = ukassaServicePayout.GetSynonimCard(model.bankCardNumber);

                // Если банковская карта не найдена, то вернуть ошибку об этом
                if (synonimCard == null)
                {
                    ModelState.AddModelError("bankCardNumber", "Банковская карта не существует!");

                    return View("SalaryCard", model);
                }

                // Если банковская карта найдена и получили ее синоним от юкассы, то создать ссылку для оплаты
                // И сохранить данные в базе данных по оплате с соответствующим статусом
                var userAuth = await _userManager.GetUserAsync(User);

                var getLastComission = await comissionService.getProcentComission();

                // Сумма выплаты с учетом процентов
                model.moneyPayProcent = (model.moneyPay / 100 * getLastComission.Procent.Value) + model.moneyPay;

                // Создаем платеж для пользователя
                var payment = ukassaServicePayment.createPayment(model, userAuth);

                if (payment != null)
                {



                    // Формируем платежку для бд
                    Models.DataBase.Payment payDb = new Models.DataBase.Payment()
                    {
                        PayerEmail = userAuth.Email,
                        PayerPhone = userAuth.phone,
                        Description = model.textPayment,
                        SumPayment = model.moneyPayProcent,
                        PaymentUserId = userAuth.Id,
                        IdUkassa = payment.Id,
                        IdComission = getLastComission.Id, // Задаем комиссию

                        // Сразу задаем в списке, что платежка создана
                        PaymentStatuses = new List<Models.DataBase.PaymentStatus>()
                        {
                            new Models.DataBase.PaymentStatus()
                            {
                                DateStatus = DateTime.Now,
                                StatusPaymentId = 1,                                
                            }
                        },

                        AddressEmp = model.address,
                        DateBirthEmp = model.dateBirth,
                        DocIssueDateEmp = model.docIssueDate,
                        DocNumberEmp = model.docNumber,
                        CityEmp = model.city,
                        NameEmp = model.Name,
                        SurnameEmp = model.Surname,
                        FamilyEmp = model.Family,
                        CountryEmp = model.country,
                        MoneyPayEmployee = model.moneyPay,
                        PhoneNumberEmp = model.PhoneNumber,
                        PostcodeEmp = model.postcode,
                        CardBank = new Models.DataBase.CardBank()
                        {
                            NumberCard = model.bankCardNumber
                        }
                    };

                    // Теперь сохраняем в базе данных платежку и кидаем пользователя на страницу оплаты
                    bool addDataBase = paymentService.AddPayment(payDb);

                    if (addDataBase == false)
                    {
                        return BadRequest("Ошибка добавления платежа в базу данных");
                    }

                    // Иначе кидаем на страницу оплаты
                    return Redirect(payment.Confirmation.ConfirmationUrl);
                }
            }


            return View("SalaryCard", model);
        }







    }
}
