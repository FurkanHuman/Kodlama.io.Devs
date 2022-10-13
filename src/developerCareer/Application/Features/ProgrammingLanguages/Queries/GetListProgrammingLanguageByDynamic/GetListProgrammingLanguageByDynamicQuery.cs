using Application.Features.ProgrammingLanguages.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageByDynamicQuery : IRequest<ProgrammingLanguageListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public string[] Roles => new[] { nameof(GetListProgrammingLanguageByDynamicQuery) };
    }
}
