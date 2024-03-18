using MediatR;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetRelatedPeopleReport
{
    public class GetRelatedPeopleQueryHandler : IRequestHandler<GetRelatedPeopleQuery, IEnumerable<RelatedPeopleModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRelatedPeopleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RelatedPeopleModel>> Handle(GetRelatedPeopleQuery request, CancellationToken cancellationToken)
        {
            var result = (await _unitOfWork.PersonRepository.GetAllAsync(cancellationToken))
                .Select(x => new RelatedPeopleModel { Id = x.Id, Name = x.Name, LastName = x.Lastname, Relateds = x.Relationship
                .GroupBy(r => r.ContactType)
                .Select(y => new RelationshipModel { ContactType = y.Key, Count = y.Count() }) });

            return result;
        }
    }
}
