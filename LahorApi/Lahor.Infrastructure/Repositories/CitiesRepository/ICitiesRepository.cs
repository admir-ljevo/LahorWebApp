using Lahor.Core.Dto.City;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.CitiesRepository
{
    public interface ICitiesRepository:IBaseRepository<City, int>
    {
        new Task<List<CityDto>> GetAllAsync();
        Task<List<CityDto>> GetByName(string name);
        Task<CityDto> GetByIdAsync(int id);
        Task<List<CityDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
