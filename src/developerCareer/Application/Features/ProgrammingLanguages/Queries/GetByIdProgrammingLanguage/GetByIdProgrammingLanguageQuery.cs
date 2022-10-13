using Application.Features.ProgrammingLanguages.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { nameof(GetByIdProgrammingLanguageQuery) };
    }
}
