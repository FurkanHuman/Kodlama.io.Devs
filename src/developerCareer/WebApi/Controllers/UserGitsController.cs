using Application.Features.UserGits.Commands.CreateGitAddress;
using Application.Features.UserGits.Commands.RemoveGitAddress;
using Application.Features.UserGits.Commands.UpdateGitAddress;
using Application.Features.UserGits.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<CreatedUserGitDto> Add([FromForm] CreateGitAddressCommand createGitAddress)
        {
            CreatedUserGitDto result = await _mediator.Send(createGitAddress);
            return result;
        }

        [HttpDelete("Remove")]
        public async Task<RemovedUserGitDto> Remove([FromForm] RemoveGitAddressCommand removeGitAddress)
        {
            RemovedUserGitDto result = await _mediator.Send(removeGitAddress);
            return result;
        }

        [HttpPut("Update")]
        public async Task<UpdatedUserGitDto> Update([FromForm] UpdateGitAddressCommand updateGitAddress)
        {
            UpdatedUserGitDto result = await _mediator.Send(updateGitAddress);
            return result;
        }
    }
}
