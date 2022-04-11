using NormativeApp.Core.Entities;

namespace NormativeApp.Core.Dtos.Recipe
{
    public class RecipeSearch : BaseSearch
    {
        public int CategoryId { get; set; }
    }
}