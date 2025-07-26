namespace RentACarAPP.Contract.Dtos.Paging
{
    public class PagedProductDTO
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public List<ProductDTO> Products { get; set; }


    }
}
