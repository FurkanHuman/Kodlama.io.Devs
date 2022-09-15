using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserBusinessRules _userBusinessRules;

        public UserLoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<AccessToken> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            User? getUser = await _userRepository.GetAsync(u => u.Email.ToLower() == request.Login.Email.ToLower());

            _userBusinessRules.NullCheckByUser(getUser);

            _userBusinessRules.HashControlByPassword(HashingHelper.VerifyPasswordHash(request.Login.Password, getUser.PasswordHash, getUser.PasswordSalt));

            IList<OperationClaim> oPList = await _userBusinessRules.GetUserOperationClaim(getUser, cancellationToken);

            return _tokenHelper.CreateToken(getUser, oPList);
        }
    }
}
