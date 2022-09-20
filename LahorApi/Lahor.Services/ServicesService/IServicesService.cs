using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Services.BaseService;

namespace Lahor.Services.ServicesService
{
    public interface IServicesService : IBaseService<ServiceDto>, IPaginationBaseService<ServiceDto>
    {
        Task<List<ServiceDto>> GetByNameAsync(string name);
        Task<List<TypeOfServiceDto>> GetPriceList();
    }
}
