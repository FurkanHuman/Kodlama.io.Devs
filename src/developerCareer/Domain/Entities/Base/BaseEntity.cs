﻿namespace Domain.Entities.Base
{
    public class BaseEntity<I> where I : struct
    {
        public I Id { get; set; }

        public string Name { get; set; }
    }
}
