using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Services.AltServices.UserOperationClaimService
{
    public interface IUserOperationClaimService
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<OperationClaim?> GetOperationClaimById(int claimId);
        Task<IPaginate<OperationClaim>> GetListOperationClaimsByIds(IList<int> claimIds);
        Task<IList<OperationClaim>> GetOperationClaimsOfExistingOnesByUserAndClaimIdsAsync(User? getUser, IList<int> ClaimIds);
    }
}
