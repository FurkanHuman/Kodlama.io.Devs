using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class UserLoginCommand:IRequest<AccessToken>
    {
       public UserForLoginDto Login { get; set; }
    }
}
