using Domain.Entities.Abstract;
using Domain.Entities.Base;

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