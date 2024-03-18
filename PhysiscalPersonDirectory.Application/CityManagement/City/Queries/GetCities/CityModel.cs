using PhysiscalPersonDirectory.Application.Shared.Mapper;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Queries.GetCities
{
    public class CityModel : MapFrom<Domain.Entities.CityAggregate.City>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
