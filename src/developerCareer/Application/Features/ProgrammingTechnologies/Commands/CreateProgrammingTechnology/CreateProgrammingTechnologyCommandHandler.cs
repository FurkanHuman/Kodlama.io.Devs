using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _technologyBusinessRules;

        public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules technologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology mappedPT = _mapper.Map<ProgrammingTechnology>(request);
            await _technologyBusinessRules.ProgrammingLanguageNullCheckById(request.PLId);
            await _technologyBusinessRules.ProgrammingTechnologyAddingBeforeDataBaseControlByName(request.Name);

            ProgrammingTechnology getPT = await _programmingTechnologyRepository.AddAsync(mappedPT);

            return _mapper.Map<CreatedProgrammingTechnologyDto>(getPT);
        }
    }
}
