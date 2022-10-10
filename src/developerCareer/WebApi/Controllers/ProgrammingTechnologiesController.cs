using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.RemoveProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgrammingTechnologiesController(IMediator mediator) => _mediator = mediator;

        [HttpPut("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnology)
        {
            CreatedProgrammingTechnologyDto createPT = await _mediator.Send(createProgrammingTechnology);
            return Created("", createPT);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Delete([FromBody] RemoveProgrammingTechnologyCommand removeProgrammingTechnology)
        {
            RemovedProgrammingTechnologyDto removePT = await _mediator.Send(removeProgrammingTechnology);
            return Ok(removePT);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnology)
        {
            UpdatedProgrammingTechnologyDto updatePT = await _mediator.Send(updateProgrammingTechnology);
            return Created("", updatePT);
        }

        [HttpGet("GetById{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingTechnologyQuery getByIdPTQuery)
        {
            ProgrammingTechnologyGetByIdDto programmingTechnologyGetByIdDto = await _mediator.Send(getByIdPTQuery);

            return Ok(programmingTechnologyGetByIdDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest };

            ProgrammingTechnologyListModel programmingTechnologyListModel = await _mediator.Send(getListProgrammingTechnologyQuery);

            return Ok(programmingTechnologyListModel);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgrammingTechnologyByDynamicQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };

            ProgrammingTechnologyListModel programmingTechnologyListModel = await _mediator.Send(getListProgrammingTechnologyQuery);

            return Ok(programmingTechnologyListModel);
        }
    }
}
