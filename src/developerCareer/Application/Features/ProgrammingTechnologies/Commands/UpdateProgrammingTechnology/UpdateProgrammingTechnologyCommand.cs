using Application.Features.ProgrammingTechnologies.Dtos;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand:IRequest<UpdatedProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramminglanguageId { get; set; }
    }
}
