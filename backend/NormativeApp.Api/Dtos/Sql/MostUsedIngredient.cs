using Microsoft.EntityFrameworkCore;

namespace NormativeApp.Core.Dtos.Sql
{
    [Keyless]
    public class MostUsedIngredient
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
}