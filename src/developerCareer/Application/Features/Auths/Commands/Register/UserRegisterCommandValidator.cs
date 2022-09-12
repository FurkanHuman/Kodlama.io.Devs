using FluentValidation;

namespace Application.Features.Auths.Commands.Register
{
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterCommandValidator()
        {
            RuleFor(u => u.Register).NotEmpty().NotNull();
            RuleFor(u => u.Register.FirstName).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(u => u.Register.LastName).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(u => u.Register.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(u => u.Register.Password).MinimumLength(8).NotEmpty().NotNull();
        }
    }
}
