using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading.Tasks;

namespace BS23.Pagination.EfCore
{
    public class SqlPagingManager : ISqlPagingManager
    {
        private readonly SqlPaginator _paginator;
        private readonly IMapper _mapper;

        public SqlPagingManager(SqlPaginator paginator, IMapper mapper)
        {
            _paginator = paginator;
            _mapper = mapper;
        }

        public async Task<PagedViewModel<TEntity>>
          PageAsync<TEntity, TArgs>(
            IQueryable<TEntity> source,
            TArgs args,
            string actionName = "")
          where TArgs : ResourceQueryParameters
        {
            var data = await PagedList<TEntity>
                .CreateAsync(source, args.PageNumber, args.PageSize);

            var metadata = _paginator
               .GetPaginationMetadata(args, data, actionName);

            return new PagedViewModel<TEntity>
            {
                Data = data,
                MetaData = metadata
            };
        }

        public async Task<PagedViewModel<TViewModel>>
            PageAsync<TViewModel, TArgs>(
            IQueryable source,
            TArgs args,
            string actionName = "")
            where TArgs : ResourceQueryParameters
        {
            var data = await PagedList<TViewModel>
                .CreateAsync(source
                                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider),
                args.PageNumber,
                args.PageSize);

            var metadata = _paginator
               .GetPaginationMetadata(args, data, actionName);

            return new PagedViewModel<TViewModel>
            {
                Data = data,
                MetaData = metadata
            };
        }
    }
}
