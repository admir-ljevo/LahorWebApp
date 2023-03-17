using Lahor.Core.Dto.Device;
using Lahor.Core.Dto.DeviceBrand;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.DeviceBrandRepository
{
    public interface IDeviceBrandRepository: IBaseRepository<DeviceBrand, int>
    {
        new Task<List<DeviceBrandDto>> GetAllAsync();
        Task<List<DeviceBrandDto>> GetByName(string name);
        Task<DeviceBrandDto> GetByIdAsync(int id);
        Task<List<DeviceBrandDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();

    }
}
