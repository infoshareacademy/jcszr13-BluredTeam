using PP0.WEB.Interfaces;
using PP0.WEB.Services;
using PP0.EntityFrameworkCore.Database.Context;
using Microsoft.EntityFrameworkCore;
using PP0.EntityFrameworkCore.Database.Extensions;
using PP0.EntityFrameworkCore.Database.Seeders;
using PP0.API.NFZ.ServiceWorkers;

namespace PP0.WEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddInfractructure(builder.Configuration);

			builder.Services.AddHttpContextAccessor(); // Dodaj tê liniê
            builder.Services.AddTransient<ILoginService, LoginService>();
            builder.Services.AddTransient<IUserServiceDb, UserServiceDb>();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddHostedService<TestWorker>();
            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<UserRoleSeeder>();
            await seeder.Seed();

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

            app.MapRazorPages();

            app.Run();
        }
    }
}
