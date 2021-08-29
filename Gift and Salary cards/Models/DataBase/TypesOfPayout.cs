using System;
using System.Collections.Generic;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class TypesOfPayout
    {
        public TypesOfPayout()
        {
            TypePayouts = new HashSet<TypePayout>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TypePayout> TypePayouts { get; set; }
    }
}
