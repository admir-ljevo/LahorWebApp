using Lahor.Core.Entities.Base;
using Lahor.Core.Entities.Identity;

namespace Lahor.Core.Entities
{
    public class PurchaseRequest: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser Employee { get; set; }
        public int EmployeeId { get; set; }

        public DateTime? DatePurchased { get; set; }

        public float Price { get; set; }
        public bool IsCompleted { get; set; }   
    }
}
