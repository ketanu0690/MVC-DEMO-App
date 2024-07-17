using DemoMVCApplication.Models.Contracts;
using DemoMVCApplication.Models.Dto;
using DemoMVCApplication.Repository;
using DemoMVCApplication.Services;

namespace DemoMVCApplication.services
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDemoDataService, DemoDataService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IApplicationSettings, ApplicationSettings>();


            return services;
        }
    }
}
