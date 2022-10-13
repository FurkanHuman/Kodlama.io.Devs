using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly IUserRepository _userRepository;

        private readonly AuthBusinessRules _authBusinessRules;

        private readonly IAuthService _authService;

        private readonly IMapper _mapper;

        public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailCanNotBeDublicatedWhenRegistered(request.Register.Email, cancellationToken);

            User mappedUser = _mapper.Map<User>(request.Register);

            HashingHelper.CreatePasswordHash(request.Register.Password, out byte[] hash, out byte[] salt);

            mappedUser.PasswordSalt = salt;
            mappedUser.PasswordHash = hash;
            mappedUser.Status = true;
            mappedUser.AuthenticatorType = 0;

            User registeredUser = await _userRepository.AddAsync(mappedUser);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(registeredUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(registeredUser, request.IpAddress);
            RefreshToken AddedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            return new() { AccessToken = createdAccessToken, RefreshToken = AddedRefreshToken };
        }
    }
}
