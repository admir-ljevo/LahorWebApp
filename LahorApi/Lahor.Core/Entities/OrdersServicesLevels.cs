using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class OrdersServicesLevels:BaseEntity
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public LevelOfServiceExecution LevelOfServiceExecution { get; set; }
        public int LevelOfServiceExecutionId { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
    }
}
