using Lahor.Core.Dto.DeviceBrand;
using Lahor.Core.Dto.DeviceType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.Device
{
    public class DeviceUpsertDto: BaseDto
    {
        public string Name { get; set; }
        public int DeviceBrandId { get; set; }
        public int DeviceTypeId { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
