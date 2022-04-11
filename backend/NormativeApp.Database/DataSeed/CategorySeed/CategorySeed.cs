using Microsoft.EntityFrameworkCore;
using NormativeApp.Core.Entities;

namespace NormativeApp.Database.DataSeed.CategorySeed
{
    public static class CategorySeed
    {
        public static void Categories(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Breakfast" },
                    new Category { Id = 2, Name = "Lunch" },
                    new Category { Id = 3, Name = "Dinner" },
                    new Category { Id = 4, Name = "Brunch" },
                    new Category { Id = 5, Name = "Snack" },
                    new Category { Id = 6, Name = "Midnight snack" },
                    new Category { Id = 7, Name = "Healty snack" },
                    new Category { Id = 8, Name = "Dessert" }
                );
        }
    }
}