using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class ServicesLevelsPrice : BaseEntity
    {
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public LevelOfServiceExecution LevelOfServiceExecution { get; set; }
        public int LevelOfServiceExecutionId { get; set; }
        public float Price { get; set; }
    }
}


