using FluentValidation;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommandValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreateProgrammingTechnologyCommandValidator()
        {
            RuleFor(pt => pt.PLId).NotEmpty().NotNull();
            RuleFor(pt => pt.Name).NotEmpty().NotNull();
        }
    }
}
