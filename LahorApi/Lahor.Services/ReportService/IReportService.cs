using Lahor.Core.SearchObjects;

namespace Lahor.Services.ReportService
{
    public interface IReportService
    {
        Task<byte[]> CreateServicesReportFile(string pathRdlc,ReportSearchObject reportSearchObject);
        Task<byte[]> CreateEmployeesReportFile(string pathRdlc,ReportSearchObject reportSearchObject);
        Task<byte[]> CreateClientsReportFile(string pathRdlc,ReportSearchObject reportSearchObject);
    }
}
