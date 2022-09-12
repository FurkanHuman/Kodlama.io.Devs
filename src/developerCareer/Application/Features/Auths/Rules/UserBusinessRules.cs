using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Auths.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserIsExistByEmail(string mail)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(u => u.Email.ToLower() == mail.ToLower());
            if (result.Count >= 1) throw new BusinessException("User is exit");
        }

        public void HashControlByPassword(bool hashControl)
        {
            if (!hashControl) throw new BusinessException("invalid mail or password.");
        }

        public void NullCheckByUser(User? getUser)
        {
            if (getUser==null) throw new BusinessException("invalid mail or password.");
        }
    }
}
