using Application.Features.ProgrammingLanguages.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(CreateProgrammingLanguageCommand) };
    }
}
