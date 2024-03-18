using MediatR;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Delete
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetSingleAsync(x => x.Id == request.Id, cancellationToken) ??
                throw new NotFoundException(StringResource.City, StringResource.Id, request.Id);

            city.Delete();
            _unitOfWork.CityRepository.Update(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
