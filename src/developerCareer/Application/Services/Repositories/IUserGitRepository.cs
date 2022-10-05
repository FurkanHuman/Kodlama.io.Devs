using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IUserGitRepository : IAsyncRepository<UserGit>, IRepository<UserGit>
    {
    }
}
