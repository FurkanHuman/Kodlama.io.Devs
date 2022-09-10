using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Commands.RemoveProgrammingTechnology
{
    public class RemoveProgrammingTechnologyCommandHandler : IRequestHandler<RemoveProgrammingTechnologyCommand, RemovedProgrammingTechnologyDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepo;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public RemoveProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepo, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepo = programmingTechnologyRepo;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<RemovedProgrammingTechnologyDto> Handle(RemoveProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology? getPT = await _programmingTechnologyRepo.GetAsync(pt => pt.Id == request.Id);
            await _programmingTechnologyBusinessRules.ProgrammingTechnologyNullCheck(getPT);
            ProgrammingTechnology deletedPt = await _programmingTechnologyRepo.DeleteAsync(getPT);

            return new(deletedPt.Id, true);
        }
    }
}
