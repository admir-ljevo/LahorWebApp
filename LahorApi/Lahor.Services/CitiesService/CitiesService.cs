using Lahor.Core.Dto.City;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.CitiesService
{
    public class CitiesService : ICitiesService
    {
        private readonly UnitOfWork _unitOfWork;

        public CitiesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<CityDto> AddAsync(CityDto city)
        {
            city = await _unitOfWork.CitiesRepository.AddAsync(city);
            await _unitOfWork.SaveChangesAsync();
            return city;
        }

        public Task<CityDto> GetByIdAsync(int id)
        {
            return _unitOfWork.CitiesRepository.GetByIdAsync(id);
        }

        public Task<List<CityDto>> GetAllAsync()
        {
            return _unitOfWork.CitiesRepository.GetAllAsync();
        }

        public Task<List<CityDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.CitiesRepository.GetByName(name);
        }
        public async Task<List<CityDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offeset)
        {
            return await _unitOfWork.CitiesRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.CitiesRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(CityDto entity)
        {
            _unitOfWork.CitiesRepository.Update<CityDto>(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<CityDto> UpdateAsync(CityDto entity)
        {
            _unitOfWork.CitiesRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
