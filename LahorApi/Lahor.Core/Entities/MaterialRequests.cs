using Lahor.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Entities
{
    public class MaterialRequests : BaseEntity
    {
        public PurchaseRequest PurchaseRequest { get; set; }
        public int PurchaseRequestId { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public float UnitPrice { get; set; }
        public int Amount { get; set; }
        public float TotalPrice { get; set; }
    }
}
