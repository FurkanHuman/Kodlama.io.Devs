using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserGitRepository : EfRepositoryBase<UserGit, BaseDbContext>, IUserGitRepository
    {
        public UserGitRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
