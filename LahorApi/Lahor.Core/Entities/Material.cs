using Lahor.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Entities
{
    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }

}
