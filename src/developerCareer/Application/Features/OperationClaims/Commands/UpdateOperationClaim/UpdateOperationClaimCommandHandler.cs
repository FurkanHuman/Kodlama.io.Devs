using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public partial class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim mappedOC = _mapper.Map<OperationClaim>(request);

            await _operationClaimBusinessRules.NameIsExist(request.Name);

            await _operationClaimBusinessRules.IdIsAlreadyInDatabase(request.Id);

            OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOC);

            return _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
        }
    }
}
