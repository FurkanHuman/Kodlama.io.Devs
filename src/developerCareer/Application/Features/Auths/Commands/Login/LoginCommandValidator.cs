using FluentValidation;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.Login.Email).NotEmpty().NotNull();
            RuleFor(u => u.Login.Password).NotEmpty().NotNull();
        }
    }
}
