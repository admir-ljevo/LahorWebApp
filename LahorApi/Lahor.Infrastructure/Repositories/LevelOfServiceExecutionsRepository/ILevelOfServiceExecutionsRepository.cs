using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.LevelOfServiceExecutionsRepository
{
    public interface ILevelOfServiceExecutionsRepository:IBaseRepository<LevelOfServiceExecution, int>
    {
        new Task<List<LevelOfServiceExecutionDto>> GetAllAsync();
        Task<List<LevelOfServiceExecutionDto>> GetByName(string name);
        Task<LevelOfServiceExecutionDto> GetByIdAsync(int id);
        Task<List<LevelOfServiceExecutionDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
