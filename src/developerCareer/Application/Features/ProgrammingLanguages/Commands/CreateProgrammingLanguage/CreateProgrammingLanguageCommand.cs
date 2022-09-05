using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }
    }
}
