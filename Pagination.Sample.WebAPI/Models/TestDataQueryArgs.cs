using BS23.Pagination.EfCore;

namespace Pagination.Sample.WebAPI.Models
{
    public class TestDataQueryArgs : ResourceQueryParameters
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
