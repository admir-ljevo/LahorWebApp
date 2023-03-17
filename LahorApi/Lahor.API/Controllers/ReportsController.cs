using Lahor.API.Services.FileManager;
using Lahor.Core.Enumerations;
using Lahor.Core.SearchObjects;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.ReportService;
using Lahor.Services.ServicesService;
using Lahor.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IReportService ReportService;
        private IServicesService ServicesService;
        private IApplicationUsersService ApplicationUsersService;
        private IFileManager FileManager;
        public ReportsController(IReportService reportService,IServicesService servicesService,IApplicationUsersService applicationUsersService, IFileManager fileManager)
        {
            ReportService = reportService;
            FileManager= fileManager;
            ServicesService = servicesService;  
            ApplicationUsersService = applicationUsersService;
        }

        [HttpGet]
        [Route("services")]
        public async Task<IActionResult> ExportServices([FromQuery] ReportSearchObject reportSearchObject)
        {
            if (reportSearchObject.ReportType == ReportType.Preview)
            {
                return Ok(await ServicesService.GetReportData(reportSearchObject));
            }

            if (reportSearchObject.ReportType == ReportType.PDF)
            {
                var byteRes = new byte[] { };
                string path = FileManager.GeneratePathForReport(ReportPath.ServicesReport);
                byteRes = await ReportService.CreateServicesReportFile(path,reportSearchObject);

                return File(byteRes,
                    System.Net.Mime.MediaTypeNames.Application.Octet,
                    $"{ReportNames.ServicesReport}.pdf");
            }

            return Ok();

        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> ExportEmployees([FromQuery] ReportSearchObject reportSearchObject)
        {
            if (reportSearchObject.ReportType == ReportType.Preview)
            {
                return Ok(await ApplicationUsersService.GetEmployeesReportData(reportSearchObject));
            }

            if (reportSearchObject.ReportType == ReportType.PDF)
            {
                var byteRes = new byte[] { };
                string path = FileManager.GeneratePathForReport(ReportPath.EmployeesReport);
                byteRes = await ReportService.CreateEmployeesReportFile(path, reportSearchObject);

                return File(byteRes,
                    System.Net.Mime.MediaTypeNames.Application.Octet,
                    $"{ReportNames.EmployeesReport}.pdf");
            }

            return Ok();

        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> ExportClients([FromQuery] ReportSearchObject reportSearchObject)
        {
            if (reportSearchObject.ReportType == ReportType.Preview)
            {
                return Ok(await ApplicationUsersService.GetClientsReportData(reportSearchObject));
            }

            if (reportSearchObject.ReportType == ReportType.PDF)
            {
                var byteRes = new byte[] { };
                string path = FileManager.GeneratePathForReport(ReportPath.ClientsReport);
                byteRes = await ReportService.CreateClientsReportFile(path, reportSearchObject);

                return File(byteRes,
                    System.Net.Mime.MediaTypeNames.Application.Octet,
                    $"{ReportNames.ClientsReport}.pdf");
            }

            return Ok();

        }
    }
}
