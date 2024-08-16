namespace Application.Common.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasNextPage { get; }

        public PaginatedList(List<T> items, int count, int limit, int skip)
        {
            TotalPages = CalculateTotalPages(limit, count);
            TotalCount = count;
            Items = items;
            HasNextPage = CalculateHasNextPage(limit, skip, count);
        }

        private static bool CalculateHasNextPage(int limit, int skip, int count)
        {
            if ((limit + skip) >= count || limit == 0)
            {
                return false;
            }
            return true;
        }

        private static int CalculateTotalPages(int limit, int count)
        {
            if (limit == 0)
            {
                return 1;
            }
            else
            {
                return (int)Math.Ceiling(count / (double)limit);
            }
        }
    }
}
