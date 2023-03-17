using AutoMapper;
using Lahor.Core.Dto.Device;
using Lahor.Core.Dto.DeviceBrand;
using Lahor.Core.Dto.DeviceType;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.DeviceRepository
{
    public class DeviceRepository: BaseRepository<Device, int>, IDeviceRepository
    {
        public DeviceRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<DeviceDto> GetByIdAsync(int id)
        {
            var device = await ProjectToFirstOrDefaultAsync<DeviceDto>(DatabaseContext.Device.Where(d => d.Id == id && d.IsDeleted == false));
            device.DeviceBrand = await ProjectToFirstOrDefaultAsync<DeviceBrandDto>(DatabaseContext.DeviceBrand.Where(db => db.Id == device.DeviceBrandId));
            device.DeviceType = await ProjectToFirstOrDefaultAsync<DeviceTypeDto>(DatabaseContext.DeviceType.Where(dt => dt.Id == device.DeviceTypeId));
         
            return device;
        }  

        public async Task<List<DeviceDto>> GetByName(string name)
        {
            return await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Where(d => d.Name == name));
        }
           
        public async new Task<List<DeviceDto>> GetAllAsync()
        {
            return await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Where(d => d.IsDeleted == false));
        }

        public async Task<List<DeviceDto>> GetAllOrderedAsync(string sortCol, string sortDir )
        {
            sortCol = char.ToUpper(sortCol[0]) + sortCol.Substring(1);
            List<DeviceDto> devices;
            
           
            switch (sortCol)
            {
                case "DeviceBrand.Name":
                    _ = sortDir == "asc" ? devices = await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Include(db=>db.DeviceBrand).Where(d => d.IsDeleted == false).OrderBy(d=>d.DeviceBrand.Name)) :
                devices = await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Include(db=>db.DeviceBrand).Where(d => d.IsDeleted == false).OrderByDescending(d=>d.DeviceBrand.Name));
                    break;
                case "DeviceType.Name":
                    _ = sortDir == "asc" ? devices = await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Include(dt=>dt.DeviceType).Where(d => d.IsDeleted == false).OrderBy(d => d.DeviceType.Name)) :
                devices = await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Where(d => d.IsDeleted == false).OrderByDescending(d => d.DeviceType.Name));
                    break;
                default:
                    _ = sortDir == "asc" ? devices = await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Where(d => d.IsDeleted == false).OrderBy(d => EF.Property<object>(d, sortCol))) :
                devices = await ProjectToListAsync<DeviceDto>(DatabaseContext.Device.Where(d => d.IsDeleted == false).OrderByDescending(d => EF.Property<object>(d, sortCol)));
                    break;
            }
            return devices;
        }

    }
}
