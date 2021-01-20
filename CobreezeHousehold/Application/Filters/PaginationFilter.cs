namespace Application.Filters
{
    public class PaginationFilter
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value < 1 ? 1 : value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value < 1 ? 10 : value > 50 ? 50 : value; }
        }
    }
}
