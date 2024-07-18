using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PP0.EntityFrameworkCore.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfractructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PP0DatabaseContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("PP0local")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<PP0DatabaseContext>();
        }
    }
}
