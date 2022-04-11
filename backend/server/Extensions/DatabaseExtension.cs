using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NormativeApp.Database.Data;

namespace NormativeApp.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void SetupDatabase(
            this IServiceCollection services,
            IConfiguration Configuration
        )
        {
            services.AddDbContext<DataContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
        }
    }
}