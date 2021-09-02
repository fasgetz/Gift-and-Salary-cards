using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services.EmailServiceAccount
{
    public interface IEmailServiceAccount
    {
        /// <summary>
        /// Метод отправки сообщения на email
        /// </summary>
        /// <param name="emailTo">Адрес</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="message">Сообщение</param>
        /// <param name="description">Дескрипшен к почте (предисловие в письме)</param>
        /// <returns></returns>
        public Task SendEmailAsync(string emailTo, string subject, string message, string description = "Сообщение от зарплатного сервиса virtcards");
    }
}
