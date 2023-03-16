using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Dto.Order;
using Lahor.Core.Dto.Service;


namespace Lahor.Core.Dto.OrdersServicesLevels
{
    public class OrdersServicesLevelsDto:BaseDto
    {
        public OrderDto Order { get; set; }
        public int OrderId { get; set; }
        public ServiceDto Service { get; set; }
        public int ServiceId { get; set; }
        public LevelOfServiceExecutionDto LevelOfServiceExecution { get; set; }
        public int LevelOfServiceExecutionId { get; set; }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }
        public float Amount { get; set; }
    }
}
