using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.AddClaimsForUser
{
    public class AddClaimsForUserCommandValidator : AbstractValidator<AddClaimsForUserCommand>
    {
        public AddClaimsForUserCommandValidator()
        {
            RuleFor(g => g.UserMail).NotNull().NotEmpty().EmailAddress();
            RuleFor(g => g.ClaimIds).NotNull().NotEmpty();
        }
    }
}
