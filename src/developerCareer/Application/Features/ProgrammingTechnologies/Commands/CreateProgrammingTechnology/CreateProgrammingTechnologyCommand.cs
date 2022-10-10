using Application.Features.ProgrammingTechnologies.Dtos;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreatedProgrammingTechnologyDto>
    {
        public int PLId { get; set; }
        public string Name { get; set; }
    }
}
