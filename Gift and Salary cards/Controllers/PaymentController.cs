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

        private readonly IUKassaService ukassaService;

        public PaymentController(IUKassaService ukassaService)
        {
            this.ukassaService = ukassaService;
        }


    }
}
