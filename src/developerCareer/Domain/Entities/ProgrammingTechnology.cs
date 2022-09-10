﻿using Domain.Entities.Abstract;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ProgrammingTechnology : BaseEntity<int>, IEntity
    {
        public int ProgrammingLanguageId { get; set; }

        public ProgrammingLanguage ProgrammingLanguage { get; set; }


        public ProgrammingTechnology() { }

        public ProgrammingTechnology(int id, string name, int pLId)
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = pLId;
        }
    }
}
