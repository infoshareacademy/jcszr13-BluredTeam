using Microsoft.AspNetCore.Identity;
using PP0.EntityFrameworkCore.Database.Context;
using PP0.EntityFrameworkCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Seeders
{
    public class UserRoleSeeder
    {
        private readonly PP0DatabaseContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeeder(PP0DatabaseContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(await _roleManager.FindByNameAsync(RoleType.Patient.ToString()) is null)
                {
                    IdentityRole role = new IdentityRole() { Name = RoleType.Patient.ToString() };
                    await _roleManager.CreateAsync(role);
                }
                if (await _roleManager.FindByNameAsync(RoleType.Doctor.ToString()) is null)
                {
                    IdentityRole role = new IdentityRole() { Name = RoleType.Doctor.ToString() };
                    await _roleManager.CreateAsync(role);
                }
                if (await _roleManager.FindByNameAsync(RoleType.Admin.ToString()) is null)
                {
                    IdentityRole role = new IdentityRole() { Name = RoleType.Admin.ToString() };
                    await _roleManager.CreateAsync(role);
                }
            }
        }
    }
}
