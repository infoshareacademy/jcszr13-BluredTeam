using PP0.EntityFrameworkCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Entities
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public RoleType RoleType { get; set; }
    }
}
