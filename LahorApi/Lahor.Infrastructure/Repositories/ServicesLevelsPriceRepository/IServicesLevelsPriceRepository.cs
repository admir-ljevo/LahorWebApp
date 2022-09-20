using Lahor.Core.Dto.ServicesLevelsPrices;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ServicesLevelsPriceRepository
{
    public interface IServicesLevelsPriceRepository : IBaseRepository<ServicesLevelsPrice, int>
    {
        new Task<List<ServicesLevelsPriceDto>> GetAllAsync();
        Task<List<ServicesLevelsPriceDto>> GetByName(string name);
        Task<ServicesLevelsPriceDto> GetByIdAsync(int id);
        Task<List<ServicesLevelsPriceDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
        Task<List<ServicesLevelsPriceDto>> GetServicesLevelsByServiceId(int serviceId);
    }
}
