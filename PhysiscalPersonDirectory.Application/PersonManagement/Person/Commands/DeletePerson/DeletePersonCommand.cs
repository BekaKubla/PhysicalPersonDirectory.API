using MediatR;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
