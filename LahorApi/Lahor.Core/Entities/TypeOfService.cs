﻿using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class TypeOfService:BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
