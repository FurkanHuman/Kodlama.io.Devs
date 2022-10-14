using Application.Features.UserGits.Dtos;
using Application.Features.UserGits.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserGits.Commands.UpdateGitAddress
{
    public class UpdateGitAddressCommandHandler : IRequestHandler<UpdateGitAddressCommand, UpdatedUserGitDto>
    {
        private readonly IUserGitRepository _userGitRepository;
        private readonly UserGitBusinessRules _userGitBusinessRules;

        public UpdateGitAddressCommandHandler(IUserGitRepository userGitRepository, UserGitBusinessRules userGitBusinessRules)
        {
            _userGitRepository = userGitRepository;
            _userGitBusinessRules = userGitBusinessRules;
        }

        public async Task<UpdatedUserGitDto> Handle(UpdateGitAddressCommand request, CancellationToken cancellationToken)
        {
            await _userGitBusinessRules.UserGitIsExistByUserMail(request.Email);

            UserGit? getUserGit = await _userGitRepository.GetAsync(r => r.User.Email == request.Email);

            getUserGit.GitLink = request.GitAddress;

            UserGit UpdatedUserGit = await _userGitRepository.UpdateAsync(getUserGit);

            return new() { GitAddress = UpdatedUserGit.GitLink, IsSuccess = true, };
        }
    }
}
