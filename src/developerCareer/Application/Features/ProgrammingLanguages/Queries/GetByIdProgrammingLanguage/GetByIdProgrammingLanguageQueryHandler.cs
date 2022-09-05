using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? getPl = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

            _programmingLanguageBusinessRules.ProgrammingLanguageNullCheck(getPl);

            return _mapper.Map<ProgrammingLanguageGetByIdDto>(getPl);
        }
    }
}
