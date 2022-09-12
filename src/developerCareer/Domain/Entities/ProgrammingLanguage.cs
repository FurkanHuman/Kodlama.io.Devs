
using Core.Domain.Abstract;
using Core.Domain.Base;

namespace Domain.Entities
{
    public class ProgrammingLanguage : BaseEntity<int>, IEntity
    {
        public IEnumerable<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public ProgrammingLanguage() { }

        public ProgrammingLanguage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
