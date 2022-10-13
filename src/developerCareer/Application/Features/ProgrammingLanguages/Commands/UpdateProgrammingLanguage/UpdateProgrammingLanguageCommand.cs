using Application.Features.ProgrammingLanguages.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(UpdateProgrammingLanguageCommand) };
    }
}
