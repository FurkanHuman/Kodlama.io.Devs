using Application.Features.ProgrammingTechnologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.RemoveProgrammingTechnology
{
    public class RemoveProgrammingTechnologyCommand : IRequest<RemovedProgrammingTechnologyDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { nameof(RemoveProgrammingTechnologyCommand) };
    }
}
