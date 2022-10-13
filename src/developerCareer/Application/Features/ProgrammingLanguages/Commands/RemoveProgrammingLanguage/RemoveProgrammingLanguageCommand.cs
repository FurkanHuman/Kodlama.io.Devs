using Application.Features.ProgrammingLanguages.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommand : IRequest<RemovedProgrammingLanguageDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { nameof(RemoveProgrammingLanguageCommand) };
    }
}
