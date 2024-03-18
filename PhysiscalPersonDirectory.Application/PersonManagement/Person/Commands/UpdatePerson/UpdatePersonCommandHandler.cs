using MediatR;
using PhysiscalPersonDirectory.Application.Infrastructure.Services;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UpdatePersonCommandHandler(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == request.Id && x.IsActive,cancellationToken))
            {
                throw new NotFoundException(StringResource.Person, StringResource.PersonalNumber, request.PersonalNumber);
            }

            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive,cancellationToken);

            person.Update(request.PersonalNumber, request.FirstName, request.LastName, request.Gender, request.BirthDate, request.CityId);
            person.ChangeImage(request.Image == null ? person.Image : await _fileService.Upload(request.Image));

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return person.Id;
        }
    }
}
