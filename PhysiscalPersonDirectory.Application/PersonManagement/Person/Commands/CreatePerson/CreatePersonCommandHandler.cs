using MediatR;
using PhysiscalPersonDirectory.Application.Infrastructure.Services;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _flieService;
        public CreatePersonCommandHandler(IUnitOfWork unitOfWork,
                                          IFileService flieService)
        {
            _unitOfWork = unitOfWork;
            _flieService = flieService;
        }
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.PersonRepository.AnyAsync(x => x.PersonalNumber == request.PersonalNumber && x.IsActive, cancellationToken))
            {
                throw new AlreadyExistsException(StringResource.Person, StringResource.PersonalNumber, request.PersonalNumber);
            }
            var filePath = await _flieService.Upload(request.Image);
            var person = Domain.Entities.PersonAggregate.Person.Create(request.FirstName, request.LastName, request.Gender, request.PersonalNumber, request.BirthDate, filePath);

            if (request.CityId.HasValue)
            {
                var city = await _unitOfWork.CityRepository.GetSingleAsync(x => x.Id == request.CityId && x.IsActive, cancellationToken) ??
                    throw new CustomException(StringResource.CityNotFound);

                person.AssignCity(city);
            }

            if (!string.IsNullOrEmpty(request.PhoneNumber) && request.PhoneNumberType.HasValue)
            {
                if ((await _unitOfWork.PhoneNumberRepository.AnyAsync(x => x.Number == request.PhoneNumber && x.IsActive, cancellationToken)))
                {
                    throw new AlreadyExistsException(StringResource.PhoneNumber, StringResource.PhoneNumber, request.PhoneNumber);
                }
                person.AddPhoneNumber(PhoneNumber.Create(request.PhoneNumber, request.PhoneNumberType.Value));
            }

            await _unitOfWork.PersonRepository.AddAsync(person, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return person.Id;
        }
    }
}
