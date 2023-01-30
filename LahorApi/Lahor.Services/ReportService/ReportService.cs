using AspNetCore.Reporting;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.ApplicationUsersRepository;
using Lahor.Infrastructure.Repositories.ServicesRepository;
using Lahor.Reporting.Models;
using System.Text;

namespace Lahor.Services.ReportService
{
    public class ReportService:IReportService
    {
        public IServicesRepository ServicesRepository;
        public IApplicationUsersRepository ApplicationUsersRepository;
        public ReportService(IServicesRepository servicesRepository,IApplicationUsersRepository applicationUsersRepository)
        {
            ServicesRepository = servicesRepository;
            ApplicationUsersRepository = applicationUsersRepository;
        }
        public async Task<byte[]> CreateServicesReportFile(string pathRdlc,ReportSearchObject reportSearchObject)
        {
            var result = await ServicesRepository.GetReportData(reportSearchObject);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            LocalReport report = new LocalReport(pathRdlc);
            List<ServiceReportModel> listForReport = new List<ServiceReportModel>();

                foreach (var service in result)
                {
                    listForReport.Add(new ServiceReportModel
                    {
                        Name=service.Name,
                        TypeOfService=service.TypeOfService.Name,
                        Price1 = service.LevelsPrices[0].Price.ToString(),
                        Price2 = service.LevelsPrices[1].Price.ToString(),
                        Price3 = service.LevelsPrices[2].Price.ToString(),
                        Price4 = service.LevelsPrices[3].Price.ToString(),
                        Price5 = service.LevelsPrices[4].Price.ToString(),
                        Price6 = service.LevelsPrices[5].Price.ToString(),
                    });

                }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportDateCreated", DateTime.Now.ToString());
            report.AddDataSource("dataSetServices", listForReport);
            var reportResult = report.Execute(RenderType.Pdf, 1,parameters);
            return reportResult.MainStream;
        }

        public async Task<byte[]> CreateEmployeesReportFile(string pathRdlc, ReportSearchObject reportSearchObject)
        {
            var result = await ApplicationUsersRepository.GetEmployeesReportData(reportSearchObject);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            LocalReport report = new LocalReport(pathRdlc);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportDateCreated", DateTime.Now.ToString());
            report.AddDataSource("dataSetEmployees", result);
            var reportResult = report.Execute(RenderType.Pdf, 1, parameters);
            return reportResult.MainStream;
        }

        public async Task<byte[]> CreateClientsReportFile(string pathRdlc, ReportSearchObject reportSearchObject)
        {
            var result = await ApplicationUsersRepository.GetClientsReportData(reportSearchObject);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            LocalReport report = new LocalReport(pathRdlc);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportDateCreated", DateTime.Now.ToString());
            report.AddDataSource("dataSetClients", result);
            var reportResult = report.Execute(RenderType.Pdf, 1, parameters);
            return reportResult.MainStream;
        }
    }
}
