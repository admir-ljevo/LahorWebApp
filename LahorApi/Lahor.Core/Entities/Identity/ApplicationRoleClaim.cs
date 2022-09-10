﻿using Lahor.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Lahor.Core.Entities.Identity
{
    public class ApplicationRoleClaim:IdentityRoleClaim<int>,IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
