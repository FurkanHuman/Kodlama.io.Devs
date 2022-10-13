using Application.Features.ProgrammingTechnologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreatedProgrammingTechnologyDto>, ISecuredRequest
    {
        public int PLId { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(CreateProgrammingTechnologyCommand) };
    }
}
