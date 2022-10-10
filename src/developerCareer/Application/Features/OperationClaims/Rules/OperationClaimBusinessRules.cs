
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task NameIsExist(string name)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(c => c.Name.ToLower() == name.ToLower());
            if (result != null) throw new BusinessException("Claim is Exit.");
        }

        public async Task<OperationClaim> IdIsAlreadyInDatabase(int id)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(o => o.Id == id);

            if (result == null) throw new BusinessException("Claim not found.");

            return result;
        }
    }
}
