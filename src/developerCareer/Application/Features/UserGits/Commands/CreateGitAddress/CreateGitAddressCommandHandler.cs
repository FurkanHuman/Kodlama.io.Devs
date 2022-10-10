using Application.Features.UserGits.Dtos;
using Application.Features.UserGits.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserGits.Commands.CreateGitAddress
{
    public class CreateGitAddressCommandHandler : IRequestHandler<CreateGitAddressCommand, CreatedUserGitDto>
    {
        private readonly IUserGitRepository _userGitRepository;
        private readonly UserGitBusinessRules _userGitBusinessRules;

        public CreateGitAddressCommandHandler(IUserGitRepository userGitRepository, UserGitBusinessRules userGitBusinessRules)
        {
            _userGitRepository = userGitRepository;
            _userGitBusinessRules = userGitBusinessRules;
        }

        public async Task<CreatedUserGitDto> Handle(CreateGitAddressCommand request, CancellationToken cancellationToken)
        {
            User controledUser = await _userGitBusinessRules.UserIsExistByUserMailAndGitAddress(request.Email, request.GitAddress);


            UserGit userGitForNew = new() { GitLink = request.GitAddress, User = controledUser, UserId = controledUser.Id };

            await _userGitRepository.AddAsync(userGitForNew);

            return new() { GitAddress = request.GitAddress, IsSuccess = true, Email = controledUser.Email };
        }
    }
}
