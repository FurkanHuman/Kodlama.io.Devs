using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Services.AltServices.UserOperationClaimService
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, IUserRepository userRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
            _userRepository = userRepository;
        }

        public Task<IPaginate<OperationClaim>> GetListOperationClaimsByIds(IList<int> claimIds)
        {
            return _operationClaimRepository.GetListAsync(op => claimIds.Contains(op.Id), size: int.MaxValue);
        }

        public Task<OperationClaim?> GetOperationClaimById(int claimId)
        {
            return _operationClaimRepository.GetAsync(op => op.Id == claimId);
        }

        public async Task<IList<OperationClaim>> GetOperationClaimsOfExistingOnesByUserAndClaimIdsAsync(User? getUser, IList<int> ClaimIds)
        {
            IPaginate<OperationClaim> getOperationClaimsForUser = await _operationClaimRepository.GetListAsync(o => ClaimIds.Contains(o.Id), size: int.MaxValue);

            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(k => k.UserId == getUser.Id, size: int.MaxValue);

            return getOperationClaimsForUser.Items.Except(userOperationClaims.Items.Select(y => y.OperationClaim)).ToList();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetAsync(p => p.Email == email);
        }
    }
}
