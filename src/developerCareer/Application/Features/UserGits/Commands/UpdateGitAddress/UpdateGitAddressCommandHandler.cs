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
            UserGit controledUserGit = await _userGitBusinessRules.UserGitIsExistByUserMail(request.Email);

            controledUserGit.GitLink = request.GitAddress;

            await _userGitRepository.UpdateAsync(controledUserGit);

            return new() { GitAddress = request.GitAddress, IsSuccess = true, };
        }
    }
}
