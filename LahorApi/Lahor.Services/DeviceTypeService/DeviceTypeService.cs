using Lahor.Core.Dto.DeviceType;
using Lahor.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.DeviceTypeService
{
    public class DeviceTypeService: IDeviceTypeService
    {
        private readonly UnitOfWork unitOfWork;

        public DeviceTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<DeviceTypeDto> AddAsync(DeviceTypeDto deviceType)
        {
            deviceType = await unitOfWork.DeviceTypeRepository.AddAsync(deviceType);
            await unitOfWork.SaveChangesAsync();
            return deviceType;
        }

        public async Task<List<DeviceTypeDto>> GetAllAsync()
        {
            return await unitOfWork.DeviceTypeRepository.GetAllAsync();
        }

        public async Task<DeviceTypeDto> GetByIdAsync(int id)
        {
            return await unitOfWork.DeviceTypeRepository.GetByIdAsync(id);
        }

        public async Task<List<DeviceTypeDto>> GetByNameAsync(string name)
        {
            return await unitOfWork.DeviceTypeRepository.GetByName(name);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.DeviceTypeRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }

        public void Update(DeviceTypeDto deviceType)
        {
            unitOfWork.DeviceTypeRepository.Update(deviceType);
            unitOfWork.SaveChanges();
        }

        public async Task<DeviceTypeDto> UpdateAsync(DeviceTypeDto deviceType)
        {
            unitOfWork.DeviceTypeRepository.Update(deviceType);
            await unitOfWork.SaveChangesAsync();
            return deviceType;
        }
    }
}
