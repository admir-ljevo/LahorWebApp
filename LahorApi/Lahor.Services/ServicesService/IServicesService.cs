using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.Model;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;

namespace Lahor.Services.ServicesService
{
    public interface IServicesService : IBaseService<ServiceDto>, IPaginationBaseService<ServiceDto>
    {
        Task<List<ServiceDto>> GetByNameAsync(string name);
        Task<List<TypeOfServiceDto>> GetPriceList();
        Task<List<ServiceDto>> GetReportData(ReportSearchObject reportSearchObject);
        Task<ServicesDashboard> GetServicesDashboard();
    }
}
