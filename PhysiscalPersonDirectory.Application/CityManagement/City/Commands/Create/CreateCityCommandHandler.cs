using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Create
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive))
            {
                throw new AlreadyExistsException(StringResource.City, StringResource.Name, request.Name);
            }

            var city = Domain.Entities.CityAggregate.City.Create(request.Name);
            await _unitOfWork.CityRepository.AddAsync(city, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return city.Id;
        }
    }
}
