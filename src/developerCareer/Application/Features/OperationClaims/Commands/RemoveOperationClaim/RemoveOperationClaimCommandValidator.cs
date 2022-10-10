using FluentValidation;

namespace Application.Features.OperationClaims.Commands.RemoveOperationClaim
{
    public class RemoveOperationClaimCommandValidator : AbstractValidator<RemoveOperationClaimCommand>
    {
        public RemoveOperationClaimCommandValidator()
        {
            RuleFor(o => o.Id).GreaterThan(0).NotEmpty().NotNull().LessThan(int.MaxValue);
        }
    }
}

