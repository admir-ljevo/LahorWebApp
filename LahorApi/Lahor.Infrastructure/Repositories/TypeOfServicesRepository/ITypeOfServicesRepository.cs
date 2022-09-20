using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.TypeOfServicesRepository
{
    public interface ITypeOfServicesRepository:IBaseRepository<TypeOfService, int>
    {
        new Task<List<TypeOfServiceDto>> GetAllAsync();
        Task<List<TypeOfServiceDto>> GetByName(string name);
        Task<TypeOfServiceDto> GetByIdAsync(int id);
        Task<List<TypeOfServiceDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
