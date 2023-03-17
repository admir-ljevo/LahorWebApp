using AutoMapper;
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
    public class DeviceBrandRepository: BaseRepository<DeviceBrand, int>, IDeviceBrandRepository
    {
        public DeviceBrandRepository(IMapper mapper, DatabaseContext databaseContext): base(mapper, databaseContext)
        {

        }

        public async Task<DeviceBrandDto> GetByIdAsync(int id)
        {
            var deviceBrand = await ProjectToFirstOrDefaultAsync<DeviceBrandDto>(DatabaseContext.DeviceBrand.Where(db => db.Id == id));
            return deviceBrand;
        }

        public async Task<List<DeviceBrandDto>> GetByName(string name)
        {
            return await ProjectToListAsync<DeviceBrandDto>(DatabaseContext.DeviceBrand.Where(db => db.Name == name));
        }

       public new async  Task<List<DeviceBrandDto>> GetAllAsync()
        {

            return await ProjectToListAsync<DeviceBrandDto>(DatabaseContext.DeviceBrand);
        }
    }
}
