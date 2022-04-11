using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Sql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormativeApp.Core.Interfaces
{
    public interface IRecipeReports
    {
        Task<ServiceResponse<List<MostUsedIngredient>>> GetMostUsedIngredients(
            decimal minCount,
            decimal maxCount,
            int unitMeasure
        );

        Task<ServiceResponse<List<GetRecipesByCategoryName>>> GetRecipesByCategoryName();

        Task<ServiceResponse<List<GetRecipesWithIngredientCount>>> GetRecipesWithIngredientCount();
    }
}