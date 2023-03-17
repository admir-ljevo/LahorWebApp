using Lahor.Core.Dto.Device;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.DeviceRepository
{
    public interface IDeviceRepository: IBaseRepository<Device, int>
    {

        new Task<List<DeviceDto>> GetAllAsync();
        Task<List<DeviceDto>> GetAllOrderedAsync(string sortCol, string sortDir);
        Task<List<DeviceDto>> GetByName(string name);
        Task<DeviceDto> GetByIdAsync(int id);
        Task<List<DeviceDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();

    }
}
