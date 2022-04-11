using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Recipe;
using NormativeApp.Core.Dtos.RecipeIngredient;
using NormativeApp.Core.Entities;
using NormativeApp.Database.Data;
using NormativeApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NormativeApp.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        private DbContextOptions<DataContext> _options;
        private DataContext _context;
        private RecipeService _recipeService;
        private IMapper _mapperMock;

        [OneTimeSetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "server_jap")
                .Options;
            _context = new DataContext(_options);
            var configuration = new MapperConfiguration(
                config =>
                {
                    config.CreateMap<AddRecipeDto, Recipe>();
                    config.CreateMap<Recipe, GetCategoryWithRecipeDto>();
                    config.CreateMap<AddRecipeIngredientDto, RecipeIngredient>();
                }
            );
            _mapperMock = configuration.CreateMapper();
            _recipeService = new RecipeService(_mapperMock, _context);

            SetUpDatabase();
        }

        [Test]
        public void AddRecipe_AddingTwoSameIngredients_CheckIfIngredientsAreUnique()
        {
            var request = new AddRecipeDto
            {
                Name = "AddingTwoSameIngredients",
                Description = "Description",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientDto>
                {
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.g
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.kg
                    }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(
                async () => await _recipeService.AddRecipeWithIngredients(request)
            );
        }

        [Test]
        public void AddRecipe_AddingTwoSameIngredientsWithOneDifferent_CheckIfIngredientsAreUnique()
        {
            var request = new AddRecipeDto
            {
                Name = "AddingTwoSameIngredientsAndOneDiffrent",
                Description = "Description",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientDto>
                {
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.g
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.kg
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 2,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.kg
                    }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(
                async () => await _recipeService.AddRecipeWithIngredients(request)
            );
        }

        [Test]
        public void AddRecipe_AddingFourSameIngredients_CheckIfIngredientsAreUnique()
        {
            var request = new AddRecipeDto
            {
                Name = "AddingFourSameIngredients",
                Description = "Description",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientDto>
                {
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.g
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.kg
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 2,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.kg
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 2,
                        Quantity = 10,
                        UnitMeasure = UnitMeasureEnum.kg
                    }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(
                async () => await _recipeService.AddRecipeWithIngredients(request)
            );
        }

        [Test]
        public async Task AddRecipe_WithOneIngredient()
        {
            var newRecipe = new AddRecipeDto
            {
                Name = "AddingRecipeWithOneIng",
                CategoryId = 1,
                Description = "Description",
                RecipeIngredients = new List<AddRecipeIngredientDto>()
                {
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 1,
                        UnitMeasure = UnitMeasureEnum.kg,
                    }
                }
            };

            await _recipeService.AddRecipeWithIngredients(newRecipe);
            var databaseRecipe = _context.Recipes.FirstOrDefault(r => r.Name == newRecipe.Name);

            Assert.True(newRecipe.RecipeIngredients.Any());
            Assert.AreEqual(newRecipe.Name, databaseRecipe.Name);
            Assert.AreEqual(newRecipe.Description, databaseRecipe.Description);
        }

        [Test]
        public async Task AddRecipe_WithTwoIngredients()
        {
            var newRecipe = new AddRecipeDto
            {
                Name = "AddingRecipeWithTwoIng",
                CategoryId = 1,
                Description = "Description",
                RecipeIngredients = new List<AddRecipeIngredientDto>()
                {
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 1,
                        Quantity = 1,
                        UnitMeasure = UnitMeasureEnum.kg,
                    },
                    new AddRecipeIngredientDto
                    {
                        IngredientId = 2,
                        Quantity = 1,
                        UnitMeasure = UnitMeasureEnum.kg,
                    }
                }
            };

            await _recipeService.AddRecipeWithIngredients(newRecipe);
            var databaseRecipe = _context.Recipes.FirstOrDefault(r => r.Name == newRecipe.Name);

            Assert.True(newRecipe.RecipeIngredients.Any());
            Assert.AreEqual(newRecipe.RecipeIngredients.Count(), 2);
            Assert.AreEqual(newRecipe.Name, databaseRecipe.Name);
            Assert.AreEqual(newRecipe.Description, databaseRecipe.Description);
        }

        [TestCase(0)]
        [TestCase(3)]
        [TestCase(5)]
        public async Task GetRecipe_LoadMoreRecipes(int pageSizeData)
        {
            var recipeSearch = new RecipeSearch
            {
                PageSize = pageSizeData,
                CategoryId = 1,
                Skip = 0
            };

            var result = await _recipeService.RecipeGetByCategory(recipeSearch);
            Assert.That(result.Count, Is.EqualTo(pageSizeData));
        }

        public void SetUpDatabase()
        {
            _context.Recipes.AddRange(
                new Recipe
                {
                    Id = 1,
                    CategoryId = 1,
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient { Id = 1 }
                    }
                },
                new Recipe
                {
                    Id = 2,
                    CategoryId = 1,
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient { Id = 2 }
                    }
                },
                new Recipe
                {
                    Id = 3,
                    CategoryId = 1,
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient { Id = 3 }
                    }
                },
                new Recipe
                {
                    Id = 4,
                    CategoryId = 1,
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient { Id = 4 }
                    }
                },
                new Recipe
                {
                    Id = 5,
                    CategoryId = 1,
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient { Id = 5 }
                    }
                }
            );
            _context.SaveChanges();
        }
    }
}