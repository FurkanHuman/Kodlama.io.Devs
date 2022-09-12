using FluentValidation;

namespace Application.Features.UserGits.Commands.UpdateGitAddress
{
    public class UpdateGitAddressCommandValidator : AbstractValidator<UpdateGitAddressCommand>
    {
        public UpdateGitAddressCommandValidator()
        {
            RuleFor(g => g.GitAddress).NotNull().NotEmpty();
            RuleFor(g => g.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
