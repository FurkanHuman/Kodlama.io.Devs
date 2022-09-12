using Core.Persistence.Entity.Abstract;

namespace Core.Security.Entities;

public class OtpAuthenticator : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public OtpAuthenticator() { }

    public OtpAuthenticator(Guid id, Guid userId, byte[] secretKey, bool isVerified)
    {
        Id = id;
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}