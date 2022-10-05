using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto Register { get; set; }

        public string IpAddress { get; set; }
    }
}
