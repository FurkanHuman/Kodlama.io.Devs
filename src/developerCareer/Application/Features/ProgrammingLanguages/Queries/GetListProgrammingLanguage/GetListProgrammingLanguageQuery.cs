using Application.Features.ProgrammingLanguages.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { nameof(GetListProgrammingLanguageQuery) };
    }
}
