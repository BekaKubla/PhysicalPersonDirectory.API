using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddPersonContact
{
    public class AddPersonContactCommandHandler : IRequestHandler<AddPersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddPersonContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddPersonContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.PersonId && x.IsActive) ??
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.PersonId);
            person.AddPhoneNumber(PhoneNumber.Create(request.PhoneNumber, request.PhoneNumberType));

            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
