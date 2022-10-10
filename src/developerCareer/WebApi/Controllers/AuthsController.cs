using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthsController(IMediator mediator) => _mediator = mediator;

        [HttpPut("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto register)
        {
            RegisterCommand registerCommand = new() { Register = register, IpAddress = GetIpAddress() };

            RegisteredDto result = await _mediator.Send(registerCommand);

            SetRefresTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userLogin)
        {
            LoginCommand loginCommand = new() { Login = userLogin, IpAddress = GetIpAddress() };

            LoginedDto result = await _mediator.Send(loginCommand);

            SetRefresTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }

        private void SetRefresTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
