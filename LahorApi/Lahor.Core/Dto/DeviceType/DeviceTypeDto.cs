using Lahor.Core.Dto.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.DeviceType
{
    public class DeviceTypeDto: BaseDto
    {
        public string Name { get; set; }
        public IEnumerable<DeviceDto> Devices { get; set; }
    }
}
