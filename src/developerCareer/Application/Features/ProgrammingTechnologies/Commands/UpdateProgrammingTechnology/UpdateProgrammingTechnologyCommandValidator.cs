using FluentValidation;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(pt => pt.Id).NotEmpty().NotNull();
            RuleFor(pt => pt.Name).NotEmpty().NotNull();
            RuleFor(pt => pt.ProgramminglanguageId).NotEmpty().NotNull();
        }
    }
}
