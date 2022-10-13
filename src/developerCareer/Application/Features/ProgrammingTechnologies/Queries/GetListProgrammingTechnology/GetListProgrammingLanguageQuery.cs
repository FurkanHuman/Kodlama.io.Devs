using Application.Features.ProgrammingTechnologies.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { nameof(GetListProgrammingTechnologyQuery) };
    }
}
