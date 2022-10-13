using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto Login { get; set; }

        public string IpAddress { get; set; }
    }
}
