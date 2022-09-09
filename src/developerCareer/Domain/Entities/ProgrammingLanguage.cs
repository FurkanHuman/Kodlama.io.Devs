using Domain.Entities.Abstract;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ProgrammingLanguage : BaseEntity<int>, IEntity
    {

        public ProgrammingLanguage() { }

        public ProgrammingLanguage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
