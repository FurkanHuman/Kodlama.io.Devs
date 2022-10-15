using Application.Services.AltServices.UserOperationClaimService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task CheckIfUserMailExists(string mail)
        {
            User? getUser = await _userOperationClaimService.GetUserByEmailAsync(mail) ;
            if (getUser == null) throw new BusinessException("Mail Don't Exist.");
        }

        public async Task CheckifOperationClaimExists(int claimId)
        {
            OperationClaim? getOperationClaim = await _userOperationClaimService.GetOperationClaimById(claimId);
            if (getOperationClaim == null) throw new BusinessException("operation Claim Don't Exist.");
        }

        public async Task CheckifUserOperationClaimExists(User? user, int claimId)
        {
            UserOperationClaim? getOperationClaim = await _userOperationClaimRepository.GetAsync(op => op.User == user && op.OperationClaimId == claimId);
            if (getOperationClaim != null) throw new BusinessException("User operation Claim Is Exist.");
        }

        public async Task CheckifOperationClaimsExists(IList<int> claimIds)
        {
            IPaginate<OperationClaim> getListOperationClaims = await _userOperationClaimService.GetListOperationClaimsByIds(claimIds);
            if (getListOperationClaims.Count == 0) throw new BusinessException("operation Claims Don't Exist.");
        }

        public void ClaimsIsNull(IList<OperationClaim> newOperationClaimForUser)
        {
            if (newOperationClaimForUser.Count == 0) throw new BusinessException("Operation Claims is Exist");
        }

        public void UserOperationClaimNullCheck(UserOperationClaim? getUserOC)
        {
            if (getUserOC == null) throw new BusinessException("user's claim could not be found");
        }

        public void UserOperationClaimsNullCheck(IList<UserOperationClaim?> getUserOCs)
        {
            if (getUserOCs.Count == 0) throw new BusinessException("user's claims could not be found");
        }
    }
}
