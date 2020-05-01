using System.ComponentModel.DataAnnotations.Schema;

namespace Pagination.Sample.WebAPI.Data
{
    [Table("TestTable")]
    public class TestTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
