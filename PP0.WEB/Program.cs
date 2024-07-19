using PP0.WEB.Interfaces;
using PP0.WEB.Services;
using PP0.EntityFrameworkCore.Database.Context;
using Microsoft.EntityFrameworkCore;
using PP0.EntityFrameworkCore.Database.Extensions;

namespace PP0.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddInfractructure(builder.Configuration);

			builder.Services.AddHttpContextAccessor(); // Dodaj tê liniê
            builder.Services.AddTransient<ILoginService, LoginService>();
            builder.Services.AddSingleton<IUserService, UserService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
