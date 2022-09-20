using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class LevelOfServiceExecution : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ServicesLevelsPrice> LevelsPrices { get; set; }
    }
}
