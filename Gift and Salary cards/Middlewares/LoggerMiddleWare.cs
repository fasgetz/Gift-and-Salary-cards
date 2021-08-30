using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Middlewares
{
    public class LoggerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;



        public LoggerMiddleWare(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggerMiddleWare>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();

                //_logger.LogInformation("is invoked");
                //_logger.LogInformation("test inform");

                await _next(context);
            }
            // Критическая ошибка, которая выдает ошибку пользователю
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                // Перейти к следующему компоненту
                await _next(context);
            }
            finally
            {
                _logger.LogInformation("");
            }
        }
    }
}
