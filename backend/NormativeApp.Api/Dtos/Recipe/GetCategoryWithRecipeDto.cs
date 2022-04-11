namespace NormativeApp.Core.Dtos.Recipe
{
    public class GetCategoryWithRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
    }
}