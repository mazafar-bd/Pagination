namespace BS23.Pagination.EfCore
{
    public class PagedViewModel<TViewModel>
    {
        public PagedList<TViewModel> Data { get; set; }
        public PaginationMetadataViewModel MetaData { get; set; }
    }
}
