using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.RemoveOperationClaim
{
    public class RemoveOperationClaimCommandHandler : IRequestHandler<RemoveOperationClaimCommand, RemovedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public RemoveOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<RemovedOperationClaimDto> Handle(RemoveOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim getedOperationClaim = await _operationClaimBusinessRules.IdIsAlreadyInDatabase(request.Id);

            await _operationClaimRepository.DeleteAsync(getedOperationClaim);

            return _mapper.Map<RemovedOperationClaimDto>(getedOperationClaim);
        }
    }
}
