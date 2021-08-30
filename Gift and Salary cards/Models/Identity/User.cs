using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.Identity
{

    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Имя представителя
        /// </summary>
        public string NameRepresentative { get; set; }

        /// <summary>
        /// Фамилия представителя
        /// </summary>
        public string FamilyRepresentative { get; set; }

        /// <summary>
        /// Отчество представителя
        /// </summary>
        public string SurnameRepresentative { get; set; }

        /// <summary>
        /// Дата рождения представителя
        /// </summary>
        public DateTime dateBirthRepresentative { get; set; }

        /// <summary>
        /// Наименование организации представителя
        /// </summary>
        public string nameOrganization { get; set; }

        /// <summary>
        /// Телефон представителя
        /// </summary>
        public string phone { get; set; }
    }
}
