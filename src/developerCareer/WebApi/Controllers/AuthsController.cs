using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
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
<<<<<<< HEAD
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto register)
=======
        public async Task<ActionResult> Register([FromBody] UserForRegisterDto register)
>>>>>>> 1a163cf1acc36edd41d42c3abdb62eefb134760d
        {
            RegisterCommand registerCommand = new() { Register = register, IpAddress = GetIpAddress() };

            RegisteredDto result = await _mediator.Send(registerCommand);

            SetRefresTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        [HttpPut("Login")]
<<<<<<< HEAD
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userLogin)
=======
        public async Task<ActionResult> Login([FromBody] UserForLoginDto userLogin)
>>>>>>> 1a163cf1acc36edd41d42c3abdb62eefb134760d
        {
            LoginCommand loginCommand = new() { Login = userLogin, IpAddress = GetIpAddress() };

            LoginedDto result = await _mediator.Send(loginCommand);

            SetRefresTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
<<<<<<< HEAD
=======
            // return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().MapToIPv6().ToString();
>>>>>>> 1a163cf1acc36edd41d42c3abdb62eefb134760d
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }

        private void SetRefresTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
