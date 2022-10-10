using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimsForUser
{
    public class DeleteClaimsForUserCommandValidator : AbstractValidator<DeleteClaimsForUserCommand>
    {
        public DeleteClaimsForUserCommandValidator()
        {
            RuleFor(g => g.UserMail).NotNull().NotEmpty().EmailAddress();
            RuleFor(g => g.ClaimIds).NotNull().NotEmpty();
        }
    }
}
