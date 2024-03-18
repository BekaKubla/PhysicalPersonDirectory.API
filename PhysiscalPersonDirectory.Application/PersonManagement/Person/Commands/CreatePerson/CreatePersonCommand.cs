using MediatR;
using Microsoft.AspNetCore.Http;
using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : MapFrom<CreatePersonModel>, IRequest<int>
    {
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public IFormFile Image { get; set; }
        public int? CityId { get; set; }

        public string PhoneNumber { get; set; }
        public PhoneNumberType? PhoneNumberType { get; set; }
    }
}
