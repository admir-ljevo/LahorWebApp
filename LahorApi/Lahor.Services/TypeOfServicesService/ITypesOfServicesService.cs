using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;

namespace Lahor.Services.TypeOfServicesService
{
    public interface ITypeOfServicesService : IBaseService<TypeOfServiceDto>, IPaginationBaseService<TypeOfServiceDto>
    {
        Task<List<TypeOfServiceDto>> GetByNameAsync(string name);
        Task<List<TypeOfServiceDto>> GetReportData(ReportSearchObject reportSearchObject);
    }
}
