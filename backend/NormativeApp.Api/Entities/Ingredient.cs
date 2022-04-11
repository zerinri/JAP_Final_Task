using NormativeApp.Common.Entities;
using System.Collections.Generic;

namespace NormativeApp.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public UnitMeasureEnum PurchaseUnitMeasure { get; set; }
        public decimal PurchasePrice { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}