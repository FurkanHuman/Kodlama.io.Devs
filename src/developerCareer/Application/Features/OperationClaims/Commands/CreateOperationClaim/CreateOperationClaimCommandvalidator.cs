using FluentValidation;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandvalidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandvalidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
