using Microsoft.Extensions.DependencyInjection;
using PP0.API.NFZ.ServiceWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.API.NFZ
{
    public static class ApiNfzExtensions
    {
        public static void AddApiNfz(this IServiceCollection services)
        {
           // services.AddSingleton<TestWorker>();
            services.AddHostedService<TestWorker>();
        }
    }
}
