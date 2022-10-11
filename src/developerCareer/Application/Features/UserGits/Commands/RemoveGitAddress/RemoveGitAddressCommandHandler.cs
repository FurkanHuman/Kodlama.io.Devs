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
            await _userGitBusinessRules.UserGitIsExistByUserMail(request.Email);

            UserGit deletedGitAddress = await _userGitRepository.DeleteAsync(y => y.User.Email == request.Email);

            return new() { GitAddress = deletedGitAddress.GitLink, IsSuccess = true };
        }
    }
}
