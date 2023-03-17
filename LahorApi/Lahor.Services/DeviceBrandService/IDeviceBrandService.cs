using Lahor.Core.Dto.DeviceBrand;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.DeviceBrandService
{
    public interface IDeviceBrandService : IBaseService<DeviceBrandDto>
    {
        Task<List<DeviceBrandDto>> GetByNameAsync(string name);
    }
}
