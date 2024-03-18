using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommandHandler : IRequestHandler<AddRelatedPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddRelatedPersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.PersonId && x.IsActive, cancellationToken) ??
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.PersonId);

            var relatedPerson = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.RelatedPersonId && x.IsActive, cancellationToken) ??
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.RelatedPersonId);

            person.AddRelatedPerson(relatedPerson, request.ContactType);

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
