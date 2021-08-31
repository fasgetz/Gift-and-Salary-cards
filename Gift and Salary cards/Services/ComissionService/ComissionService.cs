using Gift_and_Salary_cards.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services.ComissionService
{
    public class ComissionService : IComissionService
    {

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly GiftCardsContext db;

        public ComissionService(GiftCardsContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Метод получения комиссии сервиса
        /// </summary>
        /// <returns></returns>
        public async Task<Models.DataBase.ComissionService> getProcentComission()
        {
            var comission = await db.ComissionServices.OrderBy(i => i.Id).LastOrDefaultAsync();


            return comission;
        }
    }
}
