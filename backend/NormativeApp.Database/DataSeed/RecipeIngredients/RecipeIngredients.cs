using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace NormativeApp.Database.DataSeed.RecipeIngredients
{
    public static class RecipeIngredients
    {
        public static void RecipeIngredientsSeed(this ModelBuilder modelBuilder)
        {
            Random random = new Random();
            List<RecipeIngredient> recipeIngredients = new();

            List<UnitMeasureEnum> unitMeasures =
                new()
                {
                    UnitMeasureEnum.g,
                    UnitMeasureEnum.kg,
                    UnitMeasureEnum.l,
                    UnitMeasureEnum.ml
                };

            for (int i = 1; i <= 500; i++)
            {
                recipeIngredients.Add(
                    new RecipeIngredient
                    {
                        Id = i,
                        RecipeId = random.Next(1, 50),
                        IngredientId = random.Next(1, 10),
                        Quantity = random.Next(10, 100),
                        UnitMeasure = unitMeasures[random.Next(0, 4)],
                    }
                );
            }
            modelBuilder.Entity<RecipeIngredient>().HasData(recipeIngredients);
        }
    }
}