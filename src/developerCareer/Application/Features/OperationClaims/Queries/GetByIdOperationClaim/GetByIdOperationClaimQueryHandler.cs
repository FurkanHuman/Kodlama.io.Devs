using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimGetByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public GetByIdOperationClaimQueryHandler(IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<OperationClaimGetByIdDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
        {
            OperationClaim getByIdForOperationClaim = await _operationClaimBusinessRules.IdIsAlreadyInDatabase(request.Id);

            return _mapper.Map<OperationClaimGetByIdDto>(getByIdForOperationClaim);
        }
    }
}
