using AutoMapper;
using Pagination.Sample.WebAPI.Data;
using Pagination.Sample.WebAPI.Models;

namespace Pagination.Sample.WebAPI.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TestTable, TestTableViewModel>();
        }
    }
}
