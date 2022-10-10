using Application.Features.UserGits.Commands.CreateGitAddress;
using Application.Features.UserGits.Commands.RemoveGitAddress;
using Application.Features.UserGits.Commands.UpdateGitAddress;
using Application.Features.UserGits.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("Add")]
        public async Task<IActionResult> Add([FromForm] CreateGitAddressCommand createGitAddress)
        {
            CreatedUserGitDto result = await _mediator.Send(createGitAddress);
            return Created("", result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove([FromForm] RemoveGitAddressCommand removeGitAddress)
        {
            RemovedUserGitDto result = await _mediator.Send(removeGitAddress);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateGitAddressCommand updateGitAddress)
        {
            UpdatedUserGitDto result = await _mediator.Send(updateGitAddress);
            return Created("", result);
        }
    }
}
