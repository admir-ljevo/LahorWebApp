using Lahor.Core.Dto.Country;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.CountriesRepository
{
    public interface ICountriesRepository : IBaseRepository<Country, int>
    {
        new Task<List<CountryDto>> GetAllAsync();
        Task<List<CountryDto>> GetByName(string name);
        Task<CountryDto> GetByIdAsync(int id);
        Task<List<CountryDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
