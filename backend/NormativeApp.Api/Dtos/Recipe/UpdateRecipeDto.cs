using NormativeApp.Core.Dtos.Ingredient;
using System.Collections.Generic;

namespace NormativeApp.Core.Dtos.Recipe
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public List<AddIngredientToRecipeDto> Ingredients { get; set; }
    }
}
