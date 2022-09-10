using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology, BaseDbContext>, IProgrammingTechnologyRepository
    {
        public ProgrammingTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
