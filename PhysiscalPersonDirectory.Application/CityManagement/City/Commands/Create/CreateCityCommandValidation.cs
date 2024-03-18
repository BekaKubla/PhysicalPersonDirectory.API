using FluentValidation;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Commands.Create
{
    public class CreateCityCommandValidation : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
