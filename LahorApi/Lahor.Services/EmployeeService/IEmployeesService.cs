using Lahor.Core.Dto.City;
using Lahor.Core.Model;
using Lahor.Services.BaseService;

namespace Lahor.Services.CitiesService
{
    public interface IEmployeesService : IBaseService<CityDto>, IPaginationBaseService<CityDto>
    {
        Task<List<CityDto>> GetByNameAsync(string name);
        Task<EmployeesDashboard> GetEmployeesDashboard();
    }
}
