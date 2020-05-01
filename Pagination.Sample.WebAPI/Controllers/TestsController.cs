using System.Linq;
using System.Threading.Tasks;
using BS23.Pagination.EfCore;
using Microsoft.AspNetCore.Mvc;
using Pagination.Sample.WebAPI.Data;
using Pagination.Sample.WebAPI.Models;

namespace Pagination.Sample.WebAPI.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly PaginationDbContext _paginationDbContext;
        private readonly ISqlPagingManager _pagingManager;

        public TestsController(
            PaginationDbContext paginationDbContext,
            ISqlPagingManager pagingManager)
        {
            this._paginationDbContext = paginationDbContext;
            this._pagingManager = pagingManager;
        }

        private IQueryable<TestTable> TestQuery(TestDataQueryArgs args)
        {
            IQueryable<TestTable> testQuery =
                _paginationDbContext.TestTables.AsQueryable();

            if (args.Id > 0)
                testQuery = testQuery.Where(t => t.Id == args.Id);

            if (!string.IsNullOrEmpty(args.Name))
                testQuery = testQuery
                    .Where(t => t.Name.Contains(args.Name));

            if (!string.IsNullOrEmpty(args.Address))
                testQuery = testQuery
                    .Where(t => t.Address.Contains(args.Address));

            if (!string.IsNullOrEmpty(args.Phone))
                testQuery = testQuery
                    .Where(t => t.Phone.Contains(args.Phone));

            return testQuery;
        }

      
        [HttpGet("automapper")]
        public async Task<IActionResult> 
            GetTestDataUsingAutomapper([FromQuery] TestDataQueryArgs args)
        {
            IQueryable<TestTable> testQuery = this.TestQuery(args);
            PagedViewModel<TestTableViewModel> testDataWithAutomappper = 
                await _pagingManager
                .PageAsync<TestTableViewModel, TestDataQueryArgs>(testQuery, args);

            return Ok(testDataWithAutomappper);
        }


        [HttpGet]
        public async Task<IActionResult> 
            GetTestData([FromQuery] TestDataQueryArgs args)
        {
            IQueryable<TestTable> testQuery = this.TestQuery(args);
            IQueryable<TestTableViewModel> testProjection = testQuery
                .Select(t => new TestTableViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Phone = t.Phone,
                    Address = t.Address
                });

            PagedViewModel<TestTableViewModel> testData
                = await _pagingManager.PageAsync(testProjection, args);

            return Ok(testData);
        }
    }
}