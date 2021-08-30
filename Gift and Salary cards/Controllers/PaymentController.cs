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

        private readonly IUkassaServicePayment ukassaService;

        public PaymentController(IUkassaServicePayment ukassaService)
        {
            this.ukassaService = ukassaService;
        }


        public IActionResult Ok()
        {
            //var payment = ukassaService.createPayment(new PaymentFormViewModel()
            //{
            //    moneyPay = 5000,
            //    moneyPayProcent = 5600
            //});


            var str = "as;";


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
