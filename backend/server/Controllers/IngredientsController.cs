using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Services;
using System.Threading.Tasks;

namespace NormativeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ingredientService.GetAllIngredients());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _ingredientService.DeleteIngredient(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddIngredientDto newIngredient)
        {
            return Ok(await _ingredientService.AddIngredient(newIngredient));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIngredient(UpdateIngredientDto updateIngredient)
        {
            var response = await _ingredientService.UpdateIngredient(updateIngredient);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}