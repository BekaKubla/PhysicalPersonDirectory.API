using MediatR;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsModel>
    {
        public int Id { get; set; }
    }
}
