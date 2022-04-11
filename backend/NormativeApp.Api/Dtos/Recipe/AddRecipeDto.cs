using NormativeApp.Core.Dtos.RecipeIngredient;
using System.Collections.Generic;

namespace NormativeApp.Core.Dtos.Recipe
{
    public class AddRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public List<AddRecipeIngredientDto> RecipeIngredients { get; set; }
    }
}