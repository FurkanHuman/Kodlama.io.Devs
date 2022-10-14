using Application.Features.UserGits.Dtos;
using Application.Features.UserGits.Rules;
using Application.Services.AltServices.UserGitService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserGits.Commands.CreateGitAddress
{
    public class CreateGitAddressCommandHandler : IRequestHandler<CreateGitAddressCommand, CreatedUserGitDto>
    {
        private readonly IUserGitRepository _userGitRepository;
        private readonly IUserGitService _userGitService;
        private readonly UserGitBusinessRules _userGitBusinessRules;

        public CreateGitAddressCommandHandler(IUserGitRepository userGitRepository, IUserGitService userGitService, UserGitBusinessRules userGitBusinessRules)
        {
            _userGitRepository = userGitRepository;
            _userGitService = userGitService;
            _userGitBusinessRules = userGitBusinessRules;
        }

        public async Task<CreatedUserGitDto> Handle(CreateGitAddressCommand request, CancellationToken cancellationToken)
        {
            await _userGitBusinessRules.UserIsExistByUserMailAndGitAddress(request.Email, request.GitAddress);

            UserGit userGitForNew = new() { GitLink = request.GitAddress, User = await _userGitService.GetUserByEmailAsync(request.Email) };

            UserGit addedGitUser = await _userGitRepository.AddAsync(userGitForNew);

            return new() { GitAddress = addedGitUser.GitLink, IsSuccess = true, Email = addedGitUser.User.Email };
        }
    }
}
