using CalcTest.Domain.Interfaces;
using CalcTest.Domain.Notifications;
using CalcTest.Service.Interfaces;
using CalcTest.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalcTest.DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDomainNotification, DomainNotification>();
            services.AddScoped<IJurosCompostosService, JurosCompostosService>();
        }

       
    }
}
