using FluentValidation;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
