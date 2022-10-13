using Application.Features.Users.Dtos;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Services.AltServices.UserService
{
    public interface IUserService
    {
        Task<IList<string>> GetByUserForUserOperationClaimsAsync(User? user);
    }
}
