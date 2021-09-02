using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services.EmailServiceAccount
{
    public class EmailServiceAccount : IEmailServiceAccount
    {

        private readonly IConfiguration config;
        private readonly string emailFrom;
        private readonly string emailPassword;
        private readonly string smtpHost;
        private readonly short smtpPort;

        public EmailServiceAccount(IConfiguration config)
        {
            emailFrom = config.GetValue<string>("emailSettings:email");
            emailPassword = config.GetValue<string>("emailSettings:password");
            smtpHost = config.GetValue<string>("emailSettings:smtpHost");
            smtpPort = config.GetValue<short>("emailSettings:smtpPort");
        }


        /// <summary>
        /// Метод отправки сообщения на email
        /// </summary>
        /// <param name="emailTo">Адрес</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string emailTo, string subject, string message)
        {
            // SMTP YANDEX
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("virtcards", emailFrom));
            emailMessage.To.Add(new MailboxAddress(emailTo, emailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpHost, smtpPort, true);
                await client.AuthenticateAsync(emailFrom, emailPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }

        }
    }
}
