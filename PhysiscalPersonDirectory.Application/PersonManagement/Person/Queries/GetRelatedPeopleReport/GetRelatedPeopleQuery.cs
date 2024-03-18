using MediatR;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetRelatedPeopleReport
{
    public class GetRelatedPeopleQuery : IRequest<IEnumerable<RelatedPeopleModel>>
    {
    }
}
