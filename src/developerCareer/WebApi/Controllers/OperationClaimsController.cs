using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.RemoveOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OperationClaimsController(IMediator mediator) => _mediator = mediator;


        [HttpPut("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaim)
        {
            CreatedOperationClaimDto result = await _mediator.Send(createOperationClaim);
            return Created("", result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] RemoveOperationClaimCommand removeOperationClaim)
        {
            RemovedOperationClaimDto result = await _mediator.Send(removeOperationClaim);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaim)
        {
            UpdatedOperationClaimDto result = await _mediator.Send(updateOperationClaim);
            return Created("", result);
        }

        [HttpGet("GetById{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaim)
        {
            OperationClaimGetByIdDto result = await _mediator.Send(getByIdOperationClaim);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaim = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await _mediator.Send(getListOperationClaim);

            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListOperationClaimByDynamicQuery getListOperationClaimByDynamic = new() { PageRequest = pageRequest, Dynamic = dynamic };
            OperationClaimListModel result = await _mediator.Send(getListOperationClaimByDynamic);

            return Ok(result);
        }
    }
}
