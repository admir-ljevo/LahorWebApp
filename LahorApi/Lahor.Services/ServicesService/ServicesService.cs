using Lahor.Core.Dto.Service;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.ServicesService
{
    public class ServicesService : IServicesService
    {
        private readonly UnitOfWork _unitOfWork;

        public ServicesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<ServiceDto> AddAsync(ServiceDto service)
        {
            service = await _unitOfWork.ServicesRepository.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();
            return service;
        }

        public Task<ServiceDto> GetByIdAsync(int id)
        {
            return _unitOfWork.ServicesRepository.GetByIdAsync(id);
        }

        public Task<List<ServiceDto>> GetAllAsync()
        {
            return _unitOfWork.ServicesRepository.GetAllAsync();
        }

        public Task<List<ServiceDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.ServicesRepository.GetByName(name);
        }
        public Task<List<ServiceDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
        {
            return _unitOfWork.ServicesRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.ServicesRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(ServiceDto entity)
        {
            _unitOfWork.ServicesRepository.Update<ServiceDto>(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<ServiceDto> UpdateAsync(ServiceDto entity)
        {
            _unitOfWork.ServicesRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
