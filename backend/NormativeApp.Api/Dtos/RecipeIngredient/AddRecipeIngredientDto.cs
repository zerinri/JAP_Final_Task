using NormativeApp.Common.Entities;

namespace NormativeApp.Core.Dtos.RecipeIngredient
{
    public class AddRecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public UnitMeasureEnum UnitMeasure { get; set; }
    }
}