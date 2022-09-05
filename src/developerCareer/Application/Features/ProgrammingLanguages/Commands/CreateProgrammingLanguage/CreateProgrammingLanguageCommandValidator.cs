using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
