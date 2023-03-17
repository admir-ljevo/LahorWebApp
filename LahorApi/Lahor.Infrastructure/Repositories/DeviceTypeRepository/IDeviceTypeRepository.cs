using Lahor.Core.Dto.DeviceType;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.DeviceTypeRepository
{
    public interface IDeviceTypeRepository: IBaseRepository<DeviceType, int>
    {
        new Task<List<DeviceTypeDto>> GetAllAsync();
        Task<List<DeviceTypeDto>> GetByName(string name);
        Task<DeviceTypeDto> GetByIdAsync(int id);
        Task<List<DeviceTypeDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
