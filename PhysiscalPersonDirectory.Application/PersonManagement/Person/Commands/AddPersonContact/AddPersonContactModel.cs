using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddPersonContact
{
    public class AddPersonContactModel
    {
        public int PersonId { get; set; }
        public string? PhoneNumber { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
