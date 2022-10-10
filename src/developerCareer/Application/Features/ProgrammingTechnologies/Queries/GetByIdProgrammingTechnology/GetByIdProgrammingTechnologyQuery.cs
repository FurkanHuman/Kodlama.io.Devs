using Application.Features.ProgrammingTechnologies.Dtos;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology
{
    public class GetByIdProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyGetByIdDto>
    {
        public int Id { get; set; }
    }
}
