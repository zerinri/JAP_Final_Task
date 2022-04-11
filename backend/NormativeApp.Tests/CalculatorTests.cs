using NormativeApp.Common.Entities;
using NormativeApp.Core.Entities;
using NormativeApp.Services.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace NormativeApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void CalculateRecipe_RecipeWithOneIngredient()
        {
            var recipe = new Recipe
            {
                Name = "NewRecipe",
                RecipeIngredients = new List<RecipeIngredient>()
                {
                new RecipeIngredient
                {
                    UnitMeasure = UnitMeasureEnum.kg,
                    Quantity = 10,
                    Ingredient = new Ingredient
                    {
                        Name = "NewIngredient",
                        PurchaseQuantity = 10,
                        PurchasePrice = 10,
                        PurchaseUnitMeasure = UnitMeasureEnum.kg,
                    }
                }
                }
            };
            var results = CalculateTotalCost.RecipeTotalCost(recipe);
            var expectedResult = 10;

            Assert.AreEqual(expectedResult, results);
        }

        [Test]
        public void CalculateRecipe_RecipeWithTwoIngredients()
        {
            var recipe = new Recipe
            {
                Name = "NewRecipe",
                RecipeIngredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient
                    {
                        UnitMeasure = UnitMeasureEnum.kg,
                        Quantity = 10,
                        Ingredient = new Ingredient
                        {
                            Name = "NewIngredient1",
                            PurchaseQuantity = 10,
                            PurchasePrice = 10,
                            PurchaseUnitMeasure = UnitMeasureEnum.kg,
                        }
                    },
                    new RecipeIngredient
                    {
                        UnitMeasure = UnitMeasureEnum.g,
                        Quantity = 20,
                        Ingredient = new Ingredient
                        {
                            Name = "NewIngredient2",
                            PurchaseQuantity = 20,
                            PurchasePrice = 20,
                            PurchaseUnitMeasure = UnitMeasureEnum.g,
                        }
                    }
                }
            };
            var results = CalculateTotalCost.RecipeTotalCost(recipe);
            var expectedResult = 30;

            Assert.AreEqual(expectedResult, results);
        }

        [Test]
        public void CalculateRecipe_RecipeWithDecimalPoint()
        {
            var recipe = new Recipe
            {
                Name = "NewRecipe",
                RecipeIngredients = new List<RecipeIngredient>()
                {
                    new ()
                    {
                        UnitMeasure = UnitMeasureEnum.kg,
                        Quantity = 10,
                        Ingredient = new ()
                        {
                            Name = "NewIngredient1",
                            PurchaseQuantity = 10,
                            PurchasePrice = 10.11m,
                            PurchaseUnitMeasure = UnitMeasureEnum.kg,
                        }
                    },
                    new ()
                    {
                        UnitMeasure = UnitMeasureEnum.g,
                        Quantity = 20,
                        Ingredient = new ()
                        {
                            Name = "NewIngredient2",
                            PurchaseQuantity = 20,
                            PurchasePrice = 20.22m,
                            PurchaseUnitMeasure = UnitMeasureEnum.g,
                        }
                    }
                }
            };
            var results = CalculateTotalCost.RecipeTotalCost(recipe);
            var expectedResult = 30.33m;

            Assert.AreEqual(expectedResult, results);
        }

        [Test]
        public void CalculateIngredient_SingleIngredientWithNoConversion()
        {
            var recipeIng = new RecipeIngredient
            {
                Quantity = 10,
                UnitMeasure = UnitMeasureEnum.kg,
                Ingredient = new Ingredient
                {
                    Name = "NewIngredient1",
                    PurchaseQuantity = 10,
                    PurchasePrice = 10,
                    PurchaseUnitMeasure = UnitMeasureEnum.kg,
                }
            };
            var results = CalculateTotalCost.IngredientTotalCost(recipeIng);
            var expectedResult = 10;

            Assert.AreEqual(expectedResult, results);
        }

        [Test]
        public void CalculateIngredient_SingleIngredientWithConversion()
        {
            var recipeIng = new RecipeIngredient
            {
                Quantity = 3550,
                UnitMeasure = UnitMeasureEnum.g,
                Ingredient = new Ingredient
                {
                    Name = "NewIngredient1",
                    PurchaseQuantity = 10,
                    PurchasePrice = 10,
                    PurchaseUnitMeasure = UnitMeasureEnum.kg,
                }
            };
            var results = CalculateTotalCost.IngredientTotalCost(recipeIng);
            var expectedResult = 3.55;

            Assert.AreEqual(expectedResult, results);
        }

        [Test]
        public void CalculateIngredient_SingleIngredientWithDecimalPoint()
        {
            var recipeIng = new RecipeIngredient
            {
                Quantity = 11.11m,
                UnitMeasure = UnitMeasureEnum.kg,
                Ingredient = new Ingredient
                {
                    Name = "NewIngredient1",
                    PurchaseQuantity = 10.10m,
                    PurchasePrice = 19.11m,
                    PurchaseUnitMeasure = UnitMeasureEnum.kg,
                }
            };
            var results = CalculateTotalCost.IngredientTotalCost(recipeIng);
            var expectedResult = 21.021;

            Assert.AreEqual(expectedResult, results);
        }
    }
}