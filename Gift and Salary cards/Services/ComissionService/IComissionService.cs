using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services.ComissionService
{
    public interface IComissionService
    {
        /// <summary>
        /// Метод получения комиссии сервиса
        /// </summary>
        /// <returns></returns>
        public Task<Models.DataBase.ComissionService> getProcentComission();
    }
}
