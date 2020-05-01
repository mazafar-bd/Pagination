using Microsoft.EntityFrameworkCore;

namespace Pagination.Sample.WebAPI.Data
{
    public class PaginationDbContext : DbContext
    {
        public PaginationDbContext(DbContextOptions<PaginationDbContext> options)
             : base(options)
        {
        }

        public virtual DbSet<TestTable> TestTables { get; set; }

    }
}
