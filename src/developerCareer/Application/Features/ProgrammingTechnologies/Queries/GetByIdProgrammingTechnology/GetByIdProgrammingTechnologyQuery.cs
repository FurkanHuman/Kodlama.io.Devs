using Application.Features.ProgrammingTechnologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology
{
    public class GetByIdProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { nameof(GetByIdProgrammingTechnologyQuery) };
    }
}
