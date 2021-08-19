using Gift_and_Salary_cards.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Controllers
{

    [Authorize]
    public class CardController : Controller
    {
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
    }
}
