using System.Linq;
using System.Threading.Tasks;

namespace BS23.Pagination.EfCore
{
    public interface ISqlPagingManager
    {
        Task<PagedViewModel<TViewModel>> PageAsync<TViewModel, TArgs>(
            IQueryable source,
            TArgs args,
            string actionName = default)
            where TArgs : ResourceQueryParameters;

        Task<PagedViewModel<TEntity>> PageAsync<TEntity, TArgs>(
            IQueryable<TEntity> source,
            TArgs args,
            string actionName = default)
            where TArgs : ResourceQueryParameters;
    }
}
