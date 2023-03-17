using Lahor.Core.Dto.Material;
using Lahor.Core.Dto.PurchaseRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.MaterialRequests
{
    public class MaterialRequestsDto: BaseDto
    {
        public PurchaseRequestDto PurchaseRequest { get; set; }
        public int PurchaseRequestId { get; set; }
        public MaterialDto Material { get; set; }
        public int MaterialId { get; set; }
        public float UnitPrice { get; set; }
        public int Amount { get; set; }
        public float TotalPrice { get; set; }
    }
}
