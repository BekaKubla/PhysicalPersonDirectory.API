using FluentValidation;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommandValidator : AbstractValidator<DeleteRelatedPersonCommand>
    {
        public DeleteRelatedPersonCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.RelatedPersonId).NotEmpty();
        }
    }
}
