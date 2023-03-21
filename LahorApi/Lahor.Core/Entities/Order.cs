using Lahor.Core.Entities.Base;
using Lahor.Core.Entities.Identity;

namespace Lahor.Core.Entities
{
    public class Order:BaseEntity
    {
        public string Name { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool Delivered { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public bool Online { get; set; }
        public ApplicationUser Employee { get; set; }
        public int EmployeeId { get; set; }
        public ApplicationUser Client { get; set; }
        public int ClientId { get; set; }
    }
}
