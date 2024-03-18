using AutoMapper;
using MediatR;
using PhysiscalPersonDirectory.Application.Infrastructure.Services;
using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.SeedWork;
using static System.Net.Mime.MediaTypeNames;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public GetPersonDetailsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<PersonDetailsModel> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive) ??
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.Id);
            var personModel = _mapper.Map<PersonDetailsModel>(person);
            personModel.File = await _fileService.Download(person.Image);

            return personModel;
        }
    }
}
