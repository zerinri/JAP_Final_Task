using Microsoft.EntityFrameworkCore;

namespace NormativeApp.Core.Dtos.Sql
{
    [Keyless]
    public class GetRecipesByCategoryName
    {
        public string CategoryName { get; set; }
        public string RecipeName { get; set; }
        public decimal TotalCost { get; set; }
    }
}