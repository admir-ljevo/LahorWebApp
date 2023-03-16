using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.OrdersServicesLevels
{
    public class OrdersServiceLevelsUpsertDto:BaseDto
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int LevelOfServiceExecutionId { get; set;  }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }
        public float Amount { get; set; }
    }
}
