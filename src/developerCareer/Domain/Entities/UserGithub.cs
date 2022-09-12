using Core.Persistence.Entity.Abstract;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class UserGithub : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string GithubLink { get; set; }

        public User User { get; set; }
        public UserGithub() { }

        public UserGithub(Guid id, Guid userId, string githubLink)
        {
            Id = id;
            UserId = userId;
            GithubLink = githubLink;
        }
    }
}
