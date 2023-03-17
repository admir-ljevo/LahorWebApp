using Lahor.Core.Dto.Device;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.DeviceService
{
    public interface IDeviceService: IBaseService<DeviceDto>
    {
        Task<List<DeviceDto>> GetByNameAsync(string name);
        Task<List<DeviceDto>> GetAllOrderedAsync(string sortCol, string sortDir);
    }
}
