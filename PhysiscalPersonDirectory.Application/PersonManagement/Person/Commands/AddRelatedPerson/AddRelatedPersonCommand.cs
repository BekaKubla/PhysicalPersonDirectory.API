using MediatR;
using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommand : MapFrom<AddRelatedPersonModel>, IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public ContactType ContactType { get; set; }
    }
}
