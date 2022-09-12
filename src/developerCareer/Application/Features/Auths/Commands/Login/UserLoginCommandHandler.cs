using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Commands.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepo;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserBusinessRules _userBusinessRules;

        public UserLoginCommandHandler(IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepo, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userOperationClaimRepo = userOperationClaimRepo;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<AccessToken> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            User? getUser = await _userRepository.GetAsync(u=>u.Email.ToLower()==request.Login.Email.ToLower());
            _userBusinessRules.NullCheckByUser(getUser);

            bool hashControl = HashingHelper.VerifyPasswordHash(request.Login.Password, getUser.PasswordHash, getUser.PasswordSalt);
            _userBusinessRules.HashControlByPassword(hashControl);

            IPaginate<UserOperationClaim> userOpClaims = await _userOperationClaimRepo.GetListAsync(op =>
            op.UserId == getUser.Id,
            include: op => op.Include(oc => oc.OperationClaim),
            cancellationToken: cancellationToken);

            IList<OperationClaim> oPList = userOpClaims.Items.Select(p => p.OperationClaim).ToList();

            return _tokenHelper.CreateToken(getUser, oPList);
        }
    }
}
