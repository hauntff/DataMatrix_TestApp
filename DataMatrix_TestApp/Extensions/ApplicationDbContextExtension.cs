using DataMatrix_TestApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DataMatrix_TestApp.Extensions
{
    public static class ApplicationDbContextExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
