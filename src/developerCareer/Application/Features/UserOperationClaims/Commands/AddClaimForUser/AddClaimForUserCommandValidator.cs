using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.AddClaimForUser
{
    public class AddClaimForUserCommandValidator : AbstractValidator<AddClaimForUserCommand>
    {
        public AddClaimForUserCommandValidator()
        {
            RuleFor(h => h.UserMail).NotEmpty().NotNull().EmailAddress();
            RuleFor(h => h.ClaimId).NotEmpty().NotNull();
        }
    }
}
