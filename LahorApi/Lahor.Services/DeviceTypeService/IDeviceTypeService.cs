using Lahor.Core.Dto.DeviceBrand;
using Lahor.Core.Dto.DeviceType;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.DeviceTypeService
{
    public interface IDeviceTypeService : IBaseService<DeviceTypeDto>
    {
        Task<List<DeviceTypeDto>> GetByNameAsync(string name);
    }
}
