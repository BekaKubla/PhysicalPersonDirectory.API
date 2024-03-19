using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.AddRelatedPerson;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeletePerson;
using PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetRelatedPeopleReport;

namespace PhysicalPersonDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedPeopleController : BaseController
    {
        /// <summary>
        /// Related Person Controller
        /// </summary>
        public RelatedPeopleController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        /// <summary>
        /// Create Related Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonsRelationship))]
        public async Task CreatePersonsRelationship([FromBody] AddRelatedPersonModel request) =>
            await _mediator.Send(_mapper.Map<AddRelatedPersonCommand>(request));


        /// <summary>
        /// Delete Related Person
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = nameof(DeletePersonsRelationship))]
        public async Task DeletePersonsRelationship([FromQuery] DeletePersonCommand query) =>
            await _mediator.Send(query);


        /// <summary>
        /// Get Person Relationship Report
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetPersonRelationshipReport))]
        public async Task<IEnumerable<RelatedPeopleModel>> GetPersonRelationshipReport(CancellationToken cancellationToken) =>
            await _mediator.Send(new GetRelatedPeopleQuery(), cancellationToken);
    }
}
