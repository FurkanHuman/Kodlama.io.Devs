using Core.Domain.Abstract;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class UserGit : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string GitLink { get; set; }

        public User User { get; set; }
        public UserGit() { }

        public UserGit(Guid id, Guid userId, string githubLink)
        {
            Id = id;
            UserId = userId;
            GitLink = githubLink;
        }
    }
}
