using Application.Services.Repositories;
using Core.Security.Entities;

namespace Application.Services.AltServices.UserGitService
{
    public class UserGitManager : IUserGitService
    {
        private readonly IUserRepository _userRepository;

        public UserGitManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetAsync(p => p.Email == email);
        }
    }
}
