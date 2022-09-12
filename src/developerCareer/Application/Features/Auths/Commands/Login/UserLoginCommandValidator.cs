using FluentValidation;

namespace Application.Features.Auths.Commands.Login
{
    public class UserLoginCommandValidator:AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(u => u.Login.Email).NotEmpty().NotNull();
            RuleFor(u => u.Login.Password).NotEmpty().NotNull();
        }
    }
}
