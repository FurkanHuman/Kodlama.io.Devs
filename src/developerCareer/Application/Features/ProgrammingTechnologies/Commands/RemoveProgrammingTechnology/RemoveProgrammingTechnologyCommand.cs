using Application.Features.ProgrammingTechnologies.Dtos;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.RemoveProgrammingTechnology
{
    public class RemoveProgrammingTechnologyCommand : IRequest<RemovedProgrammingTechnologyDto>
    {
        public int Id { get; set; }
    }
}
