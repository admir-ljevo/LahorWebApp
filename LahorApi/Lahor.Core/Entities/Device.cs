using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public DeviceBrand DeviceBrand { get; set; }
        public int DeviceBrandId { get; set; }
        public DeviceType DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
        public string Description { get; set; }  
        public int Capacity { get; set; }
        public DateTime ServiceDate { get; set; }


    }
}
