using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommand : IRequest<RemovedProgrammingLanguageDto>
    {
        public int Id { get; set; }
    }
}
