using NormativeApp.Common.Entities;

namespace NormativeApp.Core.Entities
{
    public class RecipeIngredient : BaseEntity
    {
        public UnitMeasureEnum UnitMeasure { get; set; }
        public decimal Quantity { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}