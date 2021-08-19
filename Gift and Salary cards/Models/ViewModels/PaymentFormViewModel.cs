using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.ViewModels
{

    /// <summary>
    /// Форма для оплаты ЮKassa
    /// </summary>
    public partial class PaymentFormViewModel
    {
        [Required]
        [Display(Name = "Номер банковской карты")]
        [MinLength(length: 16, ErrorMessage = "Введите 16-ти значный номер банковской карты!")]
        [MaxLength(length: 16, ErrorMessage = "Введите 16-ти значный номер банковской карты!")]
        public string skr_destinationCardSynonim { get; set; }


        //[Required]
        [Display(Name = "Принятие оферты Юкасса")]
        public bool offerAccepted { get; set; }


        [Required]
        [Display(Name = "Сумма пополнения карты сотрудника")]
        public decimal moneyPay { get; set; }

        [Required]
        [Display(Name = "Сумма списания с учетом % сервиса virtcards")]
        public decimal moneyPayProcent { get; set; }


        [Display(Name = "Описание платежа к транзакции")]
        public string textPayment { get; set; }


        #region Данные сотрудника (протестить обязательно ли заполнять)

        [Required]
        [Display(Name = "Имя сотрудника")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия сотрудника")]
        public string Family { get; set; }

        [Display(Name = "Отчество сотрудника")]
        public string Surname { get; set; }


        [Required]
        [Display(Name = "Серия и номер паспорта сотрудника")]
        public string docNumber { get; set; }

        [Required]
        [Display(Name = "Дата выдачи паспорта в формате ДД.ММ.ГГГГ")]
        public DateTime docIssueDate { get; set; }

        [Required]
        [MaxLength(length: 11, ErrorMessage = "Введите номер телефона!")]
        [MinLength(length: 11, ErrorMessage = "Введите номер телефона!")]
        [Display(Name = "Номер телефона сотрудника")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Дата рождения сотрудника")]
        public DateTime dateBirth { get; set; }

        [Required]
        [Display(Name = "Гражданство сотрудника")]
        public string country { get; set; }

        [Required]
        [Display(Name = "Город получателя платежа")]
        [MaxLength(length: 30, ErrorMessage = "Город получателя платежа не больше 30 символов!")]
        public string city { get; set; }

        [Required]
        [Display(Name = "Адрес получателя платежа")]
        [MaxLength(length: 100, ErrorMessage = "Адрес платежа не больше 100 символов!")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Почтовый индекс")]
        [MaxLength(length: 6, ErrorMessage = "Почтовый индекс не больше 6 символов!")]
        public string postcode { get; set; }

        #endregion


    }
}
