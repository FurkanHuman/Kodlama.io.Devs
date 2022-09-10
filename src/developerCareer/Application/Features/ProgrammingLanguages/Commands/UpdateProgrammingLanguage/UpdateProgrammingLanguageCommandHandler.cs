using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage ProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);

            _programmingLanguageBusinessRules.ProgrammingLanguageNullCheck(ProgrammingLanguage);
            await _programmingLanguageBusinessRules.ProgrammingLanguageAddingBeforeDataBaseControlByName(ProgrammingLanguage.Name);

            ProgrammingLanguage updatedPl = await _programmingLanguageRepository.UpdateAsync(ProgrammingLanguage);

            return _mapper.Map<UpdatedProgrammingLanguageDto>(updatedPl);
        }
    }
}
