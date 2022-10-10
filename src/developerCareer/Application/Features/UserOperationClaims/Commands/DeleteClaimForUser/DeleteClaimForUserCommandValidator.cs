using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.DeleteClaimForUser
{
    public class DeleteClaimForUserCommandValidator : AbstractValidator<DeleteClaimForUserCommand>
    {
        public DeleteClaimForUserCommandValidator()
        {
            RuleFor(h => h.UserMail).NotEmpty().NotNull().EmailAddress();
            RuleFor(h => h.ClaimId).NotEmpty().NotNull();
        }
    }
}
