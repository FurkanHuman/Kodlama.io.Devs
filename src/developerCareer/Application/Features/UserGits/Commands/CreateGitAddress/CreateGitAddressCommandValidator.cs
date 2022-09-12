using FluentValidation;

namespace Application.Features.UserGits.Commands.CreateGitAddress
{
    public class CreateGitAddressCommandValidator : AbstractValidator<CreateGitAddressCommand>
    {
        public CreateGitAddressCommandValidator()
        {
            RuleFor(g => g.GitAddress).NotNull().NotEmpty();
            RuleFor(g => g.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
