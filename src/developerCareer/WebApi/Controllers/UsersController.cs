using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetByEmailUserForClaims;
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

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetByEmailUserForClaims")]
        public async Task<IActionResult> GetByEmailUserForClaims([FromForm] GetByEmailUserForClaimsQuery getByEmailUserForClaims )
        {
            GetByEmailUserForClaimsDto result = await _mediator.Send(getByEmailUserForClaims);
            return Ok(result);
        }
    }
}
