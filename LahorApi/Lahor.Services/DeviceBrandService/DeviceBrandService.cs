using Lahor.Core.Dto.DeviceBrand;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.DeviceBrandService
{
    public class DeviceBrandService : IDeviceBrandService
    {
        private readonly UnitOfWork unitOfWork;

        public DeviceBrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<DeviceBrandDto> AddAsync(DeviceBrandDto deviceBrand)
        {
            deviceBrand = await unitOfWork.DeviceBrandRepository.AddAsync(deviceBrand);
            await unitOfWork.SaveChangesAsync();
            return deviceBrand;
        }

        public async Task<List<DeviceBrandDto>> GetAllAsync()
        {
            return await unitOfWork.DeviceBrandRepository.GetAllAsync();
        }

        public async Task<DeviceBrandDto> GetByIdAsync(int id)
        {
            return await unitOfWork.DeviceBrandRepository.GetByIdAsync(id);
        }

        public async Task<List<DeviceBrandDto>> GetByNameAsync(string name)
        {
            return await unitOfWork.DeviceBrandRepository.GetByName(name);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.DeviceBrandRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }
        
        public void Update(DeviceBrandDto deviceBrand)
        {
            unitOfWork.DeviceBrandRepository.Update(deviceBrand);
            unitOfWork.SaveChanges();
        }

        public async Task<DeviceBrandDto> UpdateAsync(DeviceBrandDto deviceBrand)
        {
             unitOfWork.DeviceBrandRepository.Update(deviceBrand);
            await unitOfWork.SaveChangesAsync();
            return deviceBrand;
        }

    }
}
