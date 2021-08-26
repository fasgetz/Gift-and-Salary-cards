using Gift_and_Salary_cards.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yandex.Checkout.V3;

namespace Gift_and_Salary_cards.Controllers
{


    public class DataObj
    {
        /// <summary>
        /// id платежа
        /// </summary>
        public string id { get; set; }
    }

    public class PayM
    {
        public string type { get; set; }

        public DataObj Object { get; set; }
    }

    [Authorize]
    public class CardController : Controller
    {
        Client client = new Yandex.Checkout.V3.Client(
            shopId: "828374",
            secretKey: "test_Lflgiiq9CzEnOmi5Rzzj8TYYidssSxirAEJ1ikrmeDI");

        public CardController()
        {



        }


        /// <summary>
        /// Страница зарплатной карты
        /// </summary>
        /// <returns></returns>
        public IActionResult SalaryCard()
        {
            return View();
        }


        /// <summary>
        /// Пополнение банковской карты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PaymentBank(PaymentFormViewModel model)
        {





            if (ModelState.IsValid)
            {

                //if (result.Succeeded)
                //{

                //}
                //else
                //{

                //}
            }
            else
            {
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }

            return View("SalaryCard", model);
        }





        public IActionResult confirm([FromBody]PayM model)
        {
            //var serializer = new JsonSerializer();
            //serializer.Deserialize(Request.Body);
            //JsonConvert.deser(Request.Body);

            string text = $"{model.type} | {model.Object?.id} | " + DateTime.Now.ToString();

            // запись в файл
            using (FileStream fstream = new FileStream($"__note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

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
                    Email = "fasgetz@yandex.ru",
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
