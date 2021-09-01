using Gift_and_Salary_cards.Models.ControllerModels;
using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Models.ViewModels;
using Gift_and_Salary_cards.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Controllers
{



    public class PaymentController : Controller
    {

        private readonly IUkassaServicePayment ukassaServicePayment;
        private readonly IPaymentService paymentService;
        

        public PaymentController(IUkassaServicePayment ukassaServicePayment, IPaymentService paymentService)
        {
            this.ukassaServicePayment = ukassaServicePayment;
            this.paymentService = paymentService;
        }



        public async Task<IActionResult> test()
        {

            // Иначе если платежка существующая, то находим эту платежку в базе данных
            var payOnDb = paymentService.getPaymentUkassaId("28c154cc-000f-5000-8000-12bf6ff79b8a");


            var data = payOnDb.PaymentStatuses.Where(i => i.StatusPaymentId == 2 || i.StatusPaymentId == 3).ToList();


            payOnDb.PaymentStatuses.Add(new Models.DataBase.PaymentStatus()
            {
                StatusPaymentId = 2,
                DateStatus = DateTime.Now
            });

            // Теперь необходимо получить чек с юкассы и сохранить в БД
            var reciepts = await ukassaServicePayment.getReciepts(payOnDb.IdUkassa);

            // Если получили чек и он один, то добавить чек в бд
            if (reciepts != null && reciepts.Count() == 1)
            {

                var reciept = reciepts.FirstOrDefault();

                if (payOnDb.CheckPayments == null)
                {
                    payOnDb.CheckPayments = new List<CheckPayment>();
                }

                payOnDb.CheckPayments.Add(new Models.DataBase.CheckPayment()
                {
                    DateRegistered = reciept.registered_at,
                    FiscalAccumulatorNumber = reciept.fiscal_storage_number,
                    FiscalDocumentNumber = reciept.fiscal_document_number,
                    FiscalAttribute = reciept.fiscal_attribute,
                    Status = reciept.status,
                    IdCheckInUkassa = reciept.payment_id,
                    IdCheckCloudCash = reciept.fiscal_provider_id
                });
            }


            // Теперь необходимо создать платеж
            bool addedPayout = paymentService.createPayout(payOnDb);


            // Обновляем информацию в БД
            bool updated = paymentService.updatePayment(payOnDb);


            return Ok();
        }

        /// <summary>
        /// Подтверждение оплаты платежа
        /// </summary>
        /// <returns></returns>
        public IActionResult paymentNotification([FromBody]NotificationPaymentModel model)
        {
            try
            {
                string text = $"Новая платежка | {DateTime.Now}) {model.Object?.id}; {model.Object?.paid}; {model.Object?.status}";


                System.IO.File.AppendAllText("__log.txt", text + "\n");
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("__log.txt", $"{DateTime.Now}) {ex.Message}" + "\n");

            }

            // Ищем платеж на юкассе
            var payment = ukassaServicePayment.getPayment(model.Object.id);

            // Если платежку отправили несуществующую, то вернуть об этом месседж
            if (payment == null)
            {

                System.IO.File.AppendAllText("__log.txt", $"{model.Object.id} Платежка не найдена в БД" + "\n");

                return BadRequest("Платежка, которую отправили не найдена");
            }

            System.IO.File.AppendAllText("__log.txt", $"{model.Object.id} Платежка найдена в БД" + "\n");

            // Иначе если платежка существующая, то находим эту платежку в базе данных
            var payOnDb = paymentService.getPaymentUkassaId(model.Object.id);

            // Если платежку не нашли, то ошибка
            if (payOnDb == null)
            {
                System.IO.File.AppendAllText("__log.txt", "Платежка не найдена" + "\n");
            }



            // Иначе, если нашли платежку и у нее нет статуса оплаты или ошибки, то добавить эту информацию в базу данных
            if (payOnDb.PaymentStatuses.Where(i => i.StatusPaymentId == 2 || i.StatusPaymentId == 3).Count() == 0)
            {

                


                // Если платежка оплачена и статус пришедшего уведомления == true, то добавить этот статус в БД
                if (payment.Paid == true)
                {
                    payOnDb.PaymentStatuses.Add(new Models.DataBase.PaymentStatus()
                    {
                        StatusPaymentId = 2,
                        DateStatus = DateTime.Now
                    });

                    // Обновляем информацию в БД
                    bool updated = paymentService.updatePayment(payOnDb);

                    System.IO.File.AppendAllText("__log.txt", "Добавляем успешную платежку в БД" + "\n");

                    // Теперь необходимо получить чек с юкассы и сохранить в БД
                    var reciepts = ukassaServicePayment.getReciepts(payOnDb.IdUkassa).Result;

                    // Если получили чек и он один, то добавить чек в бд
                    if (reciepts != null && reciepts.Count() == 1)
                    {

                        var reciept = reciepts.FirstOrDefault();

                        if (payOnDb.CheckPayments == null)
                        {
                            payOnDb.CheckPayments = new List<CheckPayment>();
                        }

                        payOnDb.CheckPayments.Add(new Models.DataBase.CheckPayment()
                        {
                            DateRegistered = reciept.registered_at,
                            FiscalAccumulatorNumber = reciept.fiscal_storage_number,
                            FiscalDocumentNumber = reciept.fiscal_document_number,
                            FiscalAttribute = reciept.fiscal_attribute,
                            Status = reciept.status,
                            IdCheckInUkassa = reciept.payment_id,
                            IdCheckCloudCash = reciept.fiscal_provider_id
                        });
                    }


                    // Теперь необходимо создать платеж
                    bool addedPayout = paymentService.createPayout(payOnDb);





                }
                // Иначе если платежка не оплачена, то внести соответствующую информацию
                else if (payment.Paid == false)
                {

                    System.IO.File.AppendAllText("__log.txt", "Добавляем неуспешную платежку в БД" + "\n");

                    payOnDb.PaymentStatuses.Add(new Models.DataBase.PaymentStatus()
                    {
                        StatusPaymentId = 3,
                        DateStatus = DateTime.Now
                    });

                    // Обновляем информацию в БД
                    bool updated = paymentService.updatePayment(payOnDb);
                }

                

            }
            else
            {
                System.IO.File.AppendAllText("__log.txt", "Еррор, что платежка в БД уже добавлена" + "\n");


                return BadRequest("Платежка уже добавлена в БД");
            }


            return Ok();
        }




        public IActionResult Errors()
        {

            throw new Exception("test exception!!!");

            int b = 0;

            var a = 10 / b;

            return Redirect("/");
        }
    }
}
