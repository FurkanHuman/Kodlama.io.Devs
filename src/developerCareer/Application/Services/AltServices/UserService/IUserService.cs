using Core.Security.Entities;

namespace Application.Services.AltServices.UserService
{
    public interface IUserService
    {
        Task<IList<string>> GetByUserForUserOperationClaimNamesAsync(User? user);
    }
}
