using Microsoft.AspNetCore.Mvc;
using NormativeApp.Core.Interfaces;
using System.Threading.Tasks;

namespace NormativeApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeReportsController : ControllerBase
    {
        private readonly IRecipeReports _sqlService;

        public RecipeReportsController(IRecipeReports sqlService)
        {
            _sqlService = sqlService;
        }

        [HttpGet("MostUsedIngredients/{minCount}/{maxCount}/{unitMeasure}")]
        public async Task<IActionResult> GetByParams(
            decimal minCount,
            decimal maxCount,
            int unitMeasure
        )
        {
            return Ok(await _sqlService.GetMostUsedIngredients(minCount, maxCount, unitMeasure));
        }

        [HttpGet("RecipesByCategoryName")]
        public async Task<IActionResult> GetByCategoryName()
        {
            return Ok(await _sqlService.GetRecipesByCategoryName());
        }

        [HttpGet("RecipesWithIngredientCount")]
        public async Task<IActionResult> GetRecipesWithIngredientCount()
        {
            return Ok(await _sqlService.GetRecipesWithIngredientCount());
        }
    }
}