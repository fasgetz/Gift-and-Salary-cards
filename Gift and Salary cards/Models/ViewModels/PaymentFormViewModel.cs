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
        [Required(ErrorMessage = "Номер банковской карты обязателен к заполнению")]
        [Display(Name = "Номер банковской карты")]
        [DataType(DataType.CreditCard)]
        [MinLength(length: 16, ErrorMessage = "Введите 16-ти значный номер банковской карты!")]
        [MaxLength(length: 16, ErrorMessage = "Введите 16-ти значный номер банковской карты!")]
        public string bankCardNumber { get; set; }


        //[Required]
        [Display(Name = "Принятие оферты Юкасса")]
        public bool offerAccepted { get; set; }


        [Required]
        [Display(Name = "Сумма пополнения карты сотрудника")]
        [Range(1, 60000, ErrorMessage = "Сумма пополнения за раз может быть не больше 60 000 Р")]
        public decimal moneyPay { get; set; }

        [Required]
        [Display(Name = "Сумма списания с учетом % сервиса virtcards")]
        public decimal moneyPayProcent { get; set; }


        [Required(ErrorMessage = "Примечание к выплате обязательно к заполнению")]
        [Display(Name = "Примечание к выплате, которое увидит сотрудник")]
        [MinLength(10, ErrorMessage = "Минимальное количество символов 10")]
        public string textPayment { get; set; }


        #region Данные сотрудника (протестить обязательно ли заполнять)

        [Required(ErrorMessage = "Имя обязательно к заполнению")]
        [Display(Name = "Имя сотрудника")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна к заполнению")]
        [Display(Name = "Фамилия сотрудника")]
        public string Family { get; set; }

        [Display(Name = "Отчество сотрудника")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Серия и номер паспорта обязательно к заполнению")]
        [Display(Name = "Серия и номер паспорта сотрудника")]
        [MinLength(length: 10, ErrorMessage = "Серия и номер паспорта состоят из 10-ти символов")]
        [MaxLength(length: 10, ErrorMessage = "Серия и номер паспорта состоят из 10-ти символов")]        
        public string docNumber { get; set; }

        [Required(ErrorMessage = "Дата выдачи паспорта обязательно к заполнению")]
        [Display(Name = "Дата выдачи паспорта в формате ДД.ММ.ГГГГ")]
        public DateTime docIssueDate { get; set; }

        [Required(ErrorMessage = "Введите номер телефона!")]
        [MaxLength(length: 11, ErrorMessage = "Номер телефона состоит из 11-ти символов")]
        [MinLength(length: 11, ErrorMessage = "Номер телефона состоит из 11-ти символов")]
        [Display(Name = "Номер телефона сотрудника")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна к заполнению")]
        [Display(Name = "Дата рождения сотрудника")]
        public DateTime dateBirth { get; set; }

        [Required(ErrorMessage = "Гражданство обязательно к заполнению")]
        [Display(Name = "Гражданство сотрудника")]
        public string country { get; set; }

        [Required(ErrorMessage = "Город получателя платежа обязателен к заполнению")]
        [Display(Name = "Город получателя платежа")]
        [MaxLength(length: 30, ErrorMessage = "Город получателя платежа не больше 30 символов!")]
        public string city { get; set; }

        [Required(ErrorMessage = "Адрес получателя платежа обязателен к заполнению")]
        [Display(Name = "Адрес получателя платежа")]
        [MaxLength(length: 100, ErrorMessage = "Адрес платежа не больше 100 символов!")]
        [DataType(DataType.Text)]
        public string address { get; set; }

        [Required(ErrorMessage = "Почтовый индекс обязателен к заполнению")]
        [Display(Name = "Почтовый индекс")]
        [MaxLength(length: 6, ErrorMessage = "Почтовый индекс не больше 6 символов!")]
        public string postcode { get; set; }

        #endregion


    }
}
