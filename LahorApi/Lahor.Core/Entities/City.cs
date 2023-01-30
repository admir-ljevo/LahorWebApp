
using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public bool Favorite { get; set; }
    }
}
