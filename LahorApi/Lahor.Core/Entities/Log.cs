
using Lahor.Core.Entities.Base;
using Lahor.Core.Enumerations;

namespace Lahor.Core.Entities
{
    public class Log : BaseEntity
    {
        public int? RowId { get; set; }
        public int? UserId { get; set; }
        public string TableName { get; set; }
        public string ReferrerUrl { get; set; }
        public string CurrentUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public LogType Type { get; set; }
    }
}
