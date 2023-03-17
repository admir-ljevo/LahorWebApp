using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class DeviceType: BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
