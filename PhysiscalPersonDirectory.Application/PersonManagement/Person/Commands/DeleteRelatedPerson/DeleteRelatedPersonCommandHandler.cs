using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommandHandler : IRequestHandler<DeleteRelatedPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRelatedPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.PersonId && x.IsActive, cancellationToken) ??
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.PersonId);

            var relatedPerson = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.RelatedPersonId && x.IsActive, cancellationToken) ??
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.RelatedPersonId);

            person.DeleteRelatedPerson(request.RelatedPersonId);

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
