using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.CreatePerson;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeletePerson;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.UpdatePerson;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPeople;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPersonDetails;
using PhysiscalPersonDirectory.Application.Shared.Specification;

namespace PhysicalPersonDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController
    {
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Person Controller
        /// </summary>
        public PeopleController(
            IMapper mapper,
            IMediator mediator
            )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Create Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreatePerson))]
        public async Task<int> CreatePerson([FromQuery] CreatePersonModel request) =>
            await _mediator.Send(_mapper.Map<CreatePersonCommand>(request));

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdatePerson))]
        public async Task<int> UpdatePerson([FromRoute] int id, [FromQuery] UpdatePersonModel request)
        {
            var command = _mapper.Map<UpdatePersonCommand>(request);
            command.Id = id;
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeletePerson))]
        public async Task DeletePerson([FromRoute] int id) =>
            await _mediator.Send(new DeletePersonCommand { Id = id });

        /// <summary>
        /// Get People List
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetPersons))]
        public async Task<PagedList<PersonModel>> GetPersons([FromQuery] GetPeopleModel query, CancellationToken cancellationToken) =>
            await _mediator.Send(_mapper.Map<GetPeopleQuery>(query), cancellationToken);

        /// <summary>
        /// Get Person Details By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}", Name = nameof(GetPersonById))]
        public async Task<PersonDetailsModel> GetPersonById([FromRoute] int id, CancellationToken cancellationToken) =>
            await _mediator.Send(new GetPersonDetailsQuery { Id = id }, cancellationToken);



    }
}
