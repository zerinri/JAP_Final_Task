using Microsoft.EntityFrameworkCore;
using NormativeApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace NormativeApp.Database.DataSeed.RecipeSeed
{
    public static class RecipeSeed
    {
        public static void Recipes(this ModelBuilder modelBuilder)
        {
            Random random = new Random();
            List<Recipe> recipes = new();

            List<string> recipeNames =
                new() { "Pizza", "Pita", "Musaka", "Ustipci", "Palacinke", "Spagete", "Makarone", };

            for (int i = 1; i <= 50; i++)
            {
                recipes.Add(
                    new Recipe
                    {
                        Id = i,
                        Name = recipeNames[i % 7] + i.ToString(),
                        Description = "Lorem Ipsum",
                        CategoryId = random.Next(1, 8),
                    }
                );
            }
            modelBuilder.Entity<Recipe>().HasData(recipes);
        }
    }
}