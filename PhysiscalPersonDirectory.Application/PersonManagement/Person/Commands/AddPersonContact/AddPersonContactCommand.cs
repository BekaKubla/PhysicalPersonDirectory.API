using MediatR;
using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddPersonContact
{
    public class AddPersonContactCommand : MapFrom<AddPersonContactModel>, IRequest
    {
        public int PersonId { get; set; }
        public string? PhoneNumber { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
