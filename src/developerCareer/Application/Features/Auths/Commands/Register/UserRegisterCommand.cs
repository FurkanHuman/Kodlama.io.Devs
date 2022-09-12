using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register
{
    public class UserRegisterCommand:IRequest<AccessToken>
    {
        public UserForRegisterDto Register { get; set; }
    }
}
