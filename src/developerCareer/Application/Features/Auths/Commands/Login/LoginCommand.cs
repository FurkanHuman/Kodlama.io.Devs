using Application.Features.Auths.Dtos;
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
    public class LoginCommand:IRequest<LoginedDto>
    {
       public UserForLoginDto Login { get; set; }

        public string IpAddress { get; set; }
    }
}
