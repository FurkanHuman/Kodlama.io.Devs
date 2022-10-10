using FluentValidation;

namespace Application.Features.UserGits.Commands.RemoveGitAddress
{
    public class RemoveGitAddressCommandValidator : AbstractValidator<RemoveGitAddressCommand>
    {
        public RemoveGitAddressCommandValidator()
        {
            RuleFor(rg => rg.Email).NotEmpty().NotNull().EmailAddress();
        }
    }
}
