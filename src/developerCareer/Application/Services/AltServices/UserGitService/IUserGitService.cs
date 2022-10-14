using Core.Security.Entities;

namespace Application.Services.AltServices.UserGitService
{
    public interface IUserGitService
    {
        Task<User?> GetUserByEmailAsync(string email); 
    }
}
