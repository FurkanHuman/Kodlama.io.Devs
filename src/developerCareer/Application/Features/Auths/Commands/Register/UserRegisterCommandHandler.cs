using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Commands.Register
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepo;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ITokenHelper _tokenHelper;

        public UserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IUserOperationClaimRepository userOperationClaimRepo, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userOperationClaimRepo = userOperationClaimRepo;
            _userBusinessRules = userBusinessRules;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserIsExistByEmail(request.Register.Email,cancellationToken);

            User mappedUser = _mapper.Map<User>(request.Register);

            HashingHelper.CreatePasswordHash(request.Register.Password, out byte[] hash, out byte[] salt);

            mappedUser.PasswordSalt = salt;
            mappedUser.PasswordHash = hash;
            mappedUser.Status = true;
            mappedUser.AuthenticatorType = 0;

            User registeredUser = await _userRepository.AddAsync(mappedUser);

            UserOperationClaim userClaim = await _userOperationClaimRepo.AddAsync(new()
            {
                UserId = registeredUser.Id,
                OperationClaimId = 2
            });

            IList<OperationClaim> oPList = await _userBusinessRules.GetUserOperationClaim(registeredUser, cancellationToken);

            return _tokenHelper.CreateToken(registeredUser, oPList);
        }
    }
}
