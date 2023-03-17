using Lahor.Core.Dto;
using Lahor.Core.Dto.Service;
using Lahor.Core.Entities.Identity;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Lahor.Reporting.Models;

namespace Lahor.Infrastructure.Repositories.ApplicationUsersRepository
{
    public interface IApplicationUsersRepository : IBaseRepository<ApplicationUser, int>
    {
        Task<ApplicationUserDto> FindByUserNameOrEmailAsync(string UserName);
        new Task<List<ApplicationUserDto>> GetEmployees();
        Task<ApplicationUserDto> GetByIdAsync(int id);
        Task<List<int>> GetEmployeesClientsCountByMonth(bool isEmployee, bool isClient);
        new Task<List<ApplicationUserDto>> GetClients();
        Task<List<EmployeeReportModel>> GetEmployeesReportData(ReportSearchObject search);
        Task<List<ClientReportModel>> GetClientsReportData(ReportSearchObject search);
    }
}
