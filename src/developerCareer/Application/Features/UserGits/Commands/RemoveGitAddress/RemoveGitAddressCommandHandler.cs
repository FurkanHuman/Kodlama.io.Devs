using Application.Features.UserGits.Dtos;
using Application.Features.UserGits.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserGits.Commands.RemoveGitAddress
{
    public class RemoveGitAddressCommandHandler : IRequestHandler<RemoveGitAddressCommand, RemovedUserGitDto>
    {
        private readonly IUserGitRepository _userGitRepository;
        private readonly UserGitBusinessRules _userGitBusinessRules;

        public RemoveGitAddressCommandHandler(IUserGitRepository userGitRepository, UserGitBusinessRules userGitBusinessRules)
        {
            _userGitRepository = userGitRepository;
            _userGitBusinessRules = userGitBusinessRules;
        }

        public async Task<RemovedUserGitDto> Handle(RemoveGitAddressCommand request, CancellationToken cancellationToken)
        {
            UserGit controledGitUser = await _userGitBusinessRules.UserGitIsExistByUserMail(request.Email);

            await _userGitRepository.DeleteAsync(controledGitUser);

            return new() { GitAddress = controledGitUser.GitLink, IsSuccess = true };
        }
    }
}
