using MediatR;
using PhysiscalPersonDirectory.Application.Shared.Mapper;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Create
{
    public class CreateCityCommand : MapFrom<CreateCityModel>, IRequest<int>
    {
        public string? Name { get; set; }
    }
}
