using Microsoft.Extensions.DependencyInjection;
using NormativeApp.Core.Interfaces;
using NormativeApp.Data;
using NormativeApp.Services;
using NormativeApp.Services.Services;

namespace NormativeApp.Api.Extensions
{
    public static class ServiceRegistration
    {
        public static void SetupServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeReports, RecipeReportsService>();
        }
    }
}