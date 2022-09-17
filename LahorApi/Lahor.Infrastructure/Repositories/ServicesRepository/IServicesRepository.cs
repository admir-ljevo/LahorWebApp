using Lahor.Core.Dto.Service;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ServicesRepository
{
    public interface IServicesRepository : IBaseRepository<Service, int>
    {
        new Task<List<ServiceDto>> GetAllAsync();
        Task<List<ServiceDto>> GetByName(string name);
        Task<ServiceDto> GetByIdAsync(int id);
        Task<List<ServiceDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
