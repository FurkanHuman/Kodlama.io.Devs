using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)=> _mediator = mediator;

        [HttpPut("Register")]
        public async Task<AccessToken> Register([FromBody] UserRegisterCommand userRegister)
        {
            AccessToken token = await _mediator.Send(userRegister);
            return token;
        }

        [HttpPut("Login")]
        public async Task<AccessToken> Login([FromBody] UserLoginCommand userLogin)
        {
            AccessToken token = await _mediator.Send(userLogin);
            return token;
        }
    }
}
