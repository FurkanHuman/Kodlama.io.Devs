using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IProgrammingTechnologyRepository : IAsyncRepository<ProgrammingTechnology>, IRepository<ProgrammingTechnology>
    {
    }
}
