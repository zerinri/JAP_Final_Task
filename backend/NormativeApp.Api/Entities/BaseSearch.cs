namespace NormativeApp.Core.Entities
{
    public abstract class BaseSearch
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
}