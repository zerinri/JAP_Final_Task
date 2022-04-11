using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NormativeApp.Core.Dtos.Recipe;
using NormativeApp.Services;
using System.Threading.Tasks;

namespace NormativeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipesController : ControllerBase
    {
        public IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRecipeDto recipe)
        {
            await _recipeService.AddRecipeWithIngredients(recipe);
            return Ok(recipe);
        }

        [HttpGet("GetRecipeById/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _recipeService.RecipeGetById(id));
        }

        [HttpGet("GetRecipeByCategoryId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategoryId([FromQuery] RecipeSearch recipeSearch)
        {
            return Ok(await _recipeService.RecipeGetByCategory(recipeSearch));
        }

        [HttpGet("GetRecipeBySearch/{search}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string search)
        {
            return Ok(await _recipeService.GetRecipeBySearch(search));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _recipeService.DeleteRecipe(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRecipeDto updateRecipe)
        {
            var response = await _recipeService.UpdateRecipe(updateRecipe);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}