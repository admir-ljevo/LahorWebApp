using Lahor.Core.Dto.TypeOfService;
using Lahor.Services.BaseService;

namespace Lahor.Services.TypeOfServicesService
{
    public interface ITypeOfServicesService : IBaseService<TypeOfServiceDto>
    {
        Task<List<TypeOfServiceDto>> GetByNameAsync(string name);
    }
}
