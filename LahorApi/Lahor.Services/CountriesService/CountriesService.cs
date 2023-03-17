using Lahor.Core.Dto.Country;
using Lahor.Core.Dto.New;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.CountriesService
{
    public class CountriesService : ICountriesService
    {
        private readonly UnitOfWork _unitOfWork;

        public CountriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<CountryDto> AddAsync(CountryDto country)
        {
            country = await _unitOfWork.CountriesRepository.AddAsync(country);
            await _unitOfWork.SaveChangesAsync();
            return country;
        }

        public Task<CountryDto> GetByIdAsync(int id)
        {
            return _unitOfWork.CountriesRepository.GetByIdAsync(id);
        }

        public Task<List<CountryDto>> GetAllAsync()
        {
            return _unitOfWork.CountriesRepository.GetAllAsync();
        }

        public Task<List<CountryDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.CountriesRepository.GetByName(name);
        }
        public async Task<List<CountryDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offeset)
        {
            return await _unitOfWork.CountriesRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.CountriesRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(CountryDto entity)
        {
            _unitOfWork.CountriesRepository.Update<CountryDto>(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<CountryDto> UpdateAsync(CountryDto entity)
        {
            _unitOfWork.CountriesRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
