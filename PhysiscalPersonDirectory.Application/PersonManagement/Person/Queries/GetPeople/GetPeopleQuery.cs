using MediatR;
using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Application.Shared.Specification;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPeople
{
    public class GetPeopleQuery : MapFrom<GetPeopleModel>, IRequest<PagedList<PersonModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? PersonalNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
