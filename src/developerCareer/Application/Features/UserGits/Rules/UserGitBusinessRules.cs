using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.UserGits.Rules
{
    public class UserGitBusinessRules
    {
        private readonly IUserGitRepository _userGithubRepo;
        private readonly IUserRepository _userRepo;

        public UserGitBusinessRules(IUserGitRepository userGithubRepo, IUserRepository userRepo)
        {
            _userGithubRepo = userGithubRepo;
            _userRepo = userRepo;
        }

        public async Task UserIsExistByUserMailAndGitAddress(string userMail, string gitaddress)
        {
            User? getUser = await _userRepo.GetAsync(u => u.Email.ToLower() == userMail.ToLower());
            if (getUser == null) throw new BusinessException("invalid User");


            IPaginate<UserGit> result = await _userGithubRepo.GetListAsync(g => g.GitLink.ToLower() == gitaddress.ToLower() && g.UserId == getUser.Id);
            if (result.Count >= 1) throw new BusinessException("User git is exit.");
        }

        public async Task UserGitIsExistByUserMail(string userMail)
        {
            User? getUser = await _userRepo.GetAsync(u => u.Email.ToLower() == userMail.ToLower());
            if (getUser == null) throw new BusinessException("invalid User");

            UserGit? getGitUser = await _userGithubRepo.GetAsync(g => g.UserId == getUser.Id);
            if (getGitUser == null) throw new BusinessException("User Git not found");
        }
    }
}
