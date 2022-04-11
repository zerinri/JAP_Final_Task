using Microsoft.EntityFrameworkCore;

namespace NormativeApp.Core.Dtos.Sql
{
    [Keyless]
    public class GetRecipesWithIngredientCount
    {
        public int TotalIngredients { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }
        public decimal TotalCost { get; set; }
    }
}