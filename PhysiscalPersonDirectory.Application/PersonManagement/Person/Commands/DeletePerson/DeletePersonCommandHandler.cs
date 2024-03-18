using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == request.Id && x.IsActive, cancellationToken))
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.Id);
            }

            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive, cancellationToken);

            person.Delete();

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
