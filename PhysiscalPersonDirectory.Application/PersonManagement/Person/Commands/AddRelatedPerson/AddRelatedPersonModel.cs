using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddRelatedPerson
{
    public class AddRelatedPersonModel
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public ContactType ContactType { get; set; }
    }
}
