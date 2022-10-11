using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimGetByIdDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<OperationClaimGetByIdDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
        {
            OperationClaim? getByIdForOperationClaim = await _operationClaimRepository.GetAsync(r => r.Id == request.Id);

            _operationClaimBusinessRules.NullCheck(getByIdForOperationClaim);
                        
            return _mapper.Map<OperationClaimGetByIdDto>(getByIdForOperationClaim);
        }
    }
}
