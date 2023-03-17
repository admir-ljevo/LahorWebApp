using AutoMapper;
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
    public class DeviceTypeRepository: BaseRepository<DeviceType, int>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(IMapper mapper, DatabaseContext databaseContext): base(mapper, databaseContext)
        {

        }

        public async Task<DeviceTypeDto> GetByIdAsync(int id)
        {
            return await ProjectToFirstOrDefaultAsync<DeviceTypeDto>(DatabaseContext.DeviceType.Where(dt => dt.Id == id));
        }

        public async Task<List<DeviceTypeDto>> GetByName(string name)
        {
            return await ProjectToListAsync<DeviceTypeDto>(DatabaseContext.DeviceType.Where(dt => dt.Name == name));
        }

        public new async Task<List<DeviceTypeDto>> GetAllAsync()
        {
            return await ProjectToListAsync<DeviceTypeDto>(DatabaseContext.DeviceType);
        }
    }
}
