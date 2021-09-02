using Gift_and_Salary_cards.Models.ControllerModels;
using Gift_and_Salary_cards.Models.DataBase;
using Gift_and_Salary_cards.Services;
using Gift_and_Salary_cards.Services.EmailServiceAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Controllers
{



    public class PaymentController : Controller
    {
        readonly ILogger<PaymentController> logger;
        private readonly IUkassaServicePayment ukassaServicePayment;
        private readonly IPaymentService paymentService;
        readonly IEmailServiceAccount emailService;
        readonly IServiceScopeFactory serviceScopeFactory;

        public PaymentController(ILogger<PaymentController> logger, IUkassaServicePayment ukassaServicePayment, IPaymentService paymentService, IEmailServiceAccount emailService, IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.ukassaServicePayment = ukassaServicePayment;
            this.paymentService = paymentService;
            this.emailService = emailService;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Подтверждение оплаты платежа
        /// </summary>
        /// <returns></returns>
        public IActionResult paymentNotification([FromBody]NotificationPaymentModel model)
        {

            // Ищем платеж на юкассе
            var payment = ukassaServicePayment.getPayment(model.Object.id);

            // Если платежку отправили несуществующую, то вернуть об этом месседж
            if (payment == null)
            {
                logger.LogInformation($"Платежка не найдена в бд №{payment.Id}");

                return BadRequest("Платежка, которую отправили не найдена");
            }


            // Иначе если платежка существующая, то находим эту платежку в базе данных
            var payOnDb = paymentService.getPaymentUkassaId(model.Object.id);

            // Если платежку не нашли, то ошибка
            if (payOnDb == null)
            {
                logger.LogInformation($"Платежка не найдена {payOnDb.Id}");
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

                    logger.LogInformation($"Добавляем успешную платежку в БД {payOnDb.Id}");

                    // Теперь необходимо создать платеж
                    bool addedPayout = paymentService.createPayout(payOnDb);



                    // Отдельно обновляем сессию пользователя
                    _ = Task.Run(async () =>
                    {

                        using var scope = serviceScopeFactory.CreateScope();
                        var ukassaRep = scope.ServiceProvider.GetRequiredService<IUkassaServicePayment>();
                        var payRep = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                        var emailServ = scope.ServiceProvider.GetRequiredService<IEmailServiceAccount>();

                        // 10 раз в течении минуты пробуем загрузить инфу о чеках
                        for (int i = 0; i <= 100; i++)
                        {
                            Thread.Sleep(60000);


                            // Теперь необходимо получить чек с юкассы и сохранить в БД
                            var reciepts = await ukassaRep.getReciepts(payOnDb.IdUkassa);


                            logger.LogInformation($"Айди платежки {payOnDb.IdUkassa}| Попытка №{i + 1} | Пришло чеков: {reciepts?.Count()}");

                            // Если получили чек и он один, то добавить чек в бд
                            if (reciepts.FirstOrDefault() != null)
                            {
                                var reciept = reciepts.FirstOrDefault();

                                logger.LogInformation($"Добавляем чек №{reciept.id} платежки {payOnDb.IdUkassa}| в БД ");

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

                                payRep.updatePayment(payOnDb);

                                // Формируем сообщение
                                StringBuilder str = new StringBuilder();
                                str.Append("<h3>Платеж выполнен успешно!</h3>");
                                str.Append($"<p>Заказ №{payOnDb.Id}</p>");
                                str.Append($"<p>Дата и время №{payOnDb.PaymentStatuses.OrderByDescending(i => i.DateStatus).FirstOrDefault().DateStatus}</p>");
                                str.Append($"<p>Оплаченная сумма {payOnDb.SumPayment}</p>");
                                str.Append($"<p>Сумма к зачислению {payOnDb.MoneyPayEmployee}</p>");
                                str.Append($"<br/><b><p>Чек прихода на {payOnDb.SumPayment}</b></p>");
                                str.Append($"<p>Дата создания чека {reciept.registered_at}</p>");
                                str.Append($"<p>Номер фискального документа {reciept.fiscal_document_number}</p>");
                                str.Append($"<p>Номер фискального накопителя {reciept.fiscal_storage_number}</p>");
                                str.Append($"<p>Фискальный признак {reciept.fiscal_attribute}</p>");


                                // Теперь необходимо сделать рассылку на email о чеке
                                await emailServ.SendEmailAsync(payOnDb.PayerEmail, $"Информация о платеже №{payOnDb.Id}", str.ToString(), $"Ваш платеж №{payOnDb.Id} успешно произведен!");
                                
                                // Теперь необходимо сделать дубликат-рассылку на email о чеке
                                await emailServ.SendEmailAsync("fasgetz@yandex.ru", $"Дубликат-Информация о платеже №{payOnDb.Id}", str.ToString(), $"Ваш платеж №{payOnDb.Id} успешно произведен!");

                                break;
                            }
                            else
                            {
                                logger.LogInformation($"Чек платежки {payOnDb.IdUkassa} добавить не можем, т.к. его нету на сервере юкассы");
                            }

                            logger.LogInformation($"Выход из цикла, т.к. чек добавлен");
                        }
                        


                    });


                }
                // Иначе если платежка не оплачена, то внести соответствующую информацию
                else if (payment.Paid == false)
                {
                    logger.LogInformation($"Платежку неудачно оплаченную платежку №{payment.Id} в бд");


                    payOnDb.PaymentStatuses.Add(new Models.DataBase.PaymentStatus()
                    {
                        StatusPaymentId = 3,
                        DateStatus = DateTime.Now
                    });

                    // Обновляем информацию в БД
                    bool updated = paymentService.updatePayment(payOnDb);


                    // Формируем сообщение
                    StringBuilder str = new StringBuilder();
                    str.Append("<h3>Оплату не удалось произвести! Повторите попытку</h3>");
                    str.Append($"<p>Заказ №{payOnDb.Id}</p>");
                    str.Append($"<p>Дата и время №{payOnDb.PaymentStatuses.OrderByDescending(i => i.DateStatus).FirstOrDefault().DateStatus}</p>");
                    str.Append($"<p>Сумма к оплате {payOnDb.SumPayment}</p>");
                    str.Append($"<p>Сумма к зачислению {payOnDb.MoneyPayEmployee}</p>");

                    // Теперь необходимо сделать рассылку на email о чеке
                    emailService.SendEmailAsync(payOnDb.PayerEmail, $"Информация о платеже №{payOnDb.Id}", str.ToString(), $"Ваш платеж №{payOnDb.Id} выполнить не удалось!");

                    // Теперь необходимо сделать дубликат-рассылку на email о чеке
                    emailService.SendEmailAsync("fasgetz@yandex.ru", $"Дубликат-Информация о платеже №{payOnDb.Id}", str.ToString(), $"Ваш платеж №{payOnDb.Id} выполнить не удалось!");
                }

                

            }
            else
            {
                logger.LogError($"Платежка {payOnDb.IdUkassa} уже добавлена в БД");

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
