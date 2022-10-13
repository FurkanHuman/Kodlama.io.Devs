using Application.Features.ProgrammingTechnologies.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic
{
    public class GetListProgrammingTechnologyByDynamicQuery : IRequest<ProgrammingTechnologyListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public string[] Roles => new[] { nameof(GetListProgrammingTechnologyByDynamicQuery) };
    }
}
