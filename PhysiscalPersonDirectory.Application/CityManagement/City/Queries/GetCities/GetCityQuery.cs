using AutoMapper;
using MediatR;
using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Application.Shared.Specification;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Queries.GetCities
{
    public class GetCityQuery : MapFrom<GetCityModel>, IRequest<PagedList<CityModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? Name { get; set; }
    }
}
