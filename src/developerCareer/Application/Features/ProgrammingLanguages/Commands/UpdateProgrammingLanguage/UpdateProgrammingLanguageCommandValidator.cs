using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Id).NotEmpty().NotNull();
            RuleFor(pl => pl.Name).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
