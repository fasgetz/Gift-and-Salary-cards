using Gift_and_Salary_cards.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Services
{

    /// <summary>
    /// Интерфейс по работе с юкассой
    /// </summary>
    public interface IUKassaServicePayout
    {
        /// <summary>
        /// Метод, необходимый для получения синонима банковской карты
        /// </summary>
        ///<remarks>
        /// Перед отправкой запроса на выплату, необходимо получить синоним банковской карты!
        /// </remarks>
        /// <param name="cardNumber">Номер банковской карты</param>
        /// <param name="method">Метод получения банковской карты (по умолчанию json)</param>
        public ResponseStoreCard GetSynonimCard(string cardNumber, string method = "json");
    }
}
