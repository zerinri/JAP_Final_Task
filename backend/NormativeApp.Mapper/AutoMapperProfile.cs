using AutoMapper;
using NormativeApp.Core.Dtos.Category;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Core.Dtos.Recipe;
using NormativeApp.Core.Dtos.Sql;
using NormativeApp.Core.Entities;
using NormativeApp.Services.Helpers;

namespace NormativeApp.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, GetRecipeByIdDto>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<UpdateRecipeDto, Recipe>();

            CreateMap<Ingredient, GetIngredientDto>();
            CreateMap<AddIngredientDto, Ingredient>();
            CreateMap<UpdateIngredientDto, Ingredient>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<RecipeIngredient, GetRecipeByIdDto>()
                .ForMember(
                    dest => dest.TotalCost,
                    opt => opt.MapFrom(src => CalculateTotalCost.RecipeTotalCost(src.Recipe))
                );

            CreateMap<Recipe, GetCategoryWithRecipeDto>()
                .ForMember(
                    dest => dest.TotalCost,
                    opt => opt.MapFrom(src => CalculateTotalCost.RecipeTotalCost(src))
                );
        }
    }
}