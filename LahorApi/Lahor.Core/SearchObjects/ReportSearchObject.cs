
using Lahor.Core.Enumerations;

namespace Lahor.Core.SearchObjects
{
    public class ReportSearchObject
    {
        public ReportType ReportType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
