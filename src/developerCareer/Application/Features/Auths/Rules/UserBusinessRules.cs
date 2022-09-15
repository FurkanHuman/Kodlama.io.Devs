using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepo;

        public UserBusinessRules(IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepo)
        {
            _userRepository = userRepository;
            _userOperationClaimRepo = userOperationClaimRepo;
        }

        public async Task UserIsExistByEmail(string mail,CancellationToken cancellationToken)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(u => u.Email.ToLower() == mail.ToLower());
            if (result.Count >= 1) throw new BusinessException("User is exit");
        }

        public void HashControlByPassword(bool hashControl)
        {
            if (!hashControl) throw new BusinessException("invalid mail or password.");
        }

        public void NullCheckByUser(User? getUser)
        {
            if (getUser==null) throw new BusinessException("invalid mail or password.");
        }

        public async Task<IList<OperationClaim>> GetUserOperationClaim(User user, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOpClaims = await _userOperationClaimRepo.GetListAsync(op =>
                        op.UserId == user.Id,
                        include: op => op.Include(oc => oc.OperationClaim),
                        cancellationToken: cancellationToken);

            return userOpClaims.Items.Select(p => p.OperationClaim).ToList();
        }
    }
}
