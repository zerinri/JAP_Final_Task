using Microsoft.EntityFrameworkCore;
using NormativeApp.Core.Dtos.Sql;
using NormativeApp.Core.Entities;
using NormativeApp.Database.DataSeed.CategorySeed;
using NormativeApp.Database.DataSeed.IngredientSeed;
using NormativeApp.Database.DataSeed.RecipeIngredients;
using NormativeApp.Database.DataSeed.RecipeSeed;

namespace NormativeApp.Database.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<MostUsedIngredient> MostUsedIngredients { get; set; }

        public DbSet<GetRecipesByCategoryName> GetRecipesByCategoryName { get; set; }

        public DbSet<GetRecipesWithIngredientCount> GetRecipesWithIngredientCount { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<Recipe>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<RecipeIngredient>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MostUsedIngredient>(eb => eb.ToView("MostUsedIng"));

            modelBuilder.Entity<GetRecipesByCategoryName>(
                eb => eb.ToView("GetRecipesByCategoryName")
            );

            modelBuilder.Entity<GetRecipesWithIngredientCount>(
                eb => eb.ToView("GetRecipesWithIngredientCount")
            );

            modelBuilder
                .Entity<RecipeIngredient>()
                .HasOne(b => b.Recipe)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(bi => bi.RecipeId);

            modelBuilder
                .Entity<RecipeIngredient>()
                .HasOne(b => b.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(bi => bi.IngredientId);

            var hmac = new System.Security.Cryptography.HMACSHA512();
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"));

            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Username = "admin",
                        PasswordHash = passwordHash,
                        PasswordSalt = hmac.Key
                    }
                );

            modelBuilder.Categories();
            modelBuilder.Ingredients();
            modelBuilder.Recipes();
            modelBuilder.RecipeIngredientsSeed();
        }
    }
}