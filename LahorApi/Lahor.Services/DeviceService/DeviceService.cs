using Lahor.Core.Dto.Device;
using Lahor.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.DeviceService
{
    public class DeviceService : IDeviceService
    {
        private readonly UnitOfWork unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<DeviceDto> AddAsync(DeviceDto device)
        {
            device = await unitOfWork.DeviceRepository.AddAsync(device);
            await unitOfWork.SaveChangesAsync();
            return device;
        }

        public async Task<List<DeviceDto>> GetAllAsync()
        {
            return await unitOfWork.DeviceRepository.GetAllAsync();
        }

        public async Task<List<DeviceDto>> GetAllOrderedAsync(string sortCol, string sortDir)
        {
            return await unitOfWork.DeviceRepository.GetAllOrderedAsync(sortCol, sortDir);
        }

        public async Task<DeviceDto> GetByIdAsync(int id)
        {
            return await unitOfWork.DeviceRepository.GetByIdAsync(id);
        }

        public async Task<List<DeviceDto>> GetByNameAsync(string name)
        {
            return await unitOfWork.DeviceRepository.GetByName(name);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.DeviceRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }

        public void Update(DeviceDto device)
        {
            unitOfWork.DeviceRepository.Update(device);
            unitOfWork.SaveChanges();
        }

        public async Task<DeviceDto> UpdateAsync(DeviceDto device)
        {
            unitOfWork.DeviceRepository.Update(device);
            await unitOfWork.SaveChangesAsync();
            return device;
        }
    }
}
