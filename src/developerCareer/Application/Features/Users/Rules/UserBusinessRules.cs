using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> UserExistByMailAddress(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException("Mail not found.");
            return user;
        }
    }
}
