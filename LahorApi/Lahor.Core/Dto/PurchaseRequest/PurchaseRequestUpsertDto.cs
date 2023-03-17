using Lahor.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.PurchaseRequest
{
    public class PurchaseRequestUpsertDto: BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? DatePurchased { get; set; }
        public float Price { get; set; }
        public bool IsCompleted { get; set; }
    }
}
