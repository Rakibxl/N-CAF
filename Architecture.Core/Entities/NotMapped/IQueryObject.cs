
namespace Architecture.Core.Entities.NotMapped
{
    public class IQueryObject
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public IQueryObject()
        {
            this.Page = 1;
            this.PageSize = int.MaxValue;
        }
    }
}