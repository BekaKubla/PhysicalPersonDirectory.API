using FluentValidation;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Delete
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
