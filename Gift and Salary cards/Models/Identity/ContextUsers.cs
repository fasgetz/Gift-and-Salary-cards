﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_and_Salary_cards.Models.Identity
{
    public class ContextUsers : IdentityDbContext<User>
    {
        public ContextUsers(DbContextOptions<ContextUsers> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
