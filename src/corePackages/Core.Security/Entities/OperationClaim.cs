using Core.Persistence.Entity.Abstract;
using Core.Persistence.Entity.Base;

namespace Core.Security.Entities;

public class OperationClaim : BaseEntity<int>, IEntity
{
    public OperationClaim() { }

    public OperationClaim(int id, string name)
    {
        Id = id;
        Name = name;
    }
}