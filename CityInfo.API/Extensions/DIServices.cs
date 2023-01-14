
using CityInfo.Application.MailService;
using CityInfo.Core.IRepositories;
using CityInfo.Core.IUnitOfWork;
using CityInfo.Infrastructure.Respositories;
using CityInfo.Infrastructure.UnitOfWork;

namespace CityInfo.API.Extensions
{
    public static class DIServices
    {
        public static void Dependencies(this IServiceCollection services)
        {
            #if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
            #else
            services.AddTransient<IMailService, CloudMailService>();
            #endif

            services.AddSingleton<CitiesDataStore>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
