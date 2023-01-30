
using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public bool Favorite { get; set; }
    }
}
