using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Core.Dtos.Sql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormativeApp.Services
{
    public interface IIngredientService
    {
        Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients();
        Task<ServiceResponse<List<GetIngredientDto>>> DeleteIngredient(int id);
        Task<ServiceResponse<List<GetIngredientDto>>> AddIngredient(AddIngredientDto newIngredient);
        Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(UpdateIngredientDto updateIngredient);
    }
}