﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Entities
{
    internal class Password
    {
        public string Pass { get; init; }

        public Password(string password)
        {
            Pass = password;
        }
    }
}
