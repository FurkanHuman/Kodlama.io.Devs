using Core.Domain.Abstract;
using Core.Domain.Base;

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