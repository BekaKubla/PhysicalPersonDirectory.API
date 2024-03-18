using FluentValidation;
using PhysiscalPersonDirectory.Common.Resources;
using System.Text.RegularExpressions;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Commands.CreatePerson
{
    public partial class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x) &&
                    (EnglishWords().IsMatch(x) || GeorgianWords().IsMatch(x)))
                .WithMessage(StringResource.TextError);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(2, 50)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x) &&
                    (EnglishWords().IsMatch(x) || GeorgianWords().IsMatch(x)))
                .WithMessage(StringResource.TextError);

            RuleFor(x => x.PersonalNumber)
                .NotEmpty()
                .Length(11, 11)
                .Matches("^[0-9]*$")
                .WithMessage(StringResource.FormatInvalid);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(b => DateTime.Now.Year - b.Year >= 18)
                .WithMessage(StringResource.AgeInvalid);

            RuleFor(m => m.Gender)
                .NotEmpty()
                .WithMessage(StringResource.Mandatory);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .When(x => x.PhoneNumberType != null)
                .WithMessage(StringResource.Mandatory);

            RuleFor(x => x.PhoneNumberType)
                .NotNull()
                .NotEmpty()
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage(StringResource.Mandatory);

        }

        [GeneratedRegex("^[a-zA-Z]*$")]
        private static partial Regex EnglishWords();

        [GeneratedRegex("^[ა-ჰ]*$")]
        private static partial Regex GeorgianWords();
    }
}
