using Lahor.Core.Dto.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.DeviceBrand
{
    public class DeviceBrandDto: BaseDto
    {
        public string Name { get; set; }
        public List<DeviceDto> Devices { get; set; }
    }
}
