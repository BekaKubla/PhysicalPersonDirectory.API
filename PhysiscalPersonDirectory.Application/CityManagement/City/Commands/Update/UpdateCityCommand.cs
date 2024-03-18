using MediatR;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Update
{
    public class UpdateCityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
