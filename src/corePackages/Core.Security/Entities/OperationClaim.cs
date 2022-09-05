using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public OperationClaim() { }

    public OperationClaim(int id, string name)
    {
        Id = id;
        Name = name;
    }
}