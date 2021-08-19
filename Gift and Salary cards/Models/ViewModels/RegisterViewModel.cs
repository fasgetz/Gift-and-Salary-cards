using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.ViewModels
{
    public partial class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Имя представителя")]
        public string NameRepresentative { get; set; }

        [Required]
        [Display(Name = "Фамилия представителя")]
        public string FamilyRepresentative { get; set; }

        [Display(Name = "Отчество представителя")]
        public string SurnameRepresentative { get; set; }

        [Required]
        [Display(Name = "Дата рождения представителя")]
        public DateTime dateBirthRepresentative { get; set; }

        [Required]
        [Display(Name = "Наименование организации")]
        public string nameOrganization { get; set; }

        [Required]
        [MaxLength(length: 11, ErrorMessage = "Введите номер телефона!")]
        [MinLength(length: 11, ErrorMessage = "Введите номер телефона!")]
        [Display(Name = "Номер телефона")]
        public string phone { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
