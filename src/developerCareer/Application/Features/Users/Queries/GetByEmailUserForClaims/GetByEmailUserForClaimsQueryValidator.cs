using FluentValidation;

namespace Application.Features.Users.Queries.GetByEmailUserForClaims
{
    public class GetByEmailUserForClaimsQueryValidator : AbstractValidator<GetByEmailUserForClaimsQuery>
    {
        public GetByEmailUserForClaimsQueryValidator()
        {
            RuleFor(j => j.Email).NotNull().NotEmpty().EmailAddress();
        }
    }

}
