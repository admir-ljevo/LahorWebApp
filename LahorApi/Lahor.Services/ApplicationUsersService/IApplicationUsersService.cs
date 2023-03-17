using Lahor.Core.Dto;
using Lahor.Core.Model;
using Lahor.Core.SearchObjects;
using Lahor.Reporting.Models;
using Lahor.Services.BaseService;

namespace Lahor.Services.ApplicationUsersService
{
    public interface IApplicationUsersService : IBaseService<ApplicationUserDto>
    {
        Task<ApplicationUserDto> FindByUserNameOrEmailAsync(string pUserName);
        Task<ApplicationUserDto> AddEmployeeAsync(EmployeeInsertDto newUser);
        Task<ApplicationUserDto> AddClientAsync(ClientInsertDto newUser);
        Task<List<ApplicationUserDto>> GetEmployees();
        Task<List<ApplicationUserDto>> GetClients();
        Task<ApplicationUserDto> EditEmployee(EmployeeInsertDto user);
        Task<ClientsDashboard> GetClientsDashboard();
        Task<EmployeesDashboard> GetEmployeesDashboard();
        Task<List<EmployeeReportModel>> GetEmployeesReportData(ReportSearchObject reportSearchObject);
        Task<List<ClientReportModel>> GetClientsReportData(ReportSearchObject reportSearchObject);
        Task ChangePhoto(ApplicationUserDto entityDto);

    }
}
