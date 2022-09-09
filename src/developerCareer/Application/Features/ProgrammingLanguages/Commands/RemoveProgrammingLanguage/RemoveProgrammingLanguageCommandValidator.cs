using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommandValidator : AbstractValidator<RemoveProgrammingLanguageCommand>
    {
        public RemoveProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Id).NotNull().NotEmpty();
        }
    }
}
