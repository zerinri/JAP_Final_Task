using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Sql;
using NormativeApp.Core.Interfaces;
using NormativeApp.Database.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NormativeApp.Services.Services
{
    public class RecipeReportsService : IRecipeReports
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeReportsService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<MostUsedIngredient>>> GetMostUsedIngredients(
            decimal minCount,
            decimal maxCount,
            int unitMeasure
        )
        {
            var list = await _context.MostUsedIngredients
                .FromSqlInterpolated(
                    $"EXEC [dbo].[dbo_spRecipeIngredients_FilterIngredients] {minCount}, {maxCount},{unitMeasure}"
                )
                .ToListAsync();

            var result = list.Select(r => _mapper.Map<MostUsedIngredient>(r)).ToList();

            return new ServiceResponse<List<MostUsedIngredient>>()
            {
                Data = result,
                Count = result.Count()
            };
        }

        public async Task<ServiceResponse<List<GetRecipesByCategoryName>>> GetRecipesByCategoryName()
        {
            var list = await _context.GetRecipesByCategoryName
                .FromSqlInterpolated($"EXEC [dbo].[dbo_spCategory_GetRecipeByCategory]")
                .ToListAsync();

            var result = list.Select(r => _mapper.Map<GetRecipesByCategoryName>(r)).ToList();

            return new ServiceResponse<List<GetRecipesByCategoryName>>()
            {
                Data = result,
                Count = result.Count()
            };
        }

        public async Task<ServiceResponse<List<GetRecipesWithIngredientCount>>> GetRecipesWithIngredientCount()
        {
            var list = await _context.GetRecipesWithIngredientCount
                .FromSqlInterpolated(
                    $"EXEC [dbo].[dbo_spRecipeIngredient_GetRecipeWithIngredientCount]"
                )
                .ToListAsync();

            var result = list.Select(r => _mapper.Map<GetRecipesWithIngredientCount>(r)).ToList();

            return new ServiceResponse<List<GetRecipesWithIngredientCount>>()
            {
                Data = result,
                Count = result.Count()
            };
        }
    }
}