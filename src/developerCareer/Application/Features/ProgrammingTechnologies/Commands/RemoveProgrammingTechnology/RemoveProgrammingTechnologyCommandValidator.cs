using FluentValidation;

namespace Application.Features.ProgrammingTechnologies.Commands.RemoveProgrammingTechnology
{
    public class RemoveProgrammingTechnologyCommandValidator : AbstractValidator<RemoveProgrammingTechnologyCommand>
    {
        public RemoveProgrammingTechnologyCommandValidator()
        {
            RuleFor(pt => pt.Id).NotEmpty().NotNull();
        }
    }
}
