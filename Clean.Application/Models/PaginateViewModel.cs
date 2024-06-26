namespace Clean.Application.Models
{
    public class PaginateViewModel<TData> where TData : class
    {
        public TData Records { get; set; }

        public int TotalCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
