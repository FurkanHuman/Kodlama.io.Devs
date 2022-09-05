using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProgrammingLanguage() { }

        public ProgrammingLanguage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
