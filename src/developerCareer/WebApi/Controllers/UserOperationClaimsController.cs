using Application.Features.UserOperationClaims.Commands.AddClaimForUser;
using Application.Features.UserOperationClaims.Commands.AddClaimsForUser;
using Application.Features.UserOperationClaims.Commands.DeleteClaimForUser;
using Application.Features.UserOperationClaims.Commands.DeleteClaimsForUser;
using Application.Features.UserOperationClaims.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserOperationClaimsController(IMediator mediator) => _mediator = mediator;

        [HttpPut("Add")]
        public async Task<IActionResult> Add([FromBody] AddClaimForUserCommand addClaimForUserCommand )
        {
            AddClaimForUserDto result = await _mediator.Send(addClaimForUserCommand);
            return Created("", result);
        }

        [HttpPut("AddMultiple")]
        public async Task<IActionResult> AddMultiple([FromBody] AddClaimsForUserCommand addClaimsForUserCommand)
        {
            AddClaimsForUserDto result = await _mediator.Send(addClaimsForUserCommand);
            return Created("", result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteClaimForUserCommand deleteClaimForUserCommand)
        {
            DeleteClaimForUserDto result = await _mediator.Send(deleteClaimForUserCommand);
            return Ok(result);
        }
        
        [HttpDelete("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] DeleteClaimsForUserCommand deleteClaimsForUserCommand)
        {
            DeleteClaimsForUserDto result = await _mediator.Send(deleteClaimsForUserCommand);
            return Ok(result);
        }
    }
}
