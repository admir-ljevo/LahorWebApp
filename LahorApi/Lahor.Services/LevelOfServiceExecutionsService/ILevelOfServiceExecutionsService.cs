using Lahor.Services.BaseService;
using Lahor.Core.Dto.LevelOfServiceExecution;

namespace Lahor.Services.LevelOfServiceExecutionsService
{
    public interface ILevelOfServiceExecutionsService: IBaseService<LevelOfServiceExecutionDto>
    {
        Task<List<LevelOfServiceExecutionDto>> GetByNameAsync(string name);
    }
}
