using Microsoft.AspNetCore.Mvc;

namespace BS23.Pagination.EfCore
{
    public class SqlPaginator
    {
        private readonly IUrlHelper _urlHelper;
        public SqlPaginator(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public PaginationMetadataViewModel GetPaginationMetadata<TParameter, TPagedListViewModel>
            (
            TParameter args,
            PagedList<TPagedListViewModel> items,
            string actioName = default)
            where TParameter : ResourceQueryParameters
        {
            var nextPageLink = items.HasNext ?
                CreateResourceUri<TParameter>(args,
                    ResourceUriType.NextPage, actioName) : null;

            var previousPageLink = items.HasPrevious ?
               CreateResourceUri<TParameter>(args, ResourceUriType.PreviousPage, actioName) : null;

            var paginationMetadata = new PaginationMetadataViewModel
            {
                TotalCount = items.TotalCount,
                PageSize = items.PageSize,
                CurrentPage = items.CurrentPage,
                TotalPages = items.TotalPages,
                PreviousPageLink = previousPageLink,
                NextPageLink = nextPageLink
            };

            return paginationMetadata;
        }

        private string CreateResourceUri<TParameter>
            (
            TParameter args,
            ResourceUriType type,
            string actionName = default)
            where TParameter : ResourceQueryParameters
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    args.PageNumber -= 2;
                    return _urlHelper.Link(actionName, args);

                case ResourceUriType.NextPage:
                    args.PageNumber++;
                    return _urlHelper.Link(actionName, args);

                default:
                    return _urlHelper.Link(actionName, args);
            }
        }
    }
}
