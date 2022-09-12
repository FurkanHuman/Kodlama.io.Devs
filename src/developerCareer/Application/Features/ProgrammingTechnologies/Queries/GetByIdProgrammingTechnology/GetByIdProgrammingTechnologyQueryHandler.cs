using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology
{
    public class GetByIdProgrammingTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingTechnologyQuery, ProgrammingTechnologyGetByIdDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyRules;

        public GetByIdProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyRules = programmingTechnologyRules;
        }

        public async Task<ProgrammingTechnologyGetByIdDto> Handle(GetByIdProgrammingTechnologyQuery request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology? getPT = await _programmingTechnologyRepository.GetAsync(pl => pl.Id == request.Id);

            _programmingTechnologyRules.ProgrammingTechnologyNullCheck(getPT);

            return _mapper.Map<ProgrammingTechnologyGetByIdDto>(getPT);
        }
    }
}
