using MediatR;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Delete
{
    public class DeleteCityCommand : IRequest
    {
        public int Id { get; set; }
    }
}
