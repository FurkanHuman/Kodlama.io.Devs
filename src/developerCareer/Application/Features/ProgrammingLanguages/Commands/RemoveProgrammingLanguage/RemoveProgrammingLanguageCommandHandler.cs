using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommandHandler : IRequestHandler<RemoveProgrammingLanguageCommand, RemovedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public RemoveProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<RemovedProgrammingLanguageDto> Handle(RemoveProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? getPl = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

            _programmingLanguageBusinessRules.ProgrammingLanguageNullCheck(getPl);

            await _programmingLanguageRepository.DeleteAsync(getPl);

            return new RemovedProgrammingLanguageDto(getPl.Id, true);
        }
    }
}
