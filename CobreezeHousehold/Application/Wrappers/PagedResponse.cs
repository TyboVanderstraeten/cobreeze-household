
using System;

namespace Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        /*
         * TODO: totalrecords is the count of the already filtered collection,..
         */
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)(TotalRecords / PageSize));

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords) : base(data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }
    }
}
