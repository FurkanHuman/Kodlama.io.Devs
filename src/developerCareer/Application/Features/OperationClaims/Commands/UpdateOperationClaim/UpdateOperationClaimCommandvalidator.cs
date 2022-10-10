using FluentValidation;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{

    public class UpdateOperationClaimCommandvalidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandvalidator()
        {
            RuleFor(o => o.Id).GreaterThan(0).NotEmpty().NotNull().LessThan(int.MaxValue);
            RuleFor(c => c.Name).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}