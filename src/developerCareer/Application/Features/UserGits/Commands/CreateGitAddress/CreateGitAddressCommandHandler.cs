using Application.Features.UserGits.Dtos;
using Application.Features.UserGits.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Application.Features.UserGits.Commands.CreateGitAddress
{
    public class CreateGitAddressCommandHandler : IRequestHandler<CreateGitAddressCommand, CreatedUserGitDto>
    {
        private readonly IUserGitRepository _userGitRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserGitBusinessRules _userGitBusinessRules;

        public CreateGitAddressCommandHandler(IUserGitRepository userGitRepository, IUserRepository userRepository, UserGitBusinessRules userGitBusinessRules)
        {
            _userGitRepository = userGitRepository;
            _userRepository = userRepository;
            _userGitBusinessRules = userGitBusinessRules;
        }

        public async Task<CreatedUserGitDto> Handle(CreateGitAddressCommand request, CancellationToken cancellationToken)
        {
            await _userGitBusinessRules.UserIsExistByUserMailAndGitAddress(request.Email, request.GitAddress);

            User? getUser = await _userRepository.GetAsync(u => u.Email == request.Email);

            UserGit userGitForNew = new() { GitLink = request.GitAddress, User = getUser };

            UserGit addedGitUser = await _userGitRepository.AddAsync(userGitForNew);

            return new() { GitAddress = addedGitUser.GitLink, IsSuccess = true, Email = addedGitUser.User.Email };
        }
    }
}
