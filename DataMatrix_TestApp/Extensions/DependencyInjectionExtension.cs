using DataMatrix_TestApp.Interfaces;
using DataMatrix_TestApp.Repositories;
using DataMatrix_TestApp.Services;

namespace DataMatrix_TestApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        //Here in a large project I would create two methods.
        //one for dependency injection of repositories and their interfaces, and the second for services and their interfaces
        public static IServiceCollection AddInfrasctructure(this IServiceCollection services)
        {
            services.AddScoped<IContactUserRepository, ContactUserRepository>();
            services.AddScoped<IContactUserService, ContactUserService>();
            return services;
        }
    }
}
