using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Controllers
{
    public class ContactsController : Controller
    {
        public ContactsController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
