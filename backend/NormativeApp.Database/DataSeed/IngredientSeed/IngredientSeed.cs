using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Entities;

namespace NormativeApp.Database.DataSeed.IngredientSeed
{
    public static class IngredientSeed
    {
        public static void Ingredients(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Ingredient>()
                .HasData(
                    new Ingredient
                    {
                        Id = 1,
                        Name = "Flour",
                        PurchaseUnitMeasure = UnitMeasureEnum.kg,
                        PurchaseQuantity = 1,
                        PurchasePrice = 10
                    },
                    new Ingredient
                    {
                        Id = 2,
                        Name = "Pepper",
                        PurchaseUnitMeasure = UnitMeasureEnum.g,
                        PurchaseQuantity = 10,
                        PurchasePrice = 4
                    },
                    new Ingredient
                    {
                        Id = 3,
                        Name = "Oil",
                        PurchaseUnitMeasure = UnitMeasureEnum.l,
                        PurchaseQuantity = 1,
                        PurchasePrice = 7
                    },
                    new Ingredient
                    {
                        Id = 4,
                        Name = "Cheese",
                        PurchaseUnitMeasure = UnitMeasureEnum.g,
                        PurchaseQuantity = 100,
                        PurchasePrice = 15
                    },
                    new Ingredient
                    {
                        Id = 5,
                        Name = "Sugar",
                        PurchaseUnitMeasure = UnitMeasureEnum.g,
                        PurchaseQuantity = 80,
                        PurchasePrice = 3
                    },
                    new Ingredient
                    {
                        Id = 6,
                        Name = "Salt",
                        PurchaseUnitMeasure = UnitMeasureEnum.g,
                        PurchaseQuantity = 70,
                        PurchasePrice = 2
                    },
                    new Ingredient
                    {
                        Id = 7,
                        Name = "Meat",
                        PurchaseUnitMeasure = UnitMeasureEnum.kg,
                        PurchaseQuantity = 1,
                        PurchasePrice = 20
                    },
                    new Ingredient
                    {
                        Id = 8,
                        Name = "Tomato",
                        PurchaseUnitMeasure = UnitMeasureEnum.kg,
                        PurchaseQuantity = 5,
                        PurchasePrice = 10
                    },
                    new Ingredient
                    {
                        Id = 9,
                        Name = "Peppers",
                        PurchaseUnitMeasure = UnitMeasureEnum.kg,
                        PurchaseQuantity = 5,
                        PurchasePrice = 15
                    },
                    new Ingredient
                    {
                        Id = 10,
                        Name = "Mushrooms",
                        PurchaseUnitMeasure = UnitMeasureEnum.g,
                        PurchaseQuantity = 20,
                        PurchasePrice = 25
                    }
                );
        }
    }
}