using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class Service:BaseEntity
    {
        public string Name { get; set; }
        public TypeOfService TypeOfService { get; set; }
        public int TypeOfServiceId { get; set; }
        public ICollection<ServicesLevelsPrice> LevelsPrices { get; set; }
    }
}
