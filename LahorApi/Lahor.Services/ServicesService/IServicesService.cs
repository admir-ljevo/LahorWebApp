using Lahor.Core.Dto.Service;
using Lahor.Services.BaseService;

namespace Lahor.Services.ServicesService
{
    public interface IServicesService : IBaseService<ServiceDto>
    {
        Task<List<ServiceDto>> GetByNameAsync(string name);
    }
}
