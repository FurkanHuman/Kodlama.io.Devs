
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public UserOperationClaimBusinessRules(IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userRepository = userRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<User> CheckIfUserMailExists(string mail)
        {
            User? getUser = await _userRepository.GetAsync(u => u.Email == mail);
            if (getUser == null) throw new BusinessException("Mail Don't Exist.");
            return getUser;
        }

        public async Task<OperationClaim> CheckifOperationClaimExists(int claimId)
        {
            OperationClaim? getOperationClaim = await _operationClaimRepository.GetAsync(op => op.Id == claimId);
            if (getOperationClaim == null) throw new BusinessException("operation Claim Don't Exist.");
            return getOperationClaim;
        }

        public IList<OperationClaim> CheckifOperationClaimsExists(IList<int> claimIds)
        {
            IList<OperationClaim> getListOperationClaims = _operationClaimRepository.GetListAsync(op => claimIds.Contains(op.Id), size: int.MaxValue).Result.Items;
            if (getListOperationClaims.Count == 0) throw new BusinessException("operation Claims Don't Exist.");
            return getListOperationClaims;
        }

        public async Task<UserOperationClaim> CheckifUserOperationClaimExistsByMailAndClaimId(string mail, int claimId)
        {
            User getUser = await CheckIfUserMailExists(mail);
            OperationClaim getOC = await CheckifOperationClaimExists(claimId);

            UserOperationClaim? getUserOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.UserId == getUser.Id && u.OperationClaimId == getOC.Id);
            if (getUserOperationClaim == null) throw new BusinessException("User Operation Claim not Exist.");
            return getUserOperationClaim;
        }

        public async Task<IList<UserOperationClaim>> CheckifUserOperationClaimExistsByMailAndClaimIds(string mail, IList<int> claimIds)
        {
            User getUser = await CheckIfUserMailExists(mail);
            IList<int> getOCIds = CheckifOperationClaimsExists(claimIds).Select(p => p.Id).ToList();

            IList<UserOperationClaim> getUserOperationClaims = _userOperationClaimRepository.GetListAsync(u => u.UserId == getUser.Id && getOCIds.Contains(u.OperationClaimId), size: int.MaxValue, include: y => y.Include(k => k.OperationClaim).Include(k => k.User)).Result.Items;

            if (getUserOperationClaims.Count == 0) throw new BusinessException("User Operation Claims not Exist.");
            return getUserOperationClaims;
        }
    }
}
