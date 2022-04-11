using System.Collections.Generic;

namespace NormativeApp.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}