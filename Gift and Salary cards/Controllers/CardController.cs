using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Controllers
{
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
    }
}
