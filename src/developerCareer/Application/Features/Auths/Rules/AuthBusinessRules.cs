using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDublicatedWhenRegistered(string mail, CancellationToken cancellationToken)
        {
            User? result = await _userRepository.GetAsync(u => u.Email.ToLower() == mail.ToLower());
            if (result != null) throw new BusinessException("Mail already exist");
        }

        public void HashControlByPassword(bool hashControl)
        {
            if (!hashControl) throw new BusinessException("invalid mail or password.");
        }

        public void NullCheckByUser(User? getUser)
        {
            if (getUser == null) throw new BusinessException("invalid mail or password.");
        }
    }
}
