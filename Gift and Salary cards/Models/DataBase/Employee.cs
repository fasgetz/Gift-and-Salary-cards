using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class Employee
    {
        public Employee()
        {
            Payouts = new HashSet<Payout>();
        }

        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string FamilyEmployee { get; set; }
        public string SurnameEmployee { get; set; }
        public string SeriesAndNumbPasspEmployee { get; set; }
        public DateTime DateOfIssueEmployee { get; set; }
        public string PhoneEmployee { get; set; }
        public DateTime DateBirthEmployee { get; set; }
        public string CitizenshipCodeEmployee { get; set; }
        public string CityPaymentShip { get; set; }
        public string AddressPaymentShip { get; set; }
        public string PostCodePaymentShip { get; set; }

        public virtual ICollection<Payout> Payouts { get; set; }
    }
}
