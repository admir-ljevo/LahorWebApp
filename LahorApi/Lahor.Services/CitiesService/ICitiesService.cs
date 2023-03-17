using Lahor.Core.Dto.City;
using Lahor.Services.BaseService;

namespace Lahor.Services.CitiesService
{
    public interface ICitiesService : IBaseService<CityDto>, IPaginationBaseService<CityDto>
    {
        Task<List<CityDto>> GetByNameAsync(string name);
    }
}
