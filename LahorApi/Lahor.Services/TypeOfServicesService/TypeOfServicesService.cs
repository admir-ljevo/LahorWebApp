using Lahor.Core.Dto.TypeOfService;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.TypeOfServicesService
{
    public class TypeOfServicesServices : ITypeOfServicesService
    {
        private readonly UnitOfWork _unitOfWork;

        public TypeOfServicesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<TypeOfServiceDto> AddAsync(TypeOfServiceDto typeOfService)
        {
            typeOfService = await _unitOfWork.TypeOfServicesRepository.AddAsync(typeOfService);
            await _unitOfWork.SaveChangesAsync();
            return typeOfService;
        }

        public Task<TypeOfServiceDto> GetByIdAsync(int id)
        {
            return _unitOfWork.TypeOfServicesRepository.GetByIdAsync(id);
        }

        public Task<List<TypeOfServiceDto>> GetAllAsync()
        {
            return _unitOfWork.TypeOfServicesRepository.GetAllAsync();
        }

        public Task<List<TypeOfServiceDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.TypeOfServicesRepository.GetByName(name);
        }
        public Task<List<TypeOfServiceDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
        {
            return _unitOfWork.TypeOfServicesRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.TypeOfServicesRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(TypeOfServiceDto entity)
        {
            _unitOfWork.TypeOfServicesRepository.Update<TypeOfServiceDto>(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<TypeOfServiceDto> UpdateAsync(TypeOfServiceDto entity)
        {
            _unitOfWork.NewsRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
