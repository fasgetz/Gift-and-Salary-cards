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


    public class DataObj
    {

        public class CardData
        {

            public class Card
            {
                public string first6 { get; set; }
                public string last4 { get; set; }
                public string expiry_month { get; set; }
                public string expiry_year { get; set; }
                public string card_type { get; set; }
            }

            public string id { get; set; }
            public string type { get; set; }
            public string saved { get; set; }
            public Card card { get; set; }
            public string issuer_country { get; set; }
            public string issuer_name { get; set; }



        }
        /// <summary>
        /// id платежа
        /// </summary>
        public string id { get; set; }


        /// <summary>
        /// Статус платежа
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Оплачен
        /// </summary>
        public bool paid { get; set; }



        /*            public string created_at { get; set; }
                    public string description { get; set; }
                    public string expires_at { get; set; }


                    public CardData payment_method { get; set; }
                    public string title { get; set; }*/
    }

    public class PayM
    {
        public string type { get; set; }

        public DataObj Object { get; set; }
    }

    public class CardController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IUKassaServicePayout ukassaServicePayout;
        private readonly IUkassaServicePayment ukassaServicePayment;
        private readonly IPaymentService paymentService;
        private readonly IComissionService comissionService;

        Client client = new Yandex.Checkout.V3.Client(
            shopId: "828374",
            secretKey: "test_Lflgiiq9CzEnOmi5Rzzj8TYYidssSxirAEJ1ikrmeDI");

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
                        BankCardPayout = new Models.DataBase.BankCardPayout()
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





        public IActionResult confirm([FromBody]PayM model)
        {
            //var serializer = new JsonSerializer();
            //serializer.Deserialize(Request.Body);
            //JsonConvert.deser(Request.Body);



            try
            {
                string text = $"{DateTime.Now}) {model.Object?.id}; {model.Object?.paid}; {model.Object?.status}";


                System.IO.File.AppendAllText("__log.txt", text + "\n");
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("__log.txt", $"{DateTime.Now}) {ex.Message}" + "\n");

            }


            //// запись в файл
            //using (FileStream fstream = new FileStream($"__note.txt", FileMode.OpenOrCreate))
            //{
            //    // преобразуем строку в байты
            //    byte[] array = System.Text.Encoding.Default.GetBytes(text);
            //    // запись массива байтов в файл
            //    fstream.Write(array, 0, array.Length);

                
            //}

            return Ok();
        }


        [HttpGet]
        public IActionResult Test()
        {

            // 1. Создайте платеж и получите ссылку для оплаты
            var newPayment = new NewPayment
            {                
                Amount = new Amount { Value = 2000.00m, Currency = "RUB" },
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,                    
                    ReturnUrl = "http://localhost/thankyou?idpayment=fasfd"
                },
                Description = "Оплата заказа №2135 для fasgetz@yandex.ru",
                Capture = true,                
                Receipt = new Receipt()
                {                    
                    Email = "thefasgetz@yandex.ru",
                    Phone = "79629007965",
                    Items = new System.Collections.Generic.List<ReceiptItem>()
                    {
                        new ReceiptItem()
                        {
                            Amount = new Amount()
                            {
                                Currency = "RUB",
                                Value = 1000
                            },
                            Description = "Товар такой-то под артикулом 2013",
                            Quantity = 2,
                            VatCode = VatCode.NoVat
                        }
                    }
                }
            };


            Payment payment = null;

            try
            {
                payment = client.CreatePayment(newPayment);
            }
            catch (Exception ex)
            {
                string asdf = "adsfsadf";
            }


            //// 2. Перенаправьте пользователя на страницу оплаты
            string url = payment.Confirmation.ConfirmationUrl;

            return Redirect(url);

        }


    }
}
