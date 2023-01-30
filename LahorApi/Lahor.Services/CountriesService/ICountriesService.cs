using Lahor.Core.Dto.Country;
using Lahor.Core.Dto.New;
using Lahor.Services.BaseService;

namespace Lahor.Services.CountriesService
{
    public interface ICountriesService : IBaseService<CountryDto>, IPaginationBaseService<CountryDto>
    {
        Task<List<CountryDto>> GetByNameAsync(string name);
    }
}
