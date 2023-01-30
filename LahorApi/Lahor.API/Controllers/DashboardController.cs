using Lahor.API.Services.FileManager;
using Lahor.Core.Dto;
using Lahor.Core.Model;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.BaseService;
using Lahor.Services.ServicesService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IApplicationUsersService ApplicationUsersService;
        private readonly IServicesService ServicesService;
        public DashboardController(IApplicationUsersService applicationUsersService,IServicesService servicesService)
        {
            ServicesService=servicesService;
            ApplicationUsersService = applicationUsersService;
        }

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetEmployeesCountByMonth()
        {
            var dashboardModel = new DashboardModel();

            dashboardModel.EmployeesDashboardData = await ApplicationUsersService.GetEmployeesDashboard();
            dashboardModel.ClientsDashboardData = await ApplicationUsersService.GetClientsDashboard();
            dashboardModel.ServicesDashboardData = await ServicesService.GetServicesDashboard();
            return Ok(dashboardModel);
        }
    }
}
