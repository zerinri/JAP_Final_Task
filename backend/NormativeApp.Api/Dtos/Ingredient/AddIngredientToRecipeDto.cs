using NormativeApp.Common.Entities;

namespace NormativeApp.Core.Dtos.Ingredient
{
    public class AddIngredientToRecipeDto
    {
        public int IngredientId { get; set; }
        public UnitMeasureEnum UnitMeasure { get; set; }
        public decimal Quantity { get; set; }

    }
}
