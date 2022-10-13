using Application.Features.ProgrammingTechnologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdatedProgrammingTechnologyDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramminglanguageId { get; set; }

        public string[] Roles => new[] { nameof(UpdateProgrammingTechnologyCommand) };
    }
}
