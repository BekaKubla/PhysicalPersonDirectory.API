using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Update
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetSingleAsync(x => x.Id == request.Id, cancellationToken) ??
                throw new NotFoundException(StringResource.City, StringResource.Id, request.Id);

            city.Update(request.Name);
            _unitOfWork.CityRepository.Update(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}
