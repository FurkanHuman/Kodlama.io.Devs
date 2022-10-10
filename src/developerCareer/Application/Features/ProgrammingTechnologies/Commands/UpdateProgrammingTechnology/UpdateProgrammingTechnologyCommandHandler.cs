using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdatedProgrammingTechnologyDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _technologyBusinessRules;

        public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules technologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<UpdatedProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology mappedPT = _mapper.Map<ProgrammingTechnology>(request);

            _technologyBusinessRules.ProgrammingTechnologyNullCheck(mappedPT);
            await _technologyBusinessRules.ProgrammingTechnologyAddingBeforeDataBaseControlByName(mappedPT.Name);
            await _technologyBusinessRules.ProgrammingLanguageNullCheckById(mappedPT.ProgrammingLanguageId);

            ProgrammingTechnology updatePt = await _programmingTechnologyRepository.UpdateAsync(mappedPT);
            return _mapper.Map<UpdatedProgrammingTechnologyDto>(updatePt);
        }
    }
}
