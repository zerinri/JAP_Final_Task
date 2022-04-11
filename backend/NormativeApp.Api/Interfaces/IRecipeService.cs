using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Recipe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormativeApp.Services
{
    public interface IRecipeService
    {
        Task AddRecipeWithIngredients(AddRecipeDto recipe);
        Task<ServiceResponse<GetRecipeByIdDto>> RecipeGetById(int recipeId);
        Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> RecipeGetByCategory(RecipeSearch recipeSearch);
        Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> GetRecipeBySearch(string search);
        Task<ServiceResponse<GetRecipeDto>> UpdateRecipe(UpdateRecipeDto updateRecipe);
        Task<ServiceResponse<List<GetRecipeDto>>> DeleteRecipe(int id);
    }
}