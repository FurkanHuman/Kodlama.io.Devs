using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? getUser = await _userRepository.GetAsync(u => u.Email == request.Login.Email);

            _authBusinessRules.NullCheckByUser(getUser);
            _authBusinessRules.HashControlByPassword(HashingHelper.VerifyPasswordHash(request.Login.Password, getUser.PasswordHash, getUser.PasswordSalt));

            AccessToken createdAccessToken = await _authService.CreateAccessToken(getUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(getUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            return new() { RefreshToken = addedRefreshToken, AccessToken = createdAccessToken };
        }
    }
}
