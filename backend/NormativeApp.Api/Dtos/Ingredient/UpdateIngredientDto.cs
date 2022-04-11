using NormativeApp.Common.Entities;

namespace NormativeApp.Core.Dtos.Ingredient
{
    public class UpdateIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public UnitMeasureEnum PurchaseUnitMeasure { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
