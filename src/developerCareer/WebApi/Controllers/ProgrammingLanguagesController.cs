using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguage)
        {
            CreatedProgrammingLanguageDto createPl = await Mediator.Send(createProgrammingLanguage);
            return Created("", createPl);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Delete([FromBody] RemoveProgrammingLanguageCommand removeProgrammingLanguage)
        {
            RemovedProgrammingLanguageDto removePl = await Mediator.Send(removeProgrammingLanguage);
            return Created("", removePl);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguage)
        {
            UpdatedProgrammingLanguageDto updatePl = await Mediator.Send(updateProgrammingLanguage);
            return Created("", updatePl);
        }

        [HttpGet("GetById{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdPlQuery)
        {
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdPlQuery);

            return Ok(programmingLanguageGetByIdDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };

            ProgrammingLanguageListModel programmingLanguageListModel = await Mediator.Send(getListProgrammingLanguageQuery);

            return Ok(programmingLanguageListModel);
        }
    }
}
